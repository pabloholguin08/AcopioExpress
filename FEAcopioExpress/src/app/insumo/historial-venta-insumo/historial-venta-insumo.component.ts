import { Component, ElementRef, ViewChild } from '@angular/core';
import { VentaInsumoService } from 'src/app/Services/venta-insumo.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ImpresionService } from 'src/app/Services/impresion.service';
import jsPDF from 'jspdf';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-historial-venta-insumo',
  templateUrl: './historial-venta-insumo.component.html',
  styleUrls: ['./historial-venta-insumo.component.css']
})
export class HistorialVentaInsumoComponent {
  historial:any
  reporte:any
  fechaInicio:any;
  fechaFin:any;
  mostrarColumna:boolean = true;
  @ViewChild('tablaReporte',{static:false}) cuerpo!:ElementRef

  constructor(private ventaInsumoService:VentaInsumoService, private formBuilder:FormBuilder, private router:Router,  private srvImpresion :ImpresionService){}

  ngOnInit(): void {


  }

  historialVenta(){
    this.ventaInsumoService.historialVentaInsumo(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.historial =data
    },err=>{
      console.log(err);
    }),
    this.ventaInsumoService.reporteVentaInsumo(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.reporte =data
      console.log(this.reporte)
    },err=>{
      console.log(err);
    })
  }

  onImprimir(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImpresion.imprimir(this.cuerpo.nativeElement,"Historial venta de insumos",true)
        this.mostrarColumna= true;
      }
    }) 
  }

  eliminarVenta(id:string){
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
        this.router.navigate([`/insumo/eliminarVenta/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }


}
