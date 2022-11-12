
import { EventEmitter } from "@angular/core";
import { catchError, Observable, switchMap } from "rxjs";
import { of } from 'rxjs/internal/observable/of';

import { AppGlblSettingsService } from 'common-services';
import { IViewModelDatasource } from 'common-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

import { IaspnetusermaskView } from 'asp-interfaces';
import { IaspnetusermaskViewPage } from 'asp-interfaces';
import { IaspnetusermaskViewFilter } from 'asp-interfaces';
import { AspnetusermaskViewService } from './aspnetusermask-view.service';

export class AspnetusermaskViewDatasource implements IViewModelDatasource {
    protected readonly _CurrentViewName: string  = 'aspnetusermaskView';
    protected readonly _ClientViewName: string | any;
    protected readonly _DirectNavigation: string | any;
    protected _IsDefined: boolean = false;
    // master name, navigation names
    protected _CurrentlyDirectMasterNavs: string[];
    // master name, navigation name, master filed, master filed value
    protected _HiddenFilter: {[key: string]: {[key: string]: {[key: string]: any}}} | any = {};
    protected _UnderHiddenFilterFields: string[] = [];
    protected _IsNew: boolean = true;
    protected _UIFormChain: string = '';
    protected _Values: {[key: string]: any} = {
       "userId": undefined ,  //  System.String
       "mask1": false ,  //  System.Boolean
       "mask2": false ,  //  System.Boolean
       "mask3": false ,  //  System.Boolean
       "mask4": false ,  //  System.Boolean
       "mask5": false ,  //  System.Boolean
       "modelPkRef": undefined ,  //  System.Int32
       "uEmail": undefined ,  //  System.String
       "uUserName": undefined ,  //  System.String
       "mModelName": undefined ,  //  System.String
    };

    constructor(private frmRootSrv: AspnetusermaskViewService, protected appGlblSettings: AppGlblSettingsService,
                ClientViewName: string | null | undefined, 
                DirectNavigation: string | any,
                CurrentlyDirectMasterNavs: string[],
                UIFormChain: string) {
        this._ClientViewName = ClientViewName;
        this._DirectNavigation = DirectNavigation;
        this._CurrentlyDirectMasterNavs = CurrentlyDirectMasterNavs;
        this._UIFormChain = UIFormChain;
    }

    public OnDetailChanged: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    public OnMasterChanged: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    public AfterMasterChanged: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    public AfterPropsChanged: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    
    public OnIsDefinedChanged: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    public OnUpdate: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    public OnAdd: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();
    public OnDelete: EventEmitter<IViewModelDatasource> = new EventEmitter<IViewModelDatasource>();

    public doEmitEvent(aftrMstrChngd: boolean = false): void {
        let isDef: boolean = this.calcIsDefined();
        if(this._IsDefined !== isDef) {
            this._IsDefined = isDef;
            this.OnIsDefinedChanged.emit(this);
        }
        this.OnDetailChanged.emit(this);
        this.OnMasterChanged.emit(this);
        if(aftrMstrChngd) this.AfterMasterChanged.emit(this);
        this.AfterPropsChanged.emit(this);
    }
    public getHiddenFilterByRow(rw: IaspnetusermaskView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        return this.frmRootSrv.getHiddenFilterByRow(rw, nvNm);
    }

