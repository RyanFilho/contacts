import { Routes } from '@angular/router';
import { ContactsPageComponent } from './contacts-page/contacts-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { maslGuard } from './masl.guard';

export const routes: Routes = [
  { path: 'contacts', component: ContactsPageComponent, canActivate: [maslGuard] },
  { path: '**', component: HomePageComponent }
];
