import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-dashboard-panel',
  templateUrl: './dashboard-panel.component.html',
  styleUrls: ['./dashboard-panel.component.css']
})
export class DashboardPanel implements OnInit {

  @Input() title: string = '';
  @Input() label: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
