import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../Services/login.service';
import { AlertaService } from '../Services/alerta.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  usuario:any
  password:any
  listaUsuario:any
  estado:boolean = false
  credencialForm:FormGroup= new FormGroup({});


  constructor(private loginService:LoginService, private formBuilder:FormBuilder, private router:Router,
    private alertaService:AlertaService){}

  ngOnInit(): void {

    this.loginService.estado(this.estado)
  }

  validarObtener(){
    this.validarUsuario
    this.loginService.variableCompartida(this.usuario)
  }

  validarContraseña(){
    this.loginService.contrasena(this.password)
  }

  validarUsuario(){
    this.loginService.validarCredenciales(this.usuario,this.password).subscribe(data=>{
      this.listaUsuario= data
      if(this.listaUsuario==null){
        this.ShowError()
        this.estado=false;
        this.loginService.estado(this.estado)
      }else if(this.listaUsuario.usuario == this.usuario && this.listaUsuario.password==this.password){
        this.loginService.Acopi(this.listaUsuario.nombreAcopi)
        this.loginService.Rol(this.listaUsuario.nombreRol)
        this.ShowSucess();
        this.estado=true;
        this.loginService.estado(this.estado)
        console.log(this.listaUsuario)
        this.validarObtener()
        this.router.navigate(['/home'])
      }else{
        this.ShowError()
      }
    },err=>{
      this.ShowError()
    })
  }

  ShowSucess(){
    this.alertaService.ShowSucess('Usuario Correcto','Credenciales Validadas');
  }
  ShowError(){
    this.alertaService.ShowError('Usuario o contraseña invalidos','Acceso denegado');
  }
}
