import { NgModule } from '@angular/core';

import { MatExpansionModule } from '@angular/material/expansion';

import { DashboardPanel } from './components/dashboard-panel/dashboard-panel.component'

@NgModule({
    imports:[
        MatExpansionModule,
    ],
    declarations:[DashboardPanel],
    exports:[DashboardPanel]
})
export class SimplePanelModule{}