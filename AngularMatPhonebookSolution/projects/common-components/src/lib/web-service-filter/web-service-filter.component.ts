import { Component, OnInit, Input, Output, EventEmitter, ChangeDetectorRef } from '@angular/core';
import { FormControl, Validators, ValidatorFn, ValidationErrors } from '@angular/forms';
import { MatFormFieldAppearance } from '@angular/material/form-field';

import { IWebServiceFilter } from 'common-interfaces';
import { IWebServiceFilterDef } from 'common-interfaces';
import { IWebServiceFilterOperator } from 'common-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { AppGlblSettingsService } from 'common-services';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';


import { MatSelectChange } from '@angular/material/select';


@Component({
  selector: 'app-web-service-filter',
  templateUrl: './web-service-filter.component.html',
  styleUrls: ['./web-service-filter.component.css']
})
export class WebServiceFilterComponent implements OnInit, IEventEmitterPub {
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

    hiddenFilterEx: Array<IWebServiceFilterRslt> = [];
    protected _hiddenFilter: Array<IWebServiceFilterRslt> = [];
    @Input('hidden-filter') 
        get hiddenFilter(): Array<IWebServiceFilterRslt>|any {
          return this._hiddenFilter;
        }
        set hiddenFilter(inDef: Array<IWebServiceFilterRslt>|any) {
          this._hiddenFilter = inDef;
          if (typeof inDef === 'undefined') {
            this.hiddenFilterEx = [];
          } else if(!Array.isArray(inDef)) {
            this.hiddenFilterEx = [];
          } else {
            this.hiddenFilterEx = inDef as Array<IWebServiceFilterRslt>;
          }
          if(this.isOnInitCalled) {
            this.onFilterDefsChanged();
          }
        } 

