
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILpdPhoneView } from 'phonebook-interfaces';
import { ILpdPhoneViewPage } from 'phonebook-interfaces';
import { ILpdPhoneViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LpdPhoneViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LpdPhoneView') + 'lpdphoneviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'lpdPhoneId': {org: 'LpdPhoneId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'phone': {org: 'Phone', fk: '', fkchain: '', isinprimkey: false, isinunqkey: true, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILpdPhoneView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LpdPhoneView'] === 'undefined') rslt['LpdPhoneView'] = {};
                if(typeof rslt['LpdPhoneView'][nvNm] === 'undefined') rslt['LpdPhoneView'][nvNm] = {};
                rslt['LpdPhoneView'][nvNm][i] = rw[i];
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
                'LprPhone01View' : {
                    'PhoneDict' : {
                        'lpdPhoneIdRef' : 'lpdPhoneId',
                    },
                },
                'LprPhone02View' : {
                    'PhoneDict' : {
                        'lpdPhoneIdRef' : 'lpdPhoneId',
                    },
                },
                'LprPhone03View' : {
                    'PhoneDict' : {
                        'lpdPhoneIdRef' : 'lpdPhoneId',
                    },
                },
                'LprPhone04View' : {
                    'PhoneDict' : {
                        'lpdPhoneIdRef' : 'lpdPhoneId',
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
    //    // handling value of type ILpdPhoneView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILpdPhoneView[]> {

        return this.http.get<ILpdPhoneView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILpdPhoneViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILpdPhoneViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILpdPhoneViewFilter): Observable<ILpdPhoneViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.lpdPhoneId === 'undefined')) {
                    if ( Array.isArray(filter.lpdPhoneId )) {
                        filter.lpdPhoneId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('lpdPhoneId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.lpdPhoneId ))
                } // if (!(typeof filter.lpdPhoneId === 'undefined'))
                if (!(typeof filter.phone === 'undefined')) {
                    if ( Array.isArray(filter.phone )) {
                        filter.phone.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phone', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phone ))
                } // if (!(typeof filter.phone === 'undefined'))


                if (!(typeof  filter.lpdPhoneIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.lpdPhoneIdOprtr )) {
                        filter.lpdPhoneIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('lpdPhoneIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('lpdPhoneIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.lpdPhoneIdOprtr))
                } // if (!(typeof  filter.lpdPhoneIdOprtr === 'undefined'))
                if (!(typeof  filter.phoneOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneOprtr )) {
                        filter.phoneOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneOprtr))
                } // if (!(typeof  filter.phoneOprtr === 'undefined'))

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
        return this.http.get<ILpdPhoneViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  lpdPhoneId: number|any 
        ): Observable<ILpdPhoneView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof lpdPhoneId === 'undefined')) {
            if (!(lpdPhoneId === null)) {
                params = params.append('lpdPhoneId', lpdPhoneId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdPhoneView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILpdPhoneViewFilter): Observable<ILpdPhoneViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.lpdPhoneId === 'undefined')) {
                    if ( Array.isArray(filter.lpdPhoneId )) {
                        filter.lpdPhoneId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('lpdPhoneId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.lpdPhoneId ))
                } // if (!(typeof filter.lpdPhoneId === 'undefined'))
                if (!(typeof  filter.lpdPhoneIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.lpdPhoneIdOprtr )) {
                        filter.lpdPhoneIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('lpdPhoneIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('lpdPhoneIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.lpdPhoneIdOprtr))
                } // if (!(typeof  filter.lpdPhoneIdOprtr === 'undefined'))

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
        return this.http.get<ILpdPhoneViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getonebyLpdPhoneUK(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getonebyLpdPhoneUK(
                  phone: string|any 
        ): Observable<ILpdPhoneView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phone === 'undefined')) {
            if (!(phone === null)) {
                params = params.append('phone', phone);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdPhoneView>(this.serviceUrl+'/getonebyLpdPhoneUK', options);
          // .pipe(
          //   catchError(this.handleError('getonebyLpdPhoneUK', []))
          // );
    }

    getmanybyrepunqLpdPhoneUK(filter: ILpdPhoneViewFilter): Observable<ILpdPhoneViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.phone === 'undefined')) {
                    if ( Array.isArray(filter.phone )) {
                        filter.phone.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phone', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phone ))
                } // if (!(typeof filter.phone === 'undefined'))
                if (!(typeof  filter.phoneOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneOprtr )) {
                        filter.phoneOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneOprtr))
                } // if (!(typeof  filter.phoneOprtr === 'undefined'))

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
        return this.http.get<ILpdPhoneViewPage>(this.serviceUrl+'/getmanybyrepunqLpdPhoneUK', options);
    }


    // 
    // HowTo: item is of type ILpdPhoneView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILpdPhoneView): Observable<ILpdPhoneView> {

        return this.http.put<ILpdPhoneView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILpdPhoneView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILpdPhoneView): Observable<ILpdPhoneView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.lpdPhoneId === 'undefined') {
                    item['lpdPhoneId'] = 0;
                }
                if(item.lpdPhoneId === null) {
                    item['lpdPhoneId'] = 0;
                }
            }
        }
        return this.http.post<ILpdPhoneView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILpdPhoneView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(lpdPhoneId: number|any ): Observable<ILpdPhoneView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof lpdPhoneId === 'undefined')) {
            if (!(lpdPhoneId === null)) {
                params = params.append('lpdPhoneId', lpdPhoneId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILpdPhoneView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILpdPhoneView, dest: ILpdPhoneView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.lpdPhoneId === 'undefined') {
            dest['lpdPhoneId'] = null;
        } else {
            dest['lpdPhoneId'] = src.lpdPhoneId;
        }
        if(typeof src.phone === 'undefined') {
            dest['phone'] = null;
        } else {
            dest['phone'] = src.phone;
        }
        
    }

    row2FilterRslt(r: ILpdPhoneView| any): Array<IWebServiceFilterRslt> {
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

