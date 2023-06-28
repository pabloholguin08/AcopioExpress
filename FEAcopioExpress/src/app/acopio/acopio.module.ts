import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { ListarAcopioComponent } from "./listar-acopio/listar-acopio.component";
import { CrearAcopioComponent } from "./crear-acopio/crear-acopio.component";
import { EditarAcopioComponent } from "./editar-acopio/editar-acopio.component";
import { EliminarAcopioComponent } from "./eliminar-acopio/eliminar-acopio.component";

@NgModule({
  declarations:[
    ListarAcopioComponent,
    CrearAcopioComponent,
    EditarAcopioComponent,
    EliminarAcopioComponent
  ],
  imports:[
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ]
})
export class AcopioModule{}
