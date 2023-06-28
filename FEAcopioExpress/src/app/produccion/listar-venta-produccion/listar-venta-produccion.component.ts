import { Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ImpresionService } from 'src/app/Services/impresion.service';
import { VentaProduccionService } from 'src/app/Services/venta-produccion.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-listar-venta-produccion',
  templateUrl: './listar-venta-produccion.component.html',
  styleUrls: ['./listar-venta-produccion.component.css']
})
export class ListarVentaProduccionComponent {

  listaVentaProduccion:any
  listaVentaProduccionEliminados:any
  addVentaProduccionForm:FormGroup= new FormGroup({});
  mostrarColumna:boolean = true
  @ViewChild('tablaVentaProduccion',{static:false}) cuerpo!:ElementRef

  constructor(private ventaProduccionServ:VentaProduccionService,
     private formBuilder:FormBuilder,
     private router:Router,
     private alertService:AlertaService,
     private srvImprimir:ImpresionService
     ){}

  ngOnInit(): void {
    this.ListaVentaProduccion()
    this.ListaVentaProduccionEliminados()


    this.addVentaProduccionForm = this.formBuilder.group({
      "idAcopio": new FormControl('',[Validators.required]),
      "nombreAcopi": new FormControl('',Validators.required),
      "fechaVenta": new FormControl(Validators.required),
      "cantidad": new FormControl('',Validators.required),
      "precio": new FormControl('',Validators.required),
      "totalVentaProduccion": new FormControl(Validators.required),
      "observaciones": new FormControl('',Validators.required),
    })
  }

  crearVentaProduccion(){
    this.ventaProduccionServ.agregarVentaProduccion(this.addVentaProduccionForm.value).subscribe(data=>{
      this.router.navigate(['/produccion/listarVenta']);
      this.ListaVentaProduccion();
      this.limpiarFormulario()
      this.alertService.ShowSucess("Venta generada exitosamente","Genrar Venta");
    },err=>{
      this.alertService.ShowError("Error al generar la venta","Generar Venta");
      console.log(err);
    })
  }

  limpiarFormulario(){
    this.addVentaProduccionForm = this.formBuilder.group({
      "idAcopio": new FormControl('',[Validators.required]),
      "nombreAcopi": new FormControl('',Validators.required),
      "fechaVenta": new FormControl(Validators.required),
      "cantidad": new FormControl('',Validators.required),
      "precio": new FormControl('',Validators.required),
      "totalVentaProduccion": new FormControl(Validators.required),
      "observaciones": new FormControl('',Validators.required),
    })
  }


  ListaVentaProduccion(){
    this.ventaProduccionServ.listarVentaProduccion().subscribe(data=>{
      this.listaVentaProduccion = data
    })
  }

  ListaVentaProduccionEliminados(){
    this.ventaProduccionServ.listarVentaProduccionEliminados().subscribe(data=>{
      this.listaVentaProduccionEliminados = data
    })
  }

  onImprimir(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImprimir.imprimir(this.cuerpo.nativeElement,"Ventas de Produccion",true)
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
        this.router.navigate([`/produccion/eliminarVenta/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }


}
