import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Group } from './Group';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GroupService {
  httpClient = inject(HttpClient);
  private apiUrl = 'http://localhost:5260/api/Groups';  

  constructor(private http: HttpClient) { }


  getAll(): Observable<Group[]> {
    return this.httpClient.get<Group[]>(this.apiUrl);
  }


  getById(id: number): Observable<Group> {
    return this.httpClient.get<Group>(`${this.apiUrl}/${id}`);
  }

  // Create a new group
  createGroup(group: Partial<Group>): Observable<Group> {
    return this.httpClient.post<Group>(this.apiUrl, group);
  }


  getGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(this.apiUrl);  
  }
}
