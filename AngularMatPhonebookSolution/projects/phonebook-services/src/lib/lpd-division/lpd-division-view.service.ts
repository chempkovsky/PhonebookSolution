
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILpdDivisionView } from 'phonebook-interfaces';
import { ILpdDivisionViewPage } from 'phonebook-interfaces';
import { ILpdDivisionViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LpdDivisionViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LpdDivisionView') + 'lpddivisionviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'divisionNameId': {org: 'DivisionNameId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'divisionName': {org: 'DivisionName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: true, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILpdDivisionView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LpdDivisionView'] === 'undefined') rslt['LpdDivisionView'] = {};
                if(typeof rslt['LpdDivisionView'][nvNm] === 'undefined') rslt['LpdDivisionView'][nvNm] = {};
                rslt['LpdDivisionView'][nvNm][i] = rw[i];
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
                'LprDivision01View' : {
                    'DivisionNameDict' : {
                        'divisionNameIdRef' : 'divisionNameId',
                    },
                },
                'LprDivision02View' : {
                    'DivisionNameDict' : {
                        'divisionNameIdRef' : 'divisionNameId',
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
    //    // handling value of type ILpdDivisionView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILpdDivisionView[]> {

        return this.http.get<ILpdDivisionView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILpdDivisionViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILpdDivisionViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILpdDivisionViewFilter): Observable<ILpdDivisionViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.divisionNameId === 'undefined')) {
                    if ( Array.isArray(filter.divisionNameId )) {
                        filter.divisionNameId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionNameId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionNameId ))
                } // if (!(typeof filter.divisionNameId === 'undefined'))
                if (!(typeof filter.divisionName === 'undefined')) {
                    if ( Array.isArray(filter.divisionName )) {
                        filter.divisionName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionName ))
                } // if (!(typeof filter.divisionName === 'undefined'))


                if (!(typeof  filter.divisionNameIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionNameIdOprtr )) {
                        filter.divisionNameIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionNameIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionNameIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionNameIdOprtr))
                } // if (!(typeof  filter.divisionNameIdOprtr === 'undefined'))
                if (!(typeof  filter.divisionNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionNameOprtr )) {
                        filter.divisionNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionNameOprtr))
                } // if (!(typeof  filter.divisionNameOprtr === 'undefined'))

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
        return this.http.get<ILpdDivisionViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdDivisionView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  divisionNameId: number|any 
        ): Observable<ILpdDivisionView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof divisionNameId === 'undefined')) {
            if (!(divisionNameId === null)) {
                params = params.append('divisionNameId', divisionNameId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdDivisionView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILpdDivisionViewFilter): Observable<ILpdDivisionViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.divisionNameId === 'undefined')) {
                    if ( Array.isArray(filter.divisionNameId )) {
                        filter.divisionNameId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionNameId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionNameId ))
                } // if (!(typeof filter.divisionNameId === 'undefined'))
                if (!(typeof  filter.divisionNameIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionNameIdOprtr )) {
                        filter.divisionNameIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionNameIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionNameIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionNameIdOprtr))
                } // if (!(typeof  filter.divisionNameIdOprtr === 'undefined'))

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
        return this.http.get<ILpdDivisionViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getonebyLpdDivisionNameUk(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdDivisionView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getonebyLpdDivisionNameUk(
                  divisionName: string|any 
        ): Observable<ILpdDivisionView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof divisionName === 'undefined')) {
            if (!(divisionName === null)) {
                params = params.append('divisionName', divisionName);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdDivisionView>(this.serviceUrl+'/getonebyLpdDivisionNameUk', options);
          // .pipe(
          //   catchError(this.handleError('getonebyLpdDivisionNameUk', []))
          // );
    }

    getmanybyrepunqLpdDivisionNameUk(filter: ILpdDivisionViewFilter): Observable<ILpdDivisionViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.divisionName === 'undefined')) {
                    if ( Array.isArray(filter.divisionName )) {
                        filter.divisionName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionName ))
                } // if (!(typeof filter.divisionName === 'undefined'))
                if (!(typeof  filter.divisionNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionNameOprtr )) {
                        filter.divisionNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionNameOprtr))
                } // if (!(typeof  filter.divisionNameOprtr === 'undefined'))

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
        return this.http.get<ILpdDivisionViewPage>(this.serviceUrl+'/getmanybyrepunqLpdDivisionNameUk', options);
    }


    // 
    // HowTo: item is of type ILpdDivisionView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILpdDivisionView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILpdDivisionView): Observable<ILpdDivisionView> {

        return this.http.put<ILpdDivisionView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILpdDivisionView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILpdDivisionView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILpdDivisionView): Observable<ILpdDivisionView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.divisionNameId === 'undefined') {
                    item['divisionNameId'] = 0;
                }
                if(item.divisionNameId === null) {
                    item['divisionNameId'] = 0;
                }
            }
        }
        return this.http.post<ILpdDivisionView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILpdDivisionView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILpdDivisionView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(divisionNameId: number|any ): Observable<ILpdDivisionView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof divisionNameId === 'undefined')) {
            if (!(divisionNameId === null)) {
                params = params.append('divisionNameId', divisionNameId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILpdDivisionView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILpdDivisionView, dest: ILpdDivisionView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.divisionNameId === 'undefined') {
            dest['divisionNameId'] = null;
        } else {
            dest['divisionNameId'] = src.divisionNameId;
        }
        if(typeof src.divisionName === 'undefined') {
            dest['divisionName'] = null;
        } else {
            dest['divisionName'] = src.divisionName;
        }
        
    }

    row2FilterRslt(r: ILpdDivisionView| any): Array<IWebServiceFilterRslt> {
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

