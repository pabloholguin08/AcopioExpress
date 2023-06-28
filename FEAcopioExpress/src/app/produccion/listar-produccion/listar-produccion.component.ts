import { Component, ElementRef, ViewChild } from '@angular/core';
import { ProduccionService } from 'src/app/Services/produccion.service';
import { PersonaService } from 'src/app/Services/persona.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ImpresionService } from 'src/app/Services/impresion.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-listar-produccion',
  templateUrl: './listar-produccion.component.html',
  styleUrls: ['./listar-produccion.component.css']
})
export class ListarProduccionComponent {
  listaProduccion:any
  listaProduccionInactiva:any
  listaPersona:any
  mostrarColumna:boolean = true;
  fechaInicio1:string ='2023-06-01';
  fechaFin2:string='2023-06-30';
  addProduccionForm:FormGroup= new FormGroup({});
  @ViewChild('tablaProduccion',{static:false}) cuerpo!:ElementRef;

  constructor(private produccionService:ProduccionService,
     private personaService:PersonaService,
      private formBuilder:FormBuilder,
      private router:Router,
      private alertService:AlertaService,
      private srvImprimir:ImpresionService){}

  ngOnInit(): void {
    this.ListaProduccion()
    this.listarPersona()
    this.ListarProduccionInactivas()

    this.addProduccionForm = this.formBuilder.group({
      "diaIngresoProducto": new FormControl('',[Validators.required]),
      "cantidad": new FormControl('',Validators.required),
      "precioProducto": new FormControl('',Validators.required),
      "observaciones": new FormControl('',Validators.required),
      "idPersona": new FormControl('',Validators.required),
      "nombres": new FormControl('',Validators.required),
      "apellidos": new FormControl('',Validators.required),
    })
  }

  crearProduccion(){
    this.produccionService.agregarProduccion(this.addProduccionForm.value).subscribe(data=>{
      this.ListaProduccion()
      this.router.navigate(['/produccion'])
      this.limpiarFormulario()
      this.alertService.ShowSucess("Produccion agregarda correctamente","Agregar Produccion");
    },err=>{
      this.alertService.ShowError("Error al agregar la produccion","Agregar Produccion");

      console.log(err);
    })
  }

  limpiarFormulario(){
    this.addProduccionForm = this.formBuilder.group({
      "diaIngresoProducto": new FormControl('',[Validators.required]),
      "cantidad": new FormControl('',Validators.required),
      "precioProducto": new FormControl('',Validators.required),
      "observaciones": new FormControl('',Validators.required),
      "idPersona": new FormControl('',Validators.required),
      "nombres": new FormControl('',Validators.required),
      "apellidos": new FormControl('',Validators.required),
    })
  }


  ListaProduccion(){
    this.produccionService.fechasProduccion(this.fechaInicio1, this.fechaFin2).subscribe(data=>{
      this.listaProduccion = data
    })
  }

  listarPersona(){
    this.personaService.listarPersonasProductores().subscribe(data=>{
      this.listaPersona = data
    })
  }

  ListarProduccionInactivas(){
    this.produccionService.listarProduccionInactivas().subscribe(data=>{
      this.listaProduccionInactiva = data
    })
  }

  onImprimir(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImprimir.imprimir(this.cuerpo.nativeElement,"Reporte de compras de produccion",true)
        this.mostrarColumna= true;
      }
    })
  }

  eliminarProduccion(id:string){
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
        this.router.navigate([`/produccion/eliminar/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }


}


