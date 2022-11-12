
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

import { IPhbkPhoneTypeView } from 'phonebook-interfaces';
// import { IPhbkPhoneTypeViewPage } from 'phonebook-interfaces';
// import { IPhbkPhoneTypeViewFilter } from 'phonebook-interfaces';
import { PhbkPhoneTypeViewService } from 'phonebook-services';
import { PhbkPhoneTypeViewDatasource } from 'phonebook-services';

import { IPhbkEmployeeView } from 'phonebook-interfaces';
// import { IPhbkEmployeeViewPage } from 'phonebook-interfaces';
// import { IPhbkEmployeeViewFilter } from 'phonebook-interfaces';
import { PhbkEmployeeViewService } from 'phonebook-services';
import { PhbkEmployeeViewDatasource } from 'phonebook-services';

import { IPhbkDivisionView } from 'phonebook-interfaces';
// import { IPhbkDivisionViewPage } from 'phonebook-interfaces';
// import { IPhbkDivisionViewFilter } from 'phonebook-interfaces';
import { PhbkDivisionViewService } from 'phonebook-services';
import { PhbkDivisionViewDatasource } from 'phonebook-services';

import { IPhbkEnterpriseView } from 'phonebook-interfaces';
// import { IPhbkEnterpriseViewPage } from 'phonebook-interfaces';
// import { IPhbkEnterpriseViewFilter } from 'phonebook-interfaces';
import { PhbkEnterpriseViewService } from 'phonebook-services';
import { PhbkEnterpriseViewDatasource } from 'phonebook-services';

import { IPhbkPhoneView } from 'phonebook-interfaces';
// import { IPhbkPhoneViewPage } from 'phonebook-interfaces';
// import { IPhbkPhoneViewFilter } from 'phonebook-interfaces';
import { PhbkPhoneViewService } from 'phonebook-services';
import { PhbkPhoneViewDatasource } from 'phonebook-services';

import { PhbkEmployeeViewSdlgComponent } from 'phonebook-sforms';
import { IPhbkEmployeeViewDlg } from 'phonebook-sforms';
import { PhbkDivisionViewSdlgComponent } from 'phonebook-sforms';
import { IPhbkDivisionViewDlg } from 'phonebook-sforms';
import { PhbkEnterpriseViewSdlgComponent } from 'phonebook-sforms';
import { IPhbkEnterpriseViewDlg } from 'phonebook-sforms';

