import { Component } from '@angular/core';
import { AcopioService } from 'src/app/Services/acopio.service';

@Component({
  selector: 'app-listar-acopio',
  templateUrl: './listar-acopio.component.html',
  styleUrls: ['./listar-acopio.component.css']
})
export class ListarAcopioComponent {
  listaAcopio:any

  constructor(private acopioService:AcopioService){}

  ngOnInit(): void {
    this.acopioService.listarAcopios().subscribe(data=>{
      this.listaAcopio = data
    })

  }
}
