import { Component, ElementRef, ViewChild } from '@angular/core';
import { NominaService } from 'src/app/Services/nomina.service';
import { PersonaService } from 'src/app/Services/persona.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ImpresionService } from 'src/app/Services/impresion.service';

import * as XLSX from 'xlsx';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-listar-nomina',
  templateUrl: './listar-nomina.component.html',
  styleUrls: ['./listar-nomina.component.css']
})
export class ListarNominaComponent {
  fileName='nominas.xlsx'
  listaNomina:any
  listaPersonas:any
  mostrarColumna= true;
  addNominaForm:FormGroup= new FormGroup({});
  @ViewChild('tablaNomina',{static:false}) cuerpo!:ElementRef;

  constructor(private nominaService:NominaService,
    private personaService:PersonaService,
    private formBuilder:FormBuilder,
    private router:Router,
    private alertService:AlertaService,
    private srvImprimir:ImpresionService){}

  ngOnInit(): void {
    this.listarNomina()
    this.listarPersonas()

    this.addNominaForm = this.formBuilder.group({
      "idPersona": new FormControl('',Validators.required),
      "salario": new FormControl('',Validators.required),
      "fechaPago": new FormControl('',Validators.required)
    })
  }

  limpiarNomina(){
    this.addNominaForm = this.formBuilder.group({
      "idPersona": new FormControl('',Validators.required),
      "salario": new FormControl('',Validators.required),
      "fechaPago": new FormControl('',Validators.required)
    })
  }

  crearNomina(){
    this.nominaService.agregarNomina(this.addNominaForm.value).subscribe(data=>{
      this.router.navigate(['/nomina'])
      this.limpiarNomina();
      this.listarNomina()
      this.alertService.ShowSucess("Nomina Generada correctamente","Generar Nomina");
    },err=>{
      this.alertService.ShowError("Error al generar la nomina","Generar Nomina");
      console.log(err);
    })
  }

  listarPersonas(){
    this.personaService.listarPersonasEmpleados().subscribe(data=>{
      this.listaPersonas = data
    })
  }

  listarNomina(){
    this.nominaService.listarNomina().subscribe(data=>{
      this.listaNomina = data
    })
  }

  imprimir(){
    this.onImprimir()
    this.exporteExcel()
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

  exporteExcel(){
    this.mostrarColumna= false;
    let element =document.getElementById('tablaExcel');
    const ws:XLSX.WorkSheet = XLSX.utils.table_to_sheet(element);

    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb,ws,'Sheet1');

    XLSX.writeFile(wb,this.fileName)
  }


  eliminarNomina(id:string){
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
        this.router.navigate([`/nomina/eliminar/${id}`])
      } else if (result.isDenied) {
        Swal.fire('Changes are not saved', '', 'info')
      }
    })
  }
}
