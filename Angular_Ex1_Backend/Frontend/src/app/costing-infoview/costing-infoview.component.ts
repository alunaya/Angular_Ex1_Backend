import { 
  Component, 
  OnInit, 
  OnChanges, 
  SimpleChanges 
} from '@angular/core';

@Component({
  selector: 'app-costing-infoview',
  templateUrl: './costing-infoview.component.html',
  styleUrls: ['./costing-infoview.component.css']
})
export class CostingInfoviewComponent implements OnInit, OnChanges {

  month: string = '';

  constructor() {  
  }

  ngOnInit(): void {
  }
  
  ngOnChanges(changes: SimpleChanges): void{
    console.log(changes);
  }

  test(value: string){
    console.log(value);
  }
}
