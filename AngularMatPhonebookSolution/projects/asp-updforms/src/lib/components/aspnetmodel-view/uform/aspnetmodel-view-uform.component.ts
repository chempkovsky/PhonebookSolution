
import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { FormControl, Validators, ValidatorFn, FormGroup, AbstractControl, ValidationErrors } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs/internal/Observable';
import { switchMap,  catchError, debounceTime } from 'rxjs/operators';
import { of } from 'rxjs/internal/observable/of';
import { MatFormFieldAppearance } from '@angular/material/form-field';
import { Subscription } from 'rxjs';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';
import { IViewModelDatasource } from 'common-interfaces';

import { IaspnetmodelView } from 'asp-interfaces';
// import { IaspnetmodelViewPage } from 'asp-interfaces';
// import { IaspnetmodelViewFilter } from 'asp-interfaces';
import { AspnetmodelViewService } from 'asp-services';
import { AspnetmodelViewDatasource } from 'asp-services';


@Component({
  selector: 'app-aspnetmodel-view-uform',
  templateUrl: './aspnetmodel-view-uform.component.html',
  styleUrls: ['./aspnetmodel-view-uform.component.css']
})
export class AspnetmodelViewUformComponent implements OnInit, OnDestroy, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@AspnetmodelViewUformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Update Model@@AspnetmodelViewUformComponent.Update-Item:Update Model`,
        'title': $localize`:Select Item@@AspnetmodelViewUformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@AspnetmodelViewUformComponent.Not-all-masters:Not all masters have been set`,
        'ModelPk-label': $localize`:Model Id@@aspnetmodelView.ModelPk-label:Model Id`,
        'ModelPk-hint': $localize`:Enter Model Id@@aspnetmodelView.ModelPk-hint:Enter Model Id`,
        'ModelPk-placeholder': $localize`:Model Id@@aspnetmodelView.ModelPk-placeholder:Model Id`,
        'ModelName-label': $localize`:Model Name@@aspnetmodelView.ModelName-label:Model Name`,
        'ModelName-hint': $localize`:Enter ModelName@@aspnetmodelView.ModelName-hint:Enter ModelName`,
        'ModelName-placeholder': $localize`:Model Name@@aspnetmodelView.ModelName-placeholder:Model Name`,
        'ModelDescription-label': $localize`:Model Description@@aspnetmodelView.ModelDescription-label:Model Description`,
        'ModelDescription-hint': $localize`:Enter ModelDescription@@aspnetmodelView.ModelDescription-hint:Enter ModelDescription`,
        'ModelDescription-placeholder': $localize`:Model Description@@aspnetmodelView.ModelDescription-placeholder:Model Description`,
    }

    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IaspnetmodelView>();
    public doSubmit(): void {
        if (this.mainFormGroup.invalid || (!this.rootDataSource.refreshIsDefined())) {
            this.mainFormGroup.markAllAsTouched();
            this.appGlblSettings.showError('http', {message: this.frases['Not-all-props']});
            return;
        }
        this.beforeSubmit.emit(this.rootDataSource.values2Interface());
        this.rootDataSource.updateone();
    }
    public rootDataSourceOnUpdate(v: IViewModelDatasource): void { 
        this.afterSubmit.emit(this.rootDataSource.values2Interface());
    }
    ngOnDestroy(): void {
        this._Subscriptions.forEach((s: Subscription) => { s.unsubscribe(); });
    }
    ngOnInit(): void {
        this.ngOnInitCalled = true;
        this.rootDataSource.refresh();
    }
    public getErrorMessage(fc: AbstractControl): string {
        return this.appGlblSettings.getValidationErrorMessage(fc);
    } 
    // start: variable declaration section
    @Input('caption') caption: string|any = this.frases['caption'];
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
    public appearance: MatFormFieldAppearance = 'outline';
    private ngOnInitCalled: boolean = false;
    public mainFormGroup: FormGroup|any = null;
    public rootDataSource: AspnetmodelViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IaspnetmodelView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IaspnetmodelView | any {
            return this.rootDataSource.values2Interface();
        } // end of get eformControlModel
    @Input('hidden-filter') 
        get hiddenFilter(): Array<IWebServiceFilterRslt> {
          return this.rootDataSource.getHiddenFilterAsFltRslt();
        }
        set hiddenFilter(inDef: Array<IWebServiceFilterRslt>) {
            this.rootDataSource.setHiddenFilter(this.rootDataSource.getHiddenFilterByFltRslt(inDef));
            let hasChanged: boolean = this.rootDataSource.updateByHiddenFilterFields(false);
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.doEmitEvent(false);
            }
        } 

    // end: input variable declaration section


    constructor(private frmSrvaspnetmodelView: AspnetmodelViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        let v: any;
        let frmcntrl: FormControl|any;
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('modelPk', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(50),Validators.minLength(1) ];
        frmcntrl = new FormControl({ value: null, disabled: false}, locValidators);
        this.mainFormGroup.addControl('modelName', frmcntrl);
        frmcntrl.valueChanges.subscribe({next: (val: any) => { 
            this.rootDataSource.setValue('modelName', val);
        }});
        locValidators = [ Validators.maxLength(50),Validators.minLength(1) ];
        frmcntrl = new FormControl({ value: null, disabled: false}, locValidators);
        this.mainFormGroup.addControl('modelDescription', frmcntrl);
        frmcntrl.valueChanges.subscribe({next: (val: any) => { 
            this.rootDataSource.setValue('modelDescription', val);
        }});
        this.rootDataSource = new AspnetmodelViewDatasource (this.frmSrvaspnetmodelView,
            this.appGlblSettings, null, null, [],'');
        this.rootDataSource.setIsNew(false);
        this._Subscriptions.push(
            this.rootDataSource
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceAfterPropsChanged(v) } })
        );
//        this._Subscriptions.push(this.rootDataSource.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(this.rootDataSource.OnUpdate.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnUpdate(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnAdd.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnAdd(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnDelete.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnDelete(v) } }));
    }
//    public rootDataSourceOnUpdate(v: IViewModelDatasource): void { }
//    public rootDataSourceOnAdd(v: IViewModelDatasource): void { }
//    public rootDataSourceOnDelete(v: IViewModelDatasource): void { }
//    public rootDataSourceOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public rootDataSourceAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'modelPk': this.rootDataSource.getValue('modelPk')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'modelName': this.rootDataSource.getValue('modelName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'modelDescription': this.rootDataSource.getValue('modelDescription')}, {emitEvent: false});
    }
    

} // the end of the AspnetmodelViewUformComponent class body


