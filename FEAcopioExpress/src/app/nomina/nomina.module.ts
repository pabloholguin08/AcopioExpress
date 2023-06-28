import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { CommonModule } from '@angular/common';
import { ListarNominaComponent } from './listar-nomina/listar-nomina.component';

import { EliminarNominaComponent } from './eliminar-nomina/eliminar-nomina.component';
import { EditarNominaComponent } from './editar-nomina/editar-nomina.component';
import { MenuModule } from '../menu/menu.module';



@NgModule({
  declarations: [
    ListarNominaComponent,
    EliminarNominaComponent,
    EditarNominaComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MenuModule
  ]
})
export class NominaModule { }
