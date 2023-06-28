import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { EditarPersonaComponent } from './editar-persona/editar-persona.component';
import { ListarPersonaComponent } from './listar-persona/listar-persona.component';
import { EliminarPersonaComponent } from './eliminar-persona/eliminar-persona.component';
import { ListarInactivosPersonaComponent } from './listar-inactivos-persona/listar-inactivos-persona.component';
import { RecuperarPersonaComponent } from './recuperar-persona/recuperar-persona.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuModule } from '../menu/menu.module';

import { ListarLiquidacionComponent } from './listar-liquidacion/listar-liquidacion.component';
import { EliminarLiquidacionComponent } from './eliminar-liquidacion/eliminar-liquidacion.component';

import { ToastrModule } from 'ngx-toastr';




@NgModule({
  declarations: [
    EditarPersonaComponent,
    ListarPersonaComponent,
    EliminarPersonaComponent,
    ListarInactivosPersonaComponent,
    RecuperarPersonaComponent,
    ListarLiquidacionComponent,
    EliminarLiquidacionComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    MenuModule,
    ToastrModule,
    BrowserAnimationsModule
  ]
})
export class PersonaModule { }
