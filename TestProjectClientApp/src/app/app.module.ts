import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatListModule, MatSelectModule, MatFormFieldModule, MatInputModule, MatTableModule, MatProgressSpinnerModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReportsComponent } from './main/reports/reports.component';
import { LoaderService } from './main/common/loader/loader.service';
import { ApplicationHttpClient, applicationHttpClientCreator } from './main/common/http-client';
import { ReportService } from './services/report.service';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { CarGridComponent } from './main/car-grid/car-grid.component';
import { LoaderComponent } from './main/common/loader/loader.component';

@NgModule({
  declarations: [
    AppComponent,
    ReportsComponent,
    CarGridComponent,
    LoaderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatListModule,
    MatSelectModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule,
    MatProgressSpinnerModule,
  ],
  exports: [
    
    MatInputModule,
    MatListModule,
    MatTableModule,
    MatProgressSpinnerModule
  ],
  providers: [
    LoaderService,
        {
            provide: ApplicationHttpClient,
            useFactory: applicationHttpClientCreator,
            deps: [HttpClient, LoaderService]
        },
        ReportService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
