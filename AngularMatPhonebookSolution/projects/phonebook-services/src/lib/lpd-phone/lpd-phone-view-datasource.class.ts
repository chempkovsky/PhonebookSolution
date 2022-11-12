
import { EventEmitter } from "@angular/core";
import { catchError, Observable, switchMap } from "rxjs";
import { of } from 'rxjs/internal/observable/of';

import { AppGlblSettingsService } from 'common-services';
import { IViewModelDatasource } from 'common-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

import { ILpdPhoneView } from 'phonebook-interfaces';
import { ILpdPhoneViewPage } from 'phonebook-interfaces';
import { ILpdPhoneViewFilter } from 'phonebook-interfaces';
import { LpdPhoneViewService } from './lpd-phone-view.service';

export class LpdPhoneViewDatasource implements IViewModelDatasource {
    protected readonly _CurrentViewName: string  = 'LpdPhoneView';
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
       "lpdPhoneId": undefined ,  //  System.Int32
       "phone": undefined ,  //  System.String
    };

    constructor(private frmRootSrv: LpdPhoneViewService, protected appGlblSettings: AppGlblSettingsService,
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
    public getHiddenFilterByRow(rw: ILpdPhoneView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
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
    public interface2Values(data: ILpdPhoneView | null, doNotify: boolean = true): boolean {
        if(typeof data === 'undefined') {
            return this.clear(doNotify);
        }
        if(data === null) {
            return this.clear(doNotify);
        }
        let hasChanged: boolean = false;
        let aftrMstrChngd: boolean = false;
        if(!this.isEqual(this.getValue('lpdPhoneId'), data.lpdPhoneId)) {
            this.setValue('lpdPhoneId', data.lpdPhoneId);
            hasChanged = true;
        }
        if(!this.isEqual(this.getValue('phone'), data.phone)) {
            this.setValue('phone', data.phone);
            hasChanged = true;
        }
        if(!hasChanged) return hasChanged;
        if(doNotify) this.doEmitEvent(aftrMstrChngd);
        return hasChanged;
    }
    public values2Interface(): ILpdPhoneView | any {
        return {
                lpdPhoneId: this.getValue('lpdPhoneId'),
                phone: this.getValue('phone'),
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
        if (this._ClientViewName === 'LprPhone01View') {
            if (this._DirectNavigation === 'PhoneDict') {
                let isKeyCrrct = true;
                let dtFrTst: any;
                if(isKeyCrrct) {
                    dtFrTst = this.getValue('lpdPhoneId');
                    if(typeof dtFrTst === 'undefined') { 
                        isKeyCrrct = false;
                    } else if (dtFrTst === null) {
                        isKeyCrrct = false;
                    }
                }
                if(isKeyCrrct) {
                    this.frmRootSrv.getone(
                    this.getValue('lpdPhoneId')
                    ).subscribe({
                        next: (data: ILpdPhoneView ) => {
                            this.interface2Values(data, true);
                        },
                        error: (error) => { // error path
                            this.appGlblSettings.showError('http', error);
                            this.clear(true);
                        }
                    });
                } else {
                    this.clear(true);
                }
            }
        }
        else if (this._ClientViewName === 'LprPhone02View') {
            if (this._DirectNavigation === 'PhoneDict') {
                let isKeyCrrct = true;
                let dtFrTst: any;
                if(isKeyCrrct) {
                    dtFrTst = this.getValue('lpdPhoneId');
                    if(typeof dtFrTst === 'undefined') { 
                        isKeyCrrct = false;
                    } else if (dtFrTst === null) {
                        isKeyCrrct = false;
                    }
                }
                if(isKeyCrrct) {
                    this.frmRootSrv.getone(
                    this.getValue('lpdPhoneId')
                    ).subscribe({
                        next: (data: ILpdPhoneView ) => {
                            this.interface2Values(data, true);
                        },
                        error: (error) => { // error path
                            this.appGlblSettings.showError('http', error);
                            this.clear(true);
                        }
                    });
                } else {
                    this.clear(true);
                }
            }
        }
        else if (this._ClientViewName === 'LprPhone03View') {
            if (this._DirectNavigation === 'PhoneDict') {
                let isKeyCrrct = true;
                let dtFrTst: any;
                if(isKeyCrrct) {
                    dtFrTst = this.getValue('lpdPhoneId');
                    if(typeof dtFrTst === 'undefined') { 
                        isKeyCrrct = false;
                    } else if (dtFrTst === null) {
                        isKeyCrrct = false;
                    }
                }
                if(isKeyCrrct) {
                    this.frmRootSrv.getone(
                    this.getValue('lpdPhoneId')
                    ).subscribe({
                        next: (data: ILpdPhoneView ) => {
                            this.interface2Values(data, true);
                        },
                        error: (error) => { // error path
                            this.appGlblSettings.showError('http', error);
                            this.clear(true);
                        }
                    });
                } else {
                    this.clear(true);
                }
            }
        }
        else if (this._ClientViewName === 'LprPhone04View') {
            if (this._DirectNavigation === 'PhoneDict') {
                let isKeyCrrct = true;
                let dtFrTst: any;
                if(isKeyCrrct) {
                    dtFrTst = this.getValue('lpdPhoneId');
                    if(typeof dtFrTst === 'undefined') { 
                        isKeyCrrct = false;
                    } else if (dtFrTst === null) {
                        isKeyCrrct = false;
                    }
                }
                if(isKeyCrrct) {
                    this.frmRootSrv.getone(
                    this.getValue('lpdPhoneId')
                    ).subscribe({
                        next: (data: ILpdPhoneView ) => {
                            this.interface2Values(data, true);
                        },
                        error: (error) => { // error path
                            this.appGlblSettings.showError('http', error);
                            this.clear(true);
                        }
                    });
                } else {
                    this.clear(true);
                }
            }
        }
    }

    public clearPartially(doNotify: boolean): boolean {
        let hasChanged: boolean = false;
        if(!this.isUnderHiddenFilterFields('lpdPhoneId')) {
            if(this.isSetValue('lpdPhoneId')) {
                this.clearValue('lpdPhoneId');
                hasChanged = true;
            }
        }
        if(!this.isUnderHiddenFilterFields('phone')) {
            if(this.isSetValue('phone')) {
                this.clearValue('phone');
                hasChanged = true;
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
    protected getFilterByCurrDirMstrs(): ILpdPhoneViewFilter {
        let flt: ILpdPhoneViewFilter | any = {}; // ILpdPhoneViewFilter
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.frmRootSrv.getm2cKeyfm();
        for(let i in m2cKeyfm) {
            for(let j in m2cKeyfm[i]) {
                if(this._CurrentlyDirectMasterNavs.indexOf(j) > -1) {
                    for(let k in m2cKeyfm[i][j]) {
                        if (this.isSetValue(m2cKeyfm[i][j][k].propNm)) {
                            let nm: string = m2cKeyfm[i][j][k].propNm;
                            let op: string = nm + 'Oprtr';
                            if (typeof flt[nm as keyof ILpdPhoneViewFilter] === 'undefined') { 
                                flt[nm as keyof ILpdPhoneViewFilter] = [this.getValue(nm)]; 
                                flt[op as keyof ILpdPhoneViewFilter] = ['eq'];
                            } else { 
                                flt[nm as keyof ILpdPhoneViewFilter].push(this.getValue(nm)); 
                                flt[op as keyof ILpdPhoneViewFilter].push('eq');
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
    public getCllctionByCurrDirMstrs(): Observable<Array<ILpdPhoneView>> {
        if (!this.isSetFilterByCurrDirMstrs()) {
            return of([]);
        }
        let flt: ILpdPhoneViewFilter | any =  this.getFilterByCurrDirMstrs();
        return this.frmRootSrv.getwithfilter(flt)
                .pipe(
                    switchMap((rslt: ILpdPhoneViewPage) => {
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
                     catchError(this.handleError<Array<ILpdPhoneView>>([]))
                );
    }
    public getCllctionByFldFilter(fldName: string|any, fldVal: any): Observable<Array<ILpdPhoneView>> {
        let isUndef: boolean = (typeof fldName === 'undefined') || (typeof fldVal === 'undefined');
        isUndef = isUndef ? isUndef : (fldVal === null);
        if(isUndef) {
            return this.getCllctionByCurrDirMstrs();
        }
        if (!this.isSetFilterByCurrDirMstrs()) {
            return of([]);
        }
        let flt: ILpdPhoneViewFilter | any =  this.getFilterByCurrDirMstrs();
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
                    switchMap((rslt: ILpdPhoneViewPage) => {
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
                     catchError(this.handleError<Array<ILpdPhoneView>>([]))
                );
    }
    public getone(
                  lpdPhoneId: number 
        ): void {
            this.frmRootSrv.getone(
                  lpdPhoneId
            ).subscribe({
                next: (data: ILpdPhoneView ) => { 
                    if(!this.interface2Values(data, true)) {
                        this.doEmitEvent(true);
                    };
                },
                error: (error) => { 
                    this.appGlblSettings.showError('http', error)
                }
            });
    }
    public getonebyLpdPhoneUK(
                  phone: string 
        ): void {
            this.frmRootSrv.getonebyLpdPhoneUK(
                  phone
            ).subscribe({
                next: (data: ILpdPhoneView ) => { 
                    if(!this.interface2Values(data, true)) {
                        this.doEmitEvent(true);
                    };
                },
                error: (error) => { 
                    this.appGlblSettings.showError('http', error)
                }
            });
    }
    public refresh(): void {
            if (
                    this.isSetValue('lpdPhoneId')
            ) {
                this.getone(
                      this.getValue('lpdPhoneId')
                );
                return;
            }
            if (
                    this.isSetValue('phone')
            ) {
                this.getonebyLpdPhoneUK(
                      this.getValue('phone')
                );
                return;
            }
        this.appGlblSettings.showError('http', {message: $localize`:Not all Unique or Primary key properties are defined to call Refresh-method@@LpdPhoneViewDatasourcerefresh.Not-all-Unique-Primary:Not all Unique or Primary key properties are defined to call Refresh-method`});
    }
    public updateone(): void {
        if(!this.getIsDefined()) {
            this.appGlblSettings.showError('http', {message: $localize`:Not all propertes are correctly defined@@LpdPhoneViewDatasourceupdateone.Not-all-propertes:Not all propertes are correctly defined`});
            return;
        }
        let itm: ILpdPhoneView | any = this.values2Interface();
        this.frmRootSrv.updateone(itm).subscribe({
                next: (data: ILpdPhoneView ) => { 
                    this.interface2Values(data, false);
                    this.OnUpdate.emit(this);
                },
                error: (error) => { 
                    this.appGlblSettings.showError('http', error)
                }
            });
    }
    public addone(): void {
        if(!this.getIsDefined()) {
            
            this.appGlblSettings.showError('http', {message: $localize`:Not all propertes are correctly defined@@LpdPhoneViewDatasourceaddone.Not-all-propertes:Not all propertes are correctly defined`});
            return;
        }
        let itm: ILpdPhoneView | any = this.values2Interface();
        this.frmRootSrv.addone(itm).subscribe({
                next: (data: ILpdPhoneView ) => { 
                    this.interface2Values(data, false);
                    this.OnAdd.emit(this);
                },
                error: (error) => { 
                    this.appGlblSettings.showError('http', error)
                }
            });
    }
    public deleteone(): void {
        if(!this.getIsDefined()) {
            this.appGlblSettings.showError('http', {message: $localize`:Not all propertes are correctly defined@@LpdPhoneViewDatasourcedeleteone.Not-all-propertes:Not all propertes are correctly defined`});
            return;
        }
        this.frmRootSrv.deleteone(  this.getValue('lpdPhoneId') ).subscribe({
                next: (data: ILpdPhoneView ) => { 
                    this.interface2Values(data, false);
                    this.OnDelete.emit(this);
                },
                error: (error) => { 
                    this.appGlblSettings.showError('http', error)
                }
            });
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

