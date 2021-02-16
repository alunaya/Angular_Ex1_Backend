import {Component} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentiacation.service';

@Component({
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css'],
    selector: 'app-register'
})
export class RegisterComponent{
    registerForm!: FormGroup;
    error = '';

    constructor(
        private authService: AuthenticationService,
        private formBuilder: FormBuilder,
        private router: Router
        ){
        }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required, Validators.minLength(6)],
            email: ['', Validators.required]
        });
    }

    onSubmit() {
        if (this.registerForm.invalid) {
            return;
        }

        const username = this.registerForm.controls.username.value;
        const password = this.registerForm.controls.password.value;
        const email = this.registerForm.controls.email.value;

        this.authService.register(username, password, email).subscribe(data => {
            if(data.error){
                this.error = data.errorMessage!;
                return;
            }
            this.router.navigate(["/login"]
            )});
    }
}