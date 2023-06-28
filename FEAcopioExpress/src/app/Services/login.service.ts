import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ListarAcopioComponent } from '../acopio/listar-acopio/listar-acopio.component';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  rol:any;
  acopio:any;
  usuario:any
  password:any
  credencial:any
  estados:boolean = false

  ruta:string ='http://localhost:5233/api/Login/'
  constructor(private http:HttpClient) { }

  validarCredenciales(usuario:String, password:String):Observable<any>{
    return this.http.get(this.ruta + 'validarGet?usuario='+usuario+'&pass='+password)
  }

  variableCompartida(usuario:String){
    this.usuario = usuario
  }

  obtenerUsuario(){
    return this.usuario
  }

  contrasena(contrasena:String){
    this.password = contrasena
  }

  obtenerContrasena(){
    return this.password
  }

  estado(estado:boolean){
    this.estados=estado
  }

  obtenerEstado(){
    return this.estados
  }

  Rol(rols:String){
    this.rol = rols
  }

  exportarRol(){
    return this.rol
  }

  Acopi(acopis:String){
    this.acopio = acopis
  }

  exportarAcopio(){
    return this.acopio
  }

  getToken(estado:boolean):Observable<boolean>{
    return of(estado)
  }

}
