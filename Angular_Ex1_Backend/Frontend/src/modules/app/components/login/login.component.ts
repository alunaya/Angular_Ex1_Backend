import { Component } from '@angular/core';

@Component({
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    selector: 'app-login'
})
export class LoginComponent{
    username: string = '';
    password: string = '';

    login(){
        console.log(this.username);
        console.log(this.password);
    }
}