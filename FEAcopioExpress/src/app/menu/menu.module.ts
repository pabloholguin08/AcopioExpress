import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuLateralComponent } from '../menu/menu-lateral/menu-lateral.component';
import { BarraSuperiorComponent } from '../menu/barra-superior/barra-superior.component';


@NgModule({
  declarations: [
    MenuLateralComponent,
    BarraSuperiorComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    MenuLateralComponent,
    BarraSuperiorComponent
  ]
})
export class MenuModule { }
