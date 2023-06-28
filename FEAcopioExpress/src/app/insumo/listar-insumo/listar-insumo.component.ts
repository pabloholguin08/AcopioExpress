import { Component, ElementRef, ViewChild } from '@angular/core';
import { InsumoService } from 'src/app/Services/insumo.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ImpresionService } from 'src/app/Services/impresion.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-listar-insumo',
  templateUrl: './listar-insumo.component.html',
  styleUrls: ['./listar-insumo.component.css']
})
export class ListarInsumoComponent {
  listaInsumo:any
  addInsumoForm:FormGroup= new FormGroup({});
  mostrarColumna:boolean = true
  @ViewChild('tablaInsumos',{static:false}) cuerpo!:ElementRef

  single:any
  chartData: any[] = [];

  constructor(private insumoService:InsumoService,
    private alertaService:AlertaService,
     private formBuilder:FormBuilder,
     private router:Router,
     private srvImpresion:ImpresionService){}

  ngOnInit(): void {
    this.listarInsumo()
    this.listarGrafica()

    this.addInsumoForm = this.formBuilder.group({
      "nombreInsumo": new FormControl('',[Validators.required]),
      "descripcion": new FormControl('',Validators.required),
      "valorUnitarioVenta": new FormControl('',Validators.required),
      "stock": new FormControl('',Validators.required),
      "valorUnitarioCompra": new FormControl('',Validators.required),
    })
  }

  listarGrafica(){
    this.insumoService.listarInsumo().subscribe(data=>{
      this.chartData = this.transformData(data)
      this.single= this.chartData
    })
  }

  transformData(data: any): any[] {
    return data.map((item:{nombreInsumo:string, stock:number}) => ({ name: item.nombreInsumo, value: item.stock }));
  }

  crearInsumo(){
    this.insumoService.agregarInsumo(this.addInsumoForm.value).subscribe(data=>{
      this.router.navigate(['/insumo']);
      this.listarInsumo();
      this.limpiarFormulario();
      this.listarGrafica();
      this.alertaService.ShowSucess("Insumo creado exitosamente","Crear Insumo");
    },err=>{

      this.alertaService.ShowError("No se pudo crear el Insumo","Crear Insumo");
      console.log(err);
    })
  }

  limpiarFormulario(){
    this.addInsumoForm = this.formBuilder.group({
      "nombreInsumo": new FormControl('',[Validators.required]),
      "descripcion": new FormControl('',Validators.required),
      "valorUnitarioVenta": new FormControl('',Validators.required),
      "stock": new FormControl('',Validators.required),
      "valorUnitarioCompra": new FormControl('',Validators.required),
    })
  }

  listarInsumo(){
    this.insumoService.listarInsumo().subscribe(data=>{
      this.listaInsumo = data
    })
  }


  onImprimir(){
    this.mostrarColumna= false;
    setTimeout(() => {
      if (this.mostrarColumna == false) {
        this.srvImpresion.imprimir(this.cuerpo.nativeElement,"Inventario de productos",true)
        this.mostrarColumna= true;
      }
    })
  }

  view:[number,number] = [900, 400];

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


  eliminarInsumo(id:string){
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
        this.router.navigate([`/insumo/eliminar/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }


}