@Component({
  selector: 'app-phbk-phone-view-uform',
  templateUrl: './phbk-phone-view-uform.component.html',
  styleUrls: ['./phbk-phone-view-uform.component.css']
})
export class PhbkPhoneViewUformComponent implements OnInit, OnDestroy, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@PhbkPhoneViewUformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Update Phone@@PhbkPhoneViewUformComponent.Update-Item:Update Phone`,
        'title': $localize`:Select Item@@PhbkPhoneViewUformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@PhbkPhoneViewUformComponent.Not-all-masters:Not all masters have been set`,
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
            this.pPhoneTypeNameCmbCntrl.markAllAsTouched();
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
        this.pPhoneTypeNameDtSrc.AfterMasterChanged.emit(this.pPhoneTypeNameDtSrc);
        this.eDEEntrprsNameDtSrc.AfterMasterChanged.emit(this.eDEEntrprsNameDtSrc);
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
    public pPhoneTypeNameCmbCntrl: FormControl | any = null;
    public pPhoneTypeNameCmbCntrlVals : Array<IPhbkPhoneTypeView> | any = null;
    public pPhoneTypeNameDtSrc: PhbkPhoneTypeViewDatasource | any = null;
    public eEmpLastNameBttnDsnbl: boolean = true;
    public eEmpLastNameDtSrc: PhbkEmployeeViewDatasource | any = null;
    public eDDivisionNameBttnDsnbl: boolean = true;
    public eDDivisionNameDtSrc: PhbkDivisionViewDatasource | any = null;
    public eDEEntrprsNameBttnDsnbl: boolean = true;
    public eDEEntrprsNameDtSrc: PhbkEnterpriseViewDatasource | any = null;

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
                this.rootDataSource.doEmitEvent(false);
            }
        } 

    // end: input variable declaration section


    constructor(private frmSrvPhbkPhoneTypeView: PhbkPhoneTypeViewService, private frmSrvPhbkEmployeeView: PhbkEmployeeViewService, private frmSrvPhbkDivisionView: PhbkDivisionViewService, private frmSrvPhbkEnterpriseView: PhbkEnterpriseViewService, private frmSrvPhbkPhoneView: PhbkPhoneViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        let v: any;
        let frmcntrl: FormControl|any;
        locValidators = [ ];
        this.mainFormGroup.addControl('phoneId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        frmcntrl = new FormControl({ value: null, disabled: false}, locValidators);
        this.mainFormGroup.addControl('phone', frmcntrl);
        frmcntrl.valueChanges.subscribe({next: (val: any) => { 
            this.rootDataSource.setValue('phone', val);
        }});
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('pPhoneTypeName', new FormControl({ value: null, disabled: false}, locValidators));
        this.pPhoneTypeNameCmbCntrl = new FormControl({ value: null, disabled: true }, [ 
                (fc)=>{  //if ((typeof fc.value === 'string') || (typeof fc.value === 'undefined') || (fc.value === null)) { 
                        if (!this.pPhoneTypeNameDtSrc.calcIsDefined()) {
                            this.mainFormGroup.patchValue({'pPhoneTypeName': null });
                            return  this.mainFormGroup.controls['pPhoneTypeName'].errors; 
                        }  
                        return null; }]);
        this.pPhoneTypeNameCmbCntrl.valueChanges
            .subscribe({
                next: (val: any) => { 
                    if(val) {
                        this.pPhoneTypeNameDtSrc.interface2Values(val, true); 
                    } else {
                        this.pPhoneTypeNameDtSrc.clearPartially(true);
                    }
                }
            });

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
        frmcntrl = new FormControl({ value: null, disabled: false}, locValidators);
        this.mainFormGroup.addControl('employeeIdRef', frmcntrl);
        frmcntrl.valueChanges.subscribe({next: (val: any) => { 
            this.rootDataSource.setValue('employeeIdRef', val);
        }});
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        frmcntrl = new FormControl({ value: null, disabled: false}, locValidators);
        this.mainFormGroup.addControl('phoneTypeIdRef', frmcntrl);
        frmcntrl.valueChanges.subscribe({next: (val: any) => { 
            this.rootDataSource.setValue('phoneTypeIdRef', val);
        }});
        this.rootDataSource = new PhbkPhoneViewDatasource (this.frmSrvPhbkPhoneView,
            this.appGlblSettings, null, null, ['PhoneType', 'Employee'],'');
        this.rootDataSource.setIsNew(false);
        this._Subscriptions.push(
            this.rootDataSource
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceAfterPropsChanged(v) } })
        );
//        this._Subscriptions.push(this.rootDataSource.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(this.rootDataSource.OnUpdate.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnUpdate(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnAdd.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnAdd(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnDelete.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnDelete(v) } }));
        this.pPhoneTypeNameDtSrc = new PhbkPhoneTypeViewDatasource (this.frmSrvPhbkPhoneTypeView,
            this.appGlblSettings, 'PhbkPhoneView', 'PhoneType', [],'PhoneType');
        this.pPhoneTypeNameDtSrc.setIsNew(false);
        this.eEmpLastNameDtSrc = new PhbkEmployeeViewDatasource (this.frmSrvPhbkEmployeeView,
            this.appGlblSettings, 'PhbkPhoneView', 'Employee', ['Division'],'Employee');
        this.eEmpLastNameDtSrc.setIsNew(false);
        this.eDDivisionNameDtSrc = new PhbkDivisionViewDatasource (this.frmSrvPhbkDivisionView,
            this.appGlblSettings, 'PhbkEmployeeView', 'Division', ['Enterprise'],'Employee.Division');
        this.eDDivisionNameDtSrc.setIsNew(false);
        this.eDEEntrprsNameDtSrc = new PhbkEnterpriseViewDatasource (this.frmSrvPhbkEnterpriseView,
            this.appGlblSettings, 'PhbkDivisionView', 'Enterprise', [],'Employee.Division.Enterprise');
        this.eDEEntrprsNameDtSrc.setIsNew(false);
//        this._Subscriptions.push(this.pPhoneTypeNameDtSrc.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.pPhoneTypeNameOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(
            this.pPhoneTypeNameDtSrc
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.pPhoneTypeNameAfterPropsChanged(v) } })
        );
        this._Subscriptions.push(
            this.pPhoneTypeNameDtSrc
                .AfterMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.pPhoneTypeNameAfterMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.pPhoneTypeNameDtSrc
                .OnMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSource.submitOnMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.rootDataSource
            .OnDetailChanged.subscribe({next: (v: IViewModelDatasource) => { this.pPhoneTypeNameDtSrc.submitOnDetailChanged(v) } })
        );

//        this._Subscriptions.push(this.eEmpLastNameDtSrc.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.eEmpLastNameOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(
            this.eEmpLastNameDtSrc
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.eEmpLastNameAfterPropsChanged(v) } })
        );
        this._Subscriptions.push(
            this.eEmpLastNameDtSrc
                .AfterMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.eEmpLastNameAfterMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.eEmpLastNameDtSrc
                .OnMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSource.submitOnMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.rootDataSource
            .OnDetailChanged.subscribe({next: (v: IViewModelDatasource) => { this.eEmpLastNameDtSrc.submitOnDetailChanged(v) } })
        );

//        this._Subscriptions.push(this.eDDivisionNameDtSrc.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDDivisionNameOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(
            this.eDDivisionNameDtSrc
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDDivisionNameAfterPropsChanged(v) } })
        );
        this._Subscriptions.push(
            this.eDDivisionNameDtSrc
                .AfterMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDDivisionNameAfterMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.eDDivisionNameDtSrc
                .OnMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.eEmpLastNameDtSrc.submitOnMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.eEmpLastNameDtSrc
            .OnDetailChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDDivisionNameDtSrc.submitOnDetailChanged(v) } })
        );
//        this._Subscriptions.push(this.eDEEntrprsNameDtSrc.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDEEntrprsNameOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(
            this.eDEEntrprsNameDtSrc
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDEEntrprsNameAfterPropsChanged(v) } })
        );
        this._Subscriptions.push(
            this.eDEEntrprsNameDtSrc
                .AfterMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDEEntrprsNameAfterMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.eDEEntrprsNameDtSrc
                .OnMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDDivisionNameDtSrc.submitOnMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.eDDivisionNameDtSrc
            .OnDetailChanged.subscribe({next: (v: IViewModelDatasource) => { this.eDEEntrprsNameDtSrc.submitOnDetailChanged(v) } })
        );
    }
//    public rootDataSourceOnUpdate(v: IViewModelDatasource): void { }
//    public rootDataSourceOnAdd(v: IViewModelDatasource): void { }
//    public rootDataSourceOnDelete(v: IViewModelDatasource): void { }
//    public rootDataSourceOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public rootDataSourceAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'phoneId': this.rootDataSource.getValue('phoneId')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'phone': this.rootDataSource.getValue('phone')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'employeeIdRef': this.rootDataSource.getValue('employeeIdRef')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'phoneTypeIdRef': this.rootDataSource.getValue('phoneTypeIdRef')}, {emitEvent: false});
        if(this.rootDataSource.isUnderHiddenFilterFields('pPhoneTypeName')) {
            this.pPhoneTypeNameCmbCntrl.disable({emitEvent: false});
        } else {
            this.pPhoneTypeNameCmbCntrl.enable({emitEvent: false});
        }
        this.eEmpLastNameBttnDsnbl = this.rootDataSource.isUnderHiddenFilterFields('eEmpLastName');
        this.eDDivisionNameBttnDsnbl = this.rootDataSource.isUnderHiddenFilterFields('eDDivisionName');
        this.eDEEntrprsNameBttnDsnbl = this.rootDataSource.isUnderHiddenFilterFields('eDEEntrprsName');
    }
    
    public pPhoneTypeNameAfterMasterChanged(v: IViewModelDatasource): void {
        this.pPhoneTypeNameDtSrc.getCllctionByCurrDirMstrs().subscribe({
            next: (data: Array<IPhbkPhoneTypeView> ) => {
                this.pPhoneTypeNameCmbCntrlVals = data;
                let lfc: any = this.pPhoneTypeNameDtSrc.values2Interface();
                let ind: number = -1;
                if(this.pPhoneTypeNameDtSrc.calcIsDefined()) {
                    ind = data.findIndex((e: any) => { return  (e.phoneTypeId === lfc.phoneTypeId) ; });
                }
                if (ind > -1) {
                    this.pPhoneTypeNameCmbCntrl.patchValue(data[ind], {emitEvent: false});
                    this.mainFormGroup.patchValue({'pPhoneTypeName': this.pPhoneTypeNameCmbCntrlVals[ind].phoneTypeName}, {emitEvent: false});
                } else {
                    this.pPhoneTypeNameCmbCntrl.patchValue(undefined, {emitEvent: false});
                    this.mainFormGroup.patchValue({'pPhoneTypeName': undefined}, {emitEvent: false});
                }
            },
            error: (error: any) => {
                this.pPhoneTypeNameCmbCntrlVals = [];
                this.pPhoneTypeNameCmbCntrl.patchValue(undefined, {emitEvent: false});
                this.mainFormGroup.patchValue({'pPhoneTypeName': undefined}, {emitEvent: false});
                this.appGlblSettings.showError('http', error);
            }
        });
        if(this.pPhoneTypeNameDtSrc.isSetFilterByCurrDirMstrs() &&
          (!this.rootDataSource.isUnderHiddenFilterFields('pPhoneTypeName'))) {
            this.pPhoneTypeNameCmbCntrl.enable({emitEvent: false});
        } else {
            this.pPhoneTypeNameCmbCntrl.disable({emitEvent: false});
        }
    }

//    public pPhoneTypeNameOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public pPhoneTypeNameAfterPropsChanged(v: IViewModelDatasource): void {
        if(this.pPhoneTypeNameCmbCntrlVals) {
            let lfc: any = this.pPhoneTypeNameDtSrc.values2Interface();
            let ind: number = this.pPhoneTypeNameCmbCntrlVals.findIndex((e: any) => { return  (e.phoneTypeId === lfc.phoneTypeId) ; });
            if (ind > -1) {
                this.pPhoneTypeNameCmbCntrl.patchValue(this.pPhoneTypeNameCmbCntrlVals[ind], {emitEvent: false});
                this.mainFormGroup.patchValue({'pPhoneTypeName': this.pPhoneTypeNameCmbCntrlVals[ind].phoneTypeName}, {emitEvent: false});
            } else {
                this.pPhoneTypeNameCmbCntrl.patchValue(undefined, {emitEvent: false});
                this.mainFormGroup.patchValue({'pPhoneTypeName': undefined}, {emitEvent: false});
            }
        } else {
            this.pPhoneTypeNameCmbCntrl.patchValue(undefined, {emitEvent: false});
            this.mainFormGroup.patchValue({'pPhoneTypeName': undefined}, {emitEvent: false});
        }
    }
    public eEmpLastNameAfterMasterChanged(v: IViewModelDatasource): void {
        this.eEmpLastNameBttnDsnbl = 
            this.rootDataSource.isUnderHiddenFilterFields('eEmpLastName') ||
            (!this.eEmpLastNameDtSrc.isSetFilterByCurrDirMstrs());
    }
    public eEmpLastNameSrchClck(): void {
        if(!this.eEmpLastNameDtSrc.isSetFilterByCurrDirMstrs()) {
            this.appGlblSettings.showError('http', {message:this.frases['Not-all-masters'],});
            return;
        }
        let flt: IPhbkEmployeeViewDlg = {
            title: this.frases['title'],
            showFilter: true,
            canAdd: false,
            canUpdate: false,
            canDelete: false,
            hiddenFilter: [], // Array<IWebServiceFilterRslt>
            selectedItems: null,
            maxHeight: 6,
            filterMaxHeight: 2
        };
        flt.hiddenFilter = this.eEmpLastNameDtSrc.getWSFltrRsltByCurrDirMstrs();
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkEmployeeViewSdlgComponent, {
            data: flt,
            maxWidth: mw,
            width: w,
        });
        dialogRef.afterClosed()
            .subscribe({
                next: (rslt) => {
                    if (!(typeof rslt === 'undefined')) {
                        if (!(rslt === null)) {
                            if (!(rslt.selectedItems === 'undefined')) {
                                if(Array.isArray(rslt.selectedItems)) {
                                    if(rslt.selectedItems.length > 0) {
                                        this.eEmpLastNameDtSrc.interface2Values(rslt.selectedItems[0], true);
                                    }
                                }
                            }
                        }
                    }
                }
            });
    }
//    public eEmpLastNameOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public eEmpLastNameAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'eEmpFirstName': this.eEmpLastNameDtSrc.getByOrgValue('EmpFirstName', '')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eEmpSecondName': this.eEmpLastNameDtSrc.getByOrgValue('EmpSecondName', '')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eEmpLastName': this.eEmpLastNameDtSrc.getValue('empLastName')}, {emitEvent: false});
    }
    public eDDivisionNameAfterMasterChanged(v: IViewModelDatasource): void {
        this.eDDivisionNameBttnDsnbl = 
            this.rootDataSource.isUnderHiddenFilterFields('eDDivisionName') ||
            (!this.eDDivisionNameDtSrc.isSetFilterByCurrDirMstrs());
    }
    public eDDivisionNameSrchClck(): void {
        if(!this.eDDivisionNameDtSrc.isSetFilterByCurrDirMstrs()) {
            this.appGlblSettings.showError('http', {message:this.frases['Not-all-masters'],});
            return;
        }
        let flt: IPhbkDivisionViewDlg = {
            title: this.frases['title'],
            showFilter: true,
            canAdd: false,
            canUpdate: false,
            canDelete: false,
            hiddenFilter: [], // Array<IWebServiceFilterRslt>
            selectedItems: null,
            maxHeight: 6,
            filterMaxHeight: 2
        };
        flt.hiddenFilter = this.eDDivisionNameDtSrc.getWSFltrRsltByCurrDirMstrs();
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkDivisionViewSdlgComponent, {
            data: flt,
            maxWidth: mw,
            width: w,
        });
        dialogRef.afterClosed()
            .subscribe({
                next: (rslt) => {
                    if (!(typeof rslt === 'undefined')) {
                        if (!(rslt === null)) {
                            if (!(rslt.selectedItems === 'undefined')) {
                                if(Array.isArray(rslt.selectedItems)) {
                                    if(rslt.selectedItems.length > 0) {
                                        this.eDDivisionNameDtSrc.interface2Values(rslt.selectedItems[0], true);
                                    }
                                }
                            }
                        }
                    }
                }
            });
    }
//    public eDDivisionNameOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public eDDivisionNameAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'eDDivisionName': this.eDDivisionNameDtSrc.getValue('divisionName')}, {emitEvent: false});
    }
    public eDEEntrprsNameAfterMasterChanged(v: IViewModelDatasource): void {
        this.eDEEntrprsNameBttnDsnbl = 
            this.rootDataSource.isUnderHiddenFilterFields('eDEEntrprsName') ||
            (!this.eDEEntrprsNameDtSrc.isSetFilterByCurrDirMstrs());
    }
    public eDEEntrprsNameSrchClck(): void {
        if(!this.eDEEntrprsNameDtSrc.isSetFilterByCurrDirMstrs()) {
            this.appGlblSettings.showError('http', {message:this.frases['Not-all-masters'],});
            return;
        }
        let flt: IPhbkEnterpriseViewDlg = {
            title: this.frases['title'],
            showFilter: true,
            canAdd: false,
            canUpdate: false,
            canDelete: false,
            hiddenFilter: [], // Array<IWebServiceFilterRslt>
            selectedItems: null,
            maxHeight: 6,
            filterMaxHeight: 2
        };
        flt.hiddenFilter = this.eDEEntrprsNameDtSrc.getWSFltrRsltByCurrDirMstrs();
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkEnterpriseViewSdlgComponent, {
            data: flt,
            maxWidth: mw,
            width: w,
        });
        dialogRef.afterClosed()
            .subscribe({
                next: (rslt) => {
                    if (!(typeof rslt === 'undefined')) {
                        if (!(rslt === null)) {
                            if (!(rslt.selectedItems === 'undefined')) {
                                if(Array.isArray(rslt.selectedItems)) {
                                    if(rslt.selectedItems.length > 0) {
                                        this.eDEEntrprsNameDtSrc.interface2Values(rslt.selectedItems[0], true);
                                    }
                                }
                            }
                        }
                    }
                }
            });
    }
//    public eDEEntrprsNameOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public eDEEntrprsNameAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'eDEEntrprsName': this.eDEEntrprsNameDtSrc.getValue('entrprsName')}, {emitEvent: false});
    }

} // the end of the PhbkPhoneViewUformComponent class body


