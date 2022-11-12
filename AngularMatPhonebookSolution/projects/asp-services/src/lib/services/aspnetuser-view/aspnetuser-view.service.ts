
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IaspnetuserView } from 'asp-interfaces';
import { IaspnetuserViewPage } from 'asp-interfaces';
import { IaspnetuserViewFilter } from 'asp-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class AspnetuserViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('aspnetuserView') + 'aspnetuserviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'id': {org: 'Id', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'string'},  // string, System.String
      'email': {org: 'Email', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'emailConfirmed': {org: 'EmailConfirmed', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'phoneNumber': {org: 'PhoneNumber', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'phoneNumberConfirmed': {org: 'PhoneNumberConfirmed', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'twoFactorEnabled': {org: 'TwoFactorEnabled', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'lockoutEnd': {org: 'LockoutEnd', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'datetimeoffset'},  // number | null, System.DateTimeOffset ?
      'lockoutEnabled': {org: 'LockoutEnabled', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'accessFailedCount': {org: 'AccessFailedCount', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'userName': {org: 'UserName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IaspnetuserView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['aspnetuserView'] === 'undefined') rslt['aspnetuserView'] = {};
                if(typeof rslt['aspnetuserView'][nvNm] === 'undefined') rslt['aspnetuserView'][nvNm] = {};
                rslt['aspnetuserView'][nvNm][i] = rw[i];
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
                'aspnetusermaskView' : {
                    'AspNetUser' : {
                        'userId' : 'id',
                    },
                },
                'aspnetuserrolesView' : {
                    'AspNetUser' : {
                        'userId' : 'id',
                    },
                },
    }
    public getc2mfm(): {[key: string]: {[key: string]: {[key: string]: string}}} {
        return this._c2mfm;
    }


    // 
    // HowTo:
    //
    // this.serviceRefInYourCode.getall().subscibe(value =>{
    //    // handling value of type IaspnetuserView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<IaspnetuserView[]> {

        return this.http.get<IaspnetuserView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type IaspnetuserViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IaspnetuserViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IaspnetuserViewFilter): Observable<IaspnetuserViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.id === 'undefined')) {
                    if ( Array.isArray(filter.id )) {
                        filter.id.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('id', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.id ))
                } // if (!(typeof filter.id === 'undefined'))
                if (!(typeof filter.email === 'undefined')) {
                    if ( Array.isArray(filter.email )) {
                        filter.email.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('email', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.email ))
                } // if (!(typeof filter.email === 'undefined'))
                if (!(typeof filter.phoneNumber === 'undefined')) {
                    if ( Array.isArray(filter.phoneNumber )) {
                        filter.phoneNumber.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneNumber', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneNumber ))
                } // if (!(typeof filter.phoneNumber === 'undefined'))
                if (!(typeof filter.userName === 'undefined')) {
                    if ( Array.isArray(filter.userName )) {
                        filter.userName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('userName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.userName ))
                } // if (!(typeof filter.userName === 'undefined'))


                if (!(typeof  filter.idOprtr === 'undefined')) {
                    if (Array.isArray(filter.idOprtr )) {
                        filter.idOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('idOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('idOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.idOprtr))
                } // if (!(typeof  filter.idOprtr === 'undefined'))
                if (!(typeof  filter.emailOprtr === 'undefined')) {
                    if (Array.isArray(filter.emailOprtr )) {
                        filter.emailOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('emailOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('emailOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.emailOprtr))
                } // if (!(typeof  filter.emailOprtr === 'undefined'))
                if (!(typeof  filter.phoneNumberOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneNumberOprtr )) {
                        filter.phoneNumberOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneNumberOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneNumberOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneNumberOprtr))
                } // if (!(typeof  filter.phoneNumberOprtr === 'undefined'))
                if (!(typeof  filter.userNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.userNameOprtr )) {
                        filter.userNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('userNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('userNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.userNameOprtr))
                } // if (!(typeof  filter.userNameOprtr === 'undefined'))

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
        return this.http.get<IaspnetuserViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type IaspnetuserView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  id: string|any 
        ): Observable<IaspnetuserView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof id === 'undefined')) {
            if (!(id === null)) {
                params = params.append('id', id);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<IaspnetuserView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: IaspnetuserViewFilter): Observable<IaspnetuserViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.id === 'undefined')) {
                    if ( Array.isArray(filter.id )) {
                        filter.id.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('id', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.id ))
                } // if (!(typeof filter.id === 'undefined'))
                if (!(typeof  filter.idOprtr === 'undefined')) {
                    if (Array.isArray(filter.idOprtr )) {
                        filter.idOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('idOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('idOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.idOprtr))
                } // if (!(typeof  filter.idOprtr === 'undefined'))

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
        return this.http.get<IaspnetuserViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type IaspnetuserView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type IaspnetuserView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: IaspnetuserView): Observable<IaspnetuserView> {

        return this.http.put<IaspnetuserView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type IaspnetuserView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type IaspnetuserView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: IaspnetuserView): Observable<IaspnetuserView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.id === 'undefined') {
                    item['id'] = '0';
                }
                if(item.id === null) {
                    item['id'] = '0';
                }
            }
        }
        return this.http.post<IaspnetuserView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type IaspnetuserView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type IaspnetuserView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(id: string|any ): Observable<IaspnetuserView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof id === 'undefined')) {
            if (!(id === null)) {
                params = params.append('id', id);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<IaspnetuserView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: IaspnetuserView, dest: IaspnetuserView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.id === 'undefined') {
            dest['id'] = null;
        } else {
            dest['id'] = src.id;
        }
        if(typeof src.email === 'undefined') {
            dest['email'] = null;
        } else {
            dest['email'] = src.email;
        }
        if(typeof src.emailConfirmed === 'undefined') {
            dest['emailConfirmed'] = null;
        } else {
            dest['emailConfirmed'] = src.emailConfirmed;
        }
        if(typeof src.phoneNumber === 'undefined') {
            dest['phoneNumber'] = null;
        } else {
            dest['phoneNumber'] = src.phoneNumber;
        }
        if(typeof src.phoneNumberConfirmed === 'undefined') {
            dest['phoneNumberConfirmed'] = null;
        } else {
            dest['phoneNumberConfirmed'] = src.phoneNumberConfirmed;
        }
        if(typeof src.twoFactorEnabled === 'undefined') {
            dest['twoFactorEnabled'] = null;
        } else {
            dest['twoFactorEnabled'] = src.twoFactorEnabled;
        }
        if(typeof src.lockoutEnd === 'undefined') {
            dest['lockoutEnd'] = null;
        } else {
            dest['lockoutEnd'] = src.lockoutEnd;
        }
        if(typeof src.lockoutEnabled === 'undefined') {
            dest['lockoutEnabled'] = null;
        } else {
            dest['lockoutEnabled'] = src.lockoutEnabled;
        }
        if(typeof src.accessFailedCount === 'undefined') {
            dest['accessFailedCount'] = null;
        } else {
            dest['accessFailedCount'] = src.accessFailedCount;
        }
        if(typeof src.userName === 'undefined') {
            dest['userName'] = null;
        } else {
            dest['userName'] = src.userName;
        }
        
    }

    row2FilterRslt(r: IaspnetuserView| any): Array<IWebServiceFilterRslt> {
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

