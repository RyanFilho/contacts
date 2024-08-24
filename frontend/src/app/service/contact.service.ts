// src/app/services/credit-card.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { ContactModel } from '../models/contact.model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = `${environment.apiUrl}/Contact`; // Update with your API URL

  constructor(private http: HttpClient) {}

  getContacts(userId: number): Observable<ContactModel[]> {
    return this.http.get<ContactModel[]>(`${this.apiUrl}/${userId}`);
  }
}
