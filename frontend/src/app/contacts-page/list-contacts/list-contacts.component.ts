import { Component, inject, OnInit } from '@angular/core';
import { ContactModel } from '../../models/contact.model';
import { MsalService } from '@azure/msal-angular';
import { ContactService } from '../../service/contact.service';

@Component({
  selector: 'list-contacts',
  standalone: true,
  imports: [],
  templateUrl: './list-contacts.component.html',
  styleUrl: './list-contacts.component.css'
})
export class ListContactsComponent implements OnInit {
  contacts: ContactModel[] = [];
  private authService = inject(MsalService);
  private contactService = inject(ContactService);

  ngOnInit(): void {
      const activeUser = this.authService.instance.getActiveAccount();
      if (activeUser?.idToken == null)
          return;
      this.contactService.getContacts(activeUser.idToken).subscribe((newContact: any) => {
          this.contacts.push(newContact);
      });
  }
}