    inputFilterDefsEx: Array<IWebServiceFilterDef> = [];
    protected _inputFilterDefs: Array<IWebServiceFilterDef> = [];
    @Input('filter-defs') 
        get inputFilterDefs(): Array<IWebServiceFilterDef> {
          return this._inputFilterDefs;
        }
        set inputFilterDefs(inDef: Array<IWebServiceFilterDef>) {
          this._inputFilterDefs = inDef;
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
  
    webServiceFilterDefs: Array<IWebServiceFilterDef> = [];
    webServiceOperators: Array<IWebServiceFilterOperator> = [];
    webServiceFilters: Array<IWebServiceFilter> = [];

    constructor(protected appGlblSettings: AppGlblSettingsService, private cd: ChangeDetectorRef) { 
        this.appearance = this.appGlblSettings.appearance;
    }

    ngOnInit(): void {
        this.webServiceOperators = [
            {oName: 'eq', oCaption: '=='},
            {oName: 'gt', oCaption: '>='},
            {oName: 'lt', oCaption: '=<'},
            {oName: 'ne', oCaption: '<>'},
            {oName: 'lk', oCaption: 'Like'}
        ];
        this.onFilterDefsChanged();
        this.isOnInitCalled = true;
        this.cd.detectChanges();
    }

    onFilterDefsChanged(): void {
        this.webServiceFilterDefs = [{fltrName: '', fltrCaption: '--No filter--',  fltrDataType: '', fltrMaxLen: null, fltrMin: null, fltrMax: null }];
        this.inputFilterDefsEx.forEach(i => {
            if(this.hiddenFilterEx.findIndex((h: { fltrName: string; }) => { return (h.fltrName === i.fltrName); }) < 0) {
            this.webServiceFilterDefs.push({ fltrName: i.fltrName, fltrCaption: i.fltrCaption, fltrDataType: i.fltrDataType, fltrMaxLen: i.fltrMaxLen, fltrMin: i.fltrMin, fltrMax: i.fltrMax });
            }
        });    
        if(this.showFilter) {
            this.webServiceFilters = [];
            this.externalFilterEx.forEach((fi: IWebServiceFilterRslt) => {
                let i: number = this.inputFilterDefsEx.findIndex((h: { fltrName: string; }) => { return (h.fltrName === fi.fltrName); });
                if(i > -1) {
                  let fDf: IWebServiceFilterDef = this.inputFilterDefsEx[i];
                  this.webServiceFilters.push({ fltrName: new FormControl(fDf.fltrName), fltrDataType: fDf.fltrDataType, 
                      fltrOperator: new FormControl(fi.fltrOperator), fltrValue: new FormControl({ value: fi.fltrValue, disabled: false }), 
                      fltrMaxLen: fDf.fltrMaxLen, fltrMin: fDf.fltrMin, fltrMax: fDf.fltrMax });
                }
            });
            if(this.webServiceFilters.length < 1) {
                const fltDef: IWebServiceFilterDef = this.webServiceFilterDefs[0];
                const fltOp: IWebServiceFilterOperator = this.webServiceOperators[0];
                this.webServiceFilters = [
                    { fltrName: new FormControl(fltDef.fltrName), fltrDataType: fltDef.fltrDataType, 
                    fltrOperator: new FormControl(fltOp.oName), fltrValue: new FormControl({ value: null, disabled: true }), 
                    fltrMaxLen: fltDef.fltrMaxLen, fltrMin: fltDef.fltrMin, fltrMax: fltDef.fltrMax }
                ];
            }
        } else {
            this.webServiceFilters = [];
        }
    }

    addFilter() {
        const fltDef: IWebServiceFilterDef = this.webServiceFilterDefs[0];
        const fltOp: IWebServiceFilterOperator = this.webServiceOperators[0];

        let item: IWebServiceFilter = { fltrName: new FormControl(fltDef.fltrName), fltrDataType: fltDef.fltrDataType, fltrOperator: new FormControl(fltOp.oName), 
          fltrValue: new FormControl({ value: null, disabled: true }), fltrMaxLen: fltDef.fltrMaxLen, fltrMin: fltDef.fltrMin, fltrMax: fltDef.fltrMax };
        this.webServiceFilters.push(item);
    }

    onSelectionChanged(event: MatSelectChange, flt: IWebServiceFilter) {
        if ((typeof flt === 'undefined') || (typeof event === 'undefined')) return;
        if (typeof event.value === 'undefined')  return;
        if ((flt === null) || (event.value === null))  return;

        let itm: IWebServiceFilterDef | any = this.webServiceFilterDefs.find((e,i,a) => {
            return (e.fltrName === event.value);
        });
        if(typeof itm === 'undefined') {
            itm = this.webServiceFilterDefs[0];
        } else if (itm === null) {
            itm = this.webServiceFilterDefs[0];
        } 

        if (!(typeof itm === 'undefined')) {
            if(!(itm === null)) {
            flt.fltrDataType = itm.fltrDataType;
            flt.fltrMaxLen = itm.fltrMaxLen;
            flt.fltrMax = itm.fltrMax;
            flt.fltrMin = itm.fltrMin;
            let validators: ValidatorFn[] = []; 

            if (!(typeof itm.fltrMaxLen === 'undefined')) {
                if (!(itm.fltrMaxLen === null)) {
                validators.push(Validators.maxLength(itm.fltrMaxLen));
                }
            }
            if (!(typeof itm.fltrMax === 'undefined')) {
                if (!(itm.fltrMax === null)) {
                validators.push(Validators.max(itm.fltrMax));
                }
            }
            if (!(typeof itm.fltrMin === 'undefined')) {
                if (!(itm.fltrMin === null)) {
                validators.push(Validators.min(itm.fltrMin));
                }
            }
            flt.fltrValue.setValidators([]);
            switch(itm.fltrDataType) {
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
        }
    }

    removeFltr(wsfdDef: IWebServiceFilter) {
        if(typeof wsfdDef === 'undefined') return;
        if (this.webServiceFilters.length < 2) return;
        const i = this.webServiceFilters.indexOf(wsfdDef);
        if (i >= 0) {
          this.webServiceFilters.splice(i, 1);
        }
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
              rslt += ' ' + $localize`:The value must be less than@@WebServiceFilterComponent.The-value-must-be-less-than:The value must be less than` + ': ' + errs[k].max;
              break;
            case 'min':
              rslt += ' ' + $localize`:The value must be greater than@@WebServiceFilterComponent.The-value-must-be-greater-than:The value must be greater than` + ': ' + errs[k].max;
              break;
            case 'pattern':
              rslt += ' ' + $localize`:Icorrect format@@WebServiceFilterComponent.Icorrect-format:Icorrect format` + ': ' + errs[k].max;
              break;
            case 'matDatepickerMin':
              rslt += ' ' + $localize`:Value must be greater than@@WebServiceFilterComponent.Value-must-be-greater-than:Value must be greater than` + ': ' + errs[k].max;
              break;
            case 'matDatepickerMax':
              rslt += ' ' + $localize`:Value must be less than@@WebServiceFilterComponent.Value-must-be-less-than:Value must be less than` + ': ' + errs[k].max;
              break;
            case 'matDatepickerParse':
              rslt += ' ' + $localize`:Icorrect date format@@WebServiceFilterComponent.Icorrect-date-format:Icorrect date format` + '.';
              break;
            default:
              rslt += ' ' + $localize`:Icorrect format@@AppGlblSettingsService.Icorrect-format2:Icorrect format` + '.';
              break;
          }
        });
        return rslt;
    }

    onApplyFilterClicked(): void {
        let result: Array<IWebServiceFilterRslt> = [];
        this.hiddenFilterEx.forEach((i: IWebServiceFilterRslt) => {
          result.push(i);
        });
        this.webServiceFilters.forEach(i => {
          if (i.fltrValue.enabled) {
            if(i.fltrValue.valid) {
              result.push({fltrName: i.fltrName.value, fltrDataType: i.fltrDataType, fltrOperator: i.fltrOperator.value, fltrValue: i.fltrValue.value});
            }
          }
        });
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

}

