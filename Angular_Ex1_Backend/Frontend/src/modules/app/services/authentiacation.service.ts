import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import config from '../../config';

interface UserInfo {
    refreshToken: string,
    accessToken: string,
}

const defaultUserInfo = {
    refreshToken: '',
    accessToken: ''
}

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<UserInfo>;
    public currentUser: Observable<UserInfo>;

    constructor(private http: HttpClient) {

        if(localStorage.getItem('currentUser')){
            this.currentUserSubject = new BehaviorSubject<UserInfo>(JSON.parse(localStorage.getItem('currentUser')!));
            this.currentUser = this.currentUserSubject.asObservable();
            return;
        }

        this.currentUserSubject = new BehaviorSubject<UserInfo>(defaultUserInfo);
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): UserInfo {
        return this.currentUserSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${config.authServerUrl}/${config.tokenEnpoint}`,
            {
                username: username,
                password: password,
                client_id: config.authClientId,
                grant_type: config.authGrantType
            }
        )
            .pipe(map(resBody => {
                const user: UserInfo = {
                    accessToken: resBody.access_token,
                    refreshToken: resBody.refresh_token
                }
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(defaultUserInfo);
    }
}