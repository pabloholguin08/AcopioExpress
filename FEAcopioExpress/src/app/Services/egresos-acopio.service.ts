import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EgresosAcopioService {

  ruta:string ='http://localhost:5233/api/EgresosAcopio/'
  constructor(private http:HttpClient) { }

  listarEgresos():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  agregarEgresos(egresosOBJ:any,fechaInicio:string, fechaFin:string):Observable<any>{

    return this.http.post(this.ruta + 'registrar?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin, egresosOBJ);

    // return this.http.post(this.ruta + 'registrar',egresosOBJ+'?fechaInicio='+fechaInicio+"&fechaFin="+fechaFin);
  }
  eliminarEgresos(idEgresos:string):Observable<any>{
    return this.http.delete(this.ruta + 'eliminar/'+idEgresos);
  }
  obtenerEgresos(fechaInicio:string,fechaFin:string):Observable<any>{
    return  this.http.get(this.ruta+'listarFecha?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin);
  }
}
