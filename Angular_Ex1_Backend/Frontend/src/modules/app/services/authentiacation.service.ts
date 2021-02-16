import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import config from '../../config';

interface UserInfo {
    refreshToken: string,
    accessToken: string,
}

interface loginResponse {
    access_token: string,
    refresh_token: string
}

interface loginRequest {
    username: string,
    password: string,
    client_id: string,
    grant_type: string
}

interface registerRequest {
    username: string,
    email: string,
    password: string,
}

interface registerResponse {
    error: boolean,
    errorMessage: string | null
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
        const loginRequest: loginRequest = {
            username: username,
            password: password,
            client_id: config.authClientId,
            grant_type: config.authGrantType
        }

        return this.http.post<loginResponse>(`${config.authServerUrl}/${config.tokenEnpoint}`, loginRequest)
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

    register(username: string, password: string, email: string){
        const registerRequest: registerRequest = {
            username, password, email
        }

        return this.http.post<registerResponse>(`${config.authServerUrl}/${config.accountRegisterEndpoint}`, registerRequest);
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(defaultUserInfo);
    }
}