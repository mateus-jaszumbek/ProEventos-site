import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './components/eventos/eventos.component';
import { NavComponent } from './shared/nav/nav.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { NgModule } from '@angular/core';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { TituloComponent } from './shared/titulo/titulo.component';



const routes: Routes = [
  { path: 'eventos', component: EventosComponent },
  { path: 'palestrantes', component: PalestrantesComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'contatos', component: ContatosComponent },
  { path: 'perfil', component: PerfilComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
