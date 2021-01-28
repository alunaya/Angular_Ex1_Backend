import { 
  Component, 
  OnInit, 
  OnChanges, 
  SimpleChanges 
} from '@angular/core';

import MockData from '../../MockData.json';

interface MonthData {
  monthId: string,
  dateString: string,
}

let defaultMonthData: MonthData[] = [];

@Component({
  selector: 'app-costing-infoview',
  templateUrl: './costing-infoview.component.html',
  styleUrls: ['./costing-infoview.component.css']
})

export class CostingInfoviewComponent implements OnInit {

  monthId: string = '';
  monthData: MonthData[] = defaultMonthData;

  constructor() {  
  }

  ngOnInit(): void {
    this.monthData = MockData.months
  }
}
