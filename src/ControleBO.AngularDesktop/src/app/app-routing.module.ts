import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TipoProcedimentoComponent } from './components/tipo-procedimento/tipo-procedimento.component';
import { ArtigoComponent } from './components/artigo/artigo.component';
import { MunicipioComponent } from './components/municipio/municipio.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  //{ path: 'home', component: HomeComponent },
  //{ path: 'counter', component: CounterComponent },
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
