import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { IMessage } from '../models/message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private messageSource = new Subject<IMessage>();

  messageListener$ = this.messageSource.asObservable();

  send(message: IMessage) {
    this.messageSource.next(message);
  }

  constructor() { }
}
