import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppBootstrapModule } from './app-bootstrap.module';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { TipoProcedimentoService } from './services/tipo-procedimento.service';
import { BaseService } from './services/base.service';
import { MessageService } from './services/message.service';

import { AppComponent } from './app.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TipoProcedimentoComponent } from './components/tipo-procedimento/tipo-procedimento.component';
import { CadastroTipoProcedimentoComponent } from './components/cadastro-tipo-procedimento/cadastro-tipo-procedimento.component';
import { ConfirmarExclusaoComponent } from './components/confirmar-exclusao/confirmar-exclusao.component';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    TipoProcedimentoComponent,
    CadastroTipoProcedimentoComponent,
    ConfirmarExclusaoComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    AppBootstrapModule,
    BrowserAnimationsModule,
    FormsModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-bottom-right',
      progressBar: true
    })
  ],
  entryComponents: [
    CadastroTipoProcedimentoComponent,
    ConfirmarExclusaoComponent
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    BaseService,
    TipoProcedimentoService,
    MessageService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base').item(0).href;
}
