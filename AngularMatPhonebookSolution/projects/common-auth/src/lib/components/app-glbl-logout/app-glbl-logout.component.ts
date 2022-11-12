import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';

import { AppGlblSettingsService } from 'common-services';
import { AppGlblLoginService } from './../../services/app-glbl-login.service';


@Component({
  selector: 'app-app-glbl-logout',
  templateUrl: './app-glbl-logout.component.html',
  styleUrls: ['./app-glbl-logout.component.css']
})
export class AppGlblLogoutComponent {
    title: string = $localize`:Do you want to Sign Out@@AppGlblLogoutComponent.Sign Out:Do you want to Sign Out?`;

    public appearance: MatFormFieldAppearance = 'outline';

    constructor(private scrtSvr: AppGlblLoginService, protected router: Router, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
    } 
    doSubmit() {
        this.appGlblSettings.perms = [0,0,0,0,  0,0,0,0,  0,0,0,0,  0,0,  1,0,0];
        this.appGlblSettings.setAuthInto(null);
        this.appGlblSettings.userName = null;
        this.appGlblSettings.vwModels = {};
        this.router.navigate(['/']);
/*
        this.scrtSvr.logout()
        .subscribe({
            next: (respdata: any ) => { // success path
                this.appGlblSettings.perms = [0,0,0,0,  0,0,0,0,  0,0,0,0,  0,0,  1,0,0];
                this.appGlblSettings.setAuthInto(null);
                this.appGlblSettings.userName = null;
                this.appGlblSettings.vwModels = {};
                this.router.navigate(['/']);
            },
            error: (error) => { // error path
                this.appGlblSettings.showError('http', error)
            }
        });
*/
    }
    onCancel(){
        this.router.navigate(['/']);
    }
}


