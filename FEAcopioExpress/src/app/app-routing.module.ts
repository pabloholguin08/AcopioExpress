import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ListarAcopioComponent } from './acopio/listar-acopio/listar-acopio.component';
import { ListarPersonaComponent } from './persona/listar-persona/listar-persona.component';
import { EditarPersonaComponent } from './persona/editar-persona/editar-persona.component';
import { EliminarPersonaComponent } from './persona/eliminar-persona/eliminar-persona.component';
import { RecuperarPersonaComponent } from './persona/recuperar-persona/recuperar-persona.component';
import { ListarInactivosPersonaComponent } from './persona/listar-inactivos-persona/listar-inactivos-persona.component';

import { InicioBlogComponent } from './blog/inicio-blog/inicio-blog.component';
import { QuienesSomosComponent } from './blog/quienes-somos/quienes-somos.component';
import { ProductoComponent } from './blog/producto/producto.component';

import { ListarNominaComponent } from './nomina/listar-nomina/listar-nomina.component';
import { EditarNominaComponent } from './nomina/editar-nomina/editar-nomina.component';
import { EliminarNominaComponent } from './nomina/eliminar-nomina/eliminar-nomina.component';

import { ListarInsumoComponent } from './insumo/listar-insumo/listar-insumo.component';
import { ListarInactivosInsumoComponent } from './insumo/listar-inactivos-insumo/listar-inactivos-insumo.component';
import { EditarInsumoComponent } from './insumo/editar-insumo/editar-insumo.component';
import { EliminarInsumoComponent } from './insumo/eliminar-insumo/eliminar-insumo.component';
import { HistorialVentaInsumoComponent } from './insumo/historial-venta-insumo/historial-venta-insumo.component';

import { RecuperarInsumoComponent } from './insumo/recuperar-insumo/recuperar-insumo.component';
import { ListarProduccionComponent } from './produccion/listar-produccion/listar-produccion.component';
import { EditarProduccionComponent } from './produccion/editar-produccion/editar-produccion.component';
import { EliminarProduccionComponent } from './produccion/eliminar-produccion/eliminar-produccion.component';
import { RecuperarProduccionComponent } from './produccion/recuperar-produccion/recuperar-produccion.component';
import { RegistrarVentaInsumoComponent } from './insumo/registrar-venta-insumo/registrar-venta-insumo.component';

import { ListarVentaProduccionComponent } from './produccion/listar-venta-produccion/listar-venta-produccion.component';
import { EditarVentaComponent } from './produccion/editar-venta/editar-venta.component';
import { RecuperarVentaComponent } from './produccion/recuperar-venta/recuperar-venta.component';
import { EliminarVentaComponent } from './produccion/eliminar-venta/eliminar-venta.component';
import { ListarLiquidacionComponent } from './persona/listar-liquidacion/listar-liquidacion.component';
import { EliminarLiquidacionComponent } from './persona/eliminar-liquidacion/eliminar-liquidacion.component';
import { RegistrarIngresosComponent } from './contabilidad/registrar-ingresos/registrar-ingresos.component';
import { EliminarIngresoComponent } from './contabilidad/eliminar-ingreso/eliminar-ingreso.component';
import { EliminarEgresoComponent } from './contabilidad/eliminar-egreso/eliminar-egreso.component';
import { LoginComponent } from './login/login.component';

import { authGuard } from './guards/auth.guard';
import { NotFoundComponent } from './not-found/not-found.component';
import { EliminarVentaInsumoComponent } from './insumo/eliminar-venta-insumo/eliminar-venta-insumo.component';


const routes: Routes = [
  {
    path:'',component:InicioBlogComponent,
  },
   {
    path:'inicio',component:InicioBlogComponent,
  },
  {
    path:'quienes-somos',component: QuienesSomosComponent
  },
  {
    path:'producto',component: ProductoComponent
  },
  {
    path:'login',component: LoginComponent
  },
  {
    path:'persona',
    children:[
      {path:'',component:ListarPersonaComponent},
      {path:'inactivosPersonas',component:ListarInactivosPersonaComponent},
      {path:'editar/:idPersona',component:EditarPersonaComponent},
      {path:'eliminar/:idPersona',component:EliminarPersonaComponent},
      {path:'recuperar/:idPersona',component:RecuperarPersonaComponent},
      {path:'liquidacion',component:ListarLiquidacionComponent},
      {path:'eliminarLiquidacion/:idLiquidacion',component:EliminarLiquidacionComponent}
    ]
  },
  {
    path:'nomina',
    children:[
      {path:'',component:ListarNominaComponent},
      {path:'inactivosNomina',component:ListarNominaComponent},
      {path:'editar/:idNomina',component:EditarNominaComponent},
      {path:'eliminar/:idNomina',component:EliminarNominaComponent}
    ]
  },
  {
    path:'insumo',
    children:[
      {path:'',component:ListarInsumoComponent},
      {path:'inactivosInsumos',component:ListarInactivosInsumoComponent},
      {path:'editar/:idInsumo',component:EditarInsumoComponent},
      {path:'eliminar/:idInsumo',component:EliminarInsumoComponent},
      {path:'recuperar/:idInsumo',component:RecuperarInsumoComponent},
      {path:'registrar-venta',component:RegistrarVentaInsumoComponent},
      {path:'historial',component:HistorialVentaInsumoComponent},
      {path:'eliminarVenta/:idVentaInsumo',component:EliminarVentaInsumoComponent}

    ]
  },
  {
    path:'produccion',
    children:[
      {path:'',component:ListarProduccionComponent},
      {path:'editar/:idProduccion',component:EditarProduccionComponent},
      {path:'eliminar/:idProduccion',component:EliminarProduccionComponent},
      {path:'recuperar/:idProduccion',component:RecuperarProduccionComponent},
      {path:'editarVenta/:idVentaProduccion',component:EditarVentaComponent},
      {path:'listarVenta',component:ListarVentaProduccionComponent},
      {path:'eliminarVenta/:idVentaProduccion',component:EliminarVentaComponent},
      {path:'recuperarVenta/:idVentaProduccion',component:RecuperarVentaComponent}
    ]
  },
  {
    path:'home',
    children:[
      {path:'',component:RegistrarIngresosComponent},
      {path:'eliminar-ingreso/:idIngresosAcopio',component:EliminarIngresoComponent},
      {path:'eliminar-egreso/:idEgresosAcopio',component:EliminarEgresoComponent}
    ]
  },
  {
    path:'**', component:NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
