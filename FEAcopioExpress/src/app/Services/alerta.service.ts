import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AlertaService {

  constructor(private toastr:ToastrService) { }

  ShowSucess(mensaje:string, titulo:string){
    this.toastr.success(mensaje,titulo);
  }
  ShowError(mensaje:string, titulo:string){
    this.toastr.error(mensaje,titulo);
  }

  ShowWarning(mensaje:string, titulo:string){
    this.toastr.warning(mensaje,titulo);
  }
  ShowInfo(mensaje:string, titulo:string){
    this.toastr.info(mensaje,titulo);
  }
}
