import { Component } from '@angular/core';
import { FormControl, Validators, ValidatorFn, FormGroup, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';

import { AppGlblSettingsService } from 'common-services';
import { AppGlblLoginService } from './../../services/app-glbl-login.service';


@Component({
  selector: 'app-app-glbl-register',
  templateUrl: './app-glbl-register.component.html',
  styleUrls: ['./app-glbl-register.component.css']
})
export class AppGlblRegisterComponent {
    title: string = $localize`:Registration@@AppGlblRegisterComponent.Registration:Registration`;

    cnfPwdhide: boolean = true;
    pwdhide: boolean = true;
    public appearance: MatFormFieldAppearance = 'outline';
    registerFormGroup: FormGroup;


    constructor(private scrtSvr: AppGlblLoginService, protected router: Router, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;

        this.registerFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 

        locValidators = [ Validators.required,Validators.minLength(3) ];
        this.registerFormGroup.addControl('email', new FormControl({ value: null, disabled: false}, locValidators));

        locValidators = [ Validators.required,Validators.minLength(6) ];
        this.registerFormGroup.addControl('password', new FormControl({ value: null, disabled: false}, locValidators));

        locValidators = [ Validators.required,Validators.minLength(6) ];
        this.registerFormGroup.addControl('confirmPassword', new FormControl({ value: null, disabled: false}, locValidators));
    } 
    getErrorMessage(fc: AbstractControl): string {
        return this.appGlblSettings.getValidationErrorMessage(fc);
    } 

    doSubmit() {
        if(typeof this.registerFormGroup === 'undefined') return;
        if(this.registerFormGroup === null) return;
        if (this.registerFormGroup.invalid) {
            this.registerFormGroup.markAllAsTouched();
            return;
        }
        if(!(this.registerFormGroup.controls['password'].value === this.registerFormGroup.controls['confirmPassword'].value)) {
            let msg = {
                message: $localize`:Password and Confirm Password must be identical@@AppGlblRegisterComponent.Password-Confirm-dentical:Password and Confirm Password must be identical` 
            };
            this.appGlblSettings.showError($localize`:Input Error@@AppGlblRegisterComponent.Input-Error:Input Error`, msg);
            return;
        }
        this.scrtSvr.register(this.registerFormGroup.value)
        .subscribe({
            next: (respdata: any) => { // success path
                this.doLogin();
            },
            error: (error) => { // error path
                this.appGlblSettings.showError('http', error)
            }
        });
    }
    doLogin() {
        this.scrtSvr.login(this.registerFormGroup.controls['email'].value, this.registerFormGroup.controls['password'].value)
        .subscribe({
            next: (respdata: any) => { // success path
                this.appGlblSettings.userName = this.registerFormGroup.controls['email'].value;
                this.appGlblSettings.setAuthInto(respdata);
                this.router.navigate(['/']);
/*
must be uncommented when security is to be turn on
                this.scrtSvr.getPermissions().subscribe({
                    next: (rspdt: {modelName: string, userPerms: number}[]) => {
                        this.appGlblSettings.vwModels = {};
                        rspdt.forEach((r: {modelName: string, userPerms: number}) => {
                            this.appGlblSettings.vwModels[r.modelName] = r.userPerms;
                        });
                        console.log(this.appGlblSettings.vwModels)
                    },
                    error: (error) => { 
                        this.appGlblSettings.showError('http', error)
                    }
                });
*/
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


