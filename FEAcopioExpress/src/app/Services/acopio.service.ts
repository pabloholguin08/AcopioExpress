
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn:'root'
})
export class AcopioService{
  ruta:string ='http://localhost:5233/api/Acopio/'
  constructor(private http:HttpClient) { }

  listarAcopios():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  obtenerAcopio(idAcopio:String):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idAcopio);
  }
  agregarAcopio(acopioOBJ:any):Observable<any>{
    return this.http.post(this.ruta + 'crear',acopioOBJ);
  }

  editarAcopio(acopioOBJ:any):Observable<any>{
    return this.http.put(this.ruta + 'editar',acopioOBJ);
  }

  eliminarAcopio(idAcopio:string):Observable<any>{
    return this.http.put(this.ruta + 'eliminar/'+idAcopio,'');
  }

  reporteContabilidad(fechaInicio:String, fechaFin:String):Observable<any>{
    return this.http.get(this.ruta+'reporte?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin)
  }
}
