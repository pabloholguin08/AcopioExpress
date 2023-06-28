import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AcopioService } from 'src/app/Services/acopio.service';
import { LoginService } from 'src/app/Services/login.service';



@Component({
  selector: 'app-barra-superior',
  templateUrl: './barra-superior.component.html',
  styleUrls: ['./barra-superior.component.css']
})
export class BarraSuperiorComponent {
  rol:any
  acopio:any
  listaAcopio:any
  usuario:any

  constructor(private acopioService:AcopioService, private router:Router, private loginService:LoginService){}

  ngOnInit(): void {
    this.obtener()
    this.rols()
    this.acopi()
  }

  obtener(){
    this.usuario = this.loginService.obtenerUsuario()
    console.log(this.usuario)
  }

  rols(){
    console.log(this.rol)
    this.rol = this.loginService.exportarRol()
  }

  acopi(){
    console.log(this.acopio)
    this.acopio=this.loginService.exportarAcopio()
  }
}
