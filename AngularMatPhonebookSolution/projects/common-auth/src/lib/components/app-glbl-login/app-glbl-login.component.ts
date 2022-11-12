import { Component } from '@angular/core';
import { FormControl, Validators, ValidatorFn, FormGroup, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';

import { AppGlblSettingsService } from 'common-services';
import { AppGlblLoginService } from './../../services/app-glbl-login.service';

@Component({
  selector: 'app-app-glbl-login',
  templateUrl: './app-glbl-login.component.html',
  styleUrls: ['./app-glbl-login.component.css']
})
export class AppGlblLoginComponent {
    title: string = $localize`:Sign in@@AppGlblLoginComponent.Sign-in:Sign in`;

    cnfPwdhide: boolean = true;
    pwdhide: boolean = true;
    public appearance: MatFormFieldAppearance = 'outline';
    loginFormGroup: FormGroup;

    constructor(private scrtSvr: AppGlblLoginService, protected router: Router, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;

        this.loginFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 

        locValidators = [ Validators.required,Validators.minLength(3) ];
        this.loginFormGroup.addControl('username', new FormControl({ value: null, disabled: false}, locValidators));

        locValidators = [ Validators.required,Validators.minLength(6) ];
        this.loginFormGroup.addControl('password', new FormControl({ value: null, disabled: false}, locValidators));

    } 
    getErrorMessage(fc: AbstractControl): string {
        return this.appGlblSettings.getValidationErrorMessage(fc);
    } 

    doSubmit() {
        if(typeof this.loginFormGroup === 'undefined') return;
        if(this.loginFormGroup === null) return;
        if (this.loginFormGroup.invalid) {
            this.loginFormGroup.markAllAsTouched();
            return;
        }
        this.scrtSvr.login(this.loginFormGroup.controls['username'].value, this.loginFormGroup.controls['password'].value)
        .subscribe({
            next: (respdata: any ) => { // success path
                this.appGlblSettings.setAuthInto(respdata);
                this.appGlblSettings.userName = this.loginFormGroup.controls['username'].value;
                this.router.navigate(['/']);

                this.scrtSvr.getPermissions().subscribe({
                    next: (rspdt: {modelName: string, userPerms: number}[]) => {
                        this.appGlblSettings.vwModels = {};
                        rspdt.forEach((r: {modelName: string, userPerms: number}) => {
                            this.appGlblSettings.vwModels[r.modelName] = r.userPerms;
                        });
                    },
                    error: (error) => { 
                        this.appGlblSettings.showError('http', error)
                    }
                });
            },
            error: (error) => { // error path
                this.appGlblSettings.showError('http', error)
            }
        });
    }
    onCancel(){
        this.router.navigate(['/']);
    }
}


