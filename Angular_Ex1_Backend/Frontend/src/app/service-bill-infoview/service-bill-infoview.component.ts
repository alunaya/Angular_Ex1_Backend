import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-service-bill-infoview',
  templateUrl: './service-bill-infoview.component.html',
  styleUrls: ['./service-bill-infoview.component.css']
})
export class ServiceBillInfoviewComponent implements OnInit, OnChanges {

  @Input() value: string ="";

  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(changes: SimpleChanges){
    console.log(changes);
  }

}
