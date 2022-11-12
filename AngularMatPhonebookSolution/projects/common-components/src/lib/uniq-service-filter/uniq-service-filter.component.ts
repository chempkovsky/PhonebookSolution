import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { MatFormFieldAppearance } from '@angular/material/form-field';
import { debounceTime, Observable, of, switchMap } from 'rxjs';

import { IUniqServiceFilter } from 'common-interfaces';
import { IUniqServiceFilterDef } from 'common-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { AppGlblSettingsService } from 'common-services';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';





@Component({
  selector: 'app-uniq-service-filter',
  templateUrl: './uniq-service-filter.component.html',
  styleUrls: ['./uniq-service-filter.component.css']
})
export class UniqServiceFilterComponent implements OnInit, IEventEmitterPub {
    protected isOnInitCalled: boolean = false;
    public appearance: MatFormFieldAppearance = 'outline';
    
    @Input('caption') caption: string = '';
    @Input('show-back-btn') showBackBtn: boolean = false;
    @Output('on-back-btn') onBackBtn = new EventEmitter<any>();
    onBackBtnMd() {
        this.onBackBtn.emit(null);
    }

    public ovrflw: string | null = null;   
    public  maxHeightEx: number|null = null;
    protected _maxHeight: number|null = null;
    @Input('max-height')
      get maxHeight(): number|null {
        return this._maxHeight;
      }
      set maxHeight(inp: number|null) {
        this._maxHeight = inp;
        if (!(typeof inp === 'undefined')) {
          if(!(inp === null)) {
            this.maxHeightEx = inp * this.appGlblSettings.filterHeightFactor + this.appGlblSettings.filterHeightAddition;
            this.ovrflw = 'auto';
            if(this.isOnInitCalled) {
              this.cd.detectChanges();
            }
            return;
          }
        }
        this.maxHeightEx = null;
        this.ovrflw = null;
        if(this.isOnInitCalled) {
            this.cd.detectChanges();
        }
      }
    @Input('show-add-flt-item') showAddFltItem: boolean = true;
    @Output('on-cont-menu-item-click') onContMenuItemEmitter = new EventEmitter<IEventEmitterData>();
    @Input('cont-menu-items') contMenuItems: Array<IMenuItemData> = [];
    onContMenuItemClicked(v: IMenuItemData)  {
        let e: IEventEmitterData = {
            id: v.id,
            sender: this,
            value: null
        }
        this.onContMenuItemEmitter.emit(e);
    }

    public showFilterEx: boolean = true;
    protected _showFilter: boolean|any = true;
    @Input('show-filter') 
      get showFilter(): boolean {
        return this._showFilter;
      }
      set showFilter(inshow: boolean|any) {
        this._showFilter = inshow;
        if (!(typeof inshow === 'undefined')) {
          if(!(inshow === null)) {
            this.showFilterEx = inshow as boolean;
            if(this.isOnInitCalled) {
              this.onFilterDefsChanged();
            }
          }
        }
      }


    inputFilterDefsEx: Array<IUniqServiceFilterDef> = [];
    protected _inputFilterDefs: Array<IUniqServiceFilterDef> = [];
    @Input('filter-defs') 
        get inputFilterDefs(): Array<IUniqServiceFilterDef> {
          return this._inputFilterDefs;
        }
        set inputFilterDefs(inDef: Array<IUniqServiceFilterDef>) {
          this._inputFilterDefs = inDef
          if (typeof inDef === 'undefined') {
            this.inputFilterDefsEx = [];
          } else if(!Array.isArray(inDef)) {
            this.inputFilterDefsEx = [];
          } else {
            this.inputFilterDefsEx =  inDef;
          }
          if(this.isOnInitCalled) {
            this.onFilterDefsChanged();
          }
        }


    @Output('on-apply-filter') onApplyFilter = new EventEmitter();
  
    webServiceFilterDefs: Array<IUniqServiceFilterDef> = [];
    webServiceFilters: Array<IUniqServiceFilter> = [];

