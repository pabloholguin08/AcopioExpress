import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AcopioService } from 'src/app/Services/acopio.service';

@Component({
  selector: 'app-editar-acopio',
  templateUrl: './editar-acopio.component.html',
  styleUrls: ['./editar-acopio.component.css']
})
export class EditarAcopioComponent {
  editarAcopioForm: FormGroup = new FormGroup({});
  acopioId: string = '';
  AcopioDetalle: any;
  dataLoaded: boolean = false;

  constructor(private router: Router, private acopioService:AcopioService, private activatedRoute: ActivatedRoute
    , private formBuilder: FormBuilder) { }

    ngOnInit(): void {
      this.dataLoaded = false;

      this.activatedRoute.params.subscribe(data=>{
        this.acopioId=data['idAcopio']
      })

      if (this.acopioId !=='') {
        this.acopioService.obtenerAcopio(this.acopioId)
          .toPromise()
          .then(data =>{
            this.AcopioDetalle=data;


            //rellenar el formulario
            this.editarAcopioForm = this.formBuilder.group({
              "idAcopio": new FormControl(this.AcopioDetalle.idAcopio,[Validators.required]),
              "nombreAcopi": new FormControl(this.AcopioDetalle.nombreAcopi,[Validators.required]),
              "ubicacion": new FormControl(this.AcopioDetalle.ubicacion,Validators.required),
              "cantidadEmpleados": new FormControl(this.AcopioDetalle.cantidadEmpleados,Validators.required),
            })

            //cargamos la pagina para que pueda mostrar todos los datos correctamente
            this.dataLoaded= true;
          })
          .catch(err =>{
            console.log(err);

          })
      }
    }
    actualizarAcopio(){
      this.acopioService.editarAcopio(this.editarAcopioForm.value).subscribe(data =>{
        this.router.navigate(['/insumo'])
      },err =>{
        console.log(err);

      })
    }
}
