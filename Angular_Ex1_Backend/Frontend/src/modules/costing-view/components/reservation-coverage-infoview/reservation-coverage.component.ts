import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import config from '../../../config';
import { HttpClient } from '@angular/common/http'

interface ReservationData {
    instanceType: string,
    totalHours: number,
    reservedHours: number,
}

interface ChartData {
    name: string,
    value: number,
}

let defaultReservationData: ReservationData[] = [];


@Component({
    selector: 'app-reservation-coverage',
    templateUrl: './reservation-coverage.component.html',
    styleUrls: ['./reservation-coverage.component.css'],
})
export class ReservationCoverageComponent implements OnChanges {
    @Input() monthId = ''
    reservationData: ReservationData[] = defaultReservationData;
    chartData: any = {
        domain:[]
    };
    private apiClient: HttpClient;

    constructor(apiClient: HttpClient){
        this.apiClient = apiClient;
    }
    ngOnChanges(changes: SimpleChanges): void {
        this.getReservationData(changes.monthId.currentValue);
    }

    getReservationData(monthId: string){
        if(!monthId){
            return;
        }

        this.apiClient.get(`${config.serverUrl}${config.reservationCoverage}${monthId}`)
        .subscribe((responseBody)=>{
            let reservationData = responseBody as ReservationData[];
            this.reservationData = reservationData;
            this.chartData = reservationData.map((x)=>({
                domain:{
                name: x.instanceType,
                value: x.totalHours,
                }
            }))
        })
    }
}   