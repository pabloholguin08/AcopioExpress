import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NominaService {
  ruta:string ='http://localhost:5233/api/Nomina/'
  constructor(private http:HttpClient) { }

  listarNomina():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  obtenerNomina(idNomina:String):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idNomina);
  }
  agregarNomina(nominaOBJ:any):Observable<any>{
    return this.http.post(this.ruta + 'crear',nominaOBJ);
  }

  editarNomina(nominaOBJ:any):Observable<any>{
    return this.http.put(this.ruta + 'editar',nominaOBJ);
  }

  eliminarNomina(idNomina:string):Observable<any>{
    return this.http.delete(`${this.ruta}eliminar/${idNomina}`);
  }
}
