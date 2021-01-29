import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-simple-expand-panel',
    templateUrl: './simple-expand-panel.component.html',
    styleUrls: ['./simple-expand-panel.component.css'],
})
export class SimpleExpandPanel {
    @Input() Title: string = '';
    isCollapsed: boolean = false;

    switchPanelState(){
        this.isCollapsed = !this.isCollapsed;
    }
}