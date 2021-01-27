import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import AppComponent from './app.component';
import { DashboardPanel } from './dashboard-panel/dashboard-panel.component'

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout'
import { MatExpansionModule } from '@angular/material/expansion'
import { MatDividerModule } from '@angular/material/divider'
import { MatIconModule } from '@angular/material/icon';
import {MatSelectModule} from '@angular/material/select';

import { CostingInfoviewComponent } from './costing-infoview/costing-infoview.component';
import { ServiceBillInfoviewComponent } from './service-bill-infoview/service-bill-infoview.component';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatExpansionModule,
    MatIconModule,
    FlexLayoutModule,
    MatDividerModule,
    MatSelectModule
  ],
  declarations: [
    AppComponent,
    DashboardPanel,
    CostingInfoviewComponent,
    ServiceBillInfoviewComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}


