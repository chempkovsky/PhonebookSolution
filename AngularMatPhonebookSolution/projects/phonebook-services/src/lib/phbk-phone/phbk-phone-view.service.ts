
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IPhbkPhoneView } from 'phonebook-interfaces';
import { IPhbkPhoneViewPage } from 'phonebook-interfaces';
import { IPhbkPhoneViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class PhbkPhoneViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('PhbkPhoneView') + 'phbkphoneviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'phoneId': {org: 'PhoneId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: true, dttp: 'int32'},  // number, System.Int32
      'phone': {org: 'Phone', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'phoneTypeIdRef': {org: 'PhoneTypeIdRef', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'employeeIdRef': {org: 'EmployeeIdRef', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'pPhoneTypeName': {org: 'PhoneTypeName', fk: 'PhoneType', fkchain: 'PhoneType', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'eEmpFirstName': {org: 'EmpFirstName', fk: 'Employee', fkchain: 'Employee', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'eEmpLastName': {org: 'EmpLastName', fk: 'Employee', fkchain: 'Employee', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'eEmpSecondName': {org: 'EmpSecondName', fk: 'Employee', fkchain: 'Employee', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'eDDivisionName': {org: 'DivisionName', fk: 'Employee', fkchain: 'Employee.Division', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'eDEEntrprsName': {org: 'EntrprsName', fk: 'Employee', fkchain: 'Employee.Division.Enterprise', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IPhbkPhoneView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['PhbkPhoneView'] === 'undefined') rslt['PhbkPhoneView'] = {};
                if(typeof rslt['PhbkPhoneView'][nvNm] === 'undefined') rslt['PhbkPhoneView'][nvNm] = {};
                rslt['PhbkPhoneView'][nvNm][i] = rw[i];
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
                'PhbkPhoneTypeView' : {
                    'PhoneType' : {
                        'phoneTypeId' : {isMstrReq: true, propNm:'phoneTypeIdRef'},
                    },
                },
                'PhbkEmployeeView' : {
                    'Employee' : {
                        'employeeId' : {isMstrReq: true, propNm:'employeeIdRef'},
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
                'PhbkPhoneTypeView' : {
                    'PhoneType' : {
                        'phoneTypeName' : 'pPhoneTypeName',
                    },
                },
                'PhbkEmployeeView' : {
                    'Employee' : {
                        'empFirstName' : 'eEmpFirstName',
                        'empLastName' : 'eEmpLastName',
                        'empSecondName' : 'eEmpSecondName',
                        'dDivisionName' : 'eDDivisionName',
                        'dEEntrprsName' : 'eDEEntrprsName',
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
                'LprPhone01View' : {
                    'Phone' : {
                        'phoneId' : 'phoneId',
                    },
                },
                'LprPhone02View' : {
                    'Phone' : {
                        'phoneId' : 'phoneId',
                    },
                },
                'LprPhone03View' : {
                    'Phone' : {
                        'phoneId' : 'phoneId',
                    },
                },
                'LprPhone04View' : {
                    'Phone' : {
                        'phoneId' : 'phoneId',
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
    //    // handling value of type IPhbkPhoneView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<IPhbkPhoneView[]> {

        return this.http.get<IPhbkPhoneView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type IPhbkPhoneViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IPhbkPhoneViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IPhbkPhoneViewFilter): Observable<IPhbkPhoneViewPage> {
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
        return this.http.get<IPhbkPhoneViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type IPhbkPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  phoneId: number|any 
        ): Observable<IPhbkPhoneView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phoneId === 'undefined')) {
            if (!(phoneId === null)) {
                params = params.append('phoneId', phoneId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<IPhbkPhoneView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: IPhbkPhoneViewFilter): Observable<IPhbkPhoneViewPage> {
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
        return this.http.get<IPhbkPhoneViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type IPhbkPhoneView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type IPhbkPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: IPhbkPhoneView): Observable<IPhbkPhoneView> {

        return this.http.put<IPhbkPhoneView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type IPhbkPhoneView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type IPhbkPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: IPhbkPhoneView): Observable<IPhbkPhoneView> {
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
        return this.http.post<IPhbkPhoneView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type IPhbkPhoneView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type IPhbkPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(phoneId: number|any ): Observable<IPhbkPhoneView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phoneId === 'undefined')) {
            if (!(phoneId === null)) {
                params = params.append('phoneId', phoneId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<IPhbkPhoneView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: IPhbkPhoneView, dest: IPhbkPhoneView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.phoneId === 'undefined') {
            dest['phoneId'] = null;
        } else {
            dest['phoneId'] = src.phoneId;
        }
        if(typeof src.phone === 'undefined') {
            dest['phone'] = null;
        } else {
            dest['phone'] = src.phone;
        }
        if(typeof src.phoneTypeIdRef === 'undefined') {
            dest['phoneTypeIdRef'] = null;
        } else {
            dest['phoneTypeIdRef'] = src.phoneTypeIdRef;
        }
        if(typeof src.employeeIdRef === 'undefined') {
            dest['employeeIdRef'] = null;
        } else {
            dest['employeeIdRef'] = src.employeeIdRef;
        }
        if(typeof src.pPhoneTypeName === 'undefined') {
            dest['pPhoneTypeName'] = null;
        } else {
            dest['pPhoneTypeName'] = src.pPhoneTypeName;
        }
        if(typeof src.eEmpFirstName === 'undefined') {
            dest['eEmpFirstName'] = null;
        } else {
            dest['eEmpFirstName'] = src.eEmpFirstName;
        }
        if(typeof src.eEmpLastName === 'undefined') {
            dest['eEmpLastName'] = null;
        } else {
            dest['eEmpLastName'] = src.eEmpLastName;
        }
        if(typeof src.eEmpSecondName === 'undefined') {
            dest['eEmpSecondName'] = null;
        } else {
            dest['eEmpSecondName'] = src.eEmpSecondName;
        }
        if(typeof src.eDDivisionName === 'undefined') {
            dest['eDDivisionName'] = null;
        } else {
            dest['eDDivisionName'] = src.eDDivisionName;
        }
        if(typeof src.eDEEntrprsName === 'undefined') {
            dest['eDEEntrprsName'] = null;
        } else {
            dest['eDEEntrprsName'] = src.eDEEntrprsName;
        }
        
    }

    row2FilterRslt(r: IPhbkPhoneView| any): Array<IWebServiceFilterRslt> {
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

