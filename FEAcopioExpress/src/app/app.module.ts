import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AcopioModule } from './acopio/acopio.module';
import { InsumoModule } from './insumo/insumo.module';
import { NominaModule } from './nomina/nomina.module';
import { PersonaModule } from './persona/persona.module';
import { ProduccionModule } from './produccion/produccion.module';
import { ContabilidadModule } from './contabilidad/contabilidad.module';

import { InicioBlogComponent } from './blog/inicio-blog/inicio-blog.component';
import { QuienesSomosComponent } from './blog/quienes-somos/quienes-somos.component';
import { ProductoComponent } from './blog/producto/producto.component';
import { PiePaginaComponent } from './static/pie-pagina/pie-pagina.component';
import { NavbarBlogComponent } from './static/navbar-blog/navbar-blog.component';
import {ToastrModule}from 'ngx-toastr'

import { ScaleLinear,ScalePoint, ScaleTime, ScaleBand } from 'd3-scale';
import { BaseType } from 'd3-selection';
import { LoginComponent } from './login/login.component';
import { DatePipe } from '@angular/common';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    InicioBlogComponent,
    QuienesSomosComponent,
    ProductoComponent,
    PiePaginaComponent,
    NavbarBlogComponent,
    LoginComponent,
    NotFoundComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    AcopioModule,
    InsumoModule,
    NominaModule,
    PersonaModule,
    ProduccionModule,
    ContabilidadModule,
    ToastrModule.forRoot({
      preventDuplicates:true,//evita que se duplique la alerta
      timeOut:3000, //el tiempo para que desaparesca
      easing:'ease-in', // animaciones
      easeTime:500
    }),
    DatePipe
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
