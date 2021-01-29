import { NgModule } from '@angular/core'
import { HttpClientModule } from '@angular/common/http'
import { ReservationCoverageComponent } from './components/reservation-coverage-infoview/reservation-coverage.component';
import { ServiceBillInfoviewComponent } from './components/service-bill-infoview/service-bill-infoview.component';
import { SimpleExpandPanelModule } from '../expand-panel/expand-panel.module'
import { CostingViewComponent } from './costing-view.component';
import { NgxChartsModule } from '@swimlane/ngx-charts';

@NgModule({
    imports:[
        HttpClientModule,
        SimpleExpandPanelModule,
        NgxChartsModule
    ],
    declarations:[
        ReservationCoverageComponent,
        ServiceBillInfoviewComponent,
        CostingViewComponent
    ],
    exports:[
        CostingViewComponent
    ]
})
export class CostingViewModule {}