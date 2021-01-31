import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import config from '../config';

interface MonthData {
  monthId: string,
  dateString: string,
  date: Date
}

let defaultMonthData: MonthData[] = [];

@Component({
    selector: 'app-costing-view',
    templateUrl: './costing-view.component.html',
    styleUrls: ['./costing-view.component.css']
})
export class CostingViewComponent{
    monthId: string = '';
  monthData: MonthData[] = defaultMonthData;
  apiClient: HttpClient;

  constructor(apiClient: HttpClient) {  
    this.apiClient = apiClient;
  }

  ngOnInit(): void {
    this.getMonthData();
  }

  getSelectedMonth(event: any){
      this.monthId = event.target.value;
  }

  getMonthData(){
    this.apiClient.get(`${config.serverUrl}${config.monthUrl}`)
    .subscribe((responseBody) => {
      this.monthData = responseBody as MonthData[];
      this.monthData.sort((a,b)=>{
        return a.date.getTime() - b.date.getTime();
      })
    });
  }
}
