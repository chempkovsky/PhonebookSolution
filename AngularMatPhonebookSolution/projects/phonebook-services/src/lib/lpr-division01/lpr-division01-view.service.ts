
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILprDivision01View } from 'phonebook-interfaces';
import { ILprDivision01ViewPage } from 'phonebook-interfaces';
import { ILprDivision01ViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LprDivision01ViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LprDivision01View') + 'lprdivision01viewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'divisionId': {org: 'DivisionId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'divisionNameIdRef': {org: 'DivisionNameIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILprDivision01View|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LprDivision01View'] === 'undefined') rslt['LprDivision01View'] = {};
                if(typeof rslt['LprDivision01View'][nvNm] === 'undefined') rslt['LprDivision01View'][nvNm] = {};
                rslt['LprDivision01View'][nvNm][i] = rw[i];
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
                'PhbkDivisionView' : {
                    'Division' : {
                        'divisionId' : {isMstrReq: true, propNm:'divisionId'},
                    },
                },
                'LpdDivisionView' : {
                    'DivisionNameDict' : {
                        'divisionNameId' : {isMstrReq: true, propNm:'divisionNameIdRef'},
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
                'PhbkDivisionView' : {
                    'Division' : {
                    },
                },
                'LpdDivisionView' : {
                    'DivisionNameDict' : {
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
    //    // handling value of type ILprDivision01View[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILprDivision01View[]> {

        return this.http.get<ILprDivision01View[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILprDivision01ViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILprDivision01ViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILprDivision01ViewFilter): Observable<ILprDivision01ViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.divisionId === 'undefined')) {
                    if ( Array.isArray(filter.divisionId )) {
                        filter.divisionId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionId ))
                } // if (!(typeof filter.divisionId === 'undefined'))
                if (!(typeof filter.divisionNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.divisionNameIdRef )) {
                        filter.divisionNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionNameIdRef ))
                } // if (!(typeof filter.divisionNameIdRef === 'undefined'))


                if (!(typeof  filter.divisionIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionIdOprtr )) {
                        filter.divisionIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionIdOprtr))
                } // if (!(typeof  filter.divisionIdOprtr === 'undefined'))
                if (!(typeof  filter.divisionNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionNameIdRefOprtr )) {
                        filter.divisionNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionNameIdRefOprtr))
                } // if (!(typeof  filter.divisionNameIdRefOprtr === 'undefined'))

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
        return this.http.get<ILprDivision01ViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILprDivision01View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  divisionNameIdRef: number|any 
                , divisionId: number|any 
        ): Observable<ILprDivision01View> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof divisionId === 'undefined')) {
            if (!(divisionId === null)) {
                params = params.append('divisionId', divisionId.toString());
                hasFilter = true;
            }
        }
        if (!(typeof divisionNameIdRef === 'undefined')) {
            if (!(divisionNameIdRef === null)) {
                params = params.append('divisionNameIdRef', divisionNameIdRef.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILprDivision01View>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILprDivision01ViewFilter): Observable<ILprDivision01ViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.divisionNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.divisionNameIdRef )) {
                        filter.divisionNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionNameIdRef ))
                } // if (!(typeof filter.divisionNameIdRef === 'undefined'))
                if (!(typeof filter.divisionId === 'undefined')) {
                    if ( Array.isArray(filter.divisionId )) {
                        filter.divisionId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionId ))
                } // if (!(typeof filter.divisionId === 'undefined'))
                if (!(typeof  filter.divisionNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionNameIdRefOprtr )) {
                        filter.divisionNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionNameIdRefOprtr))
                } // if (!(typeof  filter.divisionNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.divisionIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionIdOprtr )) {
                        filter.divisionIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionIdOprtr))
                } // if (!(typeof  filter.divisionIdOprtr === 'undefined'))

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
        return this.http.get<ILprDivision01ViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type ILprDivision01View 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILprDivision01View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILprDivision01View): Observable<ILprDivision01View> {

        return this.http.put<ILprDivision01View>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILprDivision01View 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILprDivision01View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILprDivision01View): Observable<ILprDivision01View> {
        return this.http.post<ILprDivision01View>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILprDivision01View 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILprDivision01View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(divisionNameIdRef: number|any , divisionId: number|any ): Observable<ILprDivision01View> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof divisionId === 'undefined')) {
            if (!(divisionId === null)) {
                params = params.append('divisionId', divisionId.toString());
                hasFilter = true;
            }
        }
        if (!(typeof divisionNameIdRef === 'undefined')) {
            if (!(divisionNameIdRef === null)) {
                params = params.append('divisionNameIdRef', divisionNameIdRef.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILprDivision01View>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILprDivision01View, dest: ILprDivision01View) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.divisionId === 'undefined') {
            dest['divisionId'] = null;
        } else {
            dest['divisionId'] = src.divisionId;
        }
        if(typeof src.divisionNameIdRef === 'undefined') {
            dest['divisionNameIdRef'] = null;
        } else {
            dest['divisionNameIdRef'] = src.divisionNameIdRef;
        }
        
    }

    row2FilterRslt(r: ILprDivision01View| any): Array<IWebServiceFilterRslt> {
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

