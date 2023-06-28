import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { NominaService } from 'src/app/Services/nomina.service';
import { PersonaService } from 'src/app/Services/persona.service';

@Component({
  selector: 'app-editar-nomina',
  templateUrl: './editar-nomina.component.html',
  styleUrls: ['./editar-nomina.component.css']
})
export class EditarNominaComponent {
  editarNominaForm: FormGroup = new FormGroup({});
  nominaId: string = '';
  NominaDetalle: any;
  dataLoaded: boolean = false;
  listaPersonas:any

  constructor(private router: Router,
     private nominaService:NominaService,
     private activatedRoute: ActivatedRoute,
     private formBuilder: FormBuilder, 
     private personaService:PersonaService,
     private alertService:AlertaService) { }

    ngOnInit(): void {
      this.dataLoaded = false;

      this.ListarPersonas()

      this.activatedRoute.params.subscribe(data=>{
        this.nominaId=data['idNomina']
      })

      if (this.nominaId !=='') {
        this.nominaService.obtenerNomina(this.nominaId)
          .toPromise()
          .then(data =>{
            this.NominaDetalle=data;


            //rellenar el formulario
            this.editarNominaForm = this.formBuilder.group({
              "idNomina": new FormControl(this.NominaDetalle.idNomina,[Validators.required]),
              "idPersona": new FormControl(this.NominaDetalle.idPersona,[Validators.required]),
              "fechaPago": new FormControl(this.NominaDetalle.fechaPago,[Validators.required]),
              "salario": new FormControl(this.NominaDetalle.salario,Validators.required),
            })

            //cargamos la pagina para que pueda mostrar todos los datos correctamente
            this.dataLoaded= true;
          })
          .catch(err =>{
            console.log(err);
          })
      }
    }

    ListarPersonas(){
      this.personaService.listarPersonasEmpleados().subscribe(data=>{
        this.listaPersonas = data
      })
    }

    actualizarNomina(){
      this.nominaService.editarNomina(this.editarNominaForm.value).subscribe(data =>{
        this.router.navigate(['/nomina'])
        this.alertService.ShowSucess("Nomina editada correctamente","Editar nomina")
      },err =>{
        console.log(err);
        this.alertService.ShowError("Error al editar la nomina","Editar nomina")

      })
    }
}
