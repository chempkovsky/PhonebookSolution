
import { EventEmitter } from "@angular/core";
import { IWebServiceFilterRslt } from './web-service-filter-rslt.interface';

export interface IViewModelDatasource {
    getHiddenFilterByFltRslt(fr:  Array<IWebServiceFilterRslt> | any): {[key: string]: {[key: string]: {[key: string]: any}}};
    getUIFormChain(): string;
    getHiddenFilter(): {[key: string]: {[key: string]: {[key: string]: any}}}
    setHiddenFilter(fltr: {[key: string]: {[key: string]: {[key: string]: any}}}): void;
    getCurrentViewName(): string;
    getClientViewName(): string | any;
    getDirectNavigation(): string | any;
    getIsTopDetail(): boolean;
    getIsDefined(): boolean;
    getLength(): number;
    getKeys(): string[];
    getValue(key: string): any;
    setValue(key: string, value: any): void;
    requiredValue(key: string): boolean;
    dbgeneratedValue(key: string): boolean;
    isInPrimkeyValue(key: string): boolean;
    isSetValue(key: string): boolean; 
    clearValue(key: string): void;
    clear(doNotify: boolean): boolean;
    isEqual(src: any, dest: any): boolean;

    OnDetailChanged: EventEmitter<IViewModelDatasource>;
    OnMasterChanged: EventEmitter<IViewModelDatasource>;
    AfterMasterChanged: EventEmitter<IViewModelDatasource>;
    AfterPropsChanged: EventEmitter<IViewModelDatasource>;

    OnIsDefinedChanged: EventEmitter<IViewModelDatasource>;
    OnUpdate: EventEmitter<IViewModelDatasource>;
    OnAdd: EventEmitter<IViewModelDatasource>;
    OnDelete: EventEmitter<IViewModelDatasource>;
    clearPartially(doNotify: boolean): boolean;
    submitOnDetailChanged(v: IViewModelDatasource): void;
    submitOnMasterChanged(v: IViewModelDatasource): void;
    calcIsDefined(): boolean;
    doEmitEvent(aftrMstrChngd: boolean): void;

    refreshIsDefined(): boolean;
    isSetFilterByCurrDirMstrs(): boolean;
    updateone(): void;
    addone(): void;
    deleteone(): void;
//    setUnderHiddenFilterFields(): void;
    isUnderHiddenFilterFields(fld: string|any): boolean;
    updateByHiddenFilterFields(doNotify: boolean): boolean;
    getIsNew(): boolean;
    setIsNew(v: boolean): void;
    isReadonlyValue(key: string): boolean;

}

