
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ILprEmployee02View } from 'phonebook-interfaces';
import { ILprEmployee02ViewPage } from 'phonebook-interfaces';
import { ILprEmployee02ViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class LprEmployee02ViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('LprEmployee02View') + 'lpremployee02viewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'employeeId': {org: 'EmployeeId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'empLastNameIdRef': {org: 'EmpLastNameIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'empFirstNameIdRef': {org: 'EmpFirstNameIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'empSecondNameIdRef': {org: 'EmpSecondNameIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'divisionIdRef': {org: 'DivisionIdRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: ILprEmployee02View|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['LprEmployee02View'] === 'undefined') rslt['LprEmployee02View'] = {};
                if(typeof rslt['LprEmployee02View'][nvNm] === 'undefined') rslt['LprEmployee02View'][nvNm] = {};
                rslt['LprEmployee02View'][nvNm][i] = rw[i];
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
                'PhbkEmployeeView' : {
                    'Employee' : {
                        'employeeId' : {isMstrReq: true, propNm:'employeeId'},
                    },
                },
                'LpdEmpLastNameView' : {
                    'EmpLastNameDict' : {
                        'empLastNameId' : {isMstrReq: true, propNm:'empLastNameIdRef'},
                    },
                },
                'LpdEmpFirstNameView' : {
                    'EmpFirstNameDict' : {
                        'empFirstNameId' : {isMstrReq: true, propNm:'empFirstNameIdRef'},
                    },
                },
                'LpdEmpSecondNameView' : {
                    'EmpSecondNameDict' : {
                        'empSecondNameId' : {isMstrReq: true, propNm:'empSecondNameIdRef'},
                    },
                },
                'PhbkDivisionView' : {
                    'Division' : {
                        'divisionId' : {isMstrReq: true, propNm:'divisionIdRef'},
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
                'PhbkEmployeeView' : {
                    'Employee' : {
                    },
                },
                'LpdEmpLastNameView' : {
                    'EmpLastNameDict' : {
                    },
                },
                'LpdEmpFirstNameView' : {
                    'EmpFirstNameDict' : {
                    },
                },
                'LpdEmpSecondNameView' : {
                    'EmpSecondNameDict' : {
                    },
                },
                'PhbkDivisionView' : {
                    'Division' : {
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
    //    // handling value of type ILprEmployee02View[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<ILprEmployee02View[]> {

        return this.http.get<ILprEmployee02View[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type ILprEmployee02ViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type ILprEmployee02ViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: ILprEmployee02ViewFilter): Observable<ILprEmployee02ViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.employeeId === 'undefined')) {
                    if ( Array.isArray(filter.employeeId )) {
                        filter.employeeId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('employeeId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.employeeId ))
                } // if (!(typeof filter.employeeId === 'undefined'))
                if (!(typeof filter.empLastNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.empLastNameIdRef )) {
                        filter.empLastNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empLastNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empLastNameIdRef ))
                } // if (!(typeof filter.empLastNameIdRef === 'undefined'))
                if (!(typeof filter.empFirstNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.empFirstNameIdRef )) {
                        filter.empFirstNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empFirstNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empFirstNameIdRef ))
                } // if (!(typeof filter.empFirstNameIdRef === 'undefined'))
                if (!(typeof filter.empSecondNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.empSecondNameIdRef )) {
                        filter.empSecondNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empSecondNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empSecondNameIdRef ))
                } // if (!(typeof filter.empSecondNameIdRef === 'undefined'))
                if (!(typeof filter.divisionIdRef === 'undefined')) {
                    if ( Array.isArray(filter.divisionIdRef )) {
                        filter.divisionIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionIdRef ))
                } // if (!(typeof filter.divisionIdRef === 'undefined'))


                if (!(typeof  filter.employeeIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.employeeIdOprtr )) {
                        filter.employeeIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('employeeIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('employeeIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.employeeIdOprtr))
                } // if (!(typeof  filter.employeeIdOprtr === 'undefined'))
                if (!(typeof  filter.empLastNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.empLastNameIdRefOprtr )) {
                        filter.empLastNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empLastNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empLastNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empLastNameIdRefOprtr))
                } // if (!(typeof  filter.empLastNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.empFirstNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.empFirstNameIdRefOprtr )) {
                        filter.empFirstNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empFirstNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empFirstNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empFirstNameIdRefOprtr))
                } // if (!(typeof  filter.empFirstNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.empSecondNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.empSecondNameIdRefOprtr )) {
                        filter.empSecondNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empSecondNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empSecondNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empSecondNameIdRefOprtr))
                } // if (!(typeof  filter.empSecondNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.divisionIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionIdRefOprtr )) {
                        filter.divisionIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionIdRefOprtr))
                } // if (!(typeof  filter.divisionIdRefOprtr === 'undefined'))

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
        return this.http.get<ILprEmployee02ViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILprEmployee02View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  divisionIdRef: number|any 
                , empLastNameIdRef: number|any 
                , empFirstNameIdRef: number|any 
                , empSecondNameIdRef: number|any 
                , employeeId: number|any 
        ): Observable<ILprEmployee02View> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof employeeId === 'undefined')) {
            if (!(employeeId === null)) {
                params = params.append('employeeId', employeeId.toString());
                hasFilter = true;
            }
        }
        if (!(typeof empLastNameIdRef === 'undefined')) {
            if (!(empLastNameIdRef === null)) {
                params = params.append('empLastNameIdRef', empLastNameIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof empFirstNameIdRef === 'undefined')) {
            if (!(empFirstNameIdRef === null)) {
                params = params.append('empFirstNameIdRef', empFirstNameIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof empSecondNameIdRef === 'undefined')) {
            if (!(empSecondNameIdRef === null)) {
                params = params.append('empSecondNameIdRef', empSecondNameIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof divisionIdRef === 'undefined')) {
            if (!(divisionIdRef === null)) {
                params = params.append('divisionIdRef', divisionIdRef.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<ILprEmployee02View>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: ILprEmployee02ViewFilter): Observable<ILprEmployee02ViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.divisionIdRef === 'undefined')) {
                    if ( Array.isArray(filter.divisionIdRef )) {
                        filter.divisionIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('divisionIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.divisionIdRef ))
                } // if (!(typeof filter.divisionIdRef === 'undefined'))
                if (!(typeof filter.empLastNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.empLastNameIdRef )) {
                        filter.empLastNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empLastNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empLastNameIdRef ))
                } // if (!(typeof filter.empLastNameIdRef === 'undefined'))
                if (!(typeof filter.empFirstNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.empFirstNameIdRef )) {
                        filter.empFirstNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empFirstNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empFirstNameIdRef ))
                } // if (!(typeof filter.empFirstNameIdRef === 'undefined'))
                if (!(typeof filter.empSecondNameIdRef === 'undefined')) {
                    if ( Array.isArray(filter.empSecondNameIdRef )) {
                        filter.empSecondNameIdRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empSecondNameIdRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empSecondNameIdRef ))
                } // if (!(typeof filter.empSecondNameIdRef === 'undefined'))
                if (!(typeof filter.employeeId === 'undefined')) {
                    if ( Array.isArray(filter.employeeId )) {
                        filter.employeeId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('employeeId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.employeeId ))
                } // if (!(typeof filter.employeeId === 'undefined'))
                if (!(typeof  filter.divisionIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.divisionIdRefOprtr )) {
                        filter.divisionIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('divisionIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('divisionIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.divisionIdRefOprtr))
                } // if (!(typeof  filter.divisionIdRefOprtr === 'undefined'))
                if (!(typeof  filter.empLastNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.empLastNameIdRefOprtr )) {
                        filter.empLastNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empLastNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empLastNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empLastNameIdRefOprtr))
                } // if (!(typeof  filter.empLastNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.empFirstNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.empFirstNameIdRefOprtr )) {
                        filter.empFirstNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empFirstNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empFirstNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empFirstNameIdRefOprtr))
                } // if (!(typeof  filter.empFirstNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.empSecondNameIdRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.empSecondNameIdRefOprtr )) {
                        filter.empSecondNameIdRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empSecondNameIdRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empSecondNameIdRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empSecondNameIdRefOprtr))
                } // if (!(typeof  filter.empSecondNameIdRefOprtr === 'undefined'))
                if (!(typeof  filter.employeeIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.employeeIdOprtr )) {
                        filter.employeeIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('employeeIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('employeeIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.employeeIdOprtr))
                } // if (!(typeof  filter.employeeIdOprtr === 'undefined'))

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
        return this.http.get<ILprEmployee02ViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type ILprEmployee02View 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type ILprEmployee02View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: ILprEmployee02View): Observable<ILprEmployee02View> {

        return this.http.put<ILprEmployee02View>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type ILprEmployee02View 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type ILprEmployee02View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: ILprEmployee02View): Observable<ILprEmployee02View> {
        return this.http.post<ILprEmployee02View>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type ILprEmployee02View 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type ILprEmployee02View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(divisionIdRef: number|any , empLastNameIdRef: number|any , empFirstNameIdRef: number|any , empSecondNameIdRef: number|any , employeeId: number|any ): Observable<ILprEmployee02View> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof employeeId === 'undefined')) {
            if (!(employeeId === null)) {
                params = params.append('employeeId', employeeId.toString());
                hasFilter = true;
            }
        }
        if (!(typeof empLastNameIdRef === 'undefined')) {
            if (!(empLastNameIdRef === null)) {
                params = params.append('empLastNameIdRef', empLastNameIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof empFirstNameIdRef === 'undefined')) {
            if (!(empFirstNameIdRef === null)) {
                params = params.append('empFirstNameIdRef', empFirstNameIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof empSecondNameIdRef === 'undefined')) {
            if (!(empSecondNameIdRef === null)) {
                params = params.append('empSecondNameIdRef', empSecondNameIdRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof divisionIdRef === 'undefined')) {
            if (!(divisionIdRef === null)) {
                params = params.append('divisionIdRef', divisionIdRef.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<ILprEmployee02View>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: ILprEmployee02View, dest: ILprEmployee02View) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.employeeId === 'undefined') {
            dest['employeeId'] = null;
        } else {
            dest['employeeId'] = src.employeeId;
        }
        if(typeof src.empLastNameIdRef === 'undefined') {
            dest['empLastNameIdRef'] = null;
        } else {
            dest['empLastNameIdRef'] = src.empLastNameIdRef;
        }
        if(typeof src.empFirstNameIdRef === 'undefined') {
            dest['empFirstNameIdRef'] = null;
        } else {
            dest['empFirstNameIdRef'] = src.empFirstNameIdRef;
        }
        if(typeof src.empSecondNameIdRef === 'undefined') {
            dest['empSecondNameIdRef'] = null;
        } else {
            dest['empSecondNameIdRef'] = src.empSecondNameIdRef;
        }
        if(typeof src.divisionIdRef === 'undefined') {
            dest['divisionIdRef'] = null;
        } else {
            dest['divisionIdRef'] = src.divisionIdRef;
        }
        
    }

    row2FilterRslt(r: ILprEmployee02View| any): Array<IWebServiceFilterRslt> {
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

