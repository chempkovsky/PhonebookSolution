
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IaspnetuserrolesView } from 'asp-interfaces';
import { IaspnetuserrolesViewPage } from 'asp-interfaces';
import { IaspnetuserrolesViewFilter } from 'asp-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class AspnetuserrolesViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('aspnetuserrolesView') + 'aspnetuserrolesviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'userId': {org: 'UserId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'string'},  // string, System.String
      'roleId': {org: 'RoleId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'uLockoutEnd': {org: 'LockoutEnd', fk: 'AspNetUser', fkchain: 'AspNetUser', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'datetimeoffset'},  // number | null, System.DateTimeOffset ?
      'uUserName': {org: 'UserName', fk: 'AspNetUser', fkchain: 'AspNetUser', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'rName': {org: 'Name', fk: 'AspNetRole', fkchain: 'AspNetRole', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IaspnetuserrolesView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['aspnetuserrolesView'] === 'undefined') rslt['aspnetuserrolesView'] = {};
                if(typeof rslt['aspnetuserrolesView'][nvNm] === 'undefined') rslt['aspnetuserrolesView'][nvNm] = {};
                rslt['aspnetuserrolesView'][nvNm][i] = rw[i];
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
                'aspnetroleView' : {
                    'AspNetRole' : {
                        'id' : {isMstrReq: true, propNm:'roleId'},
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
                        'lockoutEnd' : 'uLockoutEnd',
                        'userName' : 'uUserName',
                    },
                },
                'aspnetroleView' : {
                    'AspNetRole' : {
                        'name' : 'rName',
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
    // HowTo:
    //
    // this.serviceRefInYourCode.getall().subscibe(value =>{
    //    // handling value of type IaspnetuserrolesView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<IaspnetuserrolesView[]> {

        return this.http.get<IaspnetuserrolesView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type IaspnetuserrolesViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IaspnetuserrolesViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IaspnetuserrolesViewFilter): Observable<IaspnetuserrolesViewPage> {
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
                if (!(typeof filter.roleId === 'undefined')) {
                    if ( Array.isArray(filter.roleId )) {
                        filter.roleId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('roleId', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.roleId ))
                } // if (!(typeof filter.roleId === 'undefined'))
                if (!(typeof filter.uUserName === 'undefined')) {
                    if ( Array.isArray(filter.uUserName )) {
                        filter.uUserName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('uUserName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.uUserName ))
                } // if (!(typeof filter.uUserName === 'undefined'))
                if (!(typeof filter.rName === 'undefined')) {
                    if ( Array.isArray(filter.rName )) {
                        filter.rName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('rName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.rName ))
                } // if (!(typeof filter.rName === 'undefined'))


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
                if (!(typeof  filter.roleIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.roleIdOprtr )) {
                        filter.roleIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('roleIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('roleIdOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.roleIdOprtr))
                } // if (!(typeof  filter.roleIdOprtr === 'undefined'))
                if (!(typeof  filter.uUserNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.uUserNameOprtr )) {
                        filter.uUserNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('uUserNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('uUserNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.uUserNameOprtr))
                } // if (!(typeof  filter.uUserNameOprtr === 'undefined'))
                if (!(typeof  filter.rNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.rNameOprtr )) {
                        filter.rNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('rNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('rNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.rNameOprtr))
                } // if (!(typeof  filter.rNameOprtr === 'undefined'))

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
        return this.http.get<IaspnetuserrolesViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type IaspnetuserrolesView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  userId: string|any 
                , roleId: string|any 
        ): Observable<IaspnetuserrolesView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof userId === 'undefined')) {
            if (!(userId === null)) {
                params = params.append('userId', userId);
                hasFilter = true;
            }
        }
        if (!(typeof roleId === 'undefined')) {
            if (!(roleId === null)) {
                params = params.append('roleId', roleId);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<IaspnetuserrolesView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: IaspnetuserrolesViewFilter): Observable<IaspnetuserrolesViewPage> {
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
                if (!(typeof filter.roleId === 'undefined')) {
                    if ( Array.isArray(filter.roleId )) {
                        filter.roleId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('roleId', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.roleId ))
                } // if (!(typeof filter.roleId === 'undefined'))
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
                if (!(typeof  filter.roleIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.roleIdOprtr )) {
                        filter.roleIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('roleIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('roleIdOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.roleIdOprtr))
                } // if (!(typeof  filter.roleIdOprtr === 'undefined'))

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
        return this.http.get<IaspnetuserrolesViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type IaspnetuserrolesView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type IaspnetuserrolesView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: IaspnetuserrolesView): Observable<IaspnetuserrolesView> {

        return this.http.put<IaspnetuserrolesView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type IaspnetuserrolesView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type IaspnetuserrolesView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: IaspnetuserrolesView): Observable<IaspnetuserrolesView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.userId === 'undefined') {
                    item['userId'] = '0';
                }
                if(item.userId === null) {
                    item['userId'] = '0';
                }
            }
        }
        return this.http.post<IaspnetuserrolesView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type IaspnetuserrolesView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type IaspnetuserrolesView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(userId: string|any , roleId: string|any ): Observable<IaspnetuserrolesView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof userId === 'undefined')) {
            if (!(userId === null)) {
                params = params.append('userId', userId);
                hasFilter = true;
            }
        }
        if (!(typeof roleId === 'undefined')) {
            if (!(roleId === null)) {
                params = params.append('roleId', roleId);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<IaspnetuserrolesView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: IaspnetuserrolesView, dest: IaspnetuserrolesView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.userId === 'undefined') {
            dest['userId'] = null;
        } else {
            dest['userId'] = src.userId;
        }
        if(typeof src.roleId === 'undefined') {
            dest['roleId'] = null;
        } else {
            dest['roleId'] = src.roleId;
        }
        if(typeof src.uLockoutEnd === 'undefined') {
            dest['uLockoutEnd'] = null;
        } else {
            dest['uLockoutEnd'] = src.uLockoutEnd;
        }
        if(typeof src.uUserName === 'undefined') {
            dest['uUserName'] = null;
        } else {
            dest['uUserName'] = src.uUserName;
        }
        if(typeof src.rName === 'undefined') {
            dest['rName'] = null;
        } else {
            dest['rName'] = src.rName;
        }
        
    }

    row2FilterRslt(r: IaspnetuserrolesView| any): Array<IWebServiceFilterRslt> {
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

