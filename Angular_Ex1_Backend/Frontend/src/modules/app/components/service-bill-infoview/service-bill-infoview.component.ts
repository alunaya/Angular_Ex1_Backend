import { Component, Input, OnChanges, SimpleChanges, OnInit } from '@angular/core';
import MockData from '../../MockData.json';

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

@Component({
  selector: 'app-service-bill-infoview',
  templateUrl: './service-bill-infoview.component.html',
  styleUrls: ['./service-bill-infoview.component.css']
})
export class ServiceBillInfoviewComponent {

  @Input() monthId: string ="";
  serviceBills: ServiceBillDetails = defaultserviceBills;
  serviceBillChartData: ChartData[] = [];
  costSummary: CostSummaryData = defaultCostSummary;


  displayedColumns: string[] = ['legend', 'name', 'cost'];

  constructor(){
  }

  ngOnChanges(changes: SimpleChanges){
    this.setDataTest(changes.monthId.currentValue);
  }
  
  setDataTest(monthId: string): void{

    let MockDataService: any = MockData['service-bill'];
    let serviceBillData: ServiceBillData = MockDataService[monthId];
    
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
      }))
    }
  }
}
