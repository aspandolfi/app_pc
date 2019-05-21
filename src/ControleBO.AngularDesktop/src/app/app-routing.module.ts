import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TipoProcedimentoComponent } from './components/tipo-procedimento/tipo-procedimento.component';
import { ArtigoComponent } from './components/artigo/artigo.component';
import { MunicipioComponent } from './components/municipio/municipio.component';
import { ProcedimentoComponent } from './components/procedimento/procedimento.component';
import { CadastroProcedimentoComponent } from './components/cadastro-procedimento/cadastro-procedimento.component';
import { CadastroProcedimentoVitimasAutoresComponent } from './components/cadastro-procedimento-vitimas-autores/cadastro-procedimento-vitimas-autores.component';
import { CadastroProcedimentoControleComponent } from './components/cadastro-procedimento-controle/cadastro-procedimento-controle.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'cadastro-procedimento', component: CadastroProcedimentoComponent,
    children: [
      { path: 'controle', component: CadastroProcedimentoControleComponent, outlet: 'procedimento' }
    ]
  },
  {
    path: 'cadastro-procedimento/:id', component: CadastroProcedimentoComponent,
    children: [
      { path: 'controle', component: CadastroProcedimentoControleComponent, outlet: 'procedimento' },
      { path: 'vitimas-autores', component: CadastroProcedimentoVitimasAutoresComponent, outlet: 'procedimento' }
    ]
  },
  { path: 'procedimentos', component: ProcedimentoComponent },
  { path: 'municipio', component: MunicipioComponent },
  { path: 'artigo', component: ArtigoComponent },
  { path: 'tipo-procedimento', component: TipoProcedimentoComponent },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
