import { Component } from '@angular/core';
import { UserManagerService } from './services/user-manager.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Controle de Procedimentos Criminais';

  constructor(private userManager: UserManagerService) {
    this.userManager.refreshUserByTime(null, true);
  }
}
