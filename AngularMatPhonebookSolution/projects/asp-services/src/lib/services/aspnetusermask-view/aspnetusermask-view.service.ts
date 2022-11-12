
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IaspnetusermaskView } from 'asp-interfaces';
import { IaspnetusermaskViewPage } from 'asp-interfaces';
import { IaspnetusermaskViewFilter } from 'asp-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class AspnetusermaskViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('aspnetusermaskView') + 'aspnetusermaskviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'userId': {org: 'UserId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'mask1': {org: 'Mask1', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask2': {org: 'Mask2', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask3': {org: 'Mask3', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask4': {org: 'Mask4', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask5': {org: 'Mask5', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'modelPkRef': {org: 'ModelPkRef', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'uEmail': {org: 'Email', fk: 'AspNetUser', fkchain: 'AspNetUser', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'uUserName': {org: 'UserName', fk: 'AspNetUser', fkchain: 'AspNetUser', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'mModelName': {org: 'ModelName', fk: 'AspNetModel', fkchain: 'AspNetModel', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IaspnetusermaskView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['aspnetusermaskView'] === 'undefined') rslt['aspnetusermaskView'] = {};
                if(typeof rslt['aspnetusermaskView'][nvNm] === 'undefined') rslt['aspnetusermaskView'][nvNm] = {};
                rslt['aspnetusermaskView'][nvNm][i] = rw[i];
            }
        }
        return rslt;
    }
    public getLength(): number {
        return Object.keys(this._Values).length;
    }
    public getKeys(): string[] {
        return Object.keys(this._Values);
    }
    public getDtTpValue(key: string): string {
        return this._Values[key].dttp;
    }
    public getFkValue(key: string): string {
        return this._Values[key].fk;
    }
    public requiredValue(key: string): boolean {
        return this._Values[key].required;
    }
    public dbgeneratedValue(key: string): boolean {
        return this._Values[key].dbgenerated;
    }
    public isInPrimkeyValue(key: string): boolean {
        return this._Values[key].isinprimkey;
    }
    public IsInUnkKeyValue(key: string): boolean {
        return this._Values[key].isinunqkey;
    }
    public getKeyByOrgValue(org: string, fkchain: string): string|any {
        for(let i in this._Values) {
            if(this._Values[i].org === org && this._Values[i].fkchain ===fkchain) return i;
        }
        return undefined;
    }
    public getHiddenFilterAsFltRslt(hf: {[key: string]: {[key: string]: {[key: string]: any}}} | any): Array<IWebServiceFilterRslt> {
        let rslt: Array<IWebServiceFilterRslt> = [];
        if(typeof hf === 'undefined') return rslt;
        if(hf === null) return rslt;
        let m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = this.getm2cKeyfm();
        let m2cfm: {[key: string]: {[key: string]: {[key: string]: string}}} = this.getm2cfm();
        for(let i in hf) {
            for(let j in hf[i]) {
                if( Object.keys(m2cKeyfm).indexOf(i) > -1 ) {
                    if( Object.keys(m2cKeyfm[i]).indexOf(j) > -1 ) {
                        for(let k in m2cKeyfm[i][j]) {
                          if(!(typeof hf[i][j][k] === 'undefined' )) {
                            rslt.push({
                                fltrName: m2cKeyfm[i][j][k].propNm,
                                fltrDataType: this.getDtTpValue(m2cKeyfm[i][j][k].propNm),
                                fltrOperator: 'eq',
                                fltrValue: hf[i][j][k]
                            });
                          }
                        }
                    }
                }
/*
                if( Object.keys(m2cfm).indexOf(i) > -1 ) {
                    if( Object.keys(m2cfm[i]).indexOf(j) > -1 ) {
                        for(let k in m2cfm[i][j]) {
                          if(!(typeof hf[i][j][k] === 'undefined' )) {
                            rslt.push({
                                fltrName: m2cfm[i][j][k],
                                fltrDataType: this.getDtTpValue(m2cfm[i][j][k]),
                                fltrOperator: 'eq',
                                fltrValue: hf[i][j][k]
                            });
                          }
                        }
                    }
                }
*/
            }
        }
        return rslt;
    }


    //
    // first key is Master View Name, 
    // second key is Direct Navigation Name, 
    // third key is Master View Property Name, 
    // value is a  Client View Property Name, i.e. Property Name of the Current View 
    protected _m2cKeyfm: {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} = {
                'aspnetuserView' : {
                    'AspNetUser' : {
                        'id' : {isMstrReq: true, propNm:'userId'},
                    },
                },
                'aspnetmodelView' : {
                    'AspNetModel' : {
                        'modelPk' : {isMstrReq: true, propNm:'modelPkRef'},
                    },
                }
    }; 
    public getm2cKeyfm(): {[key: string]: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}}} {
        return this._m2cKeyfm;
    }
    //
    // first key is Master View Name, 
    // second key is Direct Navigation Name, 
    // third key is Master View Property Name, 
    // value is a  Client View Property Name, i.e. Property Name of the Current View 
    protected _m2cfm: {[key: string]: {[key: string]: {[key: string]: string}}} = {
                'aspnetuserView' : {
                    'AspNetUser' : {
                        'email' : 'uEmail',
                        'userName' : 'uUserName',
                    },
                },
                'aspnetmodelView' : {
                    'AspNetModel' : {
                        'modelName' : 'mModelName',
                    },
                }
    };
    public getm2cfm(): {[key: string]: {[key: string]: {[key: string]: string}}} {
        return this._m2cfm;
    }
    public getHiddenFilterByFltRslt(fr:  Array<IWebServiceFilterRslt> | any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {};
        if ((typeof fr === 'undefined') || (typeof this._m2cKeyfm === 'undefined')) return rslt;
        if ((fr === null) || (this._m2cKeyfm === null)) return rslt;
        let currMstr: string = "";
        let currNav: string = "";
        for(let i in this._m2cKeyfm) {
            for(let j in this._m2cKeyfm[i]) {
                for(let k in this._m2cKeyfm[i][j]) {
                    let fld = this._m2cKeyfm[i][j][k];
                    let r: IWebServiceFilterRslt = fr.find((e:IWebServiceFilterRslt | any) => e.fltrName === fld.propNm);
                    if (typeof r === 'undefined') continue;
                    if (currMstr !== i) { currMstr = i; rslt[currMstr] = {} }
                    if (currNav !== j) { currNav = j; rslt[currMstr][currNav] = {} }
                    rslt[currMstr][currNav][k] = r.fltrValue;
                }
            }
        }
        return rslt;
    }

    // first key is Client View Name, 
    // second key is Direct Navigation Name, 
    // third key is Client View Property Name, 
    // value is a Master View Property Name, i.e. Property Name of the Current View 
    protected _c2mfm: {[key: string]: {[key: string]: {[key: string]: string}}} = {
    }
    public getc2mfm(): {[key: string]: {[key: string]: {[key: string]: string}}} {
        return this._c2mfm;
    }



    // 
    // HowTo: flt is of type IaspnetusermaskViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IaspnetusermaskViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IaspnetusermaskViewFilter): Observable<IaspnetusermaskViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.userId === 'undefined')) {
                    if ( Array.isArray(filter.userId )) {
                        filter.userId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('userId', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.userId ))
                } // if (!(typeof filter.userId === 'undefined'))


                if (!(typeof  filter.userIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.userIdOprtr )) {
                        filter.userIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('userIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('userIdOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.userIdOprtr))
                } // if (!(typeof  filter.userIdOprtr === 'undefined'))

                if (!(typeof filter.orderby === 'undefined')) {
                    if ( Array.isArray(filter.orderby)) {
                        filter.orderby.forEach(function (value) {
                            if (!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('orderby', value);
                                    hasFilter = true;
                                }
                            }
                        });
                    }
                }
                if (!(typeof filter.page === 'undefined')) {
                    if (!(filter.page === null)) {
                        params = params.append('page', filter.page.toString());
                        hasFilter = true;
                    }
                }
                if (!(typeof filter.pagesize === 'undefined')) {
                    if (!(filter.pagesize === null)) {
                        params = params.append('pagesize', filter.pagesize.toString());
                        hasFilter = true;
                    }
                }
            } // if (!(filter === null ))
        } // if (!(typeof filter === 'undefined'))
        const options = hasFilter ? { params } : {};
        return this.http.get<IaspnetusermaskViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }





    src2dest(src: IaspnetusermaskView, dest: IaspnetusermaskView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.userId === 'undefined') {
            dest['userId'] = null;
        } else {
            dest['userId'] = src.userId;
        }
        if(typeof src.mask1 === 'undefined') {
            dest['mask1'] = null;
        } else {
            dest['mask1'] = src.mask1;
        }
        if(typeof src.mask2 === 'undefined') {
            dest['mask2'] = null;
        } else {
            dest['mask2'] = src.mask2;
        }
        if(typeof src.mask3 === 'undefined') {
            dest['mask3'] = null;
        } else {
            dest['mask3'] = src.mask3;
        }
        if(typeof src.mask4 === 'undefined') {
            dest['mask4'] = null;
        } else {
            dest['mask4'] = src.mask4;
        }
        if(typeof src.mask5 === 'undefined') {
            dest['mask5'] = null;
        } else {
            dest['mask5'] = src.mask5;
        }
        if(typeof src.modelPkRef === 'undefined') {
            dest['modelPkRef'] = null;
        } else {
            dest['modelPkRef'] = src.modelPkRef;
        }
        if(typeof src.uEmail === 'undefined') {
            dest['uEmail'] = null;
        } else {
            dest['uEmail'] = src.uEmail;
        }
        if(typeof src.uUserName === 'undefined') {
            dest['uUserName'] = null;
        } else {
            dest['uUserName'] = src.uUserName;
        }
        if(typeof src.mModelName === 'undefined') {
            dest['mModelName'] = null;
        } else {
            dest['mModelName'] = src.mModelName;
        }
        
    }

    row2FilterRslt(r: IaspnetusermaskView| any): Array<IWebServiceFilterRslt> {
        let rslt: Array<IWebServiceFilterRslt> = [];
        if (typeof r === 'undefined') return rslt;
        if (r === null) return rslt;
        for(let i in this._Values) {
            if (!(typeof r[i] === 'undefined')) {
                rslt.push({
                    fltrName: i,
                    fltrDataType: this._Values[i].dttp,
                    fltrOperator: 'eq',
                    fltrValue: r[i]
                });
            }
        }
        return rslt
    }

        

}

