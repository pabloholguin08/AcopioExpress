import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertaService } from 'src/app/Services/alerta.service';
import { NominaService } from 'src/app/Services/nomina.service';


@Component({
  selector: 'app-eliminar-nomina',
  templateUrl: './eliminar-nomina.component.html',
  styleUrls: ['./eliminar-nomina.component.css']
})
export class EliminarNominaComponent {
  nominaId:string ="";
  constructor(private nominaService:NominaService, 
    private router: Router, 
    private activatedRoute: ActivatedRoute,
    private alerService : AlertaService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.nominaId = data['idNomina']
    })
      console.log(this.nominaId);

    if (this.nominaId) {
      this.nominaService.eliminarNomina(this.nominaId).subscribe(data => {
        this.router.navigate(['/nomina'])
        this.alerService.ShowSucess("Nomina Eliminada correctamente","Eliminar nomina");

      },err => {
        this.alerService.ShowError("Error al eliminar la nomina","Eliminar nomina");

        console.log(err);
      })

    }
  }
}
