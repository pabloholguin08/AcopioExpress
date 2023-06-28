import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PersonaService } from 'src/app/Services/persona.service';


@Component({
  selector: 'app-listar-inactivos-persona',
  templateUrl: './listar-inactivos-persona.component.html',
  styleUrls: ['./listar-inactivos-persona.component.css']
})
export class ListarInactivosPersonaComponent {
  listaPersona:any;


  constructor(private personaService:PersonaService, private router:Router){}

  ngOnInit(): void {
    //Data para listar personas
    this.ListarPersona()

  }


  ListarPersona(){
    this.personaService.listarPersonasInactivas().subscribe(data=>{
      this.listaPersona = data
    })
  }
}
