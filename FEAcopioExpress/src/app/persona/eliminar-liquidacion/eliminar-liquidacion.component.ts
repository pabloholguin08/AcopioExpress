import { Component } from '@angular/core';
import { LiquidacionService } from 'src/app/Services/liquidacion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';

@Component({
  selector: 'app-eliminar-liquidacion',
  templateUrl: './eliminar-liquidacion.component.html',
  styleUrls: ['./eliminar-liquidacion.component.css']
})
export class EliminarLiquidacionComponent {
  liquidacionId:string ="";
  constructor(private liquidacionService:LiquidacionService,
     private router: Router,
      private activatedRoute: ActivatedRoute,
      private  alerService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.liquidacionId = data['idLiquidacion']
    })
      console.log(this.liquidacionId);

    if (this.liquidacionId) {
      this.liquidacionService.eliminarLiquidacion(this.liquidacionId).subscribe(data => {
        this.router.navigate(['persona/liquidacion']);
        this.alerService.ShowSucess("Liquidacion eliminada correctamente","Eliminar Liquidacion");
      },err => {
        this.alerService.ShowSucess("Error al eliminar la liquidacion","Eliminar Liquidacion");

        console.log(err);
      })

    }
  }
}
