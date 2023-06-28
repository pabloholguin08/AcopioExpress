import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { ProduccionService } from 'src/app/Services/produccion.service';


@Component({
  selector: 'app-eliminar-produccion',
  templateUrl: './eliminar-produccion.component.html',
  styleUrls: ['./eliminar-produccion.component.css']
})
export class EliminarProduccionComponent {
  produccionId:string ="";
  constructor(private produccionService:ProduccionService,
     private router: Router, 
     private activatedRoute: ActivatedRoute,
     private alertService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.produccionId = data['idProduccion']
    })
      console.log(this.produccionId);

    if (this.produccionId) {
      this.produccionService.eliminarProduccion(this.produccionId).subscribe(data => {
        this.alertService.ShowSucess("Produccion eliminada correctamente","Eliminar Producción");
        this.router.navigate(['/produccion']);

      },err => {
        this.alertService.ShowError("Error al eliminar la produccion","Eliminar Producción");
        console.log(err);
      })

    }
  }
}
