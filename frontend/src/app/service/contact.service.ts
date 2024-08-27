import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IContactModel } from '../models/contact.model';

@Injectable({
  providedIn: 'root',
})
export class ContactService {  
  private apiUrl = `${environment.apiUrl}/Contact`;

  constructor(private http: HttpClient) {}

  getContacts(userId: string): Observable<IContactModel[]> {
    return this.http.get<IContactModel[]>(`${this.apiUrl}/${userId}`);
  }

  addContact(newContact: IContactModel) {
    return this.http.post(`${this.apiUrl}`, newContact);
  }
}
