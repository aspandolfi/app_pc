import { Component, OnInit, AfterViewInit, ViewChild, Input, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { IMessage } from 'src/app/models/message';
import { Router, ActivatedRoute } from '@angular/router';
import { TabsMessageService } from 'src/app/services/tabs-message.service';

@Component({
  selector: 'app-tabs-cadastro-procedimento',
  templateUrl: './tabs-cadastro-procedimento.component.html',
  styleUrls: ['./tabs-cadastro-procedimento.component.css']
})
export class TabsCadastroProcedimentoComponent implements OnInit, AfterViewInit, OnDestroy {

  private subscription: Subscription;
  private isTabEnable: boolean;

  private procedimentoId: any;

  private isActiveControle: boolean = true;
  private isActiveVitimas: boolean = false;
  private isActiveSituacao: boolean = false;
  private isActiveObjetos: boolean = false;

  constructor(private tabsMessageService: TabsMessageService, private route: ActivatedRoute, private router: Router) {
    this.onReceiveMessage();
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.procedimentoId = params.get('id');
      this.enableTabs(this.procedimentoId);
    });
  }

  ngAfterViewInit(): void {
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  private onReceiveMessage() {
    this.subscription = this.tabsMessageService.messageListener$.subscribe(
      message => this.postReceiveMessage(message)
    );
  }

  private postReceiveMessage(message: IMessage) {
    this.enableTabs(message.data);
    this.updateRoute(); // updates the current route
  }

  private updateRoute() {
    this.clearRoute();
    this.router.navigateByUrl('/cadastro-procedimento/' + this.procedimentoId);
  }

  private navigateToControle() {
    this.isActiveControle = true;
    this.isActiveObjetos = false;
    this.isActiveSituacao = false;
    this.isActiveVitimas = false;

    if (this.procedimentoId) {
      this.clearRoute();
      this.router.navigate(['cadastro-procedimento', this.procedimentoId, { outlets: { procedimento: ['controle'] } }]);
    }
  }

  private navigateToVitimasAutores() {
    this.isActiveControle = false;
    this.isActiveObjetos = false;
    this.isActiveSituacao = false;
    this.isActiveVitimas = true;
    this.clearRoute();
    this.router.navigate(['cadastro-procedimento', this.procedimentoId, { outlets: { procedimento: ['vitimas-autores'] } }]);
  }

  private navigateToSituacoes() {
    this.isActiveControle = false;
    this.isActiveObjetos = false;
    this.isActiveSituacao = true;
    this.isActiveVitimas = false;
    this.clearRoute();
    this.router.navigate(['cadastro-procedimento', this.procedimentoId, { outlets: { procedimento: ['situacoes'] } }]);
  }

  private navigateToObjetos() {
    this.isActiveControle = false;
    this.isActiveObjetos = true;
    this.isActiveSituacao = false;
    this.isActiveVitimas = false;
    this.clearRoute();
    this.router.navigate(['cadastro-procedimento', this.procedimentoId, { outlets: { procedimento: ['objetos'] } }]);
  }

  private clearRoute() {
    this.router.navigate(['cadastro-procedimento', { outlets: { procedimento: null } }]);
  }

  private enableTabs(procedimentoId: any) {
    if (!Number.isNaN(procedimentoId)) {
      let id = Number.parseInt(procedimentoId);
      if (id > 0) {
        this.procedimentoId = id;
        this.isTabEnable = !this.isTabEnable;
      }
    }
  }

}
