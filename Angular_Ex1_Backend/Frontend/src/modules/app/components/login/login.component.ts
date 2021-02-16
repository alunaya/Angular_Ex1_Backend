import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from '../../services/authentiacation.service';
import { first } from 'rxjs/operators';
@Component({
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    selector: 'app-login'
})
export class LoginComponent implements OnInit{
    loginForm!: FormGroup;
    error = '';

    constructor(
        private authService: AuthenticationService,
        private formBuilder: FormBuilder,
        private router: Router
        ){
        }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    onSubmit() {
        if (this.loginForm.invalid) {
            return;
        }

        const username = this.loginForm.controls.username.value;
        const password = this.loginForm.controls.password.value;

        this.authService.login(username, password).pipe(first()).subscribe(data => {this.router.navigate([""])});
    }
}