import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { InsumoService } from 'src/app/Services/insumo.service';

@Component({
  selector: 'app-eliminar-insumo',
  templateUrl: './eliminar-insumo.component.html',
  styleUrls: ['./eliminar-insumo.component.css']
})
export class EliminarInsumoComponent {
  insumoId:string ="";
  constructor(private insumoService:InsumoService,
     private router: Router, 
     private activatedRoute: ActivatedRoute,
     private alertService:AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.insumoId = data['idInsumo']
    })
      console.log(this.insumoId);

    if (this.insumoId) {
      this.insumoService.eliminarInsumo(this.insumoId).subscribe(data => {
        this.router.navigate(['/insumo'])
        this.alertService.ShowSucess("Insumo eliminado correctamente","Eliminacion Insumo");
        

      },err => {
        console.log(err);
        
        this.alertService.ShowError("Error al eliminar insumo","Eliminacion Insumo")
   
      })

    }
  }
}
