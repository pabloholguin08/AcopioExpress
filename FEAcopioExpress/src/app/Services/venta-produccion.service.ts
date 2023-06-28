import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VentaProduccionService {

  ruta:string ='http://localhost:5233/api/VentaProduccion/'
  constructor(private http:HttpClient) { }

  listarVentaProduccion():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  obtenerVentaProduccion(idVentaProduccion:String):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idVentaProduccion);
  }
  agregarVentaProduccion(ventaProduccionOBJ:any):Observable<any>{
    return this.http.post(this.ruta + 'crear',ventaProduccionOBJ);
  }

  editarVentaProduccion(ventaProduccionOBJ:any):Observable<any>{
    return this.http.put(this.ruta + 'editar',ventaProduccionOBJ);
  }

  eliminarVentaProduccion(idVentaProduccion:string):Observable<any>{
    return this.http.put(this.ruta + 'eliminar/'+idVentaProduccion,'');
  }
  listarVentaProduccionEliminados():Observable<any>{
    return this.http.get(this.ruta + 'listarEliminados');
  }
  recuperarVentaProduccion(idVentaProduccion:string):Observable<any>{
    return this.http.put(this.ruta + 'recuperar/'+idVentaProduccion,'');
  }
  listarPorFecha(fechaInicio:String, fechaFin:String):Observable<any>{
    return this.http.get(this.ruta + 'listarFecha/'+fechaInicio+fechaFin);
  }
}
