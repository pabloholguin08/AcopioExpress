import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProduccionService } from 'src/app/Services/produccion.service';
import { PersonaService } from 'src/app/Services/persona.service';
import { AlertaService } from 'src/app/Services/alerta.service';

@Component({
  selector: 'app-editar-produccion',
  templateUrl: './editar-produccion.component.html',
  styleUrls: ['./editar-produccion.component.css']
})
export class EditarProduccionComponent {
  editarProduccionForm: FormGroup = new FormGroup({});
  produccionId: string = '';
  ProduccionDetalle: any;
  dataLoaded: boolean = false;
  listaPersona:any

  constructor(private produccionService:ProduccionService,
     private personaService:PersonaService,
      private formBuilder:FormBuilder, 
      private router:Router, 
      private activatedRoute: ActivatedRoute,
      private alerService:AlertaService) { }

    ngOnInit(): void {
      this.dataLoaded = false;
      this.listarPersona()

      this.activatedRoute.params.subscribe(data=>{
        this.produccionId=data['idProduccion']
      })

      if (this.produccionId !=='') {
        this.produccionService.obtenerProduccion(this.produccionId)
          .toPromise()
          .then(data =>{
            this.ProduccionDetalle=data;


            //rellenar el formulario
            this.editarProduccionForm = this.formBuilder.group({
              "idProduccion": new FormControl(this.ProduccionDetalle.idProduccion,[Validators.required]),
              "diaIngresoProducto": new FormControl(this.ProduccionDetalle.diaIngresoProducto,[Validators.required]),
              "cantidad": new FormControl(this.ProduccionDetalle.cantidad,Validators.required),
              "precioProducto": new FormControl(this.ProduccionDetalle.precioProducto,Validators.required),
              "observaciones": new FormControl(this.ProduccionDetalle.observaciones,Validators.required),
              "idPersona": new FormControl(this.ProduccionDetalle.idPersona,Validators.required),
              "nombres": new FormControl(this.ProduccionDetalle.nombres,Validators.required),
              "apellidos": new FormControl(this.ProduccionDetalle.apellidos,Validators.required),

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
      this.produccionService.editarProduccion(this.editarProduccionForm.value).subscribe(data =>{
        this.router.navigate(['/produccion']);
        this.alerService.ShowSucess("Producción editada correctamente","Editar Produccion");
      },err =>{
        this.alerService.ShowError("Error al editar producción","Editar Produccion");

        console.log(err);

      })
    }

    listarPersona(){
      this.personaService.listarPersonas().subscribe(data=>{
        this.listaPersona = data
      })
    }
}