    public getHiddenFilterByFltRslt(fr:  Array<IWebServiceFilterRslt> | any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        return this.frmRootSrv.getHiddenFilterByFltRslt(fr);
    }
    public refreshIsDefined(): boolean {
        this._IsDefined = this.calcIsDefined();
        return this._IsDefined;
    }
    public calcIsDefined(): boolean {
        for(let i in this._Values) {
            if((!this.frmRootSrv.dbgeneratedValue(i)) && 
                this.frmRootSrv.requiredValue(i)) {
                if(!this.isSetValue(i)) return false;        
            }
        }
        return true;
    }
    public getUIFormChain(): string {
        return this._UIFormChain;
    }
    public getHiddenFilter(): {[key: string]: {[key: string]: {[key: string]: any}}} {
        return this._HiddenFilter;
    }
    public getHiddenFilterAsFltRslt(): Array<IWebServiceFilterRslt> {
        return this.frmRootSrv.getHiddenFilterAsFltRslt(this._HiddenFilter);
    }
    public setHiddenFilter(fltr: {[key: string]: {[key: string]: {[key: string]: any}}}): void {
        this._HiddenFilter = fltr;
        this.setUnderHiddenFilterFields();
    }
    public getIsTopDetail(): boolean {
        return this._UIFormChain === '';
    }
    public getIsDefined(): boolean {
        return this._IsDefined;
    }
    public getCurrentViewName(): string {
        return this._CurrentViewName;
    }
    public getClientViewName(): string | any {
        return this._ClientViewName;
    }
    public getDirectNavigation(): string|any {
        return this._DirectNavigation;
    }
    public getLength(): number {
        return this.frmRootSrv.getLength();
    }
    public getKeys(): string[] {
        return this.frmRootSrv.getKeys();
    }
    public getDtTpValue(key: string): string {
        return this.frmRootSrv.getDtTpValue(key);
    }
    public getValue(key: string): any {
        return this._Values[key];
    }
    public setValue(key: string, value: any): void {
        if( this.frmRootSrv.getDtTpValue(key) === 'boolean' ) {
            if(typeof value === 'undefined') { this._Values[key] = false; } else { this._Values[key] = value; }
        } else {
            return this._Values[key] = value;
        }
    }
    public getByOrgValue(org: string, fkchain: string): any {
        let i: string|any = this.frmRootSrv.getKeyByOrgValue(org, fkchain);
        if(typeof i === 'undefined') return undefined;
        return this._Values[i];
    }
    public setByOrgValue(org: string, fkchain: string, value: any): void {
        let i: string|any = this.frmRootSrv.getKeyByOrgValue(org, fkchain);
        if(!(typeof i === 'undefined')) this._Values[i] = value; 
    }
    public requiredValue(key: string): boolean {
        return this.frmRootSrv.requiredValue(key);
    }
    public dbgeneratedValue(key: string): boolean {
        return this.frmRootSrv.dbgeneratedValue(key);
    }
    public isInPrimkeyValue(key: string): boolean {
        return this.frmRootSrv.isInPrimkeyValue(key);
    }
    public isSetValue(key: string): boolean {
        let v: any = this._Values[key];
        if(typeof v === 'undefined') return false;
        if (this.requiredValue(key) && (v === null)) return false;
        return true;
    }
    public clearValue(key: string): void {
        if( this.frmRootSrv.getDtTpValue(key) === 'boolean' ) {
            this._Values[key] = false;
        } else {
            this._Values[key] = undefined;
        }
    }
    public clear(doNotify: boolean = true): boolean {
        let hasChanged: boolean = false;
        for(let i in this._Values) {
            if( this.frmRootSrv.getDtTpValue(i) === 'boolean' ) {
                if (this._Values[i] !== false) hasChanged = true;
                this._Values[i] = false;
            } else {
                if (typeof this._Values[i] !== 'undefined') hasChanged = true;
                this._Values[i] = undefined;
            }
        }
        if(!hasChanged) return hasChanged;
        if(doNotify) this.doEmitEvent(true);
        return hasChanged;
    }

