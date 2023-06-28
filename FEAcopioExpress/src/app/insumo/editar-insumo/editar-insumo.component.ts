import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';

import { InsumoService } from 'src/app/Services/insumo.service';

@Component({
  selector: 'app-editar-insumo',
  templateUrl: './editar-insumo.component.html',
  styleUrls: ['./editar-insumo.component.css']
})
export class EditarInsumoComponent {
  editarInsumoForm: FormGroup = new FormGroup({});
  insumoId: string = '';
  InsumoDetalle: any;
  dataLoaded: boolean = false;

  constructor(private router: Router, private insumoService:InsumoService, private activatedRoute: ActivatedRoute
    , private formBuilder: FormBuilder, private alertService:AlertaService) { }

    ngOnInit(): void {
      this.dataLoaded = false;

      this.activatedRoute.params.subscribe(data=>{
        this.insumoId=data['idInsumo']
      })

      if (this.insumoId !=='') {
        this.insumoService.obtenerInsumo(this.insumoId)
          .toPromise()
          .then(data =>{
            this.InsumoDetalle=data;


            //rellenar el formulario
            this.editarInsumoForm = this.formBuilder.group({
              "idInsumo": new FormControl(this.InsumoDetalle.idInsumo,[Validators.required]),
              "nombreInsumo": new FormControl(this.InsumoDetalle.nombreInsumo,[Validators.required]),
              "descripcion": new FormControl(this.InsumoDetalle.descripcion,Validators.required),
              "valorUnitarioVenta": new FormControl(this.InsumoDetalle.valorUnitarioVenta,Validators.required),
              "stock": new FormControl(this.InsumoDetalle.stock,Validators.required),
              "valorUnitarioCompra": new FormControl(this.InsumoDetalle.valorUnitarioCompra,Validators.required),
            })

            //cargamos la pagina para que pueda mostrar todos los datos correctamente
            this.dataLoaded= true;
          })
          .catch(err =>{
            console.log(err);

          })
      }
    }
    actualizarInsumo(){
      this.insumoService.editarInsumo(this.editarInsumoForm.value).subscribe(data =>{
        this.router.navigate(['/insumo']);
        this.alertService.ShowSucess('Insumo editado correctamente ','Insumo editado');
      },err =>{
        console.log(err);
        this.alertService.ShowError('Ocurrio un error editando el insumo','Insumo editado');
      })
    }



}