    constructor(protected appGlblSettings: AppGlblSettingsService, private cd: ChangeDetectorRef) { 
        this.appearance = this.appGlblSettings.appearance;
    }

    ngOnInit(): void {
        this.onFilterDefsChanged();
        this.isOnInitCalled = true;
        this.cd.detectChanges();
    }

    onFilterDefsChanged(): void {
        this.webServiceFilterDefs = [];
        this.clrTpAheadVars();
        if(this.showFilter) {
            this.inputFilterDefsEx.forEach(i => {
                this.webServiceFilterDefs.push({ fltrName: i.fltrName, fltrCaption: i.fltrCaption, fltrDataType: i.fltrDataType, fltrMaxLen: i.fltrMaxLen, fltrMin: i.fltrMin, fltrMax: i.fltrMax, fltrFlx: i.fltrFlx, fltrMd: i.fltrMd, fltrSm: i.fltrSm, fltrXs: i.fltrXs, fltrSrv: i.fltrSrv });
            });    
            let wsfd: Array<IUniqServiceFilter> = [];
            this.webServiceFilterDefs.forEach(i => {
                let k: number = this.externalFilterEx.findIndex((h: IWebServiceFilterRslt) => { return h.fltrName === i.fltrName; });
                let flt: IUniqServiceFilter = {
                    fltrDataType: i.fltrDataType, 
                    fltrValue: new FormControl({ value: null, disabled: false }), 
                    fltrName: i.fltrName, fltrCaption: i.fltrCaption,
                    fltrMaxLen: i.fltrMaxLen, fltrMin: i.fltrMin, fltrMax: i.fltrMax,
                    fltrFlx: i.fltrFlx, fltrMd: i.fltrMd, fltrSm: i.fltrSm, fltrXs: i.fltrXs
                };
                this.resetVldtrs(flt);
                if ((k > -1) && (!(typeof this.externalFilterEx[k].fltrValue === 'undefined'))) flt.fltrValue.reset({ value: this.externalFilterEx[k].fltrValue, disabled: false });
                wsfd.push(flt);
            });
            this.webServiceFilters = wsfd;
            let indx: number = 0;
            this.webServiceFilters.forEach((flt: IUniqServiceFilter) => {
              if((flt.fltrDataType === 'boolean') || (flt.fltrDataType === 'bool')) {
                if ((typeof flt.fltrValue.value === 'undefined') || (flt.fltrValue.value === null)) flt.fltrValue.patchValue(false, {emitEvent: false});
                flt.fltrValue.valueChanges.subscribe({next: (e: any) => this.afterObjSel.emit({v:null, i: indx}) });
              } else if ((flt.fltrDataType === 'datetime'))  {
                if (typeof flt.fltrValue.value === 'undefined') flt.fltrValue.patchValue(null, {emitEvent: false});
                flt.fltrValue.valueChanges.subscribe({next: (e: any) => this.afterObjSel.emit({v:null, i: indx}) });
              } else {
                this.tpahVlChngs(flt.fltrValue, indx);
              }
              indx = indx + 1;
            });
        } else {
            this.webServiceFilters = [];
        }
        this.cd.detectChanges();
    }

