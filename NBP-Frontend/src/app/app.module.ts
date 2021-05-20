import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProdajaComponent } from './prodaja/prodaja.component';
import { MeniComponent } from './meni/meni.component';
import { HomeComponent } from './home/home.component';
import { PregledaLijekovaComponent } from './pregleda-lijekova/pregleda-lijekova.component';
import { LoginComponent } from './login/login.component';
import { PregledRecepataComponent } from './pregled-recepata/pregled-recepata.component';
import { NarudzbaLijekovaComponent } from './narudzba-lijekova/narudzba-lijekova.component';

@NgModule({
  declarations: [
    AppComponent,
    ProdajaComponent,
    MeniComponent,
    HomeComponent,
    PregledaLijekovaComponent,
    LoginComponent,
    PregledRecepataComponent,
    NarudzbaLijekovaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
