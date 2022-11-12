
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILpdEmpSecondNameView } from 'phonebook-interfaces';
import { ILpdEmpSecondNameViewPage } from 'phonebook-interfaces';
import { ILpdEmpSecondNameViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LpdEmpSecondNameViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LpdEmpSecondNameView') + 'lpdempsecondnameviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'empSecondNameId': {org: 'EmpSecondNameId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'empSecondName': {org: 'EmpSecondName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: true, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILpdEmpSecondNameView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LpdEmpSecondNameView'] === 'undefined') rslt['LpdEmpSecondNameView'] = {};
                if(typeof rslt['LpdEmpSecondNameView'][nvNm] === 'undefined') rslt['LpdEmpSecondNameView'][nvNm] = {};
                rslt['LpdEmpSecondNameView'][nvNm][i] = rw[i];
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
                    'EmpSecondNameDict' : {
                        'empSecondNameIdRef' : 'empSecondNameId',
                    },
                },
                'LprEmployee02View' : {
                    'EmpSecondNameDict' : {
                        'empSecondNameIdRef' : 'empSecondNameId',
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
    //    // handling value of type ILpdEmpSecondNameView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILpdEmpSecondNameView[]> {

        return this.http.get<ILpdEmpSecondNameView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILpdEmpSecondNameViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILpdEmpSecondNameViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILpdEmpSecondNameViewFilter): Observable<ILpdEmpSecondNameViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.empSecondNameId === 'undefined')) {
                    if ( Array.isArray(filter.empSecondNameId )) {
                        filter.empSecondNameId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empSecondNameId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empSecondNameId ))
                } // if (!(typeof filter.empSecondNameId === 'undefined'))
                if (!(typeof filter.empSecondName === 'undefined')) {
                    if ( Array.isArray(filter.empSecondName )) {
                        filter.empSecondName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empSecondName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empSecondName ))
                } // if (!(typeof filter.empSecondName === 'undefined'))


                if (!(typeof  filter.empSecondNameIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.empSecondNameIdOprtr )) {
                        filter.empSecondNameIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empSecondNameIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empSecondNameIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empSecondNameIdOprtr))
                } // if (!(typeof  filter.empSecondNameIdOprtr === 'undefined'))
                if (!(typeof  filter.empSecondNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.empSecondNameOprtr )) {
                        filter.empSecondNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empSecondNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empSecondNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empSecondNameOprtr))
                } // if (!(typeof  filter.empSecondNameOprtr === 'undefined'))

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
        return this.http.get<ILpdEmpSecondNameViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdEmpSecondNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  empSecondNameId: number|any 
        ): Observable<ILpdEmpSecondNameView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof empSecondNameId === 'undefined')) {
            if (!(empSecondNameId === null)) {
                params = params.append('empSecondNameId', empSecondNameId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdEmpSecondNameView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILpdEmpSecondNameViewFilter): Observable<ILpdEmpSecondNameViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.empSecondNameId === 'undefined')) {
                    if ( Array.isArray(filter.empSecondNameId )) {
                        filter.empSecondNameId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empSecondNameId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empSecondNameId ))
                } // if (!(typeof filter.empSecondNameId === 'undefined'))
                if (!(typeof  filter.empSecondNameIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.empSecondNameIdOprtr )) {
                        filter.empSecondNameIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empSecondNameIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empSecondNameIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empSecondNameIdOprtr))
                } // if (!(typeof  filter.empSecondNameIdOprtr === 'undefined'))

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
        return this.http.get<ILpdEmpSecondNameViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getonebyLpdEmpSecondNameUK(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdEmpSecondNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getonebyLpdEmpSecondNameUK(
                  empSecondName: string | null|any 
        ): Observable<ILpdEmpSecondNameView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof empSecondName === 'undefined')) {
            if (!(empSecondName === null)) {
                params = params.append('empSecondName', empSecondName);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILpdEmpSecondNameView>(this.serviceUrl+'/getonebyLpdEmpSecondNameUK', options);
          // .pipe(
          //   catchError(this.handleError('getonebyLpdEmpSecondNameUK', []))
          // );
    }

    getmanybyrepunqLpdEmpSecondNameUK(filter: ILpdEmpSecondNameViewFilter): Observable<ILpdEmpSecondNameViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.empSecondName === 'undefined')) {
                    if ( Array.isArray(filter.empSecondName )) {
                        filter.empSecondName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empSecondName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empSecondName ))
                } // if (!(typeof filter.empSecondName === 'undefined'))
                if (!(typeof  filter.empSecondNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.empSecondNameOprtr )) {
                        filter.empSecondNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empSecondNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empSecondNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empSecondNameOprtr))
                } // if (!(typeof  filter.empSecondNameOprtr === 'undefined'))

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
        return this.http.get<ILpdEmpSecondNameViewPage>(this.serviceUrl+'/getmanybyrepunqLpdEmpSecondNameUK', options);
    }


    // 
    // HowTo: item is of type ILpdEmpSecondNameView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILpdEmpSecondNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILpdEmpSecondNameView): Observable<ILpdEmpSecondNameView> {

        return this.http.put<ILpdEmpSecondNameView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILpdEmpSecondNameView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILpdEmpSecondNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILpdEmpSecondNameView): Observable<ILpdEmpSecondNameView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.empSecondNameId === 'undefined') {
                    item['empSecondNameId'] = 0;
                }
                if(item.empSecondNameId === null) {
                    item['empSecondNameId'] = 0;
                }
            }
        }
        return this.http.post<ILpdEmpSecondNameView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILpdEmpSecondNameView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILpdEmpSecondNameView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(empSecondNameId: number|any ): Observable<ILpdEmpSecondNameView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof empSecondNameId === 'undefined')) {
            if (!(empSecondNameId === null)) {
                params = params.append('empSecondNameId', empSecondNameId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILpdEmpSecondNameView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILpdEmpSecondNameView, dest: ILpdEmpSecondNameView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.empSecondNameId === 'undefined') {
            dest['empSecondNameId'] = null;
        } else {
            dest['empSecondNameId'] = src.empSecondNameId;
        }
        if(typeof src.empSecondName === 'undefined') {
            dest['empSecondName'] = null;
        } else {
            dest['empSecondName'] = src.empSecondName;
        }
        
    }

    row2FilterRslt(r: ILpdEmpSecondNameView| any): Array<IWebServiceFilterRslt> {
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

