
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

import { IaspnetrolemaskView } from 'asp-interfaces';
// import { IaspnetrolemaskViewPage } from 'asp-interfaces';
// import { IaspnetrolemaskViewFilter } from 'asp-interfaces';
import { AspnetrolemaskViewService } from 'asp-services';
import { AspnetrolemaskViewDatasource } from 'asp-services';


@Component({
  selector: 'app-aspnetrolemask-view-dform',
  templateUrl: './aspnetrolemask-view-dform.component.html',
  styleUrls: ['./aspnetrolemask-view-dform.component.css']
})
export class AspnetrolemaskViewDformComponent implements OnInit, OnDestroy, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@AspnetrolemaskViewDformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Delete Role Mask@@AspnetrolemaskViewDformComponent.Delete-Item:Delete Role Mask`,
        'title': $localize`:Select Item@@AspnetrolemaskViewDformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@AspnetrolemaskViewDformComponent.Not-all-masters:Not all masters have been set`,
        'RName-label': $localize`:Role Name@@aspnetrolemaskView.RName-label:Role Name`,
        'RName-hint': $localize`:Enter RoleName@@aspnetrolemaskView.RName-hint:Enter RoleName`,
        'RName-placeholder': $localize`:Role Name@@aspnetrolemaskView.RName-placeholder:Role Name`,
        'RoleDescription-label': $localize`:Role Description@@aspnetrolemaskView.RoleDescription-label:Role Description`,
        'RoleDescription-hint': $localize`:Enter Role Description@@aspnetrolemaskView.RoleDescription-hint:Enter Role Description`,
        'RoleDescription-placeholder': $localize`:Role Description@@aspnetrolemaskView.RoleDescription-placeholder:Role Description`,
        'ModelPkRef-label': $localize`:Model Id@@aspnetrolemaskView.ModelPkRef-label:Model Id`,
        'ModelPkRef-hint': $localize`:Enter Model Id@@aspnetrolemaskView.ModelPkRef-hint:Enter Model Id`,
        'ModelPkRef-placeholder': $localize`:Model Id@@aspnetrolemaskView.ModelPkRef-placeholder:Model Id`,
        'MModelName-label': $localize`:Model Name@@aspnetrolemaskView.MModelName-label:Model Name`,
        'MModelName-hint': $localize`:Enter ModelName@@aspnetrolemaskView.MModelName-hint:Enter ModelName`,
        'MModelName-placeholder': $localize`:Model Name@@aspnetrolemaskView.MModelName-placeholder:Model Name`,
        'Mask1-label': $localize`:Permission to Sel@@aspnetrolemaskView.Mask1-label:Permission to Sel`,
        'Mask1-hint': $localize`:Enter permission to Sel@@aspnetrolemaskView.Mask1-hint:Enter permission to Sel`,
        'Mask1-placeholder': $localize`:Permission to Sel@@aspnetrolemaskView.Mask1-placeholder:Permission to Sel`,
        'Mask2-label': $localize`:Permission to Del@@aspnetrolemaskView.Mask2-label:Permission to Del`,
        'Mask2-hint': $localize`:Enter permission to Del@@aspnetrolemaskView.Mask2-hint:Enter permission to Del`,
        'Mask2-placeholder': $localize`:Permission to Del@@aspnetrolemaskView.Mask2-placeholder:Permission to Del`,
        'Mask3-label': $localize`:Permission to Upd@@aspnetrolemaskView.Mask3-label:Permission to Upd`,
        'Mask3-hint': $localize`:Enter permission to Upd@@aspnetrolemaskView.Mask3-hint:Enter permission to Upd`,
        'Mask3-placeholder': $localize`:Permission to Upd@@aspnetrolemaskView.Mask3-placeholder:Permission to Upd`,
        'Mask4-label': $localize`:Permission to Add@@aspnetrolemaskView.Mask4-label:Permission to Add`,
        'Mask4-hint': $localize`:Enter permission to Add@@aspnetrolemaskView.Mask4-hint:Enter permission to Add`,
        'Mask4-placeholder': $localize`:Permission to Add@@aspnetrolemaskView.Mask4-placeholder:Permission to Add`,
        'Mask5-label': $localize`:Full scan permission@@aspnetrolemaskView.Mask5-label:Full scan permission`,
        'Mask5-hint': $localize`:Enter Full scan permission@@aspnetrolemaskView.Mask5-hint:Enter Full scan permission`,
        'Mask5-placeholder': $localize`:Full scan permission@@aspnetrolemaskView.Mask5-placeholder:Full scan permission`,
    }
    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IaspnetrolemaskView>();
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
    public rootDataSource: AspnetrolemaskViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IaspnetrolemaskView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IaspnetrolemaskView | any {
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


    constructor(private frmSrvaspnetrolemaskView: AspnetrolemaskViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        locValidators = [ Validators.required,Validators.maxLength(128),Validators.minLength(1) ];
        this.mainFormGroup.addControl('rName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.maxLength(70),Validators.minLength(0) ];
        this.mainFormGroup.addControl('roleDescription', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.pattern(/^[-+]?\d+$/),Validators.max(2147483640),Validators.min(-2147483640) ];
        this.mainFormGroup.addControl('modelPkRef', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(50),Validators.minLength(1) ];
        this.mainFormGroup.addControl('mModelName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ ];
        this.mainFormGroup.addControl('mask1', new FormControl({ value: false, disabled: false}, locValidators));
        locValidators = [ ];
        this.mainFormGroup.addControl('mask2', new FormControl({ value: false, disabled: false}, locValidators));
        locValidators = [ ];
        this.mainFormGroup.addControl('mask3', new FormControl({ value: false, disabled: false}, locValidators));
        locValidators = [ ];
        this.mainFormGroup.addControl('mask4', new FormControl({ value: false, disabled: false}, locValidators));
        locValidators = [ ];
        this.mainFormGroup.addControl('mask5', new FormControl({ value: false, disabled: false}, locValidators));
        this.rootDataSource = new AspnetrolemaskViewDatasource (this.frmSrvaspnetrolemaskView,
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
        this.mainFormGroup.patchValue({'rName': this.rootDataSource.getValue('rName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'roleDescription': this.rootDataSource.getValue('roleDescription')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'modelPkRef': this.rootDataSource.getValue('modelPkRef')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'mModelName': this.rootDataSource.getValue('mModelName')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'mask1': this.rootDataSource.getValue('mask1')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'mask2': this.rootDataSource.getValue('mask2')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'mask3': this.rootDataSource.getValue('mask3')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'mask4': this.rootDataSource.getValue('mask4')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'mask5': this.rootDataSource.getValue('mask5')}, {emitEvent: false});
    }
    

} // the end of the AspnetrolemaskViewDformComponent class body


