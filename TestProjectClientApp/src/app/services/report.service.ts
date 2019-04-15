import { ApplicationHttpClient } from '../main/common/http-client';
import { Area } from '../models/area.model';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})
export class ReportService {

    apiURL: string = '/api/report';
    constructor(private httpClient: ApplicationHttpClient) {
    }

    public getAreas() {
        return this.httpClient.get<Area[]>(`${this.apiURL}/areas`);
    }

    public getCarReportsData(id: number) {
        return this.httpClient.get<any>(`${this.apiURL}/reports/${id}`);
    }
}