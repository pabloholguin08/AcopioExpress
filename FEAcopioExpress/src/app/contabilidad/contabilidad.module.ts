import { NgModule } from '@angular/core';
import { DatePipe, CurrencyPipe } from '@angular/common';

import { CommonModule } from '@angular/common';
import { RegistrarIngresosComponent } from './registrar-ingresos/registrar-ingresos.component';
import { MenuModule } from '../menu/menu.module';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EliminarIngresoComponent } from './eliminar-ingreso/eliminar-ingreso.component';
import { EliminarEgresoComponent } from './eliminar-egreso/eliminar-egreso.component';


@NgModule({
  declarations: [
    RegistrarIngresosComponent,
    EliminarIngresoComponent,
    EliminarEgresoComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MenuModule,
    FormsModule,
    NgxChartsModule,
    BrowserModule,
    BrowserAnimationsModule,
  ],
  exports:[
    NgxChartsModule
  ],
  providers:[
    DatePipe,
    CurrencyPipe
  ]
})
export class ContabilidadModule { }
