import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ConfiguracaoComponent } from './components/configuracao/configuracao.component';
import { TipoProcedimentoComponent } from './components/tipo-procedimento/tipo-procedimento.component';
import { CadastroTipoProcedimentoComponent } from './components/cadastro-tipo-procedimento/cadastro-tipo-procedimento.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ConfiguracaoComponent,
        TipoProcedimentoComponent,
        CadastroTipoProcedimentoComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'configuracao', component: ConfiguracaoComponent },
            { path: 'tipo-procedimento', component: TipoProcedimentoComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        BrowserAnimationsModule,
        ToastrModule.forRoot()
    ]
})
export class AppModuleShared {
}
