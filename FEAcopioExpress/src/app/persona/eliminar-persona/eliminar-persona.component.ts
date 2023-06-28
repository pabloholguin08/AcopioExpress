import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { PersonaService } from 'src/app/Services/persona.service';

@Component({
  selector: 'app-eliminar-persona',
  templateUrl: './eliminar-persona.component.html',
  styleUrls: ['./eliminar-persona.component.css']
})
export class EliminarPersonaComponent {
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
      this.personaService.eliminarPersona(this.personaId).subscribe(data => {
        this.router.navigate(['/persona'])
        this.alerService.ShowSucess("Persona eliminada correctamente","Eliminar Persona");

      },err => {
        this.alerService.ShowError("Error al eliminar la persona","Eliminar Persona");

        console.log(err);
      })

    }

  }
}
