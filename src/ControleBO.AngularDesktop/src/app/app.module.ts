import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppBootstrapModule } from './app-bootstrap.module';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { NgxSpinnerModule } from 'ngx-spinner';

import { TipoProcedimentoService } from './services/tipo-procedimento.service';
import { BaseService } from './services/base.service';
import { MessageService } from './services/message.service';
import { FileService } from './services/file.service';
import { ProcedimentoService } from './services/procedimento.service';

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
    CadastroProcedimentoSituacaoComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    AppBootstrapModule,
    BrowserAnimationsModule,
    FormsModule,
    NgxMaskModule.forRoot(),
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-bottom-right',
      progressBar: true
    })
  ],
  entryComponents: [
    CadastroTipoProcedimentoComponent,
    ConfirmarExclusaoComponent,
    CadastroArtigoComponent,
    CadastroMunicipioComponent
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    BaseService,
    TipoProcedimentoService,
    MessageService,
    FileService,
    ProcedimentoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base').item(0).href;
}