    resetVldtrs(flt: IUniqServiceFilter) {
        if (typeof flt === 'undefined') {
            return;
        } else if (flt === null)  {
            return;
        } 

        let validators: ValidatorFn[] = []; 

        if (!(typeof flt.fltrMaxLen === 'undefined')) {
            if (!(flt.fltrMaxLen === null)) {
            validators.push(Validators.maxLength(flt.fltrMaxLen));
            }
        }
        if (!(typeof flt.fltrMax === 'undefined')) {
            if (!(flt.fltrMax === null)) {
            validators.push(Validators.max(flt.fltrMax));
            }
        }
        if (!(typeof flt.fltrMin === 'undefined')) {
            if (!(flt.fltrMin === null)) {
            validators.push(Validators.min(flt.fltrMin));
            }
        }
        flt.fltrValue.setValidators([]);
        switch(flt.fltrDataType) {
            case '':
                flt.fltrValue.reset({ value: null, disabled: true });
                break;
            case 'int16':
            case 'int32':
            case 'int64':
            case 'uint16':
            case 'uint32':
            case 'uint64':
                flt.fltrValue.reset({ value: null, disabled: false });
                validators.push(Validators.pattern(/^[-+]?\d+$/));
                flt.fltrValue.setValidators(validators);
                break;
            case 'double':
            case 'decimal':
            case 'single':
                flt.fltrValue.reset({ value: null, disabled: false });
                validators.push(Validators.pattern(/^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$/));
                flt.fltrValue.setValidators(validators);
                break;
            case 'guid':
                flt.fltrValue.reset({ value: '', disabled: false });
                //validators.push(Validators.pattern(/(?im)^[{(]?[0-9A-F]{8}[-]?(?:[0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?$/));
                flt.fltrValue.setValidators(validators);
                break;
            case 'datetime':
                flt.fltrValue.reset({ value: null, disabled: false });
                flt.fltrValue.setValidators(validators);
                break;
            default:
                flt.fltrValue.reset({ value: null, disabled: false });
                flt.fltrValue.setValidators(validators);
                break;
        }
        flt.fltrValue.updateValueAndValidity(); // must be called after resetting validators
    }

    removeAllFilters() {
        let i: number = this.webServiceFilters.length;
        if (i > 1) {
          this.webServiceFilters.splice(1, i-1);
        }
    }

