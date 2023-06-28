import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AcopioService } from 'src/app/Services/acopio.service';

@Component({
  selector: 'app-crear-acopio',
  templateUrl: './crear-acopio.component.html',
  styleUrls: ['./crear-acopio.component.css']
})
export class CrearAcopioComponent {
  addAcopioForm:FormGroup= new FormGroup({});
  constructor(private acopioService:AcopioService,private formBuilder:FormBuilder, private router:Router){}

  ngOnInit(): void {
    this.addAcopioForm = this.formBuilder.group({
      "nombreAcopi": new FormControl('',[Validators.required]),
      "ubicacion": new FormControl('',Validators.required),
      "cantidadEmpleados": new FormControl('',Validators.required),
    })
  }

  crearAcopio(){
    this.acopioService.agregarAcopio(this.addAcopioForm.value).subscribe(data=>{
      this.router.navigate(['/acopio/listar'])

    },err=>{
      console.log(err);
    })
  }

}
