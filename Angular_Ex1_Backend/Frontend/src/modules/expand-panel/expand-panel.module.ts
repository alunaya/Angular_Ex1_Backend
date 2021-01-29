import { NgModule} from '@angular/core'
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SimpleExpandPanel } from './components/simple-expand-panel/simple-expand-panel.component';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [NgbModule, CommonModule],
    declarations: [SimpleExpandPanel],
    exports:[
        SimpleExpandPanel,
        NgbModule,
        CommonModule
    ]
})
export class SimpleExpandPanelModule{ 
}