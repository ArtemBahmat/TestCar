import { Component, OnInit, Input } from '@angular/core';
import { CarModel } from 'src/app/models/car.model';
import { MatTableDataSource } from '@angular/material';
import { GroupBy } from 'src/app/models/group-by.model';

@Component({
  selector: 'app-car-grid',
  templateUrl: './car-grid.component.html',
  styleUrls: ['./car-grid.component.scss']
})

export class CarGridComponent implements OnInit {
  displayedColumns: string[] = ['title', 'description', 'garage', 'category'];
  dataSource: MatTableDataSource<CarModel | GroupBy>;
  private _reports: (CarModel | GroupBy)[]

  @Input('reports')  
  set reports(value: CarModel[]) {
    this._reports = value;
    if (this._reports) {
      this.bindDataSource(true);
    }
  }

  constructor() { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource<CarModel | GroupBy>(this._reports);
  }

  isGroup(index, item): boolean{
    return item.isGroupBy;
  }

  bindDataSource(withNew: boolean) {
    this.dataSource = new MatTableDataSource<CarModel | GroupBy>(this._reports);
  }
}
