
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  ruta:string ='http://localhost:5233/api/Persona/'
  constructor(private http:HttpClient) { }

  listarPersonas():Observable<any>{
    return this.http.get(this.ruta + 'listar');
  }
  obtenerPersona(idPersona:String):Observable<any>{
    return this.http.get(this.ruta + 'obtener/'+idPersona);
  }
  agregarPersona(personaOBJ:any):Observable<any>{
    return this.http.post(this.ruta + 'crear',personaOBJ);
  }

  editarPersona(personaOBJ:any):Observable<any>{
    return this.http.put(this.ruta + 'editar',personaOBJ);
  }

  eliminarPersona(idPersona:string):Observable<any>{
    return this.http.put(`${this.ruta}eliminar/${idPersona}`,null);
  }

  listarPersonasInactivas():Observable<any>{
    return this.http.get(this.ruta + 'listarEliminados');
  }

  recuperarPersona(idPersona:string):Observable<any>{
    return this.http.put(`${this.ruta}recuperar/${idPersona}`,null);
  }

  listarPersonasEmpleados():Observable<any>{
    return this.http.get(this.ruta + 'listarEmpleados');
  }

  listarPersonasProductores():Observable<any>{
    return this.http.get(this.ruta + 'listarProductores');
  }

}
