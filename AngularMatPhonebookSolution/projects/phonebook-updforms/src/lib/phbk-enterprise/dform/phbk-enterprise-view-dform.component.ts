
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

import { IPhbkEnterpriseView } from 'phonebook-interfaces';
// import { IPhbkEnterpriseViewPage } from 'phonebook-interfaces';
// import { IPhbkEnterpriseViewFilter } from 'phonebook-interfaces';
import { PhbkEnterpriseViewService } from 'phonebook-services';
import { PhbkEnterpriseViewDatasource } from 'phonebook-services';


@Component({
  selector: 'app-phbk-enterprise-view-dform',
  templateUrl: './phbk-enterprise-view-dform.component.html',
  styleUrls: ['./phbk-enterprise-view-dform.component.css']
})
export class PhbkEnterpriseViewDformComponent implements OnInit, OnDestroy, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@PhbkEnterpriseViewDformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Delete Enterprise@@PhbkEnterpriseViewDformComponent.Delete-Item:Delete Enterprise`,
        'title': $localize`:Select Item@@PhbkEnterpriseViewDformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@PhbkEnterpriseViewDformComponent.Not-all-masters:Not all masters have been set`,
        'EntrprsId-label': $localize`:Id of the Enterprise@@PhbkEnterpriseView.EntrprsId-label:Id of the Enterprise`,
        'EntrprsId-hint': $localize`:Enter Enterprise  Id@@PhbkEnterpriseView.EntrprsId-hint:Enter Enterprise  Id`,
        'EntrprsId-placeholder': $localize`:Id of the Enterprise@@PhbkEnterpriseView.EntrprsId-placeholder:Id of the Enterprise`,
        'EntrprsName-label': $localize`:Name of the Enterprise@@PhbkEnterpriseView.EntrprsName-label:Name of the Enterprise`,
        'EntrprsName-hint': $localize`:Enter Enterprise Name@@PhbkEnterpriseView.EntrprsName-hint:Enter Enterprise Name`,
        'EntrprsName-placeholder': $localize`:Name of the Enterprise@@PhbkEnterpriseView.EntrprsName-placeholder:Name of the Enterprise`,
        'EntrprsDesc-label': $localize`:Description of the Enterprise@@PhbkEnterpriseView.EntrprsDesc-label:Description of the Enterprise`,
        'EntrprsDesc-hint': $localize`:Description Enterprise Name@@PhbkEnterpriseView.EntrprsDesc-hint:Description Enterprise Name`,
        'EntrprsDesc-placeholder': $localize`:Description of the Enterprise@@PhbkEnterpriseView.EntrprsDesc-placeholder:Description of the Enterprise`,
    }
    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IPhbkEnterpriseView>();
    public doSubmit(): void {
        if (this.mainFormGroup.invalid || (!this.rootDataSource.refreshIsDefined())) {
            this.mainFormGroup.markAllAsTouched();
            this.appGlblSettings.showError('http', {message: this.frases['Not-all-props']});
            return;
        }
        this.beforeSubmit.emit(this.rootDataSource.values2Interface());
        this.rootDataSource.deleteone();
    }
    public rootDataSourceOnDelete(v: IViewModelDatasource): void { 
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
    public rootDataSource: PhbkEnterpriseViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IPhbkEnterpriseView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IPhbkEnterpriseView | any {
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


    constructor(private frmSrvPhbkEnterpriseView: PhbkEnterpriseViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('entrprsId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('entrprsName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.maxLength(250) ];
        this.mainFormGroup.addControl('entrprsDesc', new FormControl({ value: null, disabled: false}, locValidators));
        this.rootDataSource = new PhbkEnterpriseViewDatasource (this.frmSrvPhbkEnterpriseView,
            this.appGlblSettings, null, null, [],'');
        this.rootDataSource.setIsNew(false);
        this._Subscriptions.push(
            this.rootDataSource
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceAfterPropsChanged(v) } })
        );
//        this._Subscriptions.push(this.rootDataSource.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnIsDefinedChanged(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnUpdate.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnUpdate(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnAdd.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnAdd(v) } }));
        this._Subscriptions.push(this.rootDataSource.OnDelete.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnDelete(v) } }));
    }
//    public rootDataSourceOnUpdate(v: IViewModelDatasource): void { }
//    public rootDataSourceOnAdd(v: IViewModelDatasource): void { }
//    public rootDataSourceOnDelete(v: IViewModelDatasource): void { }
//    public rootDataSourceOnIsDefinedChanged(v: IViewModelDatasource): void { }

    public rootDataSourceAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'entrprsId': this.rootDataSource.getValue('entrprsId')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'entrprsName': this.rootDataSource.getValue('entrprsName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'entrprsDesc': this.rootDataSource.getValue('entrprsDesc')}, {emitEvent: false});
    }
    

} // the end of the PhbkEnterpriseViewDformComponent class body


