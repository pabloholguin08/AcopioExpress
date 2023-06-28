import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { PersonaService } from 'src/app/Services/persona.service';

@Component({
  selector: 'app-editar-persona',
  templateUrl: './editar-persona.component.html',
  styleUrls: ['./editar-persona.component.css']
})
export class EditarPersonaComponent {
  editarPersonaForm: FormGroup = new FormGroup({});
  personaId: string = '';
  PersonaDetalle: any;
  dataLoaded: boolean = false;

  constructor(private router: Router, 
    private personaService:PersonaService,
     private activatedRoute: ActivatedRoute,
     private formBuilder: FormBuilder,
    private alerService:AlertaService) { }

    ngOnInit(): void {
      this.dataLoaded = false;

      this.activatedRoute.params.subscribe(data=>{
        this.personaId=data['idPersona']
      })

      if (this.personaId !=='') {
        this.personaService.obtenerPersona(this.personaId)
          .toPromise()
          .then(data =>{
            this.PersonaDetalle=data;


            //rellenar el formulario
            this.editarPersonaForm = this.formBuilder.group({
              "idPersona": new FormControl(this.PersonaDetalle.idPersona,[Validators.required]),
              "cedula": new FormControl(this.PersonaDetalle.cedula,[Validators.required]),
              "nombres": new FormControl(this.PersonaDetalle.nombres,[Validators.required]),
              "apellidos": new FormControl(this.PersonaDetalle.apellidos,Validators.required),
              "telefono": new FormControl(this.PersonaDetalle.telefono,Validators.required),
              "direccion": new FormControl(this.PersonaDetalle.direccion,Validators.required),
              "idAcopio": new FormControl(this.PersonaDetalle.idAcopio,Validators.required),
              "idTipoProducto": new FormControl(this.PersonaDetalle.idTipoProducto,Validators.required),
              "idRol": new FormControl(this.PersonaDetalle.idRol,Validators.required),
            })

            //cargamos la pagina para que pueda mostrar todos los datos correctamente
            this.dataLoaded= true;
          })
          .catch(err =>{
            console.log(err);

          })
      }
    }
    actualizarPersona(){
      this.personaService.editarPersona(this.editarPersonaForm.value).subscribe(data =>{
        this.router.navigate(['/persona'])
        this.alerService.ShowSucess("Persona editada correctamente","Editar Persona");
      },err =>{
        this.alerService.ShowError("Error al editar la persona","Editar Persona");
        console.log(err);
      })
    }
}
