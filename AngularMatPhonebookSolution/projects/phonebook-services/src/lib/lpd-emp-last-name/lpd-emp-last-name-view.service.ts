
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILpdEmpLastNameView } from 'phonebook-interfaces';
import { ILpdEmpLastNameViewPage } from 'phonebook-interfaces';
import { ILpdEmpLastNameViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LpdEmpLastNameViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LpdEmpLastNameView') + 'lpdemplastnameviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'empLastNameId': {org: 'EmpLastNameId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'empLastName': {org: 'EmpLastName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: true, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILpdEmpLastNameView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LpdEmpLastNameView'] === 'undefined') rslt['LpdEmpLastNameView'] = {};
                if(typeof rslt['LpdEmpLastNameView'][nvNm] === 'undefined') rslt['LpdEmpLastNameView'][nvNm] = {};
                rslt['LpdEmpLastNameView'][nvNm][i] = rw[i];
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
                'LprEmployee01View' : {
                    'EmpLastNameDict' : {
                        'empLastNameIdRef' : 'empLastNameId',
                    },
                },
                'LprEmployee02View' : {
                    'EmpLastNameDict' : {
                        'empLastNameIdRef' : 'empLastNameId',
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
    //    // handling value of type ILpdEmpLastNameView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILpdEmpLastNameView[]> {

        return this.http.get<ILpdEmpLastNameView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILpdEmpLastNameViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILpdEmpLastNameViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILpdEmpLastNameViewFilter): Observable<ILpdEmpLastNameViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.empLastNameId === 'undefined')) {
                    if ( Array.isArray(filter.empLastNameId )) {
                        filter.empLastNameId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empLastNameId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empLastNameId ))
                } // if (!(typeof filter.empLastNameId === 'undefined'))
                if (!(typeof filter.empLastName === 'undefined')) {
                    if ( Array.isArray(filter.empLastName )) {
                        filter.empLastName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empLastName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empLastName ))
                } // if (!(typeof filter.empLastName === 'undefined'))


                if (!(typeof  filter.empLastNameIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.empLastNameIdOprtr )) {
                        filter.empLastNameIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empLastNameIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empLastNameIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empLastNameIdOprtr))
                } // if (!(typeof  filter.empLastNameIdOprtr === 'undefined'))
                if (!(typeof  filter.empLastNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.empLastNameOprtr )) {
                        filter.empLastNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empLastNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empLastNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empLastNameOprtr))
                } // if (!(typeof  filter.empLastNameOprtr === 'undefined'))

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
        return this.http.get<ILpdEmpLastNameViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdEmpLastNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  empLastNameId: number|any 
        ): Observable<ILpdEmpLastNameView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof empLastNameId === 'undefined')) {
            if (!(empLastNameId === null)) {
                params = params.append('empLastNameId', empLastNameId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdEmpLastNameView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILpdEmpLastNameViewFilter): Observable<ILpdEmpLastNameViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.empLastNameId === 'undefined')) {
                    if ( Array.isArray(filter.empLastNameId )) {
                        filter.empLastNameId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empLastNameId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empLastNameId ))
                } // if (!(typeof filter.empLastNameId === 'undefined'))
                if (!(typeof  filter.empLastNameIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.empLastNameIdOprtr )) {
                        filter.empLastNameIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empLastNameIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empLastNameIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empLastNameIdOprtr))
                } // if (!(typeof  filter.empLastNameIdOprtr === 'undefined'))

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
        return this.http.get<ILpdEmpLastNameViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getonebyLpdEmpLastNameUK(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdEmpLastNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getonebyLpdEmpLastNameUK(
                  empLastName: string|any 
        ): Observable<ILpdEmpLastNameView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof empLastName === 'undefined')) {
            if (!(empLastName === null)) {
                params = params.append('empLastName', empLastName);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdEmpLastNameView>(this.serviceUrl+'/getonebyLpdEmpLastNameUK', options);
          // .pipe(
          //   catchError(this.handleError('getonebyLpdEmpLastNameUK', []))
          // );
    }

    getmanybyrepunqLpdEmpLastNameUK(filter: ILpdEmpLastNameViewFilter): Observable<ILpdEmpLastNameViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.empLastName === 'undefined')) {
                    if ( Array.isArray(filter.empLastName )) {
                        filter.empLastName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empLastName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empLastName ))
                } // if (!(typeof filter.empLastName === 'undefined'))
                if (!(typeof  filter.empLastNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.empLastNameOprtr )) {
                        filter.empLastNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empLastNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empLastNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empLastNameOprtr))
                } // if (!(typeof  filter.empLastNameOprtr === 'undefined'))

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
        return this.http.get<ILpdEmpLastNameViewPage>(this.serviceUrl+'/getmanybyrepunqLpdEmpLastNameUK', options);
    }


    // 
    // HowTo: item is of type ILpdEmpLastNameView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILpdEmpLastNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILpdEmpLastNameView): Observable<ILpdEmpLastNameView> {

        return this.http.put<ILpdEmpLastNameView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILpdEmpLastNameView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILpdEmpLastNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILpdEmpLastNameView): Observable<ILpdEmpLastNameView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.empLastNameId === 'undefined') {
                    item['empLastNameId'] = 0;
                }
                if(item.empLastNameId === null) {
                    item['empLastNameId'] = 0;
                }
            }
        }
        return this.http.post<ILpdEmpLastNameView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILpdEmpLastNameView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILpdEmpLastNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(empLastNameId: number|any ): Observable<ILpdEmpLastNameView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof empLastNameId === 'undefined')) {
            if (!(empLastNameId === null)) {
                params = params.append('empLastNameId', empLastNameId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILpdEmpLastNameView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILpdEmpLastNameView, dest: ILpdEmpLastNameView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.empLastNameId === 'undefined') {
            dest['empLastNameId'] = null;
        } else {
            dest['empLastNameId'] = src.empLastNameId;
        }
        if(typeof src.empLastName === 'undefined') {
            dest['empLastName'] = null;
        } else {
            dest['empLastName'] = src.empLastName;
        }
        
    }

    row2FilterRslt(r: ILpdEmpLastNameView| any): Array<IWebServiceFilterRslt> {
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

