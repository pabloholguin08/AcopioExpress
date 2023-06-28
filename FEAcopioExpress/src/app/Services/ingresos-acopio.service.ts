import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IngresosAcopioService {

  ruta:string ='http://localhost:5233/api/IngresosAcopio/'
  constructor(private http:HttpClient) { }

  listarIngresos():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  agregarIngresos(fechaInicio:string,fechaFin:string):Observable<any>{
    return this.http.post(this.ruta + 'registrar?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin,'');
  }
  eliminarIngresos(idIngresos:string):Observable<any>{
    return this.http.delete(this.ruta + 'eliminar/'+idIngresos);
  }
  obtenerIngresos(fechaInicio:string,fechaFin:string):Observable<any>{
    return  this.http.get(this.ruta + 'listarFecha?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin);
  }
}
