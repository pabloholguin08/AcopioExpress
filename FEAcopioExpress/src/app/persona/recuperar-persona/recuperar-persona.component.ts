import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { PersonaService } from 'src/app/Services/persona.service';

@Component({
  selector: 'app-recuperar-persona',
  templateUrl: './recuperar-persona.component.html',
  styleUrls: ['./recuperar-persona.component.css']
})
export class RecuperarPersonaComponent {
  personaId:string="";
  constructor(private personaService:PersonaService,
     private router: Router,
      private activatedRoute: ActivatedRoute,
      private alerService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.personaId = data['idPersona']
    })
    console.log(this.personaId);

    if (this.personaId) {
      this.personaService.recuperarPersona(this.personaId).subscribe(data => {
        this.router.navigate(['/persona']);
        this.alerService.ShowSucess("Persona recuperada correctamente","Recuperar Persona");

      },err => {
        this.alerService.ShowError("Error al recuperar la persona","Recuperar Persona");

        console.log(err);
      })

    }

  }
}
