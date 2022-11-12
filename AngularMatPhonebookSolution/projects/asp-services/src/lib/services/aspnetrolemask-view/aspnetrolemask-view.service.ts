
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { IaspnetrolemaskView } from 'asp-interfaces';
import { IaspnetrolemaskViewPage } from 'asp-interfaces';
import { IaspnetrolemaskViewFilter } from 'asp-interfaces';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';


@Injectable({
  providedIn: 'root'
})
export class AspnetrolemaskViewService {
    serviceUrl: string;  
    constructor(private http: HttpClient, protected appGlblSettings: AppGlblSettingsService) {
       this.serviceUrl = this.appGlblSettings.getWebApiPrefix('aspnetrolemaskView') + 'aspnetrolemaskviewwebapi';  
    }
    protected _Values: {[key: string]: {org: string, fk: string, fkchain: string, isinprimkey: boolean, isinunqkey: boolean, required: boolean, dbgenerated: boolean, dttp: string}} = {
      'roleDescription': {org: 'RoleDescription', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: false, dbgenerated: false, dttp: 'string'},  // string | null, System.String
      'mask1': {org: 'Mask1', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask2': {org: 'Mask2', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask3': {org: 'Mask3', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask4': {org: 'Mask4', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'mask5': {org: 'Mask5', fk: '', fkchain: '', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'boolean'},  // boolean, System.Boolean
      'modelPkRef': {org: 'ModelPkRef', fk: '', fkchain: '', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'int32'},  // number, System.Int32
      'mModelName': {org: 'ModelName', fk: 'AspNetModel', fkchain: 'AspNetModel', isinprimkey: false, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
      'rName': {org: 'Name', fk: 'AspNetRole', fkchain: 'AspNetRole', isinprimkey: true, isinunqkey: false, required: true, dbgenerated: false, dttp: 'string'},  // string, System.String
    };
    // master name, navigation name, master filed, master filed value
    public getHiddenFilterByRow(rw: IaspnetrolemaskView|any, nvNm: string|any): {[key: string]: {[key: string]: {[key: string]: any}}} {
        let rslt: {[key: string]: {[key: string]: {[key: string]: any}}} = {}
        if((typeof rw === 'undefined') || (typeof nvNm === 'undefined')) return rslt;
        if((rw === null) || (nvNm === null)) return rslt;
        for(let i in this._Values) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                if(typeof rslt['aspnetrolemaskView'] === 'undefined') rslt['aspnetrolemaskView'] = {};
                if(typeof rslt['aspnetrolemaskView'][nvNm] === 'undefined') rslt['aspnetrolemaskView'][nvNm] = {};
                rslt['aspnetrolemaskView'][nvNm][i] = rw[i];
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
                'aspnetmodelView' : {
                    'AspNetModel' : {
                        'modelPk' : {isMstrReq: true, propNm:'modelPkRef'},
                    },
                },
                'aspnetroleView' : {
                    'AspNetRole' : {
                        'name' : {isMstrReq: true, propNm:'rName'},
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
                'aspnetmodelView' : {
                    'AspNetModel' : {
                        'modelName' : 'mModelName',
                    },
                },
                'aspnetroleView' : {
                    'AspNetRole' : {
                        'name' : 'rName',
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
    //    // handling value of type IaspnetrolemaskView[] 
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getall(): Observable<IaspnetrolemaskView[]> {

        return this.http.get<IaspnetrolemaskView[]>(this.serviceUrl+'/getall');
        //    .pipe(
        //        catchError(this.handleError('getall', []))
        //    );
    }



    // 
    // HowTo: flt is of type IaspnetrolemaskViewFilter 
    //
    // this.serviceRefInYourCode.getwithfilter(flt).subscibe(value =>{
    //    // handling value of type IaspnetrolemaskViewPage
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getwithfilter(filter: IaspnetrolemaskViewFilter): Observable<IaspnetrolemaskViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {
                if (!(typeof filter.modelPkRef === 'undefined')) {
                    if ( Array.isArray(filter.modelPkRef )) {
                        filter.modelPkRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('modelPkRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.modelPkRef ))
                } // if (!(typeof filter.modelPkRef === 'undefined'))
                if (!(typeof filter.mModelName === 'undefined')) {
                    if ( Array.isArray(filter.mModelName )) {
                        filter.mModelName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('mModelName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.mModelName ))
                } // if (!(typeof filter.mModelName === 'undefined'))
                if (!(typeof filter.rName === 'undefined')) {
                    if ( Array.isArray(filter.rName )) {
                        filter.rName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('rName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.rName ))
                } // if (!(typeof filter.rName === 'undefined'))


                if (!(typeof  filter.modelPkRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.modelPkRefOprtr )) {
                        filter.modelPkRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('modelPkRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('modelPkRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.modelPkRefOprtr))
                } // if (!(typeof  filter.modelPkRefOprtr === 'undefined'))
                if (!(typeof  filter.mModelNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.mModelNameOprtr )) {
                        filter.mModelNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('mModelNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('mModelNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.mModelNameOprtr))
                } // if (!(typeof  filter.mModelNameOprtr === 'undefined'))
                if (!(typeof  filter.rNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.rNameOprtr )) {
                        filter.rNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('rNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('rNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.rNameOprtr))
                } // if (!(typeof  filter.rNameOprtr === 'undefined'))

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
        return this.http.get<IaspnetrolemaskViewPage>(this.serviceUrl+'/getwithfilter', options);
          //    .pipe(
          //        catchError(this.handleError('getwithfilter', []))
          //    );
    }


    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type IaspnetrolemaskView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    getone(
                  rName: string|any 
                , modelPkRef: number|any 
        ): Observable<IaspnetrolemaskView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof modelPkRef === 'undefined')) {
            if (!(modelPkRef === null)) {
                params = params.append('modelPkRef', modelPkRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof rName === 'undefined')) {
            if (!(rName === null)) {
                params = params.append('rName', rName);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.get<IaspnetrolemaskView>(this.serviceUrl+'/getone', options);
          // .pipe(
          //   catchError(this.handleError('getone', []))
          // );
    }

    getmanybyrepprim(filter: IaspnetrolemaskViewFilter): Observable<IaspnetrolemaskViewPage> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof filter === 'undefined')) {
            if (!(filter === null )) {

                if (!(typeof filter.rName === 'undefined')) {
                    if ( Array.isArray(filter.rName )) {
                        filter.rName.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('rName', value);
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.rName ))
                } // if (!(typeof filter.rName === 'undefined'))
                if (!(typeof filter.modelPkRef === 'undefined')) {
                    if ( Array.isArray(filter.modelPkRef )) {
                        filter.modelPkRef.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(!(value === null)) {
                                    params = params.append('modelPkRef', value.toString());
                                    hasFilter = true;
                                } 
                            }
                        });
                    } // if ( Array.isArray(filter.modelPkRef ))
                } // if (!(typeof filter.modelPkRef === 'undefined'))
                if (!(typeof  filter.rNameOprtr === 'undefined')) {
                    if (Array.isArray(filter.rNameOprtr )) {
                        filter.rNameOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('rNameOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('rNameOprtr', value);
                                }
                            }
                        });
                    } // if (Array.isArray(filter.rNameOprtr))
                } // if (!(typeof  filter.rNameOprtr === 'undefined'))
                if (!(typeof  filter.modelPkRefOprtr === 'undefined')) {
                    if (Array.isArray(filter.modelPkRefOprtr )) {
                        filter.modelPkRefOprtr.forEach(function (value) {
                            if(!(typeof value === 'undefined')) {
                                if(value === null) {
                                    params = params.append('modelPkRefOprtr', 'eq');
                                } 
                                else {
                                    params = params.append('modelPkRefOprtr', value.toString());
                                }
                            }
                        });
                    } // if (Array.isArray(filter.modelPkRefOprtr))
                } // if (!(typeof  filter.modelPkRefOprtr === 'undefined'))

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
        return this.http.get<IaspnetrolemaskViewPage>(this.serviceUrl+'/getmanybyrepprim', options);
    }


    // 
    // HowTo: item is of type IaspnetrolemaskView 
    //
    // this.serviceRefInYourCode.updateone(item).subscibe(value =>{
    //    // handling value of type IaspnetrolemaskView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    updateone(item: IaspnetrolemaskView): Observable<IaspnetrolemaskView> {

        return this.http.put<IaspnetrolemaskView>(this.serviceUrl+'/updateone', item); //, httpOptions);
        //  .pipe(
        //    catchError(this.handleError('updateone', item))
        //  );
    }

    // 
    // HowTo: item is of type IaspnetrolemaskView 
    //
    // this.serviceRefInYourCode.addone(item).subscibe(value =>{
    //    // handling value of type IaspnetrolemaskView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    addone(item: IaspnetrolemaskView): Observable<IaspnetrolemaskView> {
        return this.http.post<IaspnetrolemaskView>(this.serviceUrl+'/addone', item); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('addone', item))
        // );   
    }

