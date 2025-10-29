import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  // use relative URL so proxy.conf.js handles requests during ng serve
  private apiUrl = '/api/auth';

  constructor(private http: HttpClient) {}

  register(userData: { username: string; password: string }): Observable<any> {
    return this.http.post(this.apiUrl + "/register", userData);
  }

  login(credentials: { username: string; password: string }): Observable<any> {
    return this.http.post<any>(this.apiUrl + "/login", credentials);
  }
}

