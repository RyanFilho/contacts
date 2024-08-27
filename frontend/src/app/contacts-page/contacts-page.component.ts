import { Component, inject, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { ContactService } from '../service/contact.service';
import { ContactModel } from '../models/contact.model';
import { ListContactsComponent } from "./list-contacts/list-contacts.component";
import { AddContactsComponent } from "./add-contacts/add-contacts.component";

@Component({
    selector: 'contacts-page',
    standalone: true,
    imports: [ListContactsComponent, AddContactsComponent],
    templateUrl: './contacts-page.component.html',
    styleUrl: './contacts-page.component.css',
})
export class ContactsPageComponent implements OnInit {
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
