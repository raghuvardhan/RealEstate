import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Property } from '../../models/property';

@Injectable({
  providedIn: 'root'
})
export class SearchFilterService {
  private apiUrl = 'http://localhost:5000/api';  // URL to your backend API

  constructor(private http: HttpClient) { }

  searchProperties(query: string): Observable<Property[]> {
    return this.http.get<Property[]>(`${this.apiUrl}/search?query=${query}`);
  }

  // Add other methods as needed (e.g., filterProperties)
}
