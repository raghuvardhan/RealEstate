import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Property } from './models/property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {
  private apiUrl = 'http://localhost:5000/api';  // URL to your backend API

  constructor(private http: HttpClient) { }

  // Fetch all properties
  getProperties(): Observable<Property[]> {
    return this.http.get<Property[]>(`${this.apiUrl}/listing`);
  }

  // Fetch a single property by its ID
  getProperty(id: number): Observable<Property> {
    return this.http.get<Property>(`${this.apiUrl}/listing/${id}`);
  }

  // Add a new property
  addProperty(property: Property): Observable<Property> {
    return this.http.post<Property>(`${this.apiUrl}/listing`, property);
  }

  // Update an existing property
  updateProperty(id: number, property: Property): Observable<Property> {
    return this.http.put<Property>(`${this.apiUrl}/listing/${id}`, property);
  }

  // Delete a property
  deleteProperty(id: number): Observable<Property> {
    return this.http.delete<Property>(`${this.apiUrl}/listing/${id}`);
  }
}
