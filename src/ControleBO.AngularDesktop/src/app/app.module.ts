import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppBootstrapModule } from './app-bootstrap.module';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { NgSelectModule } from '@ng-select/ng-select';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';

import { TipoProcedimentoService } from './services/tipo-procedimento.service';
import { BaseService } from './services/base.service';
import { MessageService } from './services/message.service';
import { FileService } from './services/file.service';
import { ProcedimentoService } from './services/procedimento.service';
import { AuthGuardService } from './guards/auth-guard.service';

import { AppComponent } from './app.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TipoProcedimentoComponent } from './components/tipo-procedimento/tipo-procedimento.component';
import { CadastroTipoProcedimentoComponent } from './components/cadastro-tipo-procedimento/cadastro-tipo-procedimento.component';
import { ConfirmarExclusaoComponent } from './components/confirmar-exclusao/confirmar-exclusao.component';
import { ArtigoComponent } from './components/artigo/artigo.component';
import { CadastroArtigoComponent } from './components/cadastro-artigo/cadastro-artigo.component';
import { MunicipioComponent } from './components/municipio/municipio.component';
import { CadastroMunicipioComponent } from './components/cadastro-municipio/cadastro-municipio.component';
import { ProcedimentoComponent } from './components/procedimento/procedimento.component';
import { GrdFilterPipe } from './pipes/grd-filter.pipe';
import { CadastroProcedimentoComponent } from './components/cadastro-procedimento/cadastro-procedimento.component';
import { TabsCadastroProcedimentoComponent } from './components/tabs-cadastro-procedimento/tabs-cadastro-procedimento.component';
import { CadastroProcedimentoControleComponent } from './components/cadastro-procedimento-controle/cadastro-procedimento-controle.component';
import { CadastroProcedimentoVitimasAutoresComponent } from './components/cadastro-procedimento-vitimas-autores/cadastro-procedimento-vitimas-autores.component';
import { CadastroProcedimentoSituacaoComponent } from './components/cadastro-procedimento-situacao/cadastro-procedimento-situacao.component';
import { UltimaMovimentacaoComponent } from './components/ultima-movimentacao/ultima-movimentacao.component';
import { MunicipioService } from './services/municipio.service';
import { CadastroVitimaComponent } from './components/cadastro-vitima/cadastro-vitima.component';
import { CadastroIndiciadoComponent } from './components/cadastro-indiciado/cadastro-indiciado.component';
import { CadastroProcedimentoObjetosApreendidosComponent } from './components/cadastro-procedimento-objetos-apreendidos/cadastro-procedimento-objetos-apreendidos.component';
import { CadastroMovimentacaoComponent } from './components/cadastro-movimentacao/cadastro-movimentacao.component';
import { EstatisticaAssuntoComponent } from './relatorios/estatistica-assunto/estatistica-assunto.component';
import { SidemenuComponent } from './components/sidemenu/sidemenu.component';
import { LoginComponent } from './components/login/login.component';
import { UserRegisterComponent } from './components/user-register/user-register.component';
import { UserListComponent } from './components/user-list/user-list.component';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { AssuntoComponent } from './components/assunto/assunto.component';
import { CadastroAssuntoComponent } from './components/cadastro-assunto/cadastro-assunto.component';
import { VaraCriminalComponent } from './components/vara-criminal/vara-criminal.component';
import { CadastroVaraCriminalComponent } from './components/cadastro-vara-criminal/cadastro-vara-criminal.component';
import { UnidadePolicialComponent } from './components/unidade-policial/unidade-policial.component';
import { CadastroUnidadePolicialComponent } from './components/cadastro-unidade-policial/cadastro-unidade-policial.component';

defineLocale('pt-br', ptBrLocale);

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    TipoProcedimentoComponent,
    CadastroTipoProcedimentoComponent,
    ConfirmarExclusaoComponent,
    ArtigoComponent,
    CadastroArtigoComponent,
    MunicipioComponent,
    CadastroMunicipioComponent,
    ProcedimentoComponent,
    GrdFilterPipe,
    CadastroProcedimentoComponent,
    TabsCadastroProcedimentoComponent,
    CadastroProcedimentoControleComponent,
    CadastroProcedimentoVitimasAutoresComponent,
    CadastroProcedimentoSituacaoComponent,
    UltimaMovimentacaoComponent,
    CadastroVitimaComponent,
    CadastroIndiciadoComponent,
    CadastroProcedimentoObjetosApreendidosComponent,
    CadastroMovimentacaoComponent,
    EstatisticaAssuntoComponent,
    SidemenuComponent,
    LoginComponent,
    UserRegisterComponent,
    UserListComponent,
    AssuntoComponent,
    CadastroAssuntoComponent,
    VaraCriminalComponent,
    CadastroVaraCriminalComponent,
    UnidadePolicialComponent,
    CadastroUnidadePolicialComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    AppBootstrapModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxMaskModule.forRoot(),
    NgSelectModule,
    LoadingBarHttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      progressBar: true,
      easeTime: 600
    })
  ],
  entryComponents: [
    CadastroTipoProcedimentoComponent,
    ConfirmarExclusaoComponent,
    CadastroArtigoComponent,
    CadastroMunicipioComponent,
    CadastroVitimaComponent,
    CadastroIndiciadoComponent,
    CadastroMovimentacaoComponent,
    LoginComponent,
    UserRegisterComponent,
    CadastroAssuntoComponent,
    CadastroVaraCriminalComponent,
    CadastroMunicipioComponent,
    CadastroUnidadePolicialComponent
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    BaseService,
    TipoProcedimentoService,
    MessageService,
    FileService,
    ProcedimentoService,
    MunicipioService,
    AuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base').item(0).href;
}