    // 
    // HowTo: item is of type IaspnetrolemaskView 
    //
    // this.serviceRefInYourCode.deleteone(item).subscibe(value =>{
    //    // handling value of type IaspnetrolemaskView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    deleteone(rName: string|any , modelPkRef: number|any ): Observable<IaspnetrolemaskView> {
        let params: HttpParams  = new HttpParams({encoder: this.appGlblSettings});
        let hasFilter: boolean = false;
        if (!(typeof modelPkRef === 'undefined')) {
            if (!(modelPkRef === null)) {
                params = params.append('modelPkRef', modelPkRef.toString());
                hasFilter = true;
            }
        }
        if (!(typeof rName === 'undefined')) {
            if (!(rName === null)) {
                params = params.append('rName', rName);
                hasFilter = true;
            }
        }
        const options = hasFilter ? { params } : {};
        return this.http.delete<IaspnetrolemaskView>(this.serviceUrl+'/deleteone', options); //, httpOptions);
        // .pipe(
        //      catchError(this.handleError('deleteone', item))
        // );   
    }

    src2dest(src: IaspnetrolemaskView, dest: IaspnetrolemaskView) {
        if ((typeof src === 'undefined') || (typeof dest === 'undefined')) return;
        if ((src === null) || (dest === null)) return;
        if(typeof src.roleDescription === 'undefined') {
            dest['roleDescription'] = null;
        } else {
            dest['roleDescription'] = src.roleDescription;
        }
        if(typeof src.mask1 === 'undefined') {
            dest['mask1'] = null;
        } else {
            dest['mask1'] = src.mask1;
        }
        if(typeof src.mask2 === 'undefined') {
            dest['mask2'] = null;
        } else {
            dest['mask2'] = src.mask2;
        }
        if(typeof src.mask3 === 'undefined') {
            dest['mask3'] = null;
        } else {
            dest['mask3'] = src.mask3;
        }
        if(typeof src.mask4 === 'undefined') {
            dest['mask4'] = null;
        } else {
            dest['mask4'] = src.mask4;
        }
        if(typeof src.mask5 === 'undefined') {
            dest['mask5'] = null;
        } else {
            dest['mask5'] = src.mask5;
        }
        if(typeof src.modelPkRef === 'undefined') {
            dest['modelPkRef'] = null;
        } else {
            dest['modelPkRef'] = src.modelPkRef;
        }
        if(typeof src.mModelName === 'undefined') {
            dest['mModelName'] = null;
        } else {
            dest['mModelName'] = src.mModelName;
        }
        if(typeof src.rName === 'undefined') {
            dest['rName'] = null;
        } else {
            dest['rName'] = src.rName;
        }
        
    }

    row2FilterRslt(r: IaspnetrolemaskView| any): Array<IWebServiceFilterRslt> {
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

