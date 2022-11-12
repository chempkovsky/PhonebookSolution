
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

import { IaspnetuserView } from 'asp-interfaces';
// import { IaspnetuserViewPage } from 'asp-interfaces';
// import { IaspnetuserViewFilter } from 'asp-interfaces';
import { AspnetuserViewService } from 'asp-services';
import { AspnetuserViewDatasource } from 'asp-services';

import { IaspnetroleView } from 'asp-interfaces';
// import { IaspnetroleViewPage } from 'asp-interfaces';
// import { IaspnetroleViewFilter } from 'asp-interfaces';
import { AspnetroleViewService } from 'asp-services';
import { AspnetroleViewDatasource } from 'asp-services';

import { IaspnetuserrolesView } from 'asp-interfaces';
// import { IaspnetuserrolesViewPage } from 'asp-interfaces';
// import { IaspnetuserrolesViewFilter } from 'asp-interfaces';
import { AspnetuserrolesViewService } from 'asp-services';
import { AspnetuserrolesViewDatasource } from 'asp-services';

import { AspnetuserViewSdlgComponent } from 'asp-sforms';
import { IaspnetuserViewDlg } from 'asp-sforms';

@Component({
  selector: 'app-aspnetuserroles-view-uform',
  templateUrl: './aspnetuserroles-view-uform.component.html',
  styleUrls: ['./aspnetuserroles-view-uform.component.css']
})
export class AspnetuserrolesViewUformComponent implements OnInit, OnDestroy, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'Not-all-props': $localize`:Not all properties are set@@AspnetuserrolesViewUformComponent.Not-all-props:Not all properties are set`,
        'caption': $localize`:Update User Role@@AspnetuserrolesViewUformComponent.Update-Item:Update User Role`,
        'title': $localize`:Select Item@@AspnetuserrolesViewUformComponent.SelItem:Select Item`,
        'Not-all-masters': $localize`:Not all masters have been set@@AspnetuserrolesViewUformComponent.Not-all-masters:Not all masters have been set`,
        'UserId-label': $localize`:User Id@@aspnetuserrolesView.UserId-label:User Id`,
        'UserId-hint': $localize`:Enter Id@@aspnetuserrolesView.UserId-hint:Enter Id`,
        'UserId-placeholder': $localize`:User Id@@aspnetuserrolesView.UserId-placeholder:User Id`,
        'UUserName-label': $localize`:User Name@@aspnetuserrolesView.UUserName-label:User Name`,
        'UUserName-hint': $localize`:Enter User Name@@aspnetuserrolesView.UUserName-hint:Enter User Name`,
        'UUserName-placeholder': $localize`:User Name@@aspnetuserrolesView.UUserName-placeholder:User Name`,
        'RoleId-label': $localize`:Role Id@@aspnetuserrolesView.RoleId-label:Role Id`,
        'RoleId-hint': $localize`:Enter Id@@aspnetuserrolesView.RoleId-hint:Enter Id`,
        'RoleId-placeholder': $localize`:Role Id@@aspnetuserrolesView.RoleId-placeholder:Role Id`,
        'RName-label': $localize`:Role Name@@aspnetuserrolesView.RName-label:Role Name`,
        'RName-hint': $localize`:Enter RoleName@@aspnetuserrolesView.RName-hint:Enter RoleName`,
        'RName-placeholder': $localize`:Role Name@@aspnetuserrolesView.RName-placeholder:Role Name`,
        'ULockoutEnd-label': $localize`:Lockout End@@aspnetuserrolesView.ULockoutEnd-label:Lockout End`,
        'ULockoutEnd-hint': $localize`:Enter Lockout@@aspnetuserrolesView.ULockoutEnd-hint:Enter Lockout`,
        'ULockoutEnd-placeholder': $localize`:Lockout End@@aspnetuserrolesView.ULockoutEnd-placeholder:Lockout End`,
    }

    @Output('before-submit') beforeSubmit = new EventEmitter();
    @Output('after-submit') afterSubmit = new EventEmitter<IaspnetuserrolesView>();
    public doSubmit(): void {
        if (this.mainFormGroup.invalid || (!this.rootDataSource.refreshIsDefined())) {
            this.mainFormGroup.markAllAsTouched();
            this.rNameCmbCntrl.markAllAsTouched();
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
        this.uUserNameDtSrc.AfterMasterChanged.emit(this.uUserNameDtSrc);
        this.rNameDtSrc.AfterMasterChanged.emit(this.rNameDtSrc);
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
    public rootDataSource: AspnetuserrolesViewDatasource | any = null;
    public uUserNameBttnDsnbl: boolean = true;
    public uUserNameDtSrc: AspnetuserViewDatasource | any = null;
    public rNameCmbCntrl: FormControl | any = null;
    public rNameCmbCntrlVals : Array<IaspnetroleView> | any = null;
    public rNameDtSrc: AspnetroleViewDatasource | any = null;

    _Subscriptions : Subscription[] = [];
    // end: variable declaration section

    // start: input variable declaration section
    @Input('eform-control-model') 
        set eformControlModel (inFormControlModel : IaspnetuserrolesView | any) {
            let hasChanged: boolean = this.rootDataSource.interface2Values(inFormControlModel, false);
            hasChanged = this.rootDataSource.updateByHiddenFilterFields(false) || hasChanged;
            if(this.ngOnInitCalled && hasChanged) {
                this.rootDataSource.refresh();
            }
        }
        get eformControlModel(): IaspnetuserrolesView | any {
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


    constructor(private frmSrvaspnetuserView: AspnetuserViewService, private frmSrvaspnetroleView: AspnetroleViewService, private frmSrvaspnetuserrolesView: AspnetuserrolesViewService, public dialog: MatDialog, protected appGlblSettings: AppGlblSettingsService ) {
        this.appearance = this.appGlblSettings.appearance;
        this.mainFormGroup =  new FormGroup({});
        let locValidators: ValidatorFn[]; 
        let v: any;
        let frmcntrl: FormControl|any;
        locValidators = [ ];
        this.mainFormGroup.addControl('userId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.maxLength(256),Validators.minLength(1) ];
        this.mainFormGroup.addControl('uUserName', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(128),Validators.minLength(1) ];
        this.mainFormGroup.addControl('roleId', new FormControl({ value: null, disabled: false}, locValidators));
        locValidators = [ Validators.required,Validators.maxLength(128),Validators.minLength(1) ];
        this.mainFormGroup.addControl('rName', new FormControl({ value: null, disabled: false}, locValidators));
        this.rNameCmbCntrl = new FormControl({ value: null, disabled: true }, [ 
                (fc)=>{  //if ((typeof fc.value === 'string') || (typeof fc.value === 'undefined') || (fc.value === null)) { 
                        if (!this.rNameDtSrc.calcIsDefined()) {
                            this.mainFormGroup.patchValue({'rName': null });
                            return  this.mainFormGroup.controls['rName'].errors; 
                        }  
                        return null; }]);
        this.rNameCmbCntrl.valueChanges
            .subscribe({
                next: (val: any) => { 
                    if(val) {
                        this.rNameDtSrc.interface2Values(val, true); 
                    } else {
                        this.rNameDtSrc.clearPartially(true);
                    }
                }
            });

        this.rootDataSource = new AspnetuserrolesViewDatasource (this.frmSrvaspnetuserrolesView,
            this.appGlblSettings, null, null, ['AspNetUser', 'AspNetRole'],'');
        this.rootDataSource.setIsNew(false);
        this._Subscriptions.push(
            this.rootDataSource
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceAfterPropsChanged(v) } })
        );
//        this._Subscriptions.push(this.rootDataSource.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(this.rootDataSource.OnUpdate.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnUpdate(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnAdd.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnAdd(v) } }));
//        this._Subscriptions.push(this.rootDataSource.OnDelete.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSourceOnDelete(v) } }));
        this.uUserNameDtSrc = new AspnetuserViewDatasource (this.frmSrvaspnetuserView,
            this.appGlblSettings, 'aspnetuserrolesView', 'AspNetUser', [],'AspNetUser');
        this.uUserNameDtSrc.setIsNew(false);
        this.rNameDtSrc = new AspnetroleViewDatasource (this.frmSrvaspnetroleView,
            this.appGlblSettings, 'aspnetuserrolesView', 'AspNetRole', [],'AspNetRole');
        this.rNameDtSrc.setIsNew(false);
//        this._Subscriptions.push(this.uUserNameDtSrc.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.uUserNameOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(
            this.uUserNameDtSrc
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.uUserNameAfterPropsChanged(v) } })
        );
        this._Subscriptions.push(
            this.uUserNameDtSrc
                .AfterMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.uUserNameAfterMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.uUserNameDtSrc
                .OnMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSource.submitOnMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.rootDataSource
            .OnDetailChanged.subscribe({next: (v: IViewModelDatasource) => { this.uUserNameDtSrc.submitOnDetailChanged(v) } })
        );

