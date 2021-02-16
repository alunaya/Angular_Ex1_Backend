import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CostingViewModule } from '../costing-view/costing-view.module';


import AppComponent from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { CostingViewComponent } from '../costing-view/costing-view.component';
import { AuthGuard } from './guard/auth.guard';
import { JwtInterceptor } from './services/jwtInterceptor.service';
import { ErrorInterceptor } from './services/httpErrorInterceptor.service';

var routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent},
  { path: 'dashboard', component: CostingViewComponent, canActivate: [AuthGuard] }
]

var router = RouterModule.forRoot(routes)

@NgModule({
  imports: [
    router,
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    CostingViewModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
  ],
  providers:[
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}


