import { Component, ElementRef, ViewChild } from '@angular/core';
import { EgresosAcopioService } from 'src/app/Services/egresos-acopio.service';
import { IngresosAcopioService } from 'src/app/Services/ingresos-acopio.service';
import { AcopioService } from 'src/app/Services/acopio.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { CurrencyPipe, DatePipe } from '@angular/common';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ImpresionService } from 'src/app/Services/impresion.service';
import Swal from 'sweetalert2';



@Component({
  selector: 'app-registrar-ingresos',
  templateUrl: './registrar-ingresos.component.html',
  styleUrls: ['./registrar-ingresos.component.css']
})
export class RegistrarIngresosComponent {
  fechaInicio:string ='2023-01-01';
  fechaFin:string='2023-12-31';
  reiniciarfecha:any

  mostrarColumna= true;

  listaIngresos:any;
  listaEgresos:any;

  single:any
  single2:any
  chartData: any[] = [];
  chartIngresos: any[] = [];

  addEgresosForm:FormGroup= new FormGroup({});

  fechaIngresoIngreso:any
  fechaFinalIngreso:any

  fechaInicioEgreso:any
  fechaFinalEgreso:any

  listaBalance:any
  balance:any
  @ViewChild('modalIngresos') modalIngresos:any
  @ViewChild('modalEgresos') modalEgresos:any

  @ViewChild('tablaIngresos',{static:false}) tablaIngresos!:ElementRef
  @ViewChild('tablaEgresos',{static:false}) tablaEgresos!:ElementRef

  constructor(private egresosService:EgresosAcopioService,
    private ingresosService:IngresosAcopioService,
    private acopioService:AcopioService ,
     private router:Router,
     private formBuilder:FormBuilder,
     private datePipe: DatePipe,
     private currencyPipe:CurrencyPipe,
     private alertService:AlertaService,
     private srvImprimir:ImpresionService){
    // Object.assign(this, { single });
  }


  ngOnInit(): void {

    this.funciones()
    //Data para listar personas
    this.addEgresosForm = this.formBuilder.group({
      "idAcopio": new FormControl('',Validators.required),
      "nombreAcopi": new FormControl('',Validators.required),
      "sumatoriaNominas": new FormControl(0,Validators.required),
      "sumatoriaLiquidacion": new FormControl(0,Validators.required),
      "totalEgresos": new FormControl(0,Validators.required),
      "arriendo": new FormControl('',Validators.required),
      "servicios": new FormControl('',Validators.required),
      "gastosExtras": new FormControl('',Validators.required),
    })
  }

  funciones(){
    this.ListaEgresosGrafica()
    this.ListaIngresosGrafica()
    this.ListaIngresos()
    this.ListaEgresos()
    this.ListarBalance()
  }

  ListarBalance(){
    this.acopioService.reporteContabilidad(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.listaBalance = data
      this.balance = this.listaBalance.gananTotal
    })
  }

  ListaEgresosGrafica(){
    this.egresosService.obtenerEgresos(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.chartData = this.transformData(data)
      this.single= this.chartData
    })
  }

  ListaIngresosGrafica(){
    this.ingresosService.obtenerIngresos(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.chartIngresos = this.transformData2(data)
      this.single2= this.chartIngresos
    })
  }


  transformData(data: any): any[] {
    return data.map((item:{fechaFinalIngresosEgresos:string, totalEgresos:number}) => ({ name: this.datePipe.transform(item.fechaFinalIngresosEgresos,'dd/MM/yyyy'), value: item.totalEgresos }));
  }


  transformData2(data: any): any[] {
    return data.map((item:{fechaFinalIngresosLiquidacion:string, totalIngresos:number}) => ({ name: this.datePipe.transform(item.fechaFinalIngresosLiquidacion,'dd/MM/yyyy'), value: item.totalIngresos }));
  }


  ListaIngresos(){
    this.ingresosService.obtenerIngresos(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.listaIngresos = data
    })
  }

  ListaEgresos(){
    this.egresosService.obtenerEgresos(this.fechaInicio,this.fechaFin).subscribe(data=>{
      this.listaEgresos = data
    })
  }

  limpiarEgresos(){
    this.addEgresosForm = this.formBuilder.group({
      "idAcopio": new FormControl('',Validators.required),
      "nombreAcopi": new FormControl('',Validators.required),
      "sumatoriaNominas": new FormControl(0,Validators.required),
      "sumatoriaLiquidacion": new FormControl(0,Validators.required),
      "totalEgresos": new FormControl(0,Validators.required),
      "arriendo": new FormControl('',Validators.required),
      "servicios": new FormControl('',Validators.required),
      "gastosExtras": new FormControl('',Validators.required),
    })
  }

  crearEgreso(){
    this.egresosService.agregarEgresos(this.addEgresosForm.value,this.fechaInicioEgreso, this.fechaFinalEgreso).subscribe(data=>{
      this.ListaEgresosGrafica();
      this.ListaEgresos()
      this.ListarBalance()
      this.alertService.ShowSucess("Egreso creado correctamente","Crear Egreso");
      this.limpiarEgresos();
    },err=>{
      console.log(err);
      this.alertService.ShowError("Error al crear el egreso","Crear Egreso");

    })
  }

  crearIngreso(){
    this.ingresosService.agregarIngresos(this.fechaIngresoIngreso, this.fechaFinalIngreso).subscribe(data=>{
      this.ListaIngresosGrafica();
      this.ListaIngresos()
      this.ListarBalance()
      this.alertService.ShowSucess("Ingreso creado correctamente","Crear Ingreso");
    },err=>{
      this.alertService.ShowError("Error al crear el ingreso","Crear Ingreso");
      console.log(err);
    })
  }

  pdfEgresos(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImprimir.imprimir(this.tablaEgresos.nativeElement,"Reporte de Egresos",true)
        this.mostrarColumna= true;
      }
    })
  }
  pdfIngresos(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImprimir.imprimir(this.tablaIngresos.nativeElement,"Reporte de Ingresos",true)
        this.mostrarColumna= true;
      }
    })
  }

  //la data que quiero colocar


  view:[number,number] = [700, 400];

  // options
  gradient: boolean = true;
  showLegend: boolean = true;
  showLabels: boolean = true;
  isDoughnut: boolean = false;


  onSelect(data:any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data:any): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data:any): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }



  view2:[number,number] = [750, 400];

  gradient2: boolean = true;
  showLegend2: boolean = true;
  showLabels2: boolean = true;
  isDoughnut2: boolean = false;


  onSelect2(data:any): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate2(data:any): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate2(data:any): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }



  eliminarAlertaEgreso(id:string){
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
        this.router.navigate([`/home/eliminar-egreso/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }

  eliminarAlertaIngreso(id:string){
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
        this.router.navigate([`/home/eliminar-ingreso/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }


}
