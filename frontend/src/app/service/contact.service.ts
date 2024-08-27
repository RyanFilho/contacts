import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { ContactModel } from '../models/contact.model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiUrl = `${environment.apiUrl}/Contact`;

  constructor(private http: HttpClient) {}

  getContacts(userId: string): Observable<ContactModel[]> {
    return this.http.get<ContactModel[]>(`${this.apiUrl}/${userId}`);
  }
}