    getErrorMessage(fc: FormControl): string {
        let rslt: string = 'Filter item will not be applied.';
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
            case 'max':
              rslt += ' ' + $localize`:The value must be less than@@UniqServiceFilterComponent.The-value-must-be-less-than:The value must be less than` + ': ' + errs[k].max;
              break;
            case 'min':
              rslt += ' ' + $localize`:The value must be greater than@@UniqServiceFilterComponent.The-value-must-be-greater-than:The value must be greater than` + ': ' + errs[k].max;
              break;
            case 'pattern':
              rslt += ' ' + $localize`:Icorrect format@@UniqServiceFilterComponent.Icorrect-format:Icorrect format` + ': ' + errs[k].max;
              break;
            case 'matDatepickerMin':
              rslt += ' ' + $localize`:Value must be greater than@@UniqServiceFilterComponent.Value-must-be-greater-than:Value must be greater than` + ': ' + errs[k].max;
              break;
            case 'matDatepickerMax':
              rslt += ' ' + $localize`:Value must be less than@@UniqServiceFilterComponent.Value-must-be-less-than:Value must be less than` + ': ' + errs[k].max;
              break;
            case 'matDatepickerParse':
              rslt += ' ' + $localize`:Icorrect date format@@UniqServiceFilterComponent.Icorrect-date-format:Icorrect date format` + '.';
              break;
            default:
              rslt += ' ' + $localize`:Icorrect format@@UniqServiceFilterComponent.Icorrect-format2:Icorrect format` + '.';
              rslt +=' Icorrect format.' ;
              break;
          }
        });
        return rslt;
    }

    onApplyFilterClicked(): void {
        let result: Array<IWebServiceFilterRslt> = [];
        let notIgnor: boolean = true;
        let msg: string = 'The following properties will be ignored: ';
        let showMsg: boolean = false;
        this.webServiceFilters.forEach(i => {
          if (i.fltrValue.enabled) {
            if(i.fltrValue.valid) {
                if(notIgnor) {
                    result.push({fltrName: i.fltrName, fltrDataType: i.fltrDataType, fltrOperator: 'eq', fltrValue: i.fltrValue.value});
                } else {
                    msg = msg + i.fltrCaption + '; ';
                    showMsg = true;
                }
            } else notIgnor = false;
          } else notIgnor = false;
        });
        if(showMsg) this.appGlblSettings.showError('input', { message: msg });
        this.onApplyFilter.emit(result);
    }

    externalFilterEx: Array<IWebServiceFilterRslt> = [];
    protected _externalFilter: Array<IWebServiceFilterRslt> = [];
    @Input('external-filter') 
    get externalFilter(): Array<IWebServiceFilterRslt> {
        return this._externalFilter;
    }
    set externalFilter(ef: Array<IWebServiceFilterRslt>|any) {
        this._externalFilter = ef;
        let isNDf = (typeof ef === 'undefined');
        isNDf = isNDf ? isNDf : (ef === null);
        isNDf = isNDf ? isNDf : (!Array.isArray(ef));
        if(isNDf) {
          if(this.externalFilterEx.length > 0) {
            this.externalFilterEx = [];
            if(this.isOnInitCalled) {
              this.onFilterDefsChanged();
            }
          }
        } else {
          this.externalFilterEx = [];
          ef.forEach((fi: IWebServiceFilterRslt) => {
            this.externalFilterEx.push({fltrName: fi.fltrName, fltrDataType: fi.fltrDataType, fltrOperator: fi.fltrOperator, fltrValue:fi.fltrValue});
          });
          if(this.isOnInitCalled) {
            this.onFilterDefsChanged();
          }
      }
    }


    tpAheadVars0: Observable<Array<any>>| any = null;
    tpAheadVars1: Observable<Array<any>>| any = null;
    tpAheadVars2: Observable<Array<any>>| any = null;
    tpAheadVars3: Observable<Array<any>>| any = null;
    tpAheadVars4: Observable<Array<any>>| any = null;
    tpAheadVars5: Observable<Array<any>>| any = null;
    tpAheadVars6: Observable<Array<any>>| any = null;

    @Input('tp-ahead-val') tpAheadVal!: (v: any, i: number) => any;
    @Input('tp-ahead-fnc') tpAheadFnc!: (srv: any, wsfs: Array<IUniqServiceFilter>, value: any, i: number) => Observable<Array<any>>;
    @Input('tp-ahead-cptn') tpAheadCptn!: (v: any, i: number) => string;
    clrTpAheadVars(): void {
      this.tpAheadVars0 = null;
      this.tpAheadVars1 = null;
      this.tpAheadVars2 = null;
      this.tpAheadVars3 = null;
      this.tpAheadVars4 = null;
      this.tpAheadVars5 = null;
      this.tpAheadVars6 = null;
    }

    tpahVlChngs(fc: FormControl, indx: number): void {
      let pp: Observable<Array<any>> = fc.valueChanges.pipe(
          debounceTime(100),
          switchMap((value: any) => {
            if(typeof value === 'string') {  
                if(typeof this.tpAheadFnc === 'undefined') {
                  return of([]);      
                } 
                if(this.tpAheadFnc === null) {
                  return of([]);      
                } 
                this.afterObjSel.emit({v:null, i: indx});
                return this.tpAheadFnc(this.webServiceFilterDefs[indx].fltrSrv, this.webServiceFilters, value, indx)
            } else {
                this.patchcontrols(value, indx);
            }
            return of([]);
          })
      );
      switch(indx) {
        case 0:
          this.tpAheadVars0 = pp;
          break;
        case 1:
          this.tpAheadVars1 = pp;
          break;
        case 2:
          this.tpAheadVars2 = pp;
          break;
        case 3:
          this.tpAheadVars3 = pp;
          break;
        case 4:
          this.tpAheadVars4 = pp;
          break;
        case 5:
          this.tpAheadVars5 = pp;
          break;
        case 6:
          this.tpAheadVars6 = pp;
          break;
      }
    }
    patchcontrols(val: any, pos: number): void {
      this.afterObjSel.emit({v:val, i: pos});
      if (typeof this.tpAheadVal === 'undefined') 
        return;
      this.webServiceFilters.forEach((f: IUniqServiceFilter, indx: number) => {
         if ((pos === indx) || this.notifyAll) {
          f.fltrValue.patchValue( this.tpAheadVal(val, indx), {emitEvent: false});
         }
      });
    }
    @Output('after-obj-sel') afterObjSel = new EventEmitter<any>();
    @Input('notify-all') notifyAll: boolean = false;

}

