import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AcopioService } from 'src/app/Services/acopio.service';

@Component({
  selector: 'app-eliminar-acopio',
  templateUrl: './eliminar-acopio.component.html',
  styleUrls: ['./eliminar-acopio.component.css']
})
export class EliminarAcopioComponent {
  acopioId:string ="";
  constructor(private acopioService:AcopioService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(data => {
      this.acopioId = data['idAcopio']
    })
      console.log(this.acopioId);

    if (this.acopioId) {
      this.acopioService.eliminarAcopio(this.acopioId).subscribe(data => {
        this.router.navigate(['/acopio'])

      },err => {
        console.log(err);
      })

    }
  }
}
