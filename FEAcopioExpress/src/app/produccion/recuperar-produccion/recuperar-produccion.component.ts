import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ProduccionService } from 'src/app/Services/produccion.service';

@Component({
  selector: 'app-recuperar-produccion',
  templateUrl: './recuperar-produccion.component.html',
  styleUrls: ['./recuperar-produccion.component.css']
})
export class RecuperarProduccionComponent {
  produccionId:string="";
  constructor(private produccionService:ProduccionService,
     private router: Router, 
     private activatedRoute: ActivatedRoute,
     private alerService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.produccionId = data['idProduccion']
    })
    console.log(this.produccionId);

    if (this.produccionId) {
      this.produccionService.recuperarProduccion(this.produccionId).subscribe(data => {
        this.router.navigate(['/produccion']);
        this.alerService.ShowSucess("Produccion recuperada exitosamente","Recuperar Produccion");

      },err => {
        this.alerService.ShowError("Error al recuperar la produccion","Recuperar Produccion");

        console.log(err);
      })

    }

  }
}
