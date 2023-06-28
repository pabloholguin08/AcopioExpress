import { Component, ElementRef, ViewChild } from '@angular/core';
import { PersonaService } from 'src/app/Services/persona.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import jsPDF from 'jspdf';
import { ImpresionService } from 'src/app/Services/impresion.service';
import { AlertaService } from 'src/app/Services/alerta.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-listar-persona',
  templateUrl: './listar-persona.component.html',
  styleUrls: ['./listar-persona.component.css']
})
export class ListarPersonaComponent {
  listaPersona:any;
  addPersonaForm:FormGroup= new FormGroup({});
  mostrarColumna:boolean = true
  @ViewChild('tablaPersona',{static:false}) cuerpo!:ElementRef

  constructor(private personaService:PersonaService,
     private formBuilder:FormBuilder,
      private router:Router,
      private srvImpresion :ImpresionService,
      private toastr:ToastrService,
      private alertService:AlertaService){}

  ngOnInit(): void {
    //Data para listar personas
    this.listarPersona()
    

    //Validaciones de formulario para Crear Persona
    this.addPersonaForm = this.formBuilder.group({
      "cedula": new FormControl('',[Validators.required]),
      "nombres": new FormControl('',Validators.required),
      "apellidos": new FormControl('',Validators.required),
      "telefono": new FormControl('',Validators.required),
      "direccion": new FormControl('',Validators.required),
      "idAcopio": new FormControl('',Validators.required),
      "idTipoProducto": new FormControl('',Validators.required),
      "idRol": new FormControl('',Validators.required)
    })
  }

  crearPersona(){
    this.personaService.agregarPersona(this.addPersonaForm.value).subscribe(data=>{
      this.router.navigate(['/persona'])
      this.listarPersona();
      this.limpiarPersona();
      this.alertService.ShowSucess("Persona creada correctamente","Crear Persona");
    },err=>{
      this.alertService.ShowError("Error al crear la persona","Crear Persona");
      console.log(err);

    })
  }

  limpiarPersona(){
    this.addPersonaForm = this.formBuilder.group({
      "cedula": new FormControl('',[Validators.required]),
      "nombres": new FormControl('',Validators.required),
      "apellidos": new FormControl('',Validators.required),
      "telefono": new FormControl('',Validators.required),
      "direccion": new FormControl('',Validators.required),
      "idAcopio": new FormControl('',Validators.required),
      "idTipoProducto": new FormControl('',Validators.required),
      "idRol": new FormControl('',Validators.required)
    })
  }

  listarPersona(){
    this.personaService.listarPersonas().subscribe(data=>{
      this.listaPersona = data
    })
  }

  onImprimir(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImpresion.imprimir(this.cuerpo.nativeElement,"tabla personas",true)
        this.mostrarColumna= true;
      }
    })
  }

  eliminarPersona(id:string){
  const swalWithBootstrapButtons = Swal.mixin({
    customClass: {
      confirmButton: 'btn btn-danger ',
      cancelButton: 'btn btn-primary me-2'
    },
    buttonsStyling: false
  })
  
  swalWithBootstrapButtons.fire({
    title: 'Esta seguro de querer eliminar?',
    icon: 'warning',
    showCancelButton: true,
    cancelButtonText: 'cancelar',
    confirmButtonText: 'Si, eliminar!',

    reverseButtons: true
  }).then((result) => {
    if (result.isConfirmed) {
      this.router.navigate([`/persona/eliminar/${id}`])
    } else if (result.isDenied) {
      Swal.fire('Changes are not saved', '', 'info')
    }
  })
}




}
