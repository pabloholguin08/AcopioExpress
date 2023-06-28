import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VentaInsumoService {

  ruta:string ='http://localhost:5233/api/VentaInsumo/'
  constructor(private http:HttpClient) { }

  registrarVentaInsumo(ventaOBJ:string):Observable<any>{
    return this.http.post(this.ruta + 'registrar',ventaOBJ);
  }
  historialVentaInsumo(fechaInicio:Date, fechaFin:Date):Observable<any>{
    return this.http.get(this.ruta + 'historial?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin);
  }
  reporteVentaInsumo(fechaInicio:String, fechaFin:String):Observable<any>{
    return this.http.get(this.ruta + 'reporte?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin);
  }
 
  eliminarVentaInsumo(idVentaInsumo:string):Observable<any>{
    return this.http.delete(`${this.ruta}eliminar/${idVentaInsumo}`);
  }

}
