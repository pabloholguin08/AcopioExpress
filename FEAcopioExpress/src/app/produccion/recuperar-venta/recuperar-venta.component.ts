import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { VentaProduccionService } from 'src/app/Services/venta-produccion.service';

@Component({
  selector: 'app-recuperar-venta',
  templateUrl: './recuperar-venta.component.html',
  styleUrls: ['./recuperar-venta.component.css']
})
export class RecuperarVentaComponent {
  produccionId:string ="";
  constructor(private ventaProduccionSer:VentaProduccionService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute,
    private alerService:AlertaService) { }
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.produccionId = data['idVentaProduccion']
    })
      console.log(this.produccionId);

    if (this.produccionId) {
      this.ventaProduccionSer.recuperarVentaProduccion(this.produccionId).subscribe(data => {
        this.router.navigate(['/produccion/listarVenta']);
        this.alerService.ShowSucess("Venta recuperada exitosamente","Recuperar Venta");
      },err => {
        this.alerService.ShowError("Venta recuperada exitosamente","Recuperar Venta");
        console.log(err);
      })

    }
  }
  
}
