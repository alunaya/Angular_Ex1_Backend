import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { CostingViewModule } from '../costing-view/costing-view.module';


import AppComponent from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { CostingViewComponent } from '../costing-view/costing-view.component';

var routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'dashboard', component: CostingViewComponent }
]
var router = RouterModule.forRoot(routes)

@NgModule({
  imports: [
    router,
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    CostingViewModule,
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}


