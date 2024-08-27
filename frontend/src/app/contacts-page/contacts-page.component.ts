import { Component, inject, OnInit } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { ContactService } from '../service/contact.service';
import { ContactModel } from '../models/contact.model';

@Component({
    selector: 'app-contacts-page',
    standalone: true,
    imports: [],
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
