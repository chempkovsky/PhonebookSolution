
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

import { IPhbkDivisionView } from 'phonebook-interfaces';
// import { IPhbkDivisionViewPage } from 'phonebook-interfaces';
// import { IPhbkDivisionViewFilter } from 'phonebook-interfaces';
import { PhbkDivisionViewService } from 'phonebook-services';
import { PhbkDivisionViewDatasource } from 'phonebook-services';


@Component({
  selector: 'app-phbk-division-view-vform',
  templateUrl: './phbk-division-view-vform.component.html',
  styleUrls: ['./phbk-division-view-vform.component.css']
})
export class PhbkDivisionViewVformComponent implements OnInit, OnDestroy, IEventEmitterPub {

    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@PhbkDivisionViewVformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Review Division@@PhbkDivisionViewVformComponent.Review-Item:Review Division`,
        'title': $localize`:Select Item@@PhbkDivisionViewVformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@PhbkDivisionViewVformComponent.Not-all-masters:Not all masters have been set`,
        'DivisionId-label': $localize`:Id of the Division@@PhbkDivisionView.DivisionId-label:Id of the Division`,
        'DivisionId-hint': $localize`:Enter Division Id@@PhbkDivisionView.DivisionId-hint:Enter Division Id`,
        'DivisionId-placeholder': $localize`:Id of the Division@@PhbkDivisionView.DivisionId-placeholder:Id of the Division`,
        'DivisionName-label': $localize`:Name of the Division@@PhbkDivisionView.DivisionName-label:Name of the Division`,
        'DivisionName-hint': $localize`:Enter Division Name@@PhbkDivisionView.DivisionName-hint:Enter Division Name`,
        'DivisionName-placeholder': $localize`:Name of the Division@@PhbkDivisionView.DivisionName-placeholder:Name of the Division`,
        'DivisionDesc-label': $localize`:Description of the Division@@PhbkDivisionView.DivisionDesc-label:Description of the Division`,
        'DivisionDesc-hint': $localize`:Enter Enterprise Division Description@@PhbkDivisionView.DivisionDesc-hint:Enter Enterprise Division Description`,
        'DivisionDesc-placeholder': $localize`:Description of the Division@@PhbkDivisionView.DivisionDesc-placeholder:Description of the Division`,
        'EntrprsIdRef-label': $localize`:Id of the Enterprise@@PhbkDivisionView.EntrprsIdRef-label:Id of the Enterprise`,
        'EntrprsIdRef-hint': $localize`:Enter Enterprise  Id@@PhbkDivisionView.EntrprsIdRef-hint:Enter Enterprise  Id`,
        'EntrprsIdRef-placeholder': $localize`:Id of the Enterprise@@PhbkDivisionView.EntrprsIdRef-placeholder:Id of the Enterprise`,
        'EEntrprsName-label': $localize`:Name of the Enterprise@@PhbkDivisionView.EEntrprsName-label:Name of the Enterprise`,
        'EEntrprsName-hint': $localize`:Enter Enterprise Name@@PhbkDivisionView.EEntrprsName-hint:Enter Enterprise Name`,
        'EEntrprsName-placeholder': $localize`:Name of the Enterprise@@PhbkDivisionView.EEntrprsName-placeholder:Name of the Enterprise`,
    }

    
    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IPhbkDivisionView>();
    public doSubmit(): void {
        if (this.mainFormGroup.invalid || (!this.rootDataSource.refreshIsDefined())) {
            this.mainFormGroup.markAllAsTouched();
            this.appGlblSettings.showError('http', {message: this.frases['Not-all-props']});
            return;
        }
        let data: IPhbkDivisionView = this.rootDataSource.values2Interface();
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
    public rootDataSource: PhbkDivisionViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IPhbkDivisionView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IPhbkDivisionView | any {
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


    constructor(private frmSrvPhbkDivisionView: PhbkDivisionViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('divisionId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('divisionName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.maxLength(250) ];
        this.mainFormGroup.addControl('divisionDesc', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('entrprsIdRef', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(20),Validators.minLength(3) ];
        this.mainFormGroup.addControl('eEntrprsName', new FormControl({ value: null, disabled: false}, locValidators));
        this.rootDataSource = new PhbkDivisionViewDatasource (this.frmSrvPhbkDivisionView,
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
        this.mainFormGroup.patchValue({'divisionId': this.rootDataSource.getValue('divisionId')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'divisionName': this.rootDataSource.getValue('divisionName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'divisionDesc': this.rootDataSource.getValue('divisionDesc')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'entrprsIdRef': this.rootDataSource.getValue('entrprsIdRef')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'eEntrprsName': this.rootDataSource.getValue('eEntrprsName')}, {emitEvent: false});
    }
    

} // the end of the PhbkDivisionViewVformComponent class body


