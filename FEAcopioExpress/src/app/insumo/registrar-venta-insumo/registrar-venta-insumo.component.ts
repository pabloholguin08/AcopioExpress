import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { VentaInsumoService } from 'src/app/Services/venta-insumo.service';
import { PersonaService } from '../../Services/persona.service';
import { InsumoService } from 'src/app/Services/insumo.service';
import { AlertaService } from 'src/app/Services/alerta.service';

@Component({
  selector: 'app-registrar-venta-insumo',
  templateUrl: './registrar-venta-insumo.component.html',
  styleUrls: ['./registrar-venta-insumo.component.css']
})
export class RegistrarVentaInsumoComponent {

  listaPersona:any;
  listaInsumo:any
  insumoEncontrado:any
  precio:number=0;
  precio2:any;
  precioId:number=0;
  cantidad:any;
  totalVentaInsumo:any;


  addVentaForm:FormGroup= new FormGroup({});
  addDetalle:FormGroup = new FormGroup({})

  constructor(private ventaInsumoService:VentaInsumoService,private alertService:AlertaService, private personaService:PersonaService, private insumoService:InsumoService, private formBuilder:FormBuilder, private router:Router){}

  ngOnInit(): void {

    this.listarPersona()
    this.listarInsumo()

    this.calcularTotalVentaInsumo()



    this.addVentaForm = this.formBuilder.group({
      "idPersona": new FormControl('',[Validators.required]),
      "nombres": new FormControl('',[Validators.required]),
      "apellidos": new FormControl('',[Validators.required]),
      "idTipoPago": new FormControl('',Validators.required),
      "nombreTipoProducto": new FormControl('',Validators.required),
      "detalleVentaInsumos": this.formBuilder.array([
        this.addDetalle = this.formBuilder.group({
          "idInsumo": new FormControl('', Validators.required),
          "nombreInsumo": new FormControl('', Validators.required),
          "cantidad": new FormControl('', Validators.required),
          "precio": new FormControl(Validators.required),
          "totalVentaInsumo": new FormControl(this.totalVentaInsumo,Validators.required)
        })
      ]),
      "observacion": new FormControl('',Validators.required),
      "fechaRegistro": new FormControl('',Validators.required,),
    });
  }

  calcularTotalVentaInsumo() {
    this.cantidad = this.addDetalle.get('cantidad')?.value;
    this.precio = this.addDetalle.get('precio')?.value;

    if (this.cantidad && this.precio) {
      this.totalVentaInsumo = this.cantidad * this.precio;
      this.addDetalle.get('totalVentaInsumo')?.setValue(this.totalVentaInsumo);
      console.log(this.totalVentaInsumo);
    }
  }

  actualizarPrecio() {
    const idInsumoSeleccionado = this.addDetalle.get('idInsumo')?.value;
      this.precio= this.addDetalle.get('precio')?.value;
      this.precioId = idInsumoSeleccionado
      console.log(this.precio)
  }

  limpiarFormulario(){
    this.addVentaForm = this.formBuilder.group({
      "idPersona": new FormControl('',[Validators.required]),
      "nombres": new FormControl('',[Validators.required]),
      "apellidos": new FormControl('',[Validators.required]),
      "idTipoPago": new FormControl('',Validators.required),
      "nombreTipoProducto": new FormControl('',Validators.required),
      "detalleVentaInsumos": this.formBuilder.array([
        this.addDetalle = this.formBuilder.group({
          "idInsumo": new FormControl('', Validators.required),
          "nombreInsumo": new FormControl('', Validators.required),
          "cantidad": new FormControl('', Validators.required),
          "precio": new FormControl(Validators.required),
          "totalVentaInsumo": new FormControl(this.totalVentaInsumo,Validators.required)
        })
      ]),
      "observacion": new FormControl('',Validators.required),
      "fechaRegistro": new FormControl('',Validators.required,),
    })
  }


  crearVenta(){
    this.ventaInsumoService.registrarVentaInsumo(this.addVentaForm.value).subscribe(data=>{
      this.router.navigate(['/insumo/registrar-venta'])
      this.alertService.ShowSucess("Venta generada correctamente","Generar venta");
      this.limpiarFormulario()
    },err=>{
      this.alertService.ShowError("Ocurrio un error al generar la venta","Generar venta");
      console.log(err);
    })
  }

  listarPersona(){
    this.personaService.listarPersonasProductores().subscribe(data=>{
      this.listaPersona = data
    })
  }

  listarInsumo(){
    this.insumoService.listarInsumo().subscribe(data=>{
      this.listaInsumo = data
    })
  }
  ObtenerInsumo(idInsumo:string){
    if (idInsumo!=='') {
      this.insumoService.obtenerInsumo(idInsumo)
        .toPromise()
        .then(data =>{
          this.insumoEncontrado=data;
        })
        .catch(err =>{
          console.log(err);
        })
    }
  }

}
