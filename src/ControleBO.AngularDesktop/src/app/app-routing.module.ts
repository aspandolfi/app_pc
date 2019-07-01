import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TipoProcedimentoComponent } from './components/tipo-procedimento/tipo-procedimento.component';
import { ArtigoComponent } from './components/artigo/artigo.component';
import { MunicipioComponent } from './components/municipio/municipio.component';
import { ProcedimentoComponent } from './components/procedimento/procedimento.component';
import { CadastroProcedimentoComponent } from './components/cadastro-procedimento/cadastro-procedimento.component';
import { CadastroProcedimentoVitimasAutoresComponent } from './components/cadastro-procedimento-vitimas-autores/cadastro-procedimento-vitimas-autores.component';
import { CadastroProcedimentoControleComponent } from './components/cadastro-procedimento-controle/cadastro-procedimento-controle.component';
import { CadastroProcedimentoSituacaoComponent } from './components/cadastro-procedimento-situacao/cadastro-procedimento-situacao.component';
import { CadastroProcedimentoObjetosApreendidosComponent } from './components/cadastro-procedimento-objetos-apreendidos/cadastro-procedimento-objetos-apreendidos.component';
import { EstatisticaAssuntoComponent } from './relatorios/estatistica-assunto/estatistica-assunto.component';
import { AuthGuardService } from './guards/auth-guard.service';
import { UserListComponent } from './components/user-list/user-list.component';
import { AssuntoComponent } from './components/assunto/assunto.component';
import { VaraCriminalComponent } from './components/vara-criminal/vara-criminal.component';
import { UnidadePolicialComponent } from './components/unidade-policial/unidade-policial.component';
import { RelacaoProcedimentosComponent } from './relatorios/relacao-procedimentos/relacao-procedimentos.component';

const routes: Routes = [
  { path: '', redirectTo: 'procedimentos', pathMatch: 'full', canActivate: [AuthGuardService] },
  {
    path: 'cadastro-procedimento', component: CadastroProcedimentoComponent, canActivate: [AuthGuardService],
    children: [
      { path: 'controle', component: CadastroProcedimentoControleComponent, outlet: 'procedimento', canActivateChild: [AuthGuardService] }
    ]
  },
  {
    path: 'cadastro-procedimento/:id', component: CadastroProcedimentoComponent, canActivate: [AuthGuardService],
    children: [
      { path: 'controle', component: CadastroProcedimentoControleComponent, outlet: 'procedimento', canActivate: [AuthGuardService] },
      { path: 'vitimas-autores', component: CadastroProcedimentoVitimasAutoresComponent, outlet: 'procedimento', canActivate: [AuthGuardService] },
      { path: 'situacao', component: CadastroProcedimentoSituacaoComponent, outlet: 'procedimento', canActivate: [AuthGuardService] },
      { path: 'objetos-apreendidos', component: CadastroProcedimentoObjetosApreendidosComponent, outlet: 'procedimento', canActivate: [AuthGuardService] },
    ]
  },
  { path: 'procedimentos', component: ProcedimentoComponent, canActivate: [AuthGuardService] },
  { path: 'municipio', component: MunicipioComponent, canActivate: [AuthGuardService] },
  { path: 'artigo', component: ArtigoComponent, canActivate: [AuthGuardService] },
  { path: 'assunto', component: AssuntoComponent, canActivate: [AuthGuardService] },
  { path: 'tipo-procedimento', component: TipoProcedimentoComponent, canActivate: [AuthGuardService] },
  { path: 'vara-criminal', component: VaraCriminalComponent, canActivate: [AuthGuardService] },
  { path: 'unidade-policial', component: UnidadePolicialComponent, canActivate: [AuthGuardService] },
  { path: 'estatistica-assunto', component: EstatisticaAssuntoComponent, canActivate: [AuthGuardService] },
  { path: 'relacao-procedimentos', component: RelacaoProcedimentosComponent, canActivate: [AuthGuardService] },
  {
    path: 'account',
    children: [
      { path: 'users', component: UserListComponent, canActivate: [AuthGuardService] }
    ]
  },
  { path: '**', redirectTo: 'procedimentos' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
