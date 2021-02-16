import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import config from '../../config';

interface User {
    accessToken: string;
    refreshToken: string;
    expiredTime: Date;
}

const defaultUser : User = {
    accessToken: '',
    refreshToken: '',
    expiredTime: new Date(),
}

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        let userString = localStorage.getItem('currentUser');
        if(userString == null){
            this.currentUserSubject = new BehaviorSubject(defaultUser)
        }else{
            this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')!));
        }
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.getValue();
    }

    login(username: string, password: string) {
        const body = new HttpParams()
        .set('username', username)
        .set('password', password)
        .set('grant_type', 'password')
        .set('client_id', 'angualr-ex');

        return this.http.post<any>(`${config.authServerUrl}${config.authTokenEndpoint}`, 
        { username, password }
        )
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(defaultUser);
    }
}