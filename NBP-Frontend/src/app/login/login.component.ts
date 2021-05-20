import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { AuthResult } from '../models/authResult';
import { LoginRequest } from '../models/request/loginRequest';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  token : AuthResult;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  
  login() {
    console.log('Usao');
    this.http.post<AuthResult>("https://localhost:49741/account/login", { Username : "arogo1", Password : "formulajedan1" }).subscribe(data => {
      this.token.Token = data.Token;
    })
  }
}
