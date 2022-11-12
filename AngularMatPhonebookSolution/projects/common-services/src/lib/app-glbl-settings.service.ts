
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild, Route } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';
import { AppConfigService } from './app-config.service';
import { HttpParameterCodec } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppGlblSettingsService implements CanActivate, CanActivateChild, HttpParameterCodec {
//
// begin HttpParameterCodec: https://github.com/angular/angular/issues/20376
//
    encodeKey(key: string): string {
      return encodeURIComponent(key);
    }
    encodeValue(value: string): string {
      return encodeURIComponent(value);
    }
    decodeKey(key: string): string {
      return decodeURIComponent(key);
    }
    decodeValue(value: string): string {
      return decodeURIComponent(value);
    }
//
// end HttpParameterCodec: https://github.com/angular/angular/issues/20376
//
    public appearance: MatFormFieldAppearance = 'outline';
    public filterHeightAddition: number = 0.5;
    public filterHeightFactor: number = 5;
    public tableHeightAddition: number = 0;
    public tableHeightFactor: number = 31;

    constructor(private _snackBar: MatSnackBar, private _settings: AppConfigService) {}
    public showMsg(msg: string) {
      this._snackBar.open(msg, 'Close', { duration: 4000 });
    }
    public showError(errTp: string, errorStruct: any) {
        let text: string = $localize`:Error prefix@@AppGlblSettingsService.Error:Error`+': ';
        if(!(typeof errTp === 'undefined')) {
            if(!(errTp === null)) {
                text = $localize`:Error of type prefix@@AppGlblSettingsService.Error-of-type:Error of type` + ' ' + errTp + ' : ';
            }
        }
        if(!(typeof errorStruct === 'undefined')) {
            if(!(errorStruct === null)) {
                if(!(typeof errorStruct.message === 'undefined')) {
                    if(!(errorStruct.message === null)) {
                        text = text + ' ' +  errorStruct.message;
                    }
                }
                if(!(typeof errorStruct.status === 'undefined')) {
                  if(!(errorStruct.status === null)) {
                      text = text + ' ' + $localize`:Status prefix@@AppGlblSettingsService.status:status` + ' ' + errorStruct.status;
                  }
              }
              if(!(typeof errorStruct.statusText === 'undefined')) {
                    if(!(errorStruct.statusText === null)) {
                        text = text + ' ' + $localize`:Status Text prefix@@AppGlblSettingsService.Status-Text:Status Text` + ' ' + errorStruct.statusText;
                    }
                }
                if(!(typeof errorStruct.error === 'undefined')) {
                  if(!(errorStruct.error === null)) {
                    if(!(typeof errorStruct.error.errors === 'undefined')) {
                      if(Array.isArray( errorStruct.error.errors )) {
                        errorStruct.error.errors.forEach((e: any) => {
                          if(e.code) text = text + ' ' + $localize`:error code prefix@@AppGlblSettingsService.error-code:error code` + ' ' + e.code;
                          if(e.description) text = text + ' ' + $localize`:error descr prefix@@AppGlblSettingsService.error-descr:error descr` + ' ' + e.description;
                        });
                      }
                    }
                  }
                }
            }
        }
        this._snackBar.open(text, 'Close', { duration: 4000 });
    }
    public getWebApiPrefix(vwNm: string): string {
        let reslt: string = '';
        if(!(vwNm === null)) {
            if(!(vwNm === null)) {
                //
                // here: defining url by ViewName
                //

                if (vwNm === 'LpdDivisionView' || vwNm === 'LprDivision01View' || vwNm === 'LprDivision02View') {
                  reslt = this._settings.config.divisionLpWebApi;
                } else if (vwNm === 'LpdEmpLastNameView' || vwNm === 'LpdEmpFirstNameView' || vwNm === 'LpdEmpSecondNameView' || vwNm === 'LprEmployee01View' || vwNm === 'LprEmployee02View' ) {
                    reslt = this._settings.config.employeeLpWebApi;
                } else if (vwNm === 'LpdPhoneView' || vwNm === 'LprPhone01View' || vwNm === 'LprPhone02View' || vwNm === 'LprPhone03View' || vwNm === 'LprPhone04View' ) {
                    reslt = this._settings.config.phoneLpWebApi;
                } else {
                  reslt = this._settings.config.webApiUrl;
                }
        
                //reslt =  this._settings.config.webApiUrl; // 'https://localhost:7148/';
            }
        }
        return reslt;
    } 
    public getSecurityWebApiPrefix(): string {
        return this._settings.config.securityUrl; //'https://localhost:7148/';
    } 
    public getPermissionWebApiPrefix(): string {
        return this._settings.config.permissionWebApi; // 'https://localhost:7148/';
    }

    getValidationErrorMessage(fc: AbstractControl): string {
        let rslt: string = $localize`:Validation Error prefix@@AppGlblSettingsService.Validation-Error:Validation Error` + '. ';

        if (typeof fc === 'undefined') {
          return rslt;
        }
        if (fc === null) {
          return rslt;
        }
        if (fc.errors === null) return rslt;
        const errs: ValidationErrors = fc.errors as ValidationErrors;
        Object.keys(errs).forEach(k => {
          switch(k) {
            case 'maxlength':
              rslt += ' ' + $localize`:Required max length@@AppGlblSettingsService.Required-max-length:Required max length` + ': ' + errs[k].requiredLength;
              break;
            case 'minlength':
              rslt += ' ' + $localize`:Required min length@@AppGlblSettingsService.Required-min-length:Required min length` + ': ' + errs[k].requiredLength;
              break;
            case 'required':
              rslt += ' ' + $localize`:Required field@@AppGlblSettingsService.Required-field:Required field` + ': ' + errs[k].requiredLength;
              break;
            case 'max':
              rslt += ' ' + $localize`:The value must be less than@@AppGlblSettingsService.The-value-must-be-less-than:The value must be less than` + ': ' + errs[k].max;
              break;
            case 'min':
              rslt += ' ' + $localize`:The value must be greater than@@AppGlblSettingsService.The-value-must-be-greater-than:The value must be greater than` + ': ' + errs[k].max;
              break;
            case 'pattern':
              rslt += ' ' + $localize`:Icorrect format@@AppGlblSettingsService.Icorrect-format:Icorrect format` + ': ' + errs[k].max;
              break;
            case 'matDatepickerMin':
              rslt += ' ' + $localize`:Value must be greater than@@AppGlblSettingsService.Value-must-be-greater-than:Value must be greater than` + ': ' + errs[k].max;
              break;
            case 'matDatepickerMax':
              rslt += ' ' + $localize`:Value must be less than@@AppGlblSettingsService.Value-must-be-less-than:Value must be less than` + ': ' + errs[k].max;
              break;
            case 'matDatepickerParse':
              rslt += ' ' + $localize`:Icorrect date format@@AppGlblSettingsService.Icorrect-date-format:Icorrect date format` + '.';
              break;
            default:
              rslt += ' ' + $localize`:Icorrect format@@AppGlblSettingsService.Icorrect-format2:Icorrect format` + '.';
              break;
          }
        });
        return rslt;
    } // end of getErrorMessage
    public getDialogWidth(vwNm: string): string {
        let rslt: string = '99vw';
        if(!(vwNm === null)) {
            if(!(vwNm === null)) {
                //
                // here: set dialog width for the given ViewName
                //
                return '99vw';        
            }
        }
        return rslt;
    }
    public getDialogMaxWidth(vwNm: string): string {
        let rslt: string = '100vw';
        if(!(vwNm === null)) {
            if(!(vwNm === null)) {
                //
                // here: set dialog max width for the given ViewName
                //
                return '100vw';        
            }
        }
        return rslt;
    }
    
    protected authInto: any = null;
    public getAuthInto(): any {
        return this.authInto;
    }
    public setAuthInto(info: any): any {
        if(typeof info === 'undefined') {
            this.authInto = null;
        } else {
            this.authInto = info;
        }
    }

    public perms: number[] = [0,0,0,0,  0,0,0,0,  0,0,0,0,  0,0,  1,0,0];
    public vwModels:  { [key: string]: number } = {
/*        
        'LitAuthorView': 0,
        'LitBookView': 1,
        'LitCountryView':2,
        'LitDialectView':3,
        'LitEditionView':4,
        'LitGenreView':5,
        'LitLanguageView':6,
        'LitManuscriptView':7,
        'LitPublisherView':8,
*/
    };
    public dshBrds:  { [key: string]: number } = {
/*
      'FirstFtrComponent': 0
*/
    };
    getViewModelMask(vwModel: string): number {
      return 31; // delete this line when vwModels is ready
      let pk = this.vwModels[vwModel];
      if(typeof pk === 'undefined') { return 0; } else { return pk; }
/*

deprecated

      let pk = this.vwModels[vwModel];
      if(typeof pk === 'undefined') return 0;
      let rid: number = Math.floor(pk/7);
      if(rid >= (this.perms.length-3))  return 0; 
      let sft: number = (pk - rid * 7) * 4;
      let rslt = this.perms[rid];
      if(sft > 0) {
        rslt = this.perms[rid] >> sft;
      }
      return rslt; 
*/
    }
    getDashBrdMask(dshBrd: string): number {
      return 1; // delete this line when dshBrds is ready
      let pk = this.vwModels[dshBrd];
      if(typeof pk === 'undefined') { return 0; } else { return pk; }
/* 

deprecated

      let pk = this.dshBrds[dshBrd];
      if(typeof pk === 'undefined') return 0;
      let rid: number = Math.floor(pk/31);
      if(rid >= (this.perms.length-14))  return 0; 
      let sft: number = (pk - rid * 31);
      let rslt = (this.perms[rid+14])
      if(sft > 0) {
        rslt = (this.perms[rid+14]) >> sft;
      }
      return rslt; 
*/
    }
    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {
      if((typeof childRoute.data['vn'] === 'undefined') || (typeof childRoute.data['va'] === 'undefined')) return false;
      if((childRoute.data['vn'] === null) || (childRoute.data['va'] === null)) return false;
      let msk = this.getViewModelMask(childRoute.data['vn']);
      let rslt: boolean = false;

      switch( childRoute.data['va'] ) {
        case 'a':
          rslt = ((msk & 8) === 8);
          break;
        case 'u':
          rslt = ((msk & 4) === 4);
          break;
        case 'd':
          rslt = ((msk & 2) === 2);
          break;
        case 'l':
          rslt = ((msk & 1) === 1);
          break;
        case 'v':
          rslt = ((msk & 1) === 1);
          break;
      };

      if(!rslt) this.showError('navigation', {message: $localize`:Access denied@@AppGlblSettingsService.Access-denied:Access denied`});


      return rslt;
/*

deprecated

      if (childRoute.routeConfig === null) return false;
      if ( typeof ((childRoute.routeConfig as Route).path) === 'undefined') return false;
      let pth: string[] = ((childRoute.routeConfig as Route).path as string).split('/');
      let vnm: string = '';
      let act: number = 1;
      let vid: number = -1;
      let cnt = 0;
      for(let i = pth.length-1; i > -1; i-- ) {
        if(!pth[i].startsWith(':')) {
          if(cnt > 0) {
            vnm = pth[i];
            vid = i;
            break;
          } else cnt++;
        }
      }
      if (vid < 0) {
        if(pth.length>0) {
          vnm = pth[0];
          vid = 0;
        } else return false;
      }
      if ( pth[pth.length-1].startsWith(':') ) {
        switch( childRoute.url[childRoute.url.length-1].path ) {
          case 'add':
            act = 8;
            break;
          case 'update':
            act = 4;
            break;
          case 'delete':
            act = 2;
            break;
        };
      } 
      return (this.getViewModelMask(vnm) & act) === act;
*/
    }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {
      if(route.routeConfig === null) return false;
      if( typeof ((route.routeConfig as Route).component) === 'undefined') return false;
      return ( this.getDashBrdMask(((route.routeConfig as Route).component as any)['name']) & 1) === 1;

    }
    
    public userName: string|null=null;

    public useLocalStorage: boolean = false;
    public useSessionStorage: boolean = false;
    protected serviceStorage: {[key: string]: any} = {};

    public getStorageItem(key: string): any {
        if(typeof key === 'undefined') return null;
        if (this.useLocalStorage) {
            return null;
        } else if (this.useSessionStorage) {
            return null;
        } else {
            return this.serviceStorage[key];
        }
    }
    public setStorageItem(key: string, val: any): void {
        if(!(typeof key === 'undefined')) {
            if (this.useLocalStorage) {
                
            } else if (this.useSessionStorage) {
            
            } else {
                this.serviceStorage[key] = val;
            }
        }
    }
    public getStorageLength(): number {
        if (this.useLocalStorage) {
            return 0;
        } else if (this.useSessionStorage) {
            return 0;
        } else {
            return Object.keys(this.serviceStorage).length;
        }
    }
    public removeStorageItem(key: string): void {
        delete this.serviceStorage[key];
    }
    public getStorageKey(index: number): string | null {
        if (this.useLocalStorage) {
            return null;
        } else if (this.useSessionStorage) {
            return null;
        } else {
            const ks = Object.keys(this.serviceStorage);
            return index >= 0 && ks.length < index ? ks[index] : null;
        }

    }
    public clearStorage(): void {
        if (this.useLocalStorage) {
            
        } else if (this.useSessionStorage) {
            
        } else {
            this.serviceStorage = {};
        }
    }
}

@Injectable({
  providedIn: 'root'
})
export class AppGlblSettingsServiceActivator implements CanActivate {
    constructor(protected appGlblSettings: AppGlblSettingsService) {}
    
    
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return this.appGlblSettings.canActivateChild(route, state);
    }
}

