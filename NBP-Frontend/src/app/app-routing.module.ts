import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NarudzbaLijekovaComponent } from './narudzba-lijekova/narudzba-lijekova.component';
import { PregledRecepataComponent } from './pregled-recepata/pregled-recepata.component';
import { PregledaLijekovaComponent } from './pregleda-lijekova/pregleda-lijekova.component';
import { ProdajaComponent } from './prodaja/prodaja.component';

const routes: Routes = [
  { path: 'prodaja', component: ProdajaComponent },
  { path: 'home', component: HomeComponent },
  { path: 'pregledLijekova', component: PregledaLijekovaComponent },
  { path: '', component: LoginComponent },
  { path: 'pregledRecepata', component: PregledRecepataComponent },
  { path: 'narudzbaLijekova', component: NarudzbaLijekovaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
