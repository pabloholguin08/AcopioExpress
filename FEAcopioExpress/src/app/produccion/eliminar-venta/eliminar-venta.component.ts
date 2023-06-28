import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { VentaProduccionService } from 'src/app/Services/venta-produccion.service';
@Component({
  selector: 'app-eliminar-venta',
  templateUrl: './eliminar-venta.component.html',
  styleUrls: ['./eliminar-venta.component.css']
})
export class EliminarVentaComponent {
  produccionId:string ="";
  constructor(private ventaProduccionSer:VentaProduccionService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute,
    private alertService:AlertaService) { }
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.produccionId = data['idVentaProduccion']
    })
      console.log(this.produccionId);

    if (this.produccionId) {
      this.ventaProduccionSer.eliminarVentaProduccion(this.produccionId).subscribe(data => {
        this.router.navigate(['/produccion/listarVenta'])
        this.alertService.ShowSucess("Venta eliminada correctamente","Eliminar Venta");
        
      },err => {
        this.alertService.ShowError("Error al eliminar la venta","Eliminar Venta");
        
        console.log(err);
      })

    }
  }
}
