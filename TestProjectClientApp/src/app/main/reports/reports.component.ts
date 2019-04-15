import { Component, OnInit } from '@angular/core';
import { ReportService } from 'src/app/services/report.service';
import { Area } from 'src/app/models/area.model';
import { CarModel } from 'src/app/models/car.model';
import { GroupBy } from 'src/app/models/group-by.model';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})

export class ReportsComponent implements OnInit {
  areas: Area[];
  selectedArea: number;
  isDisplayCars: boolean;
  reports: (CarModel | GroupBy)[] = [];

  constructor(private _reportService: ReportService) { }

  ngOnInit() {
    this._reportService.getAreas().subscribe(data => {
      this.areas = data;
    });
  }

  getReports() {
    this._reportService.getCarReportsData(this.selectedArea).subscribe(data => {
      let ids = Object.keys(data);
      ids.forEach(period => {
        let reports = data[period];
        let groupBy = new GroupBy();
        groupBy.period = period;
        this.reports.push(groupBy)

        reports.forEach(report => {
          let cars = report.cars;
          cars.forEach(car => {
            let carModel = new CarModel();
            carModel.title = car.title;
            carModel.description = car.description;
            carModel.garageId = car.garageId;
            carModel.categoryId = car.categoryId;
            this.reports.push(carModel);
          })
        })
      });
      this.isDisplayCars = true;
    })
  }

}
