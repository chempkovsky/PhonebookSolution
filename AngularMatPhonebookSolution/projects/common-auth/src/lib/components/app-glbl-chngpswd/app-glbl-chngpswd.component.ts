import { Component } from '@angular/core';
import { FormControl, Validators, ValidatorFn, FormGroup, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';

import { AppGlblSettingsService } from 'common-services';
import { AppGlblLoginService } from './../../services/app-glbl-login.service';
import { IAppGlblChngpswd } from './../../interfaces/app-glbl-chngpswd.interface';


@Component({
  selector: 'app-app-glbl-chngpswd',
  templateUrl: './app-glbl-chngpswd.component.html',
  styleUrls: ['./app-glbl-chngpswd.component.css']
})
export class AppGlblChngpswdComponent {
    title: string = $localize`:Change Password@@AppGlblChngpswdComponent.Change-Password:Change Password`;

    cnfPwdhide: boolean = true;
    pwdhide: boolean = true;
    oldpwdhide: boolean = true;
    public appearance: MatFormFieldAppearance = 'outline';
    chngpswdFormGroup: FormGroup;


    constructor(private scrtSvr: AppGlblLoginService, protected router: Router, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;

        this.chngpswdFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 

        locValidators = [ Validators.required,Validators.minLength(6) ];
        this.chngpswdFormGroup.addControl('oldpassword', new FormControl({ value: null, disabled: false}, locValidators));

        locValidators = [ Validators.required,Validators.minLength(6) ];
        this.chngpswdFormGroup.addControl('newPassword', new FormControl({ value: null, disabled: false}, locValidators));

        locValidators = [ Validators.required,Validators.minLength(6) ];
        this.chngpswdFormGroup.addControl('confirmPassword', new FormControl({ value: null, disabled: false}, locValidators));
    } 
    getErrorMessage(fc: AbstractControl): string {
        return this.appGlblSettings.getValidationErrorMessage(fc);
    } 
    doSubmit() {
        if(typeof this.chngpswdFormGroup === 'undefined') return;
        if(this.chngpswdFormGroup === null) return;
        if (this.chngpswdFormGroup.invalid) {
            this.chngpswdFormGroup.markAllAsTouched();
            return;
        }
        if(!(this.chngpswdFormGroup.controls['newPassword'].value === this.chngpswdFormGroup.controls['confirmPassword'].value)) {
            let msg = {
                message: $localize`:New Password and Confirm Password must be identical@@AppGlblChngpswdComponent.New-Password-dentical:New Password and Confirm Password must be identical` 
            };
            this.appGlblSettings.showError($localize`:Input Error@@AppGlblChngpswdComponent.Input-Error:Input Error`, msg);
            return;
        }
        let chPwd: IAppGlblChngpswd = {
           OldPassword: this.chngpswdFormGroup.controls['oldpassword'].value,
           NewPassword: this.chngpswdFormGroup.controls['newPassword'].value,
           ConfirmPassword: this.chngpswdFormGroup.controls['confirmPassword'].value,
        }
        this.scrtSvr.changePassword(chPwd)
        .subscribe({
            next: (respdata: any ) => { // success path
                this.router.navigate(['/']);
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


