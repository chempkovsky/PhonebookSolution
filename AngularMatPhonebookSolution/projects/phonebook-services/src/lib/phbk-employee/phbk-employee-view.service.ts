
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IPhbkEmployeeView } from 'phonebook-interfaces';
import { IPhbkEmployeeViewPage } from 'phonebook-interfaces';
import { IPhbkEmployeeViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class PhbkEmployeeViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('PhbkEmployeeView') + 'phbkemployeeviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'employeeId': {org: 'EmployeeId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'empFirstName': {org: 'EmpFirstName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'empLastName': {org: 'EmpLastName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'empSecondName': {org: 'EmpSecondName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'divisionIdRef': {org: 'DivisionIdRef', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'dDivisionName': {org: 'DivisionName', fk: 'Division', fkchain: 'Division', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'dEEntrprsName': {org: 'EntrprsName', fk: 'Division', fkchain: 'Division.Enterprise', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IPhbkEmployeeView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['PhbkEmployeeView'] === 'undefined') rslt['PhbkEmployeeView'] = {};
                if(typeof rslt['PhbkEmployeeView'][nvNm] === 'undefined') rslt['PhbkEmployeeView'][nvNm] = {};
                rslt['PhbkEmployeeView'][nvNm][i] = rw[i];
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
                'PhbkDivisionView' : {
                    'Division' : {
                        'divisionName' : 'dDivisionName',
                        'eEntrprsName' : 'dEEntrprsName',
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
                'LprEmployee01View' : {
                    'Employee' : {
                        'employeeId' : 'employeeId',
                    },
                },
                'LprEmployee02View' : {
                    'Employee' : {
                        'employeeId' : 'employeeId',
                    },
                },
                'PhbkPhoneView' : {
                    'Employee' : {
                        'employeeIdRef' : 'employeeId',
                    },
                },
                'LprPhone02View' : {
                    'Employee' : {
                        'employeeIdRef' : 'employeeId',
                    },
                },
                'LprPhone04View' : {
                    'Employee' : {
                        'employeeIdRef' : 'employeeId',
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
    //    // handling value of type IPhbkEmployeeView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<IPhbkEmployeeView[]> {

        return this.http.get<IPhbkEmployeeView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type IPhbkEmployeeViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IPhbkEmployeeViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IPhbkEmployeeViewFilter): Observable<IPhbkEmployeeViewPage> {
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
                if (!(typeof filter.empFirstName === 'undefined')) {
                    if ( Array.isArray(filter.empFirstName )) {
                        filter.empFirstName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('empFirstName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.empFirstName ))
                } // if (!(typeof filter.empFirstName === 'undefined'))
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
                if (!(typeof  filter.empFirstNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.empFirstNameOprtr )) {
                        filter.empFirstNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('empFirstNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('empFirstNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.empFirstNameOprtr))
                } // if (!(typeof  filter.empFirstNameOprtr === 'undefined'))
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
        return this.http.get<IPhbkEmployeeViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type IPhbkEmployeeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  employeeId: number|any 
        ): Observable<IPhbkEmployeeView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof employeeId === 'undefined')) {
            if (!(employeeId === null)) {
                params = params.append('employeeId', employeeId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<IPhbkEmployeeView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: IPhbkEmployeeViewFilter): Observable<IPhbkEmployeeViewPage> {
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
        return this.http.get<IPhbkEmployeeViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type IPhbkEmployeeView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type IPhbkEmployeeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: IPhbkEmployeeView): Observable<IPhbkEmployeeView> {

        return this.http.put<IPhbkEmployeeView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type IPhbkEmployeeView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type IPhbkEmployeeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: IPhbkEmployeeView): Observable<IPhbkEmployeeView> {
        if(!(typeof item === 'undefined')) {
            if(!(item === null)) {
                if(typeof item.employeeId === 'undefined') {
                    item['employeeId'] = 0;
                }
                if(item.employeeId === null) {
                    item['employeeId'] = 0;
                }
            }
        }
        return this.http.post<IPhbkEmployeeView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type IPhbkEmployeeView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type IPhbkEmployeeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(employeeId: number|any ): Observable<IPhbkEmployeeView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof employeeId === 'undefined')) {
            if (!(employeeId === null)) {
                params = params.append('employeeId', employeeId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<IPhbkEmployeeView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: IPhbkEmployeeView, dest: IPhbkEmployeeView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.employeeId === 'undefined') {
            dest['employeeId'] = null;
        } else {
            dest['employeeId'] = src.employeeId;
        }
        if(typeof src.empFirstName === 'undefined') {
            dest['empFirstName'] = null;
        } else {
            dest['empFirstName'] = src.empFirstName;
        }
        if(typeof src.empLastName === 'undefined') {
            dest['empLastName'] = null;
        } else {
            dest['empLastName'] = src.empLastName;
        }
        if(typeof src.empSecondName === 'undefined') {
            dest['empSecondName'] = null;
        } else {
            dest['empSecondName'] = src.empSecondName;
        }
        if(typeof src.divisionIdRef === 'undefined') {
            dest['divisionIdRef'] = null;
        } else {
            dest['divisionIdRef'] = src.divisionIdRef;
        }
        if(typeof src.dDivisionName === 'undefined') {
            dest['dDivisionName'] = null;
        } else {
            dest['dDivisionName'] = src.dDivisionName;
        }
        if(typeof src.dEEntrprsName === 'undefined') {
            dest['dEEntrprsName'] = null;
        } else {
            dest['dEEntrprsName'] = src.dEEntrprsName;
        }
        
    }

    row2FilterRslt(r: IPhbkEmployeeView| any): Array<IWebServiceFilterRslt> {
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

