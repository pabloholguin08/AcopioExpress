import { Component } from '@angular/core';
import { InsumoService } from 'src/app/Services/insumo.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-listar-inactivos-insumo',
  templateUrl: './listar-inactivos-insumo.component.html',
  styleUrls: ['./listar-inactivos-insumo.component.css']
})
export class ListarInactivosInsumoComponent {
  listaInsumo:any;


  constructor(private insumoService:InsumoService, private router:Router){}

  ngOnInit(): void {
    //Data para listar personas
    this.ListarInsumo()

  }


  ListarInsumo(){
    this.insumoService.listarInsumosInactivos().subscribe(data=>{
      this.listaInsumo = data
    })
  }
}
