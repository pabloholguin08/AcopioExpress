import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { VentaProduccionService } from 'src/app/Services/venta-produccion.service';

@Component({
  selector: 'app-editar-venta',
  templateUrl: './editar-venta.component.html',
  styleUrls: ['./editar-venta.component.css']
})
export class EditarVentaComponent {
  ventaProduccionId: string = '';
  ProduccionDetalle: any;
  dataLoaded: boolean = false;
  listaPersona:any
  editarVentaProduccionForm:FormGroup= new FormGroup({});

  constructor(private ventaProduccionServ:VentaProduccionService, 
    private formBuilder:FormBuilder, 
    private router:Router , 
    private activatedRoute: ActivatedRoute,
    private alertService:AlertaService){}

  ngOnInit(): void {
    this.dataLoaded = false;
    this.listarPersona()

    this.activatedRoute.params.subscribe(data=>{
      this.ventaProduccionId=data['idVentaProduccion']
    })

    if (this.ventaProduccionId !=='') {
      this.ventaProduccionServ.obtenerVentaProduccion(this.ventaProduccionId)
        .toPromise()
        .then(data =>{
          this.ProduccionDetalle=data;


          //rellenar el formulario
          this.editarVentaProduccionForm = this.formBuilder.group({
            "idVentaProduccion": new FormControl(this.ProduccionDetalle.idVentaProduccion,[Validators.required]),
            "idAcopio": new FormControl(this.ProduccionDetalle.idAcopio,[Validators.required]),
            "nombreAcopi": new FormControl(this.ProduccionDetalle.nombreAcopi,Validators.required),
            "fechaVenta": new FormControl( this.ProduccionDetalle.fechaVenta,Validators.required),
            "cantidad": new FormControl(this.ProduccionDetalle.cantidad,Validators.required),
            "precio": new FormControl(this.ProduccionDetalle.precio,Validators.required),
            "totalVentaProduccion": new FormControl(this.ProduccionDetalle.totalVentaProduccion,Validators.required),
            "observaciones": new FormControl(this.ProduccionDetalle.observaciones,Validators.required),

          })

          //cargamos la pagina para que pueda mostrar todos los datos correctamente
          this.dataLoaded= true;
        })
        .catch(err =>{
          console.log(err);

        })
    }
  }
  actualizarProduccion(){
    this.ventaProduccionServ.editarVentaProduccion(this.editarVentaProduccionForm.value).subscribe(data =>{
      this.router.navigate(['/produccion/listarVenta']);
      this.alertService.ShowSucess("Venta editada correctamente","Editar Venta");
    },err =>{
      this.alertService.ShowError("Error al editar la venta","Editar Venta");

      console.log(err);

    })
  }

  listarPersona(){
    this.ventaProduccionServ.listarVentaProduccion().subscribe(data=>{
      this.listaPersona = data
    })
  }
}
