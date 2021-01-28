import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import AppComponent from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FlexLayoutModule } from '@angular/flex-layout';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { SimplePanelModule } from '../simple-panel/simple-panel.module';

import { CostingInfoviewComponent } from './components/costing-infoview/costing-infoview.component';
import { ServiceBillInfoviewComponent } from './components/service-bill-infoview/service-bill-infoview.component';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatIconModule,
    FlexLayoutModule,
    MatDividerModule,
    MatSelectModule,
    MatListModule,
    SimplePanelModule,
    MatTableModule,
    NgxChartsModule
  ],
  declarations: [
    AppComponent,
    CostingInfoviewComponent,
    ServiceBillInfoviewComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}


