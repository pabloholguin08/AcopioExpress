import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { InsumoService } from 'src/app/Services/insumo.service';

@Component({
  selector: 'app-recuperar-insumo',
  templateUrl: './recuperar-insumo.component.html',
  styleUrls: ['./recuperar-insumo.component.css']
})
export class RecuperarInsumoComponent {
  insumoId:string="";
  constructor(private insumoService:InsumoService,private alertaService:AlertaService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.insumoId = data['idInsumo']
    })
    console.log(this.insumoId);

    if (this.insumoId) {
      this.insumoService.recuperarInsumo(this.insumoId).subscribe(data => {
        this.router.navigate(['/insumo'])
        this.alertaService.ShowSucess("Insumo recuperado exitosamente","Recuperar Insumo");

      },err => {
        this.alertaService.ShowError("Error al recuperar el Insumo","Recuperar Insumo");
        console.log(err);
 
      })

    }

  }
}
