import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { IngresosAcopioService } from 'src/app/Services/ingresos-acopio.service';

@Component({
  selector: 'app-eliminar-ingreso',
  templateUrl: './eliminar-ingreso.component.html',
  styleUrls: ['./eliminar-ingreso.component.css']
})
export class EliminarIngresoComponent {
  ingresoId:string ="";
  constructor(private ingresoService:IngresosAcopioService, 
      private router: Router,
     private activatedRoute: ActivatedRoute,
     private alertService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.ingresoId = data['idIngresosAcopio']
    })
      console.log(this.ingresoId);

    if (this.ingresoId) {
      this.ingresoService.eliminarIngresos(this.ingresoId).subscribe(data => {
        this.router.navigate(['/home']);
        this.alertService.ShowSucess("Ingreso eliminado correctamente","Eliminar Ingreso");
      },err => {
        this.alertService.ShowError("Error al eliminar Ingreso","Eliminar Ingreso");
        console.log(err);
      })
    }
  }
}
