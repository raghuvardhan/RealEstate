import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5000/api';  // URL to your backend API

  constructor(private http: HttpClient) { }

  getUserProfile(): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/user/profile`);
  }

  updateUserProfile(user: User): Observable<User> {
    return this.http.put<User>(`${this.apiUrl}/user/profile`, user);
  }

  login(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/user/login`, user);
  }

  register(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/user/register`, user);
  }
  // Add other methods as needed (e.g., createUser, deleteUser)
}
