
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

import { IPhbkPhoneView } from 'phonebook-interfaces';
// import { IPhbkPhoneViewPage } from 'phonebook-interfaces';
// import { IPhbkPhoneViewFilter } from 'phonebook-interfaces';
import { PhbkPhoneViewService } from 'phonebook-services';
import { PhbkPhoneViewDatasource } from 'phonebook-services';


@Component({
  selector: 'app-phbk-phone-view-vform',
  templateUrl: './phbk-phone-view-vform.component.html',
  styleUrls: ['./phbk-phone-view-vform.component.css']
})
export class PhbkPhoneViewVformComponent implements OnInit, OnDestroy, IEventEmitterPub {

    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@PhbkPhoneViewVformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Review Phone@@PhbkPhoneViewVformComponent.Review-Item:Review Phone`,
        'title': $localize`:Select Item@@PhbkPhoneViewVformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@PhbkPhoneViewVformComponent.Not-all-masters:Not all masters have been set`,
        'PhoneId-label': $localize`:Phone Id@@PhbkPhoneView.PhoneId-label:Phone Id`,
        'PhoneId-hint': $localize`:Enter Phone Id@@PhbkPhoneView.PhoneId-hint:Enter Phone Id`,
        'PhoneId-placeholder': $localize`:Phone Id@@PhbkPhoneView.PhoneId-placeholder:Phone Id`,
        'Phone-label': $localize`:Phone@@PhbkPhoneView.Phone-label:Phone`,
        'Phone-hint': $localize`:Enter Phone@@PhbkPhoneView.Phone-hint:Enter Phone`,
        'Phone-placeholder': $localize`:Phone@@PhbkPhoneView.Phone-placeholder:Phone`,
        'PPhoneTypeName-label': $localize`:Phone Type Name@@PhbkPhoneView.PPhoneTypeName-label:Phone Type Name`,
        'PPhoneTypeName-hint': $localize`:Enter Phone Type Name@@PhbkPhoneView.PPhoneTypeName-hint:Enter Phone Type Name`,
        'PPhoneTypeName-placeholder': $localize`:Phone Type Name@@PhbkPhoneView.PPhoneTypeName-placeholder:Phone Type Name`,
        'EEmpLastName-label': $localize`:Employee Last Name@@PhbkPhoneView.EEmpLastName-label:Employee Last Name`,
        'EEmpLastName-hint': $localize`:Enter Employee Last Name@@PhbkPhoneView.EEmpLastName-hint:Enter Employee Last Name`,
        'EEmpLastName-placeholder': $localize`:Employee Last Name@@PhbkPhoneView.EEmpLastName-placeholder:Employee Last Name`,
        'EEmpFirstName-label': $localize`:Employee First Name@@PhbkPhoneView.EEmpFirstName-label:Employee First Name`,
        'EEmpFirstName-hint': $localize`:Enter Employee First Name@@PhbkPhoneView.EEmpFirstName-hint:Enter Employee First Name`,
        'EEmpFirstName-placeholder': $localize`:Employee First Name@@PhbkPhoneView.EEmpFirstName-placeholder:Employee First Name`,
        'EEmpSecondName-label': $localize`:Employee Second Name@@PhbkPhoneView.EEmpSecondName-label:Employee Second Name`,
        'EEmpSecondName-hint': $localize`:Enter Employee Second Name@@PhbkPhoneView.EEmpSecondName-hint:Enter Employee Second Name`,
        'EEmpSecondName-placeholder': $localize`:Employee Second Name@@PhbkPhoneView.EEmpSecondName-placeholder:Employee Second Name`,
        'EDDivisionName-label': $localize`:Name of the Division@@PhbkPhoneView.EDDivisionName-label:Name of the Division`,
        'EDDivisionName-hint': $localize`:Enter Division Name@@PhbkPhoneView.EDDivisionName-hint:Enter Division Name`,
        'EDDivisionName-placeholder': $localize`:Name of the Division@@PhbkPhoneView.EDDivisionName-placeholder:Name of the Division`,
        'EDEEntrprsName-label': $localize`:Name of the Enterprise@@PhbkPhoneView.EDEEntrprsName-label:Name of the Enterprise`,
        'EDEEntrprsName-hint': $localize`:Enter Enterprise Name@@PhbkPhoneView.EDEEntrprsName-hint:Enter Enterprise Name`,
        'EDEEntrprsName-placeholder': $localize`:Name of the Enterprise@@PhbkPhoneView.EDEEntrprsName-placeholder:Name of the Enterprise`,
        'EmployeeIdRef-label': $localize`:Id of the Employee@@PhbkPhoneView.EmployeeIdRef-label:Id of the Employee`,
        'EmployeeIdRef-hint': $localize`:Enter Employee  Id@@PhbkPhoneView.EmployeeIdRef-hint:Enter Employee  Id`,
        'EmployeeIdRef-placeholder': $localize`:Id of the Employee@@PhbkPhoneView.EmployeeIdRef-placeholder:Id of the Employee`,
        'PhoneTypeIdRef-label': $localize`:Phone Type Id@@PhbkPhoneView.PhoneTypeIdRef-label:Phone Type Id`,
        'PhoneTypeIdRef-hint': $localize`:Enter Phone Type Id@@PhbkPhoneView.PhoneTypeIdRef-hint:Enter Phone Type Id`,
        'PhoneTypeIdRef-placeholder': $localize`:Phone Type Id@@PhbkPhoneView.PhoneTypeIdRef-placeholder:Phone Type Id`,
    }

    
    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IPhbkPhoneView>();
    public doSubmit(): void {
        if (this.mainFormGroup.invalid || (!this.rootDataSource.refreshIsDefined())) {
            this.mainFormGroup.markAllAsTouched();
            this.appGlblSettings.showError('http', {message: this.frases['Not-all-props']});
            return;
        }
        let data: IPhbkPhoneView = this.rootDataSource.values2Interface();
        this.beforeSubmit.emit(data);
        this.afterSubmit.emit(data);
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
    public rootDataSource: PhbkPhoneViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IPhbkPhoneView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IPhbkPhoneView | any {
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
                this.rootDataSource.doEmitEvent();
            }
        } 

    // end: input variable declaration section


    constructor(private frmSrvPhbkPhoneView: PhbkPhoneViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        locValidators = [ ];
        this.mainFormGroup.addControl('phoneId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('phone', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('pPhoneTypeName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(40),Validators.minLength(3) ];
        this.mainFormGroup.addControl('eEmpLastName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(25),Validators.minLength(3) ];
        this.mainFormGroup.addControl('eEmpFirstName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.maxLength(25) ];
        this.mainFormGroup.addControl('eEmpSecondName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('eDDivisionName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('eDEEntrprsName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('employeeIdRef', new FormControl({ value: null, disabled: true}, locValidators));
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('phoneTypeIdRef', new FormControl({ value: null, disabled: true}, locValidators));
        this.rootDataSource = new PhbkPhoneViewDatasource (this.frmSrvPhbkPhoneView,
            this.appGlblSettings, null, null, [],'');
        this.rootDataSource.setIsNew(false);
        this._Subscriptions.push(
            this.rootDataSource
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceAfterPropsChanged(v) } })
        );
//        this._Subscriptions.push(this.rootDataSource.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnIsDefinedChanged(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnUpdate.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnUpdate(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnAdd.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnAdd(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnDelete.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnDelete(v) } }));
    }
//    public rootDataSourceOnUpdate(v: IViewModelDatasource): void { }
//    public rootDataSourceOnAdd(v: IViewModelDatasource): void { }
//    public rootDataSourceOnDelete(v: IViewModelDatasource): void { }
//    public rootDataSourceOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public rootDataSourceAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'phoneId': this.rootDataSource.getValue('phoneId')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'phone': this.rootDataSource.getValue('phone')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'pPhoneTypeName': this.rootDataSource.getValue('pPhoneTypeName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eEmpLastName': this.rootDataSource.getValue('eEmpLastName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eEmpFirstName': this.rootDataSource.getValue('eEmpFirstName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eEmpSecondName': this.rootDataSource.getValue('eEmpSecondName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eDDivisionName': this.rootDataSource.getValue('eDDivisionName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eDEEntrprsName': this.rootDataSource.getValue('eDEEntrprsName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'employeeIdRef': this.rootDataSource.getValue('employeeIdRef')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'phoneTypeIdRef': this.rootDataSource.getValue('phoneTypeIdRef')}, {emitEvent: false});
    }
    

} // the end of the PhbkPhoneViewVformComponent class body


