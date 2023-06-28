import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { EgresosAcopioService } from 'src/app/Services/egresos-acopio.service';

@Component({
  selector: 'app-eliminar-egreso',
  templateUrl: './eliminar-egreso.component.html',
  styleUrls: ['./eliminar-egreso.component.css']
})
export class EliminarEgresoComponent {
  egresoId:string ="";
  constructor(private egresoService:EgresosAcopioService,
      private router: Router,
      private activatedRoute: ActivatedRoute,
      private alertaService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.egresoId = data['idEgresosAcopio']
    })
      console.log(this.egresoId);

    if (this.egresoId) {
      this.egresoService.eliminarEgresos(this.egresoId).subscribe(data => {
        this.router.navigate(['/home']);
        this.alertaService.ShowSucess("Egreso eliminado correctamente","Eliminar Egresos");
      },err => {
        this.alertaService.ShowError("Error al eliminar el egreso","Eliminar Egresos");

        console.log(err);
      })

    }
  }
}