//        this._Subscriptions.push(this.rNameDtSrc.OnIsDefinedChanged.subscribe({next: (v: IViewModelDatasource) => { this.rNameOnIsDefinedChanged(v) } }));
        this._Subscriptions.push(
            this.rNameDtSrc
                .AfterPropsChanged.subscribe({next: (v: IViewModelDatasource) => { this.rNameAfterPropsChanged(v) } })
        );
        this._Subscriptions.push(
            this.rNameDtSrc
                .AfterMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.rNameAfterMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.rNameDtSrc
                .OnMasterChanged.subscribe({next: (v: IViewModelDatasource) => { this.rootDataSource.submitOnMasterChanged(v) } })
        );
        this._Subscriptions.push(
            this.rootDataSource
            .OnDetailChanged.subscribe({next: (v: IViewModelDatasource) => { this.rNameDtSrc.submitOnDetailChanged(v) } })
        );

    }
//    public rootDataSourceOnUpdate(v: IViewModelDatasource): void { }
//    public rootDataSourceOnAdd(v: IViewModelDatasource): void { }
//    public rootDataSourceOnDelete(v: IViewModelDatasource): void { }
//    public rootDataSourceOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public rootDataSourceAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'userId': this.rootDataSource.getValue('userId')}, {emitEvent: false});
        this.mainFormGroup.patchValue({'roleId': this.rootDataSource.getValue('roleId')}, {emitEvent: false});
        this.uUserNameBttnDsnbl = this.rootDataSource.isUnderHiddenFilterFields('uUserName');
        if(this.rootDataSource.isUnderHiddenFilterFields('rName')) {
            this.rNameCmbCntrl.disable({emitEvent: false});
        } else {
            this.rNameCmbCntrl.enable({emitEvent: false});
        }
    }
    
    public uUserNameAfterMasterChanged(v: IViewModelDatasource): void {
        this.uUserNameBttnDsnbl = 
            this.rootDataSource.isUnderHiddenFilterFields('uUserName') ||
            (!this.uUserNameDtSrc.isSetFilterByCurrDirMstrs());
    }
    public uUserNameSrchClck(): void {
        if(!this.uUserNameDtSrc.isSetFilterByCurrDirMstrs()) {
            this.appGlblSettings.showError('http', {message:this.frases['Not-all-masters'],});
            return;
        }
        let flt: IaspnetuserViewDlg = {
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
        flt.hiddenFilter = this.uUserNameDtSrc.getWSFltrRsltByCurrDirMstrs();
        let w: string = this.appGlblSettings.getDialogWidth('aspnetuserrolesView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('aspnetuserrolesView');
        let dialogRef = this.dialog.open(AspnetuserViewSdlgComponent, {
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
                                        this.uUserNameDtSrc.interface2Values(rslt.selectedItems[0], true);
                                    }
                                }
                            }
                        }
                    }
                }
            });
    }
