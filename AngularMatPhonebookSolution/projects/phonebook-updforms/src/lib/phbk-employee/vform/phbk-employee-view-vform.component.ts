
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

import { IPhbkEmployeeView } from 'phonebook-interfaces';
// import { IPhbkEmployeeViewPage } from 'phonebook-interfaces';
// import { IPhbkEmployeeViewFilter } from 'phonebook-interfaces';
import { PhbkEmployeeViewService } from 'phonebook-services';
import { PhbkEmployeeViewDatasource } from 'phonebook-services';


@Component({
  selector: 'app-phbk-employee-view-vform',
  templateUrl: './phbk-employee-view-vform.component.html',
  styleUrls: ['./phbk-employee-view-vform.component.css']
})
export class PhbkEmployeeViewVformComponent implements OnInit, OnDestroy, IEventEmitterPub {

    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@PhbkEmployeeViewVformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Review Employee@@PhbkEmployeeViewVformComponent.Review-Item:Review Employee`,
        'title': $localize`:Select Item@@PhbkEmployeeViewVformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@PhbkEmployeeViewVformComponent.Not-all-masters:Not all masters have been set`,
        'EmployeeId-label': $localize`:Id of the Employee@@PhbkEmployeeView.EmployeeId-label:Id of the Employee`,
        'EmployeeId-hint': $localize`:Enter Employee  Id@@PhbkEmployeeView.EmployeeId-hint:Enter Employee  Id`,
        'EmployeeId-placeholder': $localize`:Id of the Employee@@PhbkEmployeeView.EmployeeId-placeholder:Id of the Employee`,
        'EmpFirstName-label': $localize`:Employee First Name@@PhbkEmployeeView.EmpFirstName-label:Employee First Name`,
        'EmpFirstName-hint': $localize`:Enter Employee First Name@@PhbkEmployeeView.EmpFirstName-hint:Enter Employee First Name`,
        'EmpFirstName-placeholder': $localize`:Employee First Name@@PhbkEmployeeView.EmpFirstName-placeholder:Employee First Name`,
        'EmpLastName-label': $localize`:Employee Last Name@@PhbkEmployeeView.EmpLastName-label:Employee Last Name`,
        'EmpLastName-hint': $localize`:Enter Employee Last Name@@PhbkEmployeeView.EmpLastName-hint:Enter Employee Last Name`,
        'EmpLastName-placeholder': $localize`:Employee Last Name@@PhbkEmployeeView.EmpLastName-placeholder:Employee Last Name`,
        'EmpSecondName-label': $localize`:Employee Second Name@@PhbkEmployeeView.EmpSecondName-label:Employee Second Name`,
        'EmpSecondName-hint': $localize`:Enter Employee Second Name@@PhbkEmployeeView.EmpSecondName-hint:Enter Employee Second Name`,
        'EmpSecondName-placeholder': $localize`:Employee Second Name@@PhbkEmployeeView.EmpSecondName-placeholder:Employee Second Name`,
        'DivisionIdRef-label': $localize`:Id of the Division@@PhbkEmployeeView.DivisionIdRef-label:Id of the Division`,
        'DivisionIdRef-hint': $localize`:Enter Division Id@@PhbkEmployeeView.DivisionIdRef-hint:Enter Division Id`,
        'DivisionIdRef-placeholder': $localize`:Id of the Division@@PhbkEmployeeView.DivisionIdRef-placeholder:Id of the Division`,
        'DDivisionName-label': $localize`:Name of the Division@@PhbkEmployeeView.DDivisionName-label:Name of the Division`,
        'DDivisionName-hint': $localize`:Enter Division Name@@PhbkEmployeeView.DDivisionName-hint:Enter Division Name`,
        'DDivisionName-placeholder': $localize`:Name of the Division@@PhbkEmployeeView.DDivisionName-placeholder:Name of the Division`,
        'DEEntrprsName-label': $localize`:Name of the Enterprise@@PhbkEmployeeView.DEEntrprsName-label:Name of the Enterprise`,
        'DEEntrprsName-hint': $localize`:Enter Enterprise Name@@PhbkEmployeeView.DEEntrprsName-hint:Enter Enterprise Name`,
        'DEEntrprsName-placeholder': $localize`:Name of the Enterprise@@PhbkEmployeeView.DEEntrprsName-placeholder:Name of the Enterprise`,
    }

    
    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IPhbkEmployeeView>();
    public doSubmit(): void {
        if (this.mainFormGroup.invalid || (!this.rootDataSource.refreshIsDefined())) {
            this.mainFormGroup.markAllAsTouched();
            this.appGlblSettings.showError('http', {message: this.frases['Not-all-props']});
            return;
        }
        let data: IPhbkEmployeeView = this.rootDataSource.values2Interface();
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
    public rootDataSource: PhbkEmployeeViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IPhbkEmployeeView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IPhbkEmployeeView | any {
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


    constructor(private frmSrvPhbkEmployeeView: PhbkEmployeeViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        locValidators = [ ];
        this.mainFormGroup.addControl('employeeId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(25),Validators.minLength(3) ];
        this.mainFormGroup.addControl('empFirstName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(40),Validators.minLength(3) ];
        this.mainFormGroup.addControl('empLastName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.maxLength(25) ];
        this.mainFormGroup.addControl('empSecondName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('divisionIdRef', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('dDivisionName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('dEEntrprsName', new FormControl({ value: null, disabled: false}, locValidators));
        this.rootDataSource = new PhbkEmployeeViewDatasource (this.frmSrvPhbkEmployeeView,
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
        this.mainFormGroup.patchValue({'employeeId': this.rootDataSource.getValue('employeeId')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'empFirstName': this.rootDataSource.getValue('empFirstName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'empLastName': this.rootDataSource.getValue('empLastName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'empSecondName': this.rootDataSource.getValue('empSecondName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'divisionIdRef': this.rootDataSource.getValue('divisionIdRef')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'dDivisionName': this.rootDataSource.getValue('dDivisionName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'dEEntrprsName': this.rootDataSource.getValue('dEEntrprsName')}, {emitEvent: false});
    }
    

} // the end of the PhbkEmployeeViewVformComponent class body


