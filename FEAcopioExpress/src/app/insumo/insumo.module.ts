import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { ListarInsumoComponent } from "./listar-insumo/listar-insumo.component";

import { EditarInsumoComponent } from './editar-insumo/editar-insumo.component';
import { EliminarInsumoComponent } from "./eliminar-insumo/eliminar-insumo.component";
import { MenuModule } from "../menu/menu.module";
import { RecuperarInsumoComponent } from './recuperar-insumo/recuperar-insumo.component';
import { ListarInactivosInsumoComponent } from './listar-inactivos-insumo/listar-inactivos-insumo.component';
import { HistorialVentaInsumoComponent } from "./historial-venta-insumo/historial-venta-insumo.component";
import { RegistrarVentaInsumoComponent } from "./registrar-venta-insumo/registrar-venta-insumo.component";
import { NgxChartsModule } from "@swimlane/ngx-charts";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { EliminarVentaInsumoComponent } from './eliminar-venta-insumo/eliminar-venta-insumo.component';


@NgModule({
  declarations:[
    ListarInsumoComponent,
    EditarInsumoComponent,
    EliminarInsumoComponent,
    RecuperarInsumoComponent,
    ListarInactivosInsumoComponent,
    HistorialVentaInsumoComponent,
    RegistrarVentaInsumoComponent,
    EliminarVentaInsumoComponent,

  ],
  imports:[
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MenuModule,
    FormsModule,
    NgxChartsModule,
    BrowserAnimationsModule,
    BrowserModule
  ]
})
export class InsumoModule{}
