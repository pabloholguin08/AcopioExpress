import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LiquidacionService {

  ruta:string ='http://localhost:5233/api/LiquidacionProductor/'
  constructor(private http:HttpClient) { }

  listarLiquidaciones():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  agregarLiquidacion(idPersona:string,fechaInicio:String, fechaFin:String):Observable<any>{
    return this.http.post(this.ruta + 'registrar?id='+idPersona+'&fechaInicio='+fechaInicio+'&fechaFin='+fechaFin,'' );
  }
  eliminarLiquidacion(idLiquidacion:string):Observable<any>{
    return this.http.delete(`${this.ruta}eliminar/${idLiquidacion}`);
  }
  obtenerLiquidacion(idLiquidacion:string):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idLiquidacion);
  }
}
