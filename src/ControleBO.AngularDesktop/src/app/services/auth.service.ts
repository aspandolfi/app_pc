import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Login } from '../models/login';
import { RegisterUsuario, Usuario } from '../models/usuario';
import { Result } from '../models/result';

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

  refresh() {
    let headers = this.baseService.getHttpHeaders().set('ignoreLoadingBar', '');
    return this.baseService.http.post<Result<Login>>(`${this.baseService.apiUrl}/${this.uri}/refresh`, null, { headers: headers });
    //return this.baseService.post<Login>(`${this.uri}/refresh`, null);
  }

  logOut() {
    return this.baseService.post(`${this.uri}/logout`, null);
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
    let headers = this.baseService.getHttpHeaders().set('ignoreLoadingBar', '');
    return this.baseService.http.get<Result<Usuario>>(`${this.baseService.apiUrl}/${this.uri}/current`, { headers: headers });
  }

  getAll() {
    return this.baseService.get<Usuario[]>(this.uri);
  }
}
