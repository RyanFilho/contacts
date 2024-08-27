import { Component, inject } from '@angular/core';
import { ContactService } from '../../service/contact.service';
import { MsalService } from '@azure/msal-angular';
import { ContactModel } from '../../models/contact.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'add-contacts',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contacts.component.html',
  styleUrl: './add-contacts.component.css'
})
export class AddContactsComponent {
  private authService = inject(MsalService);
  private contactService = inject(ContactService);

  addContact(formValues: any): void {
    const activeUser = this.authService.instance.getActiveAccount();
    const adObjId = activeUser?.idTokenClaims?.oid;
    if (adObjId == undefined)
      return;

    const newContact = new ContactModel (
      formValues.name,
      formValues.phoneNumber,
      adObjId);
    
    this.contactService.addContact(newContact);
  }

}