import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProduccionService {

  ruta:string ='http://localhost:5233/api/Produccion/'
  constructor(private http:HttpClient) { }

  listarProduccion():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  obtenerProduccion(idProduccion:String):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idProduccion);
  }
  agregarProduccion(produccionOBJ:any):Observable<any>{
    return this.http.post(this.ruta + 'crear',produccionOBJ);
  }

  editarProduccion(produccionOBJ:any):Observable<any>{
    return this.http.put(this.ruta + 'editar',produccionOBJ);
  }

  eliminarProduccion(idProduccion:string):Observable<any>{
    return this.http.put(this.ruta + 'eliminar/'+idProduccion,'');
  }

  listarProduccionInactivas():Observable<any>{
    return this.http.get(this.ruta + 'listarEliminados');
  }


  recuperarProduccion(idProduccion:string):Observable<any>{
    return this.http.put(this.ruta + 'recuperar/'+idProduccion,'');
  }

  fechasProduccion(fechaInicio:string,fechaFin:string):Observable<any>{
    return this.http.get(this.ruta+'listarFecha?fechaInicio='+fechaInicio+'&fechaFin='+fechaFin);
  }


}