    public isEqual(src: any, dest: any): boolean {
        if (typeof src === 'undefined') {
            return typeof dest === 'undefined';
        }
        if (typeof dest === 'undefined') {
            return false;
        }
        if (src === null) {
            return dest === null;
        }
        if(dest === null) {
            return false;
        }
        return src === dest;
    }
    public interface2Values(data: IaspnetusermaskView | null, doNotify: boolean = true): boolean {
        if(typeof data === 'undefined') {
            return this.clear(doNotify);
        }
        if(data === null) {
            return this.clear(doNotify);
        }
        let hasChanged: boolean = false;
        let aftrMstrChngd: boolean = false;
        if(!this.isEqual(this.getValue('userId'), data.userId)) {
            this.setValue('userId', data.userId);
            aftrMstrChngd = (this._CurrentlyDirectMasterNavs.indexOf('AspNetUser') >= 0) || aftrMstrChngd;
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('mask1'), data.mask1)) {
            this.setValue('mask1', data.mask1);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('mask2'), data.mask2)) {
            this.setValue('mask2', data.mask2);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('mask3'), data.mask3)) {
            this.setValue('mask3', data.mask3);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('mask4'), data.mask4)) {
            this.setValue('mask4', data.mask4);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('mask5'), data.mask5)) {
            this.setValue('mask5', data.mask5);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('modelPkRef'), data.modelPkRef)) {
            this.setValue('modelPkRef', data.modelPkRef);
            aftrMstrChngd = (this._CurrentlyDirectMasterNavs.indexOf('AspNetModel') >= 0) || aftrMstrChngd;
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('uEmail'), data.uEmail)) {
            this.setValue('uEmail', data.uEmail);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('uUserName'), data.uUserName)) {
            this.setValue('uUserName', data.uUserName);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('mModelName'), data.mModelName)) {
            this.setValue('mModelName', data.mModelName);
            hasChanged = true;
        }
        if(!hasChanged) return hasChanged;
        if(doNotify) this.doEmitEvent(aftrMstrChngd);
        return hasChanged;
    }
    public values2Interface(): IaspnetusermaskView | any {
        return {
                userId: this.getValue('userId'),
                mask1: this.getValue('mask1'),
                mask2: this.getValue('mask2'),
                mask3: this.getValue('mask3'),
                mask4: this.getValue('mask4'),
                mask5: this.getValue('mask5'),
                modelPkRef: this.getValue('modelPkRef'),
                uEmail: this.getValue('uEmail'),
                uUserName: this.getValue('uUserName'),
                mModelName: this.getValue('mModelName'),
        };
    }

    public submitOnDetailChanged(v: IViewModelDatasource): void {
        if ((typeof this._ClientViewName === 'undefined') || (typeof this._DirectNavigation === 'undefined')) return;
        if ((this._ClientViewName === null) || (this._DirectNavigation === null)) return;
        if(v.getCurrentViewName() !== this._ClientViewName) return;
        let clntNtChngd = true;
        let c2mfm: {[key: string]: {[key: string]: {[key: string]: string}}} = this.frmRootSrv.getc2mfm();
        if( Object.keys(c2mfm).indexOf(this._ClientViewName) > -1) {
            if( Object.keys(c2mfm[this._ClientViewName]).indexOf(this._DirectNavigation) > -1) {
                for(let i in c2mfm[this._ClientViewName][this._DirectNavigation]) {
                    let src: any = v.getValue(i);
                    let dst: any = this.getValue(c2mfm[this._ClientViewName][this._DirectNavigation][i]);
                    if (this.isEqual(src, dst)) continue;
                    clntNtChngd = false;
                    this.setValue(c2mfm[this._ClientViewName][this._DirectNavigation][i], src);
                }
            }
        }
        if (clntNtChngd) return;
    }

    public clearPartially(doNotify: boolean): boolean {
        let hasChanged: boolean = false;
        if(!this.isUnderHiddenFilterFields('userId')) {
            if(this._CurrentlyDirectMasterNavs.indexOf('AspNetUser') < 0) {
                if(this.isSetValue('userId')) {
                    this.clearValue('userId');
                    hasChanged = true;
                }
            }
        }
        if(!this.isUnderHiddenFilterFields('mask1')) {
            if(this.isSetValue('mask1')) {
                this.clearValue('mask1');
                hasChanged = true;
            }
        }
        if(!this.isUnderHiddenFilterFields('mask2')) {
            if(this.isSetValue('mask2')) {
                this.clearValue('mask2');
                hasChanged = true;
            }
        }
        if(!this.isUnderHiddenFilterFields('mask3')) {
            if(this.isSetValue('mask3')) {
                this.clearValue('mask3');
                hasChanged = true;
            }
        }
        if(!this.isUnderHiddenFilterFields('mask4')) {
            if(this.isSetValue('mask4')) {
                this.clearValue('mask4');
                hasChanged = true;
            }
        }
        if(!this.isUnderHiddenFilterFields('mask5')) {
            if(this.isSetValue('mask5')) {
                this.clearValue('mask5');
                hasChanged = true;
            }
        }
        if(!this.isUnderHiddenFilterFields('modelPkRef')) {
            if(this._CurrentlyDirectMasterNavs.indexOf('AspNetModel') < 0) {
                if(this.isSetValue('modelPkRef')) {
                    this.clearValue('modelPkRef');
                    hasChanged = true;
                }
            }
        }
        if(!this.isUnderHiddenFilterFields('uEmail')) {
            if(this._CurrentlyDirectMasterNavs.indexOf(this.frmRootSrv.getFkValue('uEmail')) < 0) {
                if(this.isSetValue('uEmail')) {
                    this.clearValue('uEmail');
                    hasChanged = true;
                }
            }
        }
        if(!this.isUnderHiddenFilterFields('uUserName')) {
            if(this._CurrentlyDirectMasterNavs.indexOf(this.frmRootSrv.getFkValue('uUserName')) < 0) {
                if(this.isSetValue('uUserName')) {
                    this.clearValue('uUserName');
                    hasChanged = true;
                }
            }
        }
        if(!this.isUnderHiddenFilterFields('mModelName')) {
            if(this._CurrentlyDirectMasterNavs.indexOf(this.frmRootSrv.getFkValue('mModelName')) < 0) {
                if(this.isSetValue('mModelName')) {
                    this.clearValue('mModelName');
                    hasChanged = true;
                }
            }
        }
        if(!hasChanged) return hasChanged;
        if(doNotify) this.doEmitEvent(false);
        return hasChanged;
    }

    public submitOnMasterChanged(v: IViewModelDatasource): void {
        let masterDirNav: string | any = v.getDirectNavigation();
        let masterClnt: string | any = v.getClientViewName();
        if ((typeof masterDirNav === 'undefined') || (typeof masterClnt == 'undefined')) return;
        if ((masterDirNav === null) || (masterClnt === null)) return;
        if (masterClnt !== this.getCurrentViewName()) return;
        let clntNtChngd = true;
        let masterVw: string | any = v.getCurrentViewName();
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        let m2cfm: {[key: string]: {[key: string]: {[key: string]: string}}} = this.frmRootSrv.getm2cfm();
        if( Object.keys(m2cKeyfm).indexOf(masterVw) > -1) {
            if( Object.keys(m2cKeyfm[masterVw]).indexOf(masterDirNav) > -1) {
                for(let i in m2cKeyfm[masterVw][masterDirNav]) {
                    let src: any = v.getValue(i);
                    let dst: any = this.getValue(m2cKeyfm[masterVw][masterDirNav][i].propNm);
                    if (this.isEqual(src, dst)) continue;
                    clntNtChngd = false;
                    this.setValue(m2cKeyfm[masterVw][masterDirNav][i].propNm, src);
                }
            }
        }
        if( Object.keys(m2cfm).indexOf(masterVw) > -1) {
            if( Object.keys(m2cfm[masterVw]).indexOf(masterDirNav) > -1) {
                for(let i in m2cfm[masterVw][masterDirNav]) {
                    let src: any = v.getValue(i);
                    if (this.isEqual(src, this.getValue(m2cfm[masterVw][masterDirNav][i]))) continue;
                    clntNtChngd = false;
                    this.setValue(m2cfm[masterVw][masterDirNav][i], src);
                }
            }
        }
        if (clntNtChngd) return;
        // clear primary and unique key props of the current ViewModel. Eliminate those associated with the current direct master props.
        if(!this.getIsTopDetail()) {
            this.clearPartially(false);
        }
        this.doEmitEvent(true);
    }
    
    public isSetFilterByCurrDirMstrs(): boolean {
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        for(let i in m2cKeyfm) {
            for(let j in m2cKeyfm[i]) {
                if(this._CurrentlyDirectMasterNavs.indexOf(j) > -1) {
                    for(let k in m2cKeyfm[i][j]) {
                        if (m2cKeyfm[i][j][k].isMstrReq && (!this.isSetValue(m2cKeyfm[i][j][k].propNm))) return false; 
                    }
                }
            }
        }
        return true;
    }
    public getWSFltrRsltByCurrDirMstrs(): Array<IWebServiceFilterRslt> {
        let rslt: Array<IWebServiceFilterRslt> = [];
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        for(let i in m2cKeyfm) {
            for(let j in m2cKeyfm[i]) {
                if(this._CurrentlyDirectMasterNavs.indexOf(j) > -1) {
                    for(let k in m2cKeyfm[i][j]) {
                        if (this.isSetValue(m2cKeyfm[i][j][k].propNm)) {
                            rslt.push({
                                fltrName: m2cKeyfm[i][j][k].propNm,
                                fltrDataType: this.getDtTpValue(m2cKeyfm[i][j][k].propNm),
                                fltrOperator: 'eq',
                                fltrValue: this.getValue(m2cKeyfm[i][j][k].propNm)
                            });
                        }
                    }
                }
            }
        }
        return rslt;
    }
    protected getFilterByCurrDirMstrs(): IaspnetusermaskViewFilter {
        let flt: IaspnetusermaskViewFilter | any = {}; // IaspnetusermaskViewFilter
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        for(let i in m2cKeyfm) {
            for(let j in m2cKeyfm[i]) {
                if(this._CurrentlyDirectMasterNavs.indexOf(j) > -1) {
                    for(let k in m2cKeyfm[i][j]) {
                        if (this.isSetValue(m2cKeyfm[i][j][k].propNm)) {
                            let nm: string = m2cKeyfm[i][j][k].propNm;
                            let op: string = nm + 'Oprtr';
                            if (typeof flt[nm as keyof IaspnetusermaskViewFilter] === 'undefined') { 
                                flt[nm as keyof IaspnetusermaskViewFilter] = [this.getValue(nm)]; 
                                flt[op as keyof IaspnetusermaskViewFilter] = ['eq'];
                            } else { 
                                flt[nm as keyof IaspnetusermaskViewFilter].push(this.getValue(nm)); 
                                flt[op as keyof IaspnetusermaskViewFilter].push('eq');
                            }
                        }
                    }
                }
            }
        }
        return flt;
    }
    private handleError<T> (result?: T) {
        return (error: any): Observable<T> => {
          this.appGlblSettings.showError('http', error);
          return of(result as T);
        };
    }
    // add input string to define flt.orderby prop
    public getCllctionByCurrDirMstrs(): Observable<Array<IaspnetusermaskView>> {
        if (!this.isSetFilterByCurrDirMstrs()) {
            return of([]);
        }
        let flt: IaspnetusermaskViewFilter | any =  this.getFilterByCurrDirMstrs();
        return this.frmRootSrv.getwithfilter(flt)
                .pipe(
                    switchMap((rslt: IaspnetusermaskViewPage) => {
                        if (!(typeof rslt === 'undefined')) {
                           if (!(rslt === null)) {
                                if (!(typeof rslt.items === 'undefined')) {
                                    if (Array.isArray( rslt.items )) {
                                        return of(rslt.items);
                                    }
                                }
                            }
                        }
                        return of([]);
                     }),
                     catchError(this.handleError<Array<IaspnetusermaskView>>([]))
                );
    }
    public getCllctionByFldFilter(fldName: string|any, fldVal: any): Observable<Array<IaspnetusermaskView>> {
        let isUndef: boolean = (typeof fldName === 'undefined') || (typeof fldVal === 'undefined');
        isUndef = isUndef ? isUndef : (fldVal === null);
        if(isUndef) {
            return this.getCllctionByCurrDirMstrs();
        }
        if (!this.isSetFilterByCurrDirMstrs()) {
            return of([]);
        }
        let flt: IaspnetusermaskViewFilter | any =  this.getFilterByCurrDirMstrs();
        if(typeof flt[fldName] === 'undefined') {
            flt[fldName] = [fldVal];
        } else {
            flt[fldName].push(fldVal);
        }
        if(typeof flt[fldName + 'Oprtr'] === 'undefined') {
            flt[fldName + 'Oprtr'] = ['lk'];
        } else {
            flt[fldName + 'Oprtr'].push('lk');
        }
        flt.orderby = fldName;
        return this.frmRootSrv.getwithfilter(flt)
                .pipe(
                    switchMap((rslt: IaspnetusermaskViewPage) => {
                        if (!(typeof rslt === 'undefined')) {
                           if (!(rslt === null)) {
                                if (!(typeof rslt.items === 'undefined')) {
                                    if (Array.isArray( rslt.items )) {
                                        return of(rslt.items);
                                    }
                                }
                            }
                        }
                        return of([]);
                     }),
                     catchError(this.handleError<Array<IaspnetusermaskView>>([]))
                );
    }
    public refresh(): void {
        this.appGlblSettings.showError('http', {message: $localize`:Not all Unique or Primary key properties are defined to call Refresh-method@@AspnetusermaskViewDatasourcerefresh.Not-all-Unique-Primary:Not all Unique or Primary key properties are defined to call Refresh-method`});
    }
    public updateone(): void {

            this.appGlblSettings.showError('http', {message: $localize`:Update is not implemeted for the current ViewModel@@AspnetusermaskViewDatasourceupdateone.Update-not-implemeted:Update is not implemeted for the current ViewModel`});

    }
    public addone(): void {

        this.appGlblSettings.showError('http', {message: $localize`:Insert is not implemeted for the current ViewModel@@AspnetusermaskViewDatasourceaddone.Insert-not-implemeted:Insert is not implemeted for the current ViewModel`});

    }
    public deleteone(): void {

        this.appGlblSettings.showError('http', {message: $localize`:Delete is not implemeted for the current ViewModel@@AspnetusermaskViewDatasourcedeleteone.Delete-not-implemeted:Delete is not implemeted for the current ViewModel`});

    }

    protected setUnderHiddenFilterFields(): void {
        this._UnderHiddenFilterFields = [];
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        let m2cfm: {[key: string]: {[key: string]: {[key: string]: string}}} = this.frmRootSrv.getm2cfm();
        if(typeof this._HiddenFilter === 'undefined') return;
        if(this._HiddenFilter === null) return;
        for(let i in this._HiddenFilter) {
            for(let j in this._HiddenFilter[i]) {
                if( Object.keys(m2cKeyfm).indexOf(i) > -1 ) {
                    if( Object.keys(m2cKeyfm[i]).indexOf(j) > -1 ) {
                        for(let k in m2cKeyfm[i][j]) {
                            this._UnderHiddenFilterFields.push(m2cKeyfm[i][j][k].propNm);
                        }
                    }
                }
                if( Object.keys(m2cfm).indexOf(i) > -1 ) {
                    if( Object.keys(m2cfm[i]).indexOf(j) > -1 ) {
                        for(let k in m2cfm[i][j]) {
                            this._UnderHiddenFilterFields.push(m2cfm[i][j][k]);
                        }
                    }
                }
            }
        }
    }
    public isUnderHiddenFilterFields(fld: string|any): boolean {
        if(typeof fld === 'undefined') return false;
        if(fld === null) return false;
        return this._UnderHiddenFilterFields.indexOf(fld) > -1;
    }
    public updateByHiddenFilterFields(doNotify: boolean = true): boolean {
        let hasChanged: boolean = false;
        let aftrMstrChngd: boolean = false;
        if(typeof this._HiddenFilter === 'undefined') return hasChanged;
        if(this._HiddenFilter === null) return hasChanged;
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        for(let i in this._HiddenFilter) {
            if( Object.keys(m2cKeyfm).indexOf(i) > -1 ) {
                for(let j in this._HiddenFilter[i]) {
                    if( Object.keys(m2cKeyfm[i]).indexOf(j) > -1 ) {
                        for(let k in this._HiddenFilter[i][j]) {
                            if( Object.keys(m2cKeyfm[i][j]).indexOf(k) > -1 ) {
                                let src: any = this._HiddenFilter[i][j][k];
                                if (!this.isEqual(this.getValue(m2cKeyfm[i][j][k].propNm), this._HiddenFilter[i][j][k])) {
                                    this.setValue(m2cKeyfm[i][j][k].propNm, this._HiddenFilter[i][j][k]);
                                    aftrMstrChngd = (this._CurrentlyDirectMasterNavs.indexOf(j) >= 0) || aftrMstrChngd;
                                    hasChanged = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        if(!hasChanged) return hasChanged;
        if(doNotify) this.doEmitEvent(aftrMstrChngd);
        return hasChanged;
    }
    public getIsNew(): boolean {
        return this._IsNew;
    }
    public setIsNew(v: boolean): void {
        this._IsNew = v;
    }
    public isReadonlyValue(key: string): boolean {
        let rslt: boolean = this.dbgeneratedValue(key);
        if(!rslt) rslt = this.isUnderHiddenFilterFields(key);
        if ((!rslt) && (!this.getIsNew())) {
            rslt = this.frmRootSrv.isInPrimkeyValue(key);
        }
        return rslt;
    }
}

