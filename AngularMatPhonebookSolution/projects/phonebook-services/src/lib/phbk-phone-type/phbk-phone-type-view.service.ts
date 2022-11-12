
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';
import { IPhbkPhoneTypeViewPage } from 'phonebook-interfaces';
import { IPhbkPhoneTypeViewFilter } from 'phonebook-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class PhbkPhoneTypeViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('PhbkPhoneTypeView') + 'phbkphonetypeviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'phoneTypeId': {org: 'PhoneTypeId', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'phoneTypeName': {org: 'PhoneTypeName', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'phoneTypeDesc': {org: 'PhoneTypeDesc', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IPhbkPhoneTypeView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['PhbkPhoneTypeView'] === 'undefined') rslt['PhbkPhoneTypeView'] = {};
                if(typeof rslt['PhbkPhoneTypeView'][nvNm] === 'undefined') rslt['PhbkPhoneTypeView'][nvNm] = {};
                rslt['PhbkPhoneTypeView'][nvNm][i] = rw[i];
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
                'PhbkPhoneView' : {
                    'PhoneType' : {
                        'phoneTypeIdRef' : 'phoneTypeId',
                    },
                },
                'LprPhone03View' : {
                    'PhoneType' : {
                        'phoneTypeIdRef' : 'phoneTypeId',
                    },
                },
                'LprPhone04View' : {
                    'PhoneType' : {
                        'phoneTypeIdRef' : 'phoneTypeId',
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
    //    // handling value of type IPhbkPhoneTypeView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<IPhbkPhoneTypeView[]> {

        return this.http.get<IPhbkPhoneTypeView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type IPhbkPhoneTypeViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IPhbkPhoneTypeViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IPhbkPhoneTypeViewFilter): Observable<IPhbkPhoneTypeViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.phoneTypeId === 'undefined')) {
                    if ( Array.isArray(filter.phoneTypeId )) {
                        filter.phoneTypeId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneTypeId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneTypeId ))
                } // if (!(typeof filter.phoneTypeId === 'undefined'))
                if (!(typeof filter.phoneTypeName === 'undefined')) {
                    if ( Array.isArray(filter.phoneTypeName )) {
                        filter.phoneTypeName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneTypeName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneTypeName ))
                } // if (!(typeof filter.phoneTypeName === 'undefined'))


                if (!(typeof  filter.phoneTypeIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneTypeIdOprtr )) {
                        filter.phoneTypeIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneTypeIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneTypeIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneTypeIdOprtr))
                } // if (!(typeof  filter.phoneTypeIdOprtr === 'undefined'))
                if (!(typeof  filter.phoneTypeNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneTypeNameOprtr )) {
                        filter.phoneTypeNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneTypeNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneTypeNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneTypeNameOprtr))
                } // if (!(typeof  filter.phoneTypeNameOprtr === 'undefined'))

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
        return this.http.get<IPhbkPhoneTypeViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type IPhbkPhoneTypeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  phoneTypeId: number|any 
        ): Observable<IPhbkPhoneTypeView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phoneTypeId === 'undefined')) {
            if (!(phoneTypeId === null)) {
                params = params.append('phoneTypeId', phoneTypeId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<IPhbkPhoneTypeView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: IPhbkPhoneTypeViewFilter): Observable<IPhbkPhoneTypeViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.phoneTypeId === 'undefined')) {
                    if ( Array.isArray(filter.phoneTypeId )) {
                        filter.phoneTypeId.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('phoneTypeId', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.phoneTypeId ))
                } // if (!(typeof filter.phoneTypeId === 'undefined'))
                if (!(typeof  filter.phoneTypeIdOprtr === 'undefined')) {
                    if (Array.isArray(filter.phoneTypeIdOprtr )) {
                        filter.phoneTypeIdOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('phoneTypeIdOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('phoneTypeIdOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.phoneTypeIdOprtr))
                } // if (!(typeof  filter.phoneTypeIdOprtr === 'undefined'))

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
        return this.http.get<IPhbkPhoneTypeViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type IPhbkPhoneTypeView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type IPhbkPhoneTypeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: IPhbkPhoneTypeView): Observable<IPhbkPhoneTypeView> {

        return this.http.put<IPhbkPhoneTypeView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type IPhbkPhoneTypeView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type IPhbkPhoneTypeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: IPhbkPhoneTypeView): Observable<IPhbkPhoneTypeView> {
        return this.http.post<IPhbkPhoneTypeView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type IPhbkPhoneTypeView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type IPhbkPhoneTypeView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(phoneTypeId: number|any ): Observable<IPhbkPhoneTypeView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof phoneTypeId === 'undefined')) {
            if (!(phoneTypeId === null)) {
                params = params.append('phoneTypeId', phoneTypeId.toString());
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<IPhbkPhoneTypeView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: IPhbkPhoneTypeView, dest: IPhbkPhoneTypeView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.phoneTypeId === 'undefined') {
            dest['phoneTypeId'] = null;
        } else {
            dest['phoneTypeId'] = src.phoneTypeId;
        }
        if(typeof src.phoneTypeName === 'undefined') {
            dest['phoneTypeName'] = null;
        } else {
            dest['phoneTypeName'] = src.phoneTypeName;
        }
        if(typeof src.phoneTypeDesc === 'undefined') {
            dest['phoneTypeDesc'] = null;
        } else {
            dest['phoneTypeDesc'] = src.phoneTypeDesc;
        }
        
    }

    row2FilterRslt(r: IPhbkPhoneTypeView| any): Array<IWebServiceFilterRslt> {
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

