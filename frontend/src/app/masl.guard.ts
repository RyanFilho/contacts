import { CanActivateFn } from '@angular/router';
import { MsalService } from '@azure/msal-angular'

export const maslGuard: CanActivateFn = (route, state) => {
  MsalService
  return true;
};
