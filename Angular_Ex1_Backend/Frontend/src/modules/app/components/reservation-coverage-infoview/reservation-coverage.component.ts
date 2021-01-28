import { Component, Input } from '@angular/core';
import MockData from '../../MockData.json';

interface ReservationData {
    instanceType: string,
    totalHours: number,
    reservedHours: number,
}

let defaultReservationData: ReservationData[] = [];


@Component({
    templateUrl: './reservation-coverage.component.html',
    styleUrls: ['./reservation-coverage.compnent.css'],
})
export class ReservationCoverageComponent{
    @Input() monthId = ''
    reservationData: ReservationData[] = defaultReservationData;
    constructor(){}
}