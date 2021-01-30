import { Component, Input, OnChanges, SimpleChanges, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import config from '../../../config';

interface ServiceBillData {
  isCurrentMonth: boolean,
  totalCost: number,
  previousMonthCost: number | null,
  estimatedCost: number | null,
  changeFromLastMonth: number | null,
  serviceBills: ServiceBillDetail[]
}

interface ServiceBillDetail {
  serviceName: string,
  cost: number
}

interface ServiceBillDetails {
  services: ServiceBillDetail[],
  totalCost: number
}

interface ChartData {
  name: string,
  value: number,
}

interface CostSummaryData {
  isCurrentMonth: boolean,
  totalCost: number,
  previousMonthCost: number | null,
  estimatedCost: number | null,
  changeFromLastMonth: number | null,
}

interface ChartColor {
  name: string,
  value: string
}

let defaultserviceBills: ServiceBillDetails = {
  services: [],
  totalCost: 0
}

let defaultCostSummary: CostSummaryData = {
  isCurrentMonth: false,
  totalCost: 0,
  previousMonthCost: 0,
  estimatedCost: 0,
  changeFromLastMonth: 0,
} 

function getRandomColor(): string {
  var letters = '0123456789ABCDEF';
  var color = '#';
  for (var i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)];
  }
  return color;
}

@Component({
  selector: 'app-service-bill-infoview',
  templateUrl: './service-bill-infoview.component.html',
  styleUrls: ['./service-bill-infoview.component.css']
})
export class ServiceBillInfoviewComponent {

  @Input() monthId: string ="";
  private serviceBills: ServiceBillDetails = defaultserviceBills;
  serviceBillChartData: ChartData[] = [];
  costSummary: CostSummaryData = defaultCostSummary;
  tableColor: Map<string,string> = new Map<string,string>();
  chartColor: ChartColor[] = [];
  private apiClient: HttpClient;


  randomizeColors() {
    this.tableColor = new Map<string,string>();
    this.chartColor = [];
    for (let i = 0; i < this.serviceBills.services.length; i++){
      let color: string = getRandomColor();
      this.tableColor.set(this.serviceBills.services[i].serviceName,color);
      this.chartColor.push({
        name: this.serviceBills.services[i].serviceName,
        value: color,
      })
    }
  }

  constructor(apiClient: HttpClient){
    this.apiClient = apiClient;
  }

  ngOnChanges(changes: SimpleChanges){
    this.getMonthData(changes.monthId.currentValue);
  }

  getMonthData(monthId: string) {
    if( !monthId ){
      return;
    }

    this.apiClient.get(`${config.serverUrl}${config.servicesBill}${monthId}`)
      .subscribe((responseBody) => {
      let serviceBillData: ServiceBillData = responseBody as ServiceBillData;
    
      if(serviceBillData){
        this.serviceBills.totalCost = serviceBillData.totalCost;
        this.serviceBills.services = serviceBillData.serviceBills;
        
        this.costSummary.totalCost = serviceBillData.totalCost;
        this.costSummary.estimatedCost = serviceBillData.estimatedCost;
        this.costSummary.changeFromLastMonth = serviceBillData.changeFromLastMonth;
        this.costSummary.isCurrentMonth = serviceBillData.isCurrentMonth;
        this.costSummary.previousMonthCost = serviceBillData.previousMonthCost;

        this.serviceBillChartData = serviceBillData.serviceBills.map( (x: ServiceBillDetail) => ({
            name: x.serviceName,
            value: x.cost
        }));

        this.randomizeColors()
      }
    });

  
  }
}
