import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MsalService, MsalBroadcastService } from '@azure/msal-angular';
import { EventMessage, AuthenticationResult, InteractionStatus, EventType } from '@azure/msal-browser';
import { filter } from 'rxjs/operators';
import { UserModel } from '../models/user.model';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class LoginService {
    loginDisplay = false;
    private apiUrl = `${environment.apiUrl}/Contact`;

    constructor(private authService: MsalService, private msalBroadcastService: MsalBroadcastService, private http: HttpClient) {
        this.msalBroadcastService.msalSubject$
            .pipe(
                filter((msg: EventMessage) => msg.eventType === EventType.LOGIN_SUCCESS),
            )
            .subscribe((result: EventMessage) => {
                const payload = result.payload as AuthenticationResult;
                this.authService.instance.setActiveAccount(payload.account);
                this.createNewUser();
            });

        this.msalBroadcastService.inProgress$
            .pipe(
                filter((status: InteractionStatus) => status === InteractionStatus.None)
            )
            .subscribe(() => {
                this.setLoginDisplay();
            });
    }


    setLoginDisplay() {
        this.loginDisplay = this.authService.instance.getAllAccounts().length > 0;
    }

    canActivate(): boolean {
        if (this.authService.instance.getActiveAccount() == null) {
            return false;
        }
        return true;
    }

    createNewUser() {
        const activeAccount = this.authService.instance.getActiveAccount();
        const adObjId = activeAccount?.idTokenClaims?.oid;
        if (adObjId == undefined) {
            console.log("It was possible to found the user oid!", activeAccount)
            return;
        }

        const currentUser = new UserModel(
            activeAccount?.name || '',
            activeAccount?.username || '',
            adObjId,
        );

        this.http.post(`${this.apiUrl}`, currentUser);
    }
}
