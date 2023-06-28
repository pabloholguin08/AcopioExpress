
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn:'root'
})
export class InsumoService{
  ruta:string ='http://localhost:5233/api/Insumo/'
  constructor(private http:HttpClient) { }

  listarInsumo():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  obtenerInsumo(idInsumo:String):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idInsumo);
  }
  agregarInsumo(insumoOBJ:any):Observable<any>{
    return this.http.post(this.ruta + 'crear',insumoOBJ);
  }

  editarInsumo(insumoOBJ:any):Observable<any>{
    return this.http.put(this.ruta + 'editar',insumoOBJ);
  }

  eliminarInsumo(idInsumo:string):Observable<any>{
    return this.http.put(this.ruta + 'eliminar/'+idInsumo,'');
  }

  listarInsumosInactivos():Observable<any>{
    return this.http.get(this.ruta + 'listarEliminados');
  }

  recuperarInsumo(idInsumo:string):Observable<any>{
    return this.http.put(`${this.ruta}recuperar/${idInsumo}`,null);
  }
}
