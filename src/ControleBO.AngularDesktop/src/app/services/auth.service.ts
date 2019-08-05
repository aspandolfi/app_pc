import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Login } from '../models/login';
import { RegisterUsuario, Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly uri: string = 'api/account';

  constructor(private baseService: BaseService) {
  }

  login(model: Login) {
    return this.baseService.post(`${this.uri}/login`, model);
  }

  logOut() {
    localStorage.removeItem('access_token');
  }

  create(model: RegisterUsuario) {
    return this.baseService.post(this.uri, model);
  }

  update(model: RegisterUsuario) {
    return this.baseService.put(`${this.uri}/${model.id}`, model);
  }

  getByEmail(email: string) {
    return this.baseService.get<Usuario>(`${this.uri}/getbyemail/${email}`);
  }

  getById(id: string) {
    return this.baseService.get<Usuario>(`${this.uri}/${id}`);
  }

  getCurrent() {
    return this.baseService.get<Usuario>(`${this.uri}/current`);
  }

  getAll() {
    return this.baseService.get<Usuario[]>(this.uri);
  }
}
