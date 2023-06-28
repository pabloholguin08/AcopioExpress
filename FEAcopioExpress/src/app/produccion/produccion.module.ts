import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { FormsModule } from '@angular/forms';

import { EliminarProduccionComponent } from './eliminar-produccion/eliminar-produccion.component';
import { EditarProduccionComponent } from './editar-produccion/editar-produccion.component';

import { ListarProduccionComponent } from './listar-produccion/listar-produccion.component';

import { MenuModule } from '../menu/menu.module';

import { RecuperarProduccionComponent } from './recuperar-produccion/recuperar-produccion.component';
import { ListarVentaProduccionComponent } from './listar-venta-produccion/listar-venta-produccion.component';
import { EliminarVentaComponent } from './eliminar-venta/eliminar-venta.component';
import { RecuperarVentaComponent } from './recuperar-venta/recuperar-venta.component';
import { EditarVentaComponent } from './editar-venta/editar-venta.component';


@NgModule({
  declarations: [
    EliminarProduccionComponent,
    EditarProduccionComponent,
    ListarProduccionComponent,

    RecuperarProduccionComponent,
      ListarVentaProduccionComponent,
      EliminarVentaComponent,
      RecuperarVentaComponent,
      EditarVentaComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    MenuModule
  ],
  providers:[
    DatePipe,
  ]
})
export class ProduccionModule { }
