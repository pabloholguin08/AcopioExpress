import { inject } from '@angular/core';
import { CanActivateFn, CanMatchFn } from '@angular/router';
import { LoginService } from '../Services/login.service';


export const authGuard: CanMatchFn = (route, state) => {
  const authService = inject(LoginService)
  let usuario = authService.obtenerUsuario()
  let password = authService.obtenerContrasena()
  let estado = authService.obtenerEstado()

  return authService.getToken(estado)
};
