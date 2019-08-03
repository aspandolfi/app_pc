import { Injectable, OnDestroy } from '@angular/core';
import { BaseService } from './base.service';
import { Login } from '../models/login';
import { RegisterUsuario, Usuario } from '../models/usuario';
import { MessageService } from './message.service';
import { Message } from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends MessageService implements OnDestroy {

  private readonly uri: string = 'api/account';
  /* ms  * s  * min = 5 min */
  private readonly timeToRefresh: number = 1000 * 60;
  private intervalId: any;

  constructor(private baseService: BaseService) {
    super();
  }

  ngOnDestroy(): void {
    clearInterval(this.intervalId);
  }

  refreshUserByTime(user?: Usuario, refreshNow?: boolean) {

    // O método é chamado de locais diferentes, mas só é ativado uma vez
    if (!this.intervalId) {
      if (user) {
        this.send(new Message({ data: user, errors: null, message: '', success: true }));
      }

      if (refreshNow) {
        this.getCurrent().subscribe(res => {
          if (res) {
            this.send(new Message(res));
          }
        });
      }

      this.intervalId = setInterval(() => {
        this.getCurrent().subscribe(res => {
          if (res) {
            this.send(new Message(res));
          }
        })
      }, this.timeToRefresh);
    }
  }

  login(model: Login) {
    return this.baseService.post(`${this.uri}/login`, model);
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
