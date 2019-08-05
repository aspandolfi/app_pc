import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';
import { UserManagerService } from '../../services/user-manager.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  get username(): string {
    return this.userManager.name;
  }

  constructor(private userManager: UserManagerService) { }

  ngOnInit() {
  }

  doLogOut() {
    this.userManager.logOut();
  }

}
