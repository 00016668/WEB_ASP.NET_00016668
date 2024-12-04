import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Contact } from './Contact';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private apiUrl = 'http://localhost:5260/api/Contacts'; 

  httpClient = inject(HttpClient);

  constructor(private http: HttpClient) { }

  getAll() {
    return this.httpClient.get<Contact[]>(this.apiUrl);
  }

  getById(id: number) {
    return this.httpClient.get<Contact>(`http://localhost:5260/api/Contacts/${id}`);
  }

  create(contact: Contact) {
    return this.httpClient.post<Contact>("http://localhost:5260/api/Contacts", contact);
  }

  update(id: number, contact: Contact) {
    return this.httpClient.put<Contact>(`http://localhost:5260/api/Contacts/${id}`, contact);
  }

  delete(id: number) {
    return this.httpClient.delete<void>(`http://localhost:5260/api/Contacts/${id}`);
  }

  deleteContact(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getContactById(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.apiUrl}/${id}`);
  }
  
  updateContact(id: number, contact: Contact): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, contact);
  }
}
