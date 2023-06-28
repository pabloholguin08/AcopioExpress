import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { VentaInsumoService } from 'src/app/Services/venta-insumo.service';


@Component({
  selector: 'app-eliminar-venta-insumo',
  templateUrl: './eliminar-venta-insumo.component.html',
  styleUrls: ['./eliminar-venta-insumo.component.css']
})
export class EliminarVentaInsumoComponent {
  ventaId:string ="";
  constructor(private ventaInsumoserv:VentaInsumoService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute,
    private alerService : AlertaService) { }

    ngOnInit(): void {
      this.activatedRoute.params.subscribe(data => {
        this.ventaId = data['idVentaInsumo']
      })
      console.log(this.ventaId);
      
      if (this.ventaId) {
        this.ventaInsumoserv.eliminarVentaInsumo(this.ventaId).subscribe(data => {
          this.router.navigate(['/insumo/historial'])
          this.alerService.ShowSucess("Venta Eliminada correctamente","Eliminar Venta");
  
        },err => {
          this.alerService.ShowError("Error al eliminar la Venta","Eliminar Venta");
  
          console.log(err);
        })
  
      }
    }
}