//    public uUserNameOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public uUserNameAfterPropsChanged(v: IViewModelDatasource): void {
        this.mainFormGroup.patchValue({'uUserName': this.uUserNameDtSrc.getValue('userName')}, {emitEvent: false});
    }
    public rNameAfterMasterChanged(v: IViewModelDatasource): void {
        this.rNameDtSrc.getCllctionByCurrDirMstrs().subscribe({
            next: (data: Array<IaspnetroleView> ) => {
                this.rNameCmbCntrlVals = data;
                let lfc: any = this.rNameDtSrc.values2Interface();
                let ind: number = -1;
                if(this.rNameDtSrc.calcIsDefined()) {
                    ind = data.findIndex((e: any) => { return  (e.id === lfc.id) ; });
                }
                if (ind > -1) {
                    this.rNameCmbCntrl.patchValue(data[ind], {emitEvent: false});
                    this.mainFormGroup.patchValue({'rName': this.rNameCmbCntrlVals[ind].name}, {emitEvent: false});
                } else {
                    this.rNameCmbCntrl.patchValue(undefined, {emitEvent: false});
                    this.mainFormGroup.patchValue({'rName': undefined}, {emitEvent: false});
                }
            },
            error: (error: any) => {
                this.rNameCmbCntrlVals = [];
                this.rNameCmbCntrl.patchValue(undefined, {emitEvent: false});
                this.mainFormGroup.patchValue({'rName': undefined}, {emitEvent: false});
                this.appGlblSettings.showError('http', error);
            }
        });
        if(this.rNameDtSrc.isSetFilterByCurrDirMstrs() &&
          (!this.rootDataSource.isUnderHiddenFilterFields('rName'))) {
            this.rNameCmbCntrl.enable({emitEvent: false});
        } else {
            this.rNameCmbCntrl.disable({emitEvent: false});
        }
    }

//    public rNameOnIsDefinedChanged(v: IViewModelDatasource): void { }
    public rNameAfterPropsChanged(v: IViewModelDatasource): void {
        if(this.rNameCmbCntrlVals) {
            let lfc: any = this.rNameDtSrc.values2Interface();
            let ind: number = this.rNameCmbCntrlVals.findIndex((e: any) => { return  (e.id === lfc.id) ; });
            if (ind > -1) {
                this.rNameCmbCntrl.patchValue(this.rNameCmbCntrlVals[ind], {emitEvent: false});
                this.mainFormGroup.patchValue({'rName': this.rNameCmbCntrlVals[ind].name}, {emitEvent: false});
            } else {
                this.rNameCmbCntrl.patchValue(undefined, {emitEvent: false});
                this.mainFormGroup.patchValue({'rName': undefined}, {emitEvent: false});
            }
        } else {
            this.rNameCmbCntrl.patchValue(undefined, {emitEvent: false});
            this.mainFormGroup.patchValue({'rName': undefined}, {emitEvent: false});
        }
    }

} // the end of the AspnetuserrolesViewUformComponent class body


