
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILprPhone04View } from 'phonebook-interfaces';
import { ILprPhone04ViewPage } from 'phonebook-interfaces';
import { ILprPhone04ViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LprPhone04ViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LprPhone04View') + 'lprphone04viewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'phoneId': {org: 'PhoneId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'lpdPhoneIdRef': {org: 'LpdPhoneIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'employeeIdRef': {org: 'EmployeeIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'phoneTypeIdRef': {org: 'PhoneTypeIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILprPhone04View|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LprPhone04View'] === 'undefined') rslt['LprPhone04View'] = {};
                if(typeof rslt['LprPhone04View'][nvNm] === 'undefined') rslt['LprPhone04View'][nvNm] = {};
                rslt['LprPhone04View'][nvNm][i] = rw[i];
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
                'LpdPhoneView' : {
                    'PhoneDict' : {
                        'lpdPhoneId' : {isMstrReq: true, propNm:'lpdPhoneIdRef'},
                    },
                },
                'PhbkPhoneView' : {
                    'Phone' : {
                        'phoneId' : {isMstrReq: true, propNm:'phoneId'},
                    },
                },
                'PhbkEmployeeView' : {
                    'Employee' : {
                        'employeeId' : {isMstrReq: true, propNm:'employeeIdRef'},
                    },
                },
                'PhbkPhoneTypeView' : {
                    'PhoneType' : {
                        'phoneTypeId' : {isMstrReq: true, propNm:'phoneTypeIdRef'},
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
                'LpdPhoneView' : {
                    'PhoneDict' : {
                    },
                },
                'PhbkPhoneView' : {
                    'Phone' : {
                    },
                },
                'PhbkEmployeeView' : {
                    'Employee' : {
                    },
                },
                'PhbkPhoneTypeView' : {
                    'PhoneType' : {
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
    //    // handling value of type ILprPhone04View[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILprPhone04View[]> {

        return this.http.get<ILprPhone04View[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILprPhone04ViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILprPhone04ViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILprPhone04ViewFilter): Observable<ILprPhone04ViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.phoneId === 'undefined')) {
                    if ( Array.isArray(filter.phoneId )) {
                        filter.phoneId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneId ))
                } // if (!(typeof filter.phoneId === 'undefined'))
                if (!(typeof filter.lpdPhoneIdRef === 'undefined')) {
                    if ( Array.isArray(filter.lpdPhoneIdRef )) {
                        filter.lpdPhoneIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('lpdPhoneIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.lpdPhoneIdRef ))
                } // if (!(typeof filter.lpdPhoneIdRef === 'undefined'))
                if (!(typeof filter.employeeIdRef === 'undefined')) {
                    if ( Array.isArray(filter.employeeIdRef )) {
                        filter.employeeIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('employeeIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.employeeIdRef ))
                } // if (!(typeof filter.employeeIdRef === 'undefined'))
                if (!(typeof filter.phoneTypeIdRef === 'undefined')) {
                    if ( Array.isArray(filter.phoneTypeIdRef )) {
                        filter.phoneTypeIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneTypeIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneTypeIdRef ))
                } // if (!(typeof filter.phoneTypeIdRef === 'undefined'))


                if (!(typeof  filter.phoneIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneIdOprtr )) {
                        filter.phoneIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneIdOprtr))
                } // if (!(typeof  filter.phoneIdOprtr === 'undefined'))
                if (!(typeof  filter.lpdPhoneIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.lpdPhoneIdRefOprtr )) {
                        filter.lpdPhoneIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('lpdPhoneIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('lpdPhoneIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.lpdPhoneIdRefOprtr))
                } // if (!(typeof  filter.lpdPhoneIdRefOprtr === 'undefined'))
                if (!(typeof  filter.employeeIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.employeeIdRefOprtr )) {
                        filter.employeeIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('employeeIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('employeeIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.employeeIdRefOprtr))
                } // if (!(typeof  filter.employeeIdRefOprtr === 'undefined'))
                if (!(typeof  filter.phoneTypeIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneTypeIdRefOprtr )) {
                        filter.phoneTypeIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneTypeIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneTypeIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneTypeIdRefOprtr))
                } // if (!(typeof  filter.phoneTypeIdRefOprtr === 'undefined'))

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
        return this.http.get<ILprPhone04ViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILprPhone04View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  employeeIdRef: number|any 
                , phoneTypeIdRef: number|any 
                , lpdPhoneIdRef: number|any 
                , phoneId: number|any 
        ): Observable<ILprPhone04View> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phoneId === 'undefined')) {
            if (!(phoneId === null)) {
                params = params.append('phoneId', phoneId.toString());
                hasFilter = true;
            }
        }
        if (!(typeof lpdPhoneIdRef === 'undefined')) {
            if (!(lpdPhoneIdRef === null)) {
                params = params.append('lpdPhoneIdRef', lpdPhoneIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof employeeIdRef === 'undefined')) {
            if (!(employeeIdRef === null)) {
                params = params.append('employeeIdRef', employeeIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof phoneTypeIdRef === 'undefined')) {
            if (!(phoneTypeIdRef === null)) {
                params = params.append('phoneTypeIdRef', phoneTypeIdRef.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILprPhone04View>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILprPhone04ViewFilter): Observable<ILprPhone04ViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.employeeIdRef === 'undefined')) {
                    if ( Array.isArray(filter.employeeIdRef )) {
                        filter.employeeIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('employeeIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.employeeIdRef ))
                } // if (!(typeof filter.employeeIdRef === 'undefined'))
                if (!(typeof filter.phoneTypeIdRef === 'undefined')) {
                    if ( Array.isArray(filter.phoneTypeIdRef )) {
                        filter.phoneTypeIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneTypeIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneTypeIdRef ))
                } // if (!(typeof filter.phoneTypeIdRef === 'undefined'))
                if (!(typeof filter.lpdPhoneIdRef === 'undefined')) {
                    if ( Array.isArray(filter.lpdPhoneIdRef )) {
                        filter.lpdPhoneIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('lpdPhoneIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.lpdPhoneIdRef ))
                } // if (!(typeof filter.lpdPhoneIdRef === 'undefined'))
                if (!(typeof filter.phoneId === 'undefined')) {
                    if ( Array.isArray(filter.phoneId )) {
                        filter.phoneId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneId ))
                } // if (!(typeof filter.phoneId === 'undefined'))
                if (!(typeof  filter.employeeIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.employeeIdRefOprtr )) {
                        filter.employeeIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('employeeIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('employeeIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.employeeIdRefOprtr))
                } // if (!(typeof  filter.employeeIdRefOprtr === 'undefined'))
                if (!(typeof  filter.phoneTypeIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneTypeIdRefOprtr )) {
                        filter.phoneTypeIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneTypeIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneTypeIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneTypeIdRefOprtr))
                } // if (!(typeof  filter.phoneTypeIdRefOprtr === 'undefined'))
                if (!(typeof  filter.lpdPhoneIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.lpdPhoneIdRefOprtr )) {
                        filter.lpdPhoneIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('lpdPhoneIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('lpdPhoneIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.lpdPhoneIdRefOprtr))
                } // if (!(typeof  filter.lpdPhoneIdRefOprtr === 'undefined'))
                if (!(typeof  filter.phoneIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneIdOprtr )) {
                        filter.phoneIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneIdOprtr))
                } // if (!(typeof  filter.phoneIdOprtr === 'undefined'))

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
        return this.http.get<ILprPhone04ViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type ILprPhone04View 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILprPhone04View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILprPhone04View): Observable<ILprPhone04View> {

        return this.http.put<ILprPhone04View>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILprPhone04View 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILprPhone04View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILprPhone04View): Observable<ILprPhone04View> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.phoneId === 'undefined') {
                    item['phoneId'] = 0;
                }
                if(item.phoneId === null) {
                    item['phoneId'] = 0;
                }
            }
        }
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.lpdPhoneIdRef === 'undefined') {
                    item['lpdPhoneIdRef'] = 0;
                }
                if(item.lpdPhoneIdRef === null) {
                    item['lpdPhoneIdRef'] = 0;
                }
            }
        }
        return this.http.post<ILprPhone04View>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILprPhone04View 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILprPhone04View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(employeeIdRef: number|any , phoneTypeIdRef: number|any , lpdPhoneIdRef: number|any , phoneId: number|any ): Observable<ILprPhone04View> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phoneId === 'undefined')) {
            if (!(phoneId === null)) {
                params = params.append('phoneId', phoneId.toString());
                hasFilter = true;
            }
        }
        if (!(typeof lpdPhoneIdRef === 'undefined')) {
            if (!(lpdPhoneIdRef === null)) {
                params = params.append('lpdPhoneIdRef', lpdPhoneIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof employeeIdRef === 'undefined')) {
            if (!(employeeIdRef === null)) {
                params = params.append('employeeIdRef', employeeIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof phoneTypeIdRef === 'undefined')) {
            if (!(phoneTypeIdRef === null)) {
                params = params.append('phoneTypeIdRef', phoneTypeIdRef.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILprPhone04View>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILprPhone04View, dest: ILprPhone04View) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.phoneId === 'undefined') {
            dest['phoneId'] = null;
        } else {
            dest['phoneId'] = src.phoneId;
        }
        if(typeof src.lpdPhoneIdRef === 'undefined') {
            dest['lpdPhoneIdRef'] = null;
        } else {
            dest['lpdPhoneIdRef'] = src.lpdPhoneIdRef;
        }
        if(typeof src.employeeIdRef === 'undefined') {
            dest['employeeIdRef'] = null;
        } else {
            dest['employeeIdRef'] = src.employeeIdRef;
        }
        if(typeof src.phoneTypeIdRef === 'undefined') {
            dest['phoneTypeIdRef'] = null;
        } else {
            dest['phoneTypeIdRef'] = src.phoneTypeIdRef;
        }
        
    }

    row2FilterRslt(r: ILprPhone04View| any): Array<IWebServiceFilterRslt> {
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

