import { Injectable } from '@angular/core';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class VitimaMessageService extends MessageService {

  constructor() {
    super();
  }
}
