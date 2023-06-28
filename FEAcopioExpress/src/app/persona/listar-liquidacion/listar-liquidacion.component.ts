import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import jsPDF from 'jspdf';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ImpresionService } from 'src/app/Services/impresion.service';
import { LiquidacionService } from 'src/app/Services/liquidacion.service';
import { PersonaService } from 'src/app/Services/persona.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-listar-liquidacion',
  templateUrl: './listar-liquidacion.component.html',
  styleUrls: ['./listar-liquidacion.component.css']
})
export class ListarLiquidacionComponent {
  listaLiquidacion:any;
  listaPersonas:any;
  liquidacion:any;
  fechaInicio:any;
  fechaFin:any;
  idPersona:any;
  mostrarColumna:boolean=true

  addLiquidacionForm:FormGroup= new FormGroup({});
  @ViewChild('tablaPersona',{static:false}) cuerpo!:ElementRef

  constructor(private liquidacionService:LiquidacionService,
    private personaService:PersonaService ,
    private router:Router,
    private srvImpresion :ImpresionService,
    private alertaService:AlertaService){}


  ngOnInit(): void {
    //Data para listar personas
    this.listarLiquidacion();
    this.listarPersonas();

  }

  crearLiquidacion(){
    this.liquidacionService.agregarLiquidacion(this.idPersona,this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.liquidacion =data;
      this.router.navigate(['persona/liquidacion'])
      this.listarLiquidacion()
      this.alertaService.ShowSucess("Liquidacion generada correctamente","Generar Liquidacion");
    },err=>{
      this.alertaService.ShowError("Error al crear la liquidacion","Generar Liquidacion")
      console.log(err);
    })
  }

  listarLiquidacion(){
    this.liquidacionService.listarLiquidaciones().subscribe(data=>{
      this.listaLiquidacion = data
    })
  }
  listarPersonas(){
    this.personaService.listarPersonasProductores().subscribe(data=>{
      this.listaPersonas = data
    })
  }

  onImprimir(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImpresion.imprimir(this.cuerpo.nativeElement,"Reporte de liquidaciones",true)
        this.mostrarColumna= true;
      }
    })


  }


  eliminarLiquidacion(id:string){
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
        this.router.navigate([`/persona/eliminarLiquidacion/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }

}
