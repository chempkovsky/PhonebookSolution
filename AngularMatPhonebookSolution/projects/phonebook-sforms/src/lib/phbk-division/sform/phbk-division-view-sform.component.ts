import { Component, OnInit, Input, Output, EventEmitter, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { Sort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { SelectionChange, SelectionModel } from '@angular/cdk/collections';
import { catchError, Observable, of, Subject, switchMap } from 'rxjs';

import { AppGlblSettingsService } from 'common-services';
import { IUniqServiceFilterDef } from 'common-interfaces';
import { IUniqServiceFilter } from 'common-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';
import { IItemHeightData } from 'common-interfaces';
import { IColumnSelectorItem } from 'common-interfaces';
import { ColumnSelectorDlgComponent } from 'common-components';


import { IPhbkDivisionView } from 'phonebook-interfaces';
import { IPhbkDivisionViewPage } from 'phonebook-interfaces';
import { IPhbkDivisionViewFilter } from 'phonebook-interfaces';
import { PhbkDivisionViewService } from 'phonebook-services';
import { LpdDivisionViewService } from 'phonebook-services';
import { ILpdDivisionView } from 'phonebook-interfaces';
import { ILpdDivisionViewPage } from 'phonebook-interfaces';
import { ILpdDivisionViewFilter } from 'phonebook-interfaces';
import { LprDivision01ViewService } from 'phonebook-services';
import { ILprDivision01View } from 'phonebook-interfaces';
import { ILprDivision01ViewPage } from 'phonebook-interfaces';
import { ILprDivision01ViewFilter } from 'phonebook-interfaces';
import { LprDivision02ViewService } from 'phonebook-services';
import { ILprDivision02View } from 'phonebook-interfaces';
import { ILprDivision02ViewPage } from 'phonebook-interfaces';
import { ILprDivision02ViewFilter } from 'phonebook-interfaces';


// begin: internationalization of the mat-paginator
/*
class PhbkDivisionViewMtPgntrIntl implements MatPaginatorIntl {
    changes = new Subject<void>();
    firstPageLabel = $localize`First page@@PhbkDivisionViewSformComponent.firstPageLabel:First page`;
    itemsPerPageLabel = $localize`Items per page@@PhbkDivisionViewSformComponent.itemsPerPageLabel:Items per page`;
    lastPageLabel = $localize`Last page@@PhbkDivisionViewSformComponent.lastPageLabel:Last page`;
    nextPageLabel = $localize`Next page@@PhbkDivisionViewSformComponent.nextPageLabel:Next page`;
    previousPageLabel = $localize`Previous page@@PhbkDivisionViewSformComponent.previousPageLabel:Previous page`;
    ofLabel = $localize`of@@PhbkDivisionViewSformComponent.ofLabel:of`;
    getRangeLabel(page: number, pageSize: number, length: number): string {
        if (length == 0 || pageSize == 0) { return `0 of ${length}`; } 
        length = Math.max(length, 0); 
        const startIndex = page * pageSize; 
        const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize; 
        return `${startIndex + 1} - ${endIndex} ${this.ofLabel} ${length}`; 
    }     
}    
*/
// end: internationalization of the mat-paginator



@Component({
  selector: 'app-phbk-division-view-sform',
  templateUrl: './phbk-division-view-sform.component.html',
  styleUrls: ['./phbk-division-view-sform.component.css'],
//  providers: [{ provide: MatPaginatorIntl, useClass: PhbkDivisionViewMtPgntrIntl }]
})
export class PhbkDivisionViewSformComponent implements OnInit, AfterViewInit,  IEventEmitterPub, IItemHeightData {

    @Input('caption') caption: string = $localize`:Divisions@@PhbkDivisionViewSformComponent.caption:Divisions`;


    clmnCptnsPhbkDivisionView: {[key:string]: string}  = {
        'divisionId': $localize`:Id of the Division@@PhbkDivisionView.divisionId-Name:Id of the Division`,
        'divisionName': $localize`:Name of the Division@@PhbkDivisionView.divisionName-Name:Name of the Division`,
        'divisionDesc': $localize`:Description of the Division@@PhbkDivisionView.divisionDesc-Name:Description of the Division`,
        'entrprsIdRef': $localize`:Id of the Enterprise@@PhbkDivisionView.entrprsIdRef-Name:Id of the Enterprise`,
        'eEntrprsName': $localize`:Name of the Enterprise@@PhbkDivisionView.eEntrprsName-Name:Name of the Enterprise`,
    };

    clmnCptnsLpdDivisionView: {[key:string]: string}  = {
        'divisionName': $localize`:Name of the Division@@PhbkDivisionViewSformComponent.LpdDivisionView-divisionName-Name:Name of the Division`,
    };

    menuCptns: {[key:string]: string}  = {
        'fullscann': $localize`:full scan@@PhbkDivisionViewSformComponent.fullscann-menu:full scan`,
        'scannByPrimary': $localize`:filter by Primary@@PhbkDivisionViewSformComponent.scannByPrimary-menu:filter by Primary`,
        'LprDivision01View': $localize`:filter by Division Name ref01@@PhbkDivisionViewSformComponent.LprDivision01View-menu:filter by Division Name ref01`,
        'LprDivision02View': $localize`:filter by Division Name ref02@@PhbkDivisionViewSformComponent.LprDivision02View-menu:filter by Division Name ref02`,
    };



    showMultiSelectedRowEx: boolean = true;
    protected _showMultiSelectedRow: boolean|null = true;
    @Input('show-multi-selected-row')
        get showMultiSelectedRow(): boolean|null {
            return this._showMultiSelectedRow;
        }
      set showMultiSelectedRow(inp: boolean|null) {
        this._showMultiSelectedRow = inp;
        if (!(typeof inp === 'undefined')) {
            let nc: boolean = false;
            if(inp) {
                nc = this.showMultiSelectedRowEx;
            } else {
                nc = !this.showMultiSelectedRowEx;
            }
            if(nc) return;
            this.showMultiSelectedRowEx = !this.showMultiSelectedRowEx;
            let r: string[] = ['selectAction']
            if(this.showMultiSelectedRowEx) r.push('selectMultAction');
            this.displayedColumns.forEach((s: string) => {if(s !== 'selectAction' && s !== 'selectMultAction') r.push(s)});
            this.displayedColumns = r;
            this.cd.detectChanges();
        }
      }


    public currentMultiRow: Array<IPhbkDivisionView> = [];
    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IPhbkDivisionView>> = new EventEmitter<Array<IPhbkDivisionView>>();
    public multSelection: SelectionModel<IPhbkDivisionView> = new SelectionModel<IPhbkDivisionView>(true, []);
    selectRows(e: Array<IPhbkDivisionView>) {
        if((typeof e === 'undefined') || (typeof this.dataSource  === 'undefined')) return;
        if((e === null) || (this.dataSource  === null)) return;
        if(!Array.isArray(e)) return;
        let rslt: Array<IPhbkDivisionView>=[];
        e.forEach(row => { if(this.dataSource.indexOf(row) > -1) rslt.push(row) });
        this.multSelection.select(...rslt);
    }
    deselectRows(e: Array<IPhbkDivisionView>) {
        this.multSelection.deselect(...e);
    }
    isAllSelected() {
      const numSelected = this.multSelection.selected.length;
      const numRows = this.dataSource.length;
      return numSelected == numRows;
    }
    masterToggle() {
      this.isAllSelected() ?
          this.multSelection.clear() :
          this.dataSource.forEach(row => this.multSelection.select(row));
    }
    onMultiSelectRow(e: Array<IPhbkDivisionView>) {
        if (typeof e === 'undefined') {
            this.currentMultiRow = [];
        } else {
            this.currentMultiRow = e;
        }
        this.cd.detectChanges();
        this.multiSelectedRow.emit(this.currentMultiRow);
    }

    ngOnInit() {
        this.multSelection.changed.subscribe({next: 
            (e: SelectionChange<IPhbkDivisionView>) => {
                this.onMultiSelectRow(this.multSelection.selected);
            }
        });
    }

//===============
    isOnInitCalled: boolean = false;
    protected currentFilter: Array<IWebServiceFilterRslt> = [];
    protected currentSortColumn: string = '';
    protected currentSortdirection: string = '';
    public currentPageIndex: number = 0;
    public currentPageSize: number = 10;
    public dataSource: Array<IPhbkDivisionView> = [];
    matPaginatorLen: number = 0;
    matPaginatorPageSize: number = 10;
    matPaginatorPageSizeOptions: Array<number> = [10, 25, 50, 100];
    displayedColumns:  Array<string> = ['selectAction', 'selectMultAction', 'divisionId', 'divisionName', 'eEntrprsName', 'menuAction'];
    @Input('show-filter') showFilter: boolean = true;
    @Input('row-commands')  rowCommands:Array<IMenuItemData>|any;

    tableCommandsEx: Array<IMenuItemData> = [];
    protected _tableCommands: Array<IMenuItemData> = [];
    @Input('table-commands')  
        get tableCommands(): Array<IMenuItemData> {
            return this._tableCommands;
        }
        set tableCommands(v :Array<IMenuItemData>) {
            this._tableCommands = v;
            if (typeof v === 'undefined') {
                this.tableCommandsEx = [];
            } else if (!Array.isArray(v)) {
                this.tableCommandsEx = [];
            } else {
                this.tableCommandsEx =  v;
            }
            this.onTableMenuItemsData();
            if(this.isOnInitCalled) {
                this.cd.detectChanges();
            }
        }

    @Input('show-add-flt-item') showAddFltItem: boolean = true;
    onTableMenuItemsData() {
        let tmp: Array<IMenuItemData> = [];
        tmp = tmp.concat(this.tableIndexMenuItemsData, this.tableCommandsEx);
        this.tableMenuItemsData = tmp;
    }

    @Input('show-back-btn') showBackBtn: boolean = false;
    @Output('on-back-btn') onBackBtn = new EventEmitter<any>();
    onBackBtnMd(v: any) {
        this.onBackBtn.emit(v);
    }

    @Output('before-squery') beforeSquery = new EventEmitter<string>();

    @Output('on-cont-menu-item-click') onContMenuItemEmitter = new EventEmitter<IEventEmitterData>();
    @Input('cont-menu-items') contMenuItems: Array<IMenuItemData> = [];
    onContMenuItemClicked(v: IEventEmitterData)  {
        this.onContMenuItemEmitter.emit(v);
    }

    @Input('filter-max-height')  filterMaxHeight: number | null = null;
    public ovrflw: string | null = null;   

    maxHeightEx: number|null = null;
    protected _maxHeight: number|null = null;
    @Input('max-height')
        get maxHeight(): number|null {
            return this._maxHeight;
        }
      set maxHeight(inp: number|null) {
        this._maxHeight = inp;
        if (!(typeof inp === 'undefined')) {
          if(!(inp === null)) {
            this.maxHeightEx = inp * this.appGlblSettings.tableHeightFactor + this.appGlblSettings.tableHeightAddition;
            this.ovrflw = 'auto';
            if(this.isOnInitCalled) {
              this.cd.detectChanges();
            }
            return;
          }
        }
        this.maxHeightEx = null;
        this.ovrflw = null;
        if(this.isOnInitCalled) {
            this.cd.detectChanges();
        }
      }


    @Output('on-row-command') onRowCommand: EventEmitter<IEventEmitterData> = new EventEmitter<IEventEmitterData>();
    @Output('on-table-command') onTableCommand: EventEmitter<IEventEmitterData> = new EventEmitter<IEventEmitterData>();

    filterDefs: Array<IUniqServiceFilterDef> = [];
    tableMenuItemsData: Array<IMenuItemData> = [];
    curIndexMenuItemsData: IMenuItemData|any;
    crIMIDid: string|any;
    tableIndexMenuItemsData: Array<IMenuItemData> = [];
    redefTableIndexMenuItemsData(): void {
        this.tableIndexMenuItemsData = this.defineTableIndexMenuItemsData();
        this.onTableMenuItemsData();
        if(this.tableIndexMenuItemsData.length > 0) {
          if(this.curIndexMenuItemsData) {
            let mi: IMenuItemData|any = this.tableIndexMenuItemsData.find((e: IMenuItemData) => e.id === this.curIndexMenuItemsData.id);
            if (mi) {
                this.curIndexMenuItemsData = mi;
            } else {
                this.curIndexMenuItemsData = this.tableIndexMenuItemsData[0];
            }
          } else this.curIndexMenuItemsData = this.tableIndexMenuItemsData[0];
        } else this.curIndexMenuItemsData = undefined;
        if(this.curIndexMenuItemsData) {
            this.crIMIDid = this.curIndexMenuItemsData.id;
        } else {
            this.crIMIDid = undefined;
        }
    }
    defineTableIndexMenuItemsData(): Array<IMenuItemData> {
        let rslt: Array<IMenuItemData> = [];
        let hasNtExternal: boolean = true;
        let extHiddflt: Array<string> = [];
        this.hiddenFilterEx.forEach((f: IWebServiceFilterRslt) => {if(!this.mdlMptProps.some((s:string) => s === f.fltrName)){extHiddflt.push(f.fltrName);}});
        hasNtExternal = extHiddflt.length === 0;
        let crrMDFP: Array<string> = [];
        for (let fld in this.mdlDrctFkProps) { 
            if (this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.mdlDrctFkProps[fld]})) {
                crrMDFP.push(this.mdlDrctFkProps[fld]);
            }
        }

        let doIns: boolean = false;
        doIns = crrMDFP.length === this.reqHiddenProps['LprDivision01View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprDivision01View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprDivision01View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprDivision01View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprDivision01View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprDivision01View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprDivision01View', caption: this.menuCptns['LprDivision01View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'divisionName', fltrCaption: this.clmnCptnsLpdDivisionView['divisionName'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdDivisionView},
        ]})};
        doIns = crrMDFP.length === this.reqHiddenProps['LprDivision02View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprDivision02View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprDivision02View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprDivision02View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprDivision02View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprDivision02View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprDivision02View', caption: this.menuCptns['LprDivision02View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'divisionName', fltrCaption: this.clmnCptnsLpdDivisionView['divisionName'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdDivisionView},
        ]})};
        if(hasNtExternal) {
          let reqFkPrps: Array<string> = [];
          if(this.hiddenFilterEx.length === reqFkPrps.length) {
              let insmi: boolean = true;
              for(let vmfn of reqFkPrps) {
                if(! this.hiddenFilterEx.some((hfp: IWebServiceFilterRslt) => vmfn === hfp.fltrName)) {
                    insmi = false;
                    break;
                }
              }
              if(insmi) {
                rslt.push(
                  {id: 'scannByPrimary', caption: this.menuCptns['scannByPrimary'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
                  {fltrName: 'divisionId', fltrCaption: this.clmnCptnsPhbkDivisionView['divisionId'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmRootSrv},
                ]});
              }
            }
        }
        if(hasNtExternal && this.cnFllscn) {
          rslt.push(
            {id: 'fullscann', caption: this.menuCptns['fullscann'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'divisionId', fltrCaption: this.clmnCptnsPhbkDivisionView['divisionId'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'divisionName', fltrCaption: this.clmnCptnsPhbkDivisionView['divisionName'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'entrprsIdRef', fltrCaption: this.clmnCptnsPhbkDivisionView['entrprsIdRef'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
          ]});
        }
      return rslt;
    }
    mdlDrctFkProps: Array<string> = [ 'entrprsIdRef'];
    mdlMptProps: Array<string> = [ 'divisionId', 'divisionName', 'entrprsIdRef'];
    reqHiddenProps: {[key: string]: Array<string>} = {
                    'LprDivision01View': [],
                    'LprDivision02View': [ 'entrprsIdRef'],
    };
    extHiddenProps: {[key: string]: Array<string>} = {
                    'LprDivision01View': [],
                    'LprDivision02View': [],
    };
    

    protected resetCurFltr(): void {
        this.currentFilter = [];
        this.hiddenFilterEx.forEach((hf: IWebServiceFilterRslt) => { this.currentFilter.push({
            fltrName: hf.fltrName,
            fltrDataType: hf.fltrDataType,
            fltrOperator: hf.fltrOperator,
            fltrValue: hf.fltrValue,
        }); });
        this.externalFilterRslt.forEach((ef: IWebServiceFilterRslt) => { 
          if(this.filterDefs.findIndex((fd: { fltrName: string; }) => { return (fd.fltrName === ef.fltrName); }) > -1) {
            this.currentFilter.push({
                fltrName: ef.fltrName,
                fltrDataType: ef.fltrDataType,
                fltrOperator: ef.fltrOperator,
                fltrValue: ef.fltrValue,
            }); 
          }
        });
    }

    hiddenFilterEx: Array<IWebServiceFilterRslt> = [];
    protected _hiddenFilter: Array<IWebServiceFilterRslt> = [];
    @Input('hidden-filter') 
        get hiddenFilter(): Array<IWebServiceFilterRslt> | any {
          return this._hiddenFilter;
        }
        set hiddenFilter(inDef: Array<IWebServiceFilterRslt> | any) {
          this._hiddenFilter =  inDef;
          if (typeof inDef === 'undefined') {
            this.hiddenFilterEx = [];
          } else if(!Array.isArray(inDef)) {
            this.hiddenFilterEx = [];
          } else {
            this.hiddenFilterEx =  inDef;
          }
          this.redefTableIndexMenuItemsData();
          this.onHiddenFilter();
          this.resetexternalFilter();
          if(this.isOnInitCalled) {
            this.srchSlctRwLprDivision01ViewLpdDivisionView = null;
            this.srchSlctRwLprDivision02ViewLpdDivisionView = null;

            this.resetCurFltr();
            this.onFilter();
          }
        } 

    public externalFilterRslt: Array<IWebServiceFilterRslt> = [];
    externalFilterEx: string|null = null;
    protected _externalFilter: string|null = null;
    @Input('external-filter') 
        get externalFilter(): string|any {
            return this._externalFilter;
        }
        set externalFilter(ef: string|any) {
            this._externalFilter = ef;
            let isNDf = (typeof ef === 'undefined');
            isNDf = isNDf ? isNDf : (ef === null);
            if(isNDf) {
              this.externalFilterEx = null;
              this.resetexternalFilter();
            } else {
                this.externalFilterEx = ef;
                this.resetexternalFilter();
            }
        }
    resetexternalFilter() {
        if(this.isOnInitCalled) return;
        let efs: string| any = this.externalFilterEx;
        if ((typeof efs === 'undefined') ? true : ((efs === null) ? true : (efs === ''))) return;
        let ef: {id: string; f: {[key: string]: string}|any; csc: string; pgi: number; pgsz: number} = JSON.parse(efs);
        
        this.currentSortColumn = '';
        // since if(this.isOnInitCalled) return; we ned to reset props if input is defined
        if(ef.csc) { this.currentSortColumn = ef.csc; } else { this.currentSortColumn = ''; } 
        if(ef.pgi) { this.currentPageIndex = ef.pgi; } else { this.currentPageIndex = 0; }
        if(ef.pgsz) { this.currentPageSize = ef.pgsz; } else { this.currentPageSize = 10; }
        if(typeof ef.id === 'undefined') return;
        let mi: IMenuItemData|any = this.tableIndexMenuItemsData.find((e: IMenuItemData) => e.id === ef.id);
        if(mi) {
            this.curIndexMenuItemsData = mi;
            this.crIMIDid = this.curIndexMenuItemsData.id;
            this.onHiddenFilter();
        } else {
            return;
        }
        if(typeof ef.f === 'undefined') return;
        if((ef.f === null) || (ef.f === 'null') || (ef.f === '')) return;
        let r: Array<IWebServiceFilterRslt> = [];
        switch(ef.id) {
            case 'LprDivision01View':  
                if(ef.f['LpdDivisionView']) {
                    this.srchSlctRwLprDivision01ViewLpdDivisionView = JSON.parse(ef.f['LpdDivisionView']);
                    if(this.srchSlctRwLprDivision01ViewLpdDivisionView) {
                        if(!(typeof this.srchSlctRwLprDivision01ViewLpdDivisionView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdDivisionView.row2FilterRslt(this.srchSlctRwLprDivision01ViewLpdDivisionView));
                        }
                    }
                }
                break;           
            case 'LprDivision02View':  
                if(ef.f['LpdDivisionView']) {
                    this.srchSlctRwLprDivision02ViewLpdDivisionView = JSON.parse(ef.f['LpdDivisionView']);
                    if(this.srchSlctRwLprDivision02ViewLpdDivisionView) {
                        if(!(typeof this.srchSlctRwLprDivision02ViewLpdDivisionView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdDivisionView.row2FilterRslt(this.srchSlctRwLprDivision02ViewLpdDivisionView));
                        }
                    }
                }
                break;           
            default:
                let flt: IPhbkDivisionViewFilter|any = JSON.parse(ef.f['data']);
                if(flt) {
                    this.filterDefs.forEach((fd: IUniqServiceFilterDef) => {
                        if(!this.hiddenFilterEx.some((v: IWebServiceFilterRslt) => v.fltrName === fd.fltrName)) {
                            if( Array.isArray(flt[fd.fltrName]) ) {
                                let oprtrs: Array<string> = [];    
                                if( Array.isArray(flt[fd.fltrName+'Oprtr']) ) {
                                    oprtrs = flt[fd.fltrName+'Oprtr'];
                                }
                                flt[fd.fltrName].forEach((val: any, i: number) => {
                                    let op = 'eq';
                                    if(oprtrs.length > i) op = oprtrs[i];
                                    r.push({fltrName: fd.fltrName, fltrDataType: fd.fltrDataType, fltrOperator: op, fltrValue:val});
                                });
                            }
                        }
                    });
                }
                this.externalFilterRslt = r;
                this.resetCurFltr();
                return;
        } // switch(ef.id) {}
        let rslt: Array<IWebServiceFilterRslt> = [];
        this.filterDefs.forEach((fd: IUniqServiceFilterDef) => {
            if(!this.hiddenFilterEx.some((v: IWebServiceFilterRslt) => v.fltrName === fd.fltrName)) {
                rslt = rslt.concat( r.filter((ri: IWebServiceFilterRslt) => ri.fltrName === fd.fltrName) );
            }
        });
        this.externalFilterRslt = rslt;
        this.resetCurFltr();
    }

    public currentRow: IPhbkDivisionView | null = null;
    @Output('selected-row') selectedRow: EventEmitter<IPhbkDivisionView|null> = new EventEmitter<IPhbkDivisionView|null>();
    @Output('apply-filter') applyFilter: EventEmitter<PhbkDivisionViewSformComponent|null> = new EventEmitter<PhbkDivisionViewSformComponent|null>();

    cnFllscn: boolean = false;
    constructor(public  frmRootSrv: PhbkDivisionViewService, public appGlblSettings: AppGlblSettingsService, 
                public  frmSrvLprDivision01View: LprDivision01ViewService,
                public  frmSrvLpdDivisionView: LpdDivisionViewService,
                public  frmSrvLprDivision02View: LprDivision02ViewService,
    
            protected dialog: MatDialog, private cd: ChangeDetectorRef) {
            this.cnFllscn = (appGlblSettings.getViewModelMask('PhbkDivisionView') & 16) === 16;
        this.redefTableIndexMenuItemsData();
    }

    onHiddenFilter() {
        if(this.curIndexMenuItemsData) {
            if(this.curIndexMenuItemsData.data) {
                let dimi: Array<IUniqServiceFilterDef> = this.curIndexMenuItemsData.data as Array<IUniqServiceFilterDef>;
                if(this.hiddenFilterEx.length < 1) {
                    this.filterDefs = dimi;
                } else {
                    let rslt: Array<IUniqServiceFilterDef> = [];
                    dimi.forEach((e: IUniqServiceFilterDef) => {
                        if(!this.hiddenFilterEx.some((h: IWebServiceFilterRslt) => h.fltrName === e.fltrName)) {
                            rslt.push(e);
                        }
                    });
                    this.filterDefs = rslt;
                }
                return;
            }
        }
        this.filterDefs = [];
    }
    
    onBeforeSquery(flt: IPhbkDivisionViewFilter|any) {
        if(typeof this.curIndexMenuItemsData === 'undefined') return;
        if(this.curIndexMenuItemsData === null) return;
        let r: {id: string; f: {[key: string]: string}|any; csc: string; pgi: number; pgsz: number} = {id: this.curIndexMenuItemsData.id, f: undefined, csc:this.currentSortColumn, pgi: this.currentPageIndex, pgsz: this.currentPageSize};
        let kyvl: {[key: string]: string} = {};
        switch (r.id) {
            case 'LprDivision01View':  
                if(this.srchSlctRwLprDivision01ViewLpdDivisionView) {
                    kyvl['LpdDivisionView'] = JSON.stringify(this.srchSlctRwLprDivision01ViewLpdDivisionView);
                }
                r.f = kyvl;
                break;           
            case 'LprDivision02View':  
                if(this.srchSlctRwLprDivision02ViewLpdDivisionView) {
                    kyvl['LpdDivisionView'] = JSON.stringify(this.srchSlctRwLprDivision02ViewLpdDivisionView);
                }
                r.f = kyvl;
                break;           
            case 'scannByPrimary':  
                if(flt) {
                    kyvl['data'] = JSON.stringify(flt);
                    r.f = kyvl;
                }
                break;           
            case 'fullscann':
                if(flt) {
                    kyvl['data'] = JSON.stringify(flt);
                    r.f = kyvl;
                }
                break;           
            default:
                return;
        } // switch (this.curIndexMenuItemsData.id) {...}
        this.beforeSquery.emit(JSON.stringify(r));
    }
    ngAfterViewInit() {
        setTimeout(() => {
            this.isOnInitCalled = true;
            this.resetCurFltr();
            this.onFilter();
        });
    }    
    onSort(srt: Sort) {
        this.currentSortColumn = srt.active;
        this.currentSortdirection = srt.direction;
        this.onFilter();
    }
    onPage(pg: PageEvent) {
        this.currentPageIndex = pg.pageIndex;
        this.currentPageSize = pg.pageSize;
        this.onFilter();
    }
    onApplyFilter(flt: Array<IWebServiceFilterRslt>) {
        this.currentFilter = flt; 
        this.hiddenFilterEx.forEach((hf: IWebServiceFilterRslt) => { this.currentFilter.push({
            fltrName: hf.fltrName,
            fltrDataType: hf.fltrDataType,
            fltrOperator: hf.fltrOperator,
            fltrValue: hf.fltrValue,
        }); });
        this.currentPageIndex = 0;
        this.onFilter();
    }

    inQuery: boolean = false;
    onFilter() {
        if(typeof this.curIndexMenuItemsData === 'undefined') return;
        if(this.curIndexMenuItemsData === null) return;
        switch (this.curIndexMenuItemsData.id) {
            case 'LprDivision01View':  
                this.srchDoSlctRwLprDivision01View();
                return;
            case 'LprDivision02View':  
                this.srchDoSlctRwLprDivision02View();
                return;
        }
        let flt: IPhbkDivisionViewFilter|any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        if (!(typeof this.currentSortColumn === 'undefined')) {
            if (!(this.currentSortColumn === null)) {
                if(!(this.currentSortColumn === '')) {
                    flt.orderby = [];
                    let asc: string = '';
                    if (!(typeof this.currentSortdirection === 'undefined')) {
                        if (!(this.currentSortdirection === null)) {
                            if(this.currentSortdirection === 'desc') {
                                asc = '-';
                            }
                        }
                    }
                    flt.orderby.push(asc + this.currentSortColumn);
                }
            }
        }
        if (Array.isArray(this.currentFilter)) {
            this.currentFilter.forEach(e => {
                let opNm =  e.fltrName + 'Oprtr';
                if(typeof flt[e.fltrName] === 'undefined') {
                    flt[e.fltrName] = [];
                    flt[opNm] = [];
                }
                flt[e.fltrName].push(e.fltrValue);
                flt[opNm].push(e.fltrOperator);
            });
        }
        this.onBeforeSquery(flt);
        this.inQuery = true;
        let mc: Observable<IPhbkDivisionViewPage> | any;
        switch (this.curIndexMenuItemsData.id) {


            case 'scannByPrimary':  
                mc = this.frmRootSrv.getmanybyrepprim(flt);
                break;
            default:
                mc = this.frmRootSrv.getwithfilter(flt);
        }
        mc.subscribe({
                next: (v: IPhbkDivisionViewPage) =>{
                    this.inQuery = false;
                    let pl: number = 0;
                    if (!(typeof v.total === 'undefined')) {
                        if(!(v.total === null)) {
                            pl = v.total;
                        }
                    }
                    this.matPaginatorLen = pl;
                    let rslt: Array<IPhbkDivisionView> = [];
                    if (!(typeof v.items === 'undefined')) {
                        if(!(v.items === null)) {
                            rslt = v.items;
                        }
                    }
                    this.dataSource = rslt;
                    this.applyFilter.emit(this);
                    let currow: IPhbkDivisionView | null = null;
                    if(Array.isArray(this.dataSource)) {
                        if(this.dataSource.length > 0) {
                            currow = this.dataSource[0];
                        }
                    }
                    this.onSelectRow(currow);
                    this.cd.detectChanges();
                },
                error: (error: any) => {
                    this.inQuery = false;
                    this.appGlblSettings.showError('http', error);
                }
        });
    }

    onSelectRow(e: IPhbkDivisionView|any) {
        if (typeof e === 'undefined') {
            this.currentRow = null;
        } else {
            this.currentRow = e;
        }
        this.cd.detectChanges();
        this.selectedRow.emit(this.currentRow);
    }
    rowCommand(e: IPhbkDivisionView, id: string) {
        let v: IEventEmitterData = {
            id: id,
            sender: this,
            value: e
        };
        this.onRowCommand.emit(v);
    }
    tableCommand(id: string) {
        if(
           (id === 'LprDivision01View') ||
           (id === 'LprDivision02View') ||
           (id === 'scannByPrimary') ||
           (id === 'fullscann'))
        {
            let mi: IMenuItemData|any = this.tableIndexMenuItemsData.find((e: IMenuItemData) => e.id === id);
            if(mi) {
                this.srchSlctRwLprDivision01ViewLpdDivisionView = null;
                this.srchSlctRwLprDivision02ViewLpdDivisionView = null;
                this.externalFilterRslt = [];
                this.curIndexMenuItemsData = mi;
                this.crIMIDid = this.curIndexMenuItemsData.id;
                this.onHiddenFilter();
            }
            return;
        }
        let v: IEventEmitterData = {
            id: id,
            sender: this,
            value: null
        };
        this.onTableCommand.emit(v);
    }
    onSettings() {
        let locdata: Array<IColumnSelectorItem>=[
            { name: 'divisionId', caption: this.clmnCptnsPhbkDivisionView['divisionId'], checked: false },
            { name: 'divisionName', caption: this.clmnCptnsPhbkDivisionView['divisionName'], checked: false },
            { name: 'eEntrprsName', caption: this.clmnCptnsPhbkDivisionView['eEntrprsName'], checked: false },
            { name: 'divisionDesc', caption: this.clmnCptnsPhbkDivisionView['divisionDesc'], checked: false },
            { name: 'entrprsIdRef', caption: this.clmnCptnsPhbkDivisionView['entrprsIdRef'], checked: false },
        ];
        let len: number =  this.displayedColumns.length;
        // i = 1 is correct
        for(var i = 1; i < len-1; i++) {
            let ind=locdata.findIndex(e => { return e.name === this.displayedColumns[i]; })
            if(ind > -1) {
                locdata[ind].checked = true;
            }
        }
        let dialogRef = this.dialog.open(ColumnSelectorDlgComponent, {
              data: locdata,
              maxWidth: '100vw',
              width: '65vw',
            });
        dialogRef.afterClosed().subscribe({
            next: (rslt: any) => {
                if (!(typeof rslt === 'undefined')) {
                    if (!(rslt === null)) {
                        let r: string[] = ['selectAction']
                        if(this.showMultiSelectedRowEx) r.push('selectMultAction');
                        rslt.forEach((e: { checked: any; name: string; }) => { if (e.checked) { r.push(e.name) }});
                        r.push('menuAction');
                        this.displayedColumns = r;
                        this.cd.detectChanges();
                    }
                }
            }
        });
    } 



    clrDs(): void {
        this.dataSource = [];
        this.inQuery = false;
        this.applyFilter.emit(this);
        this.onSelectRow(null);
        this.cd.detectChanges();
    }
/////////////////////////////////////////
    srchSlctRwLprDivision01ViewLpdDivisionView: ILpdDivisionView | any = null;
    
    srchDoSlctRwLprDivision01View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprDivision01ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprDivision01ViewLpdDivisionView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprDivision01View.getHiddenFilterAsFltRslt(this.frmSrvLpdDivisionView.getHiddenFilterByRow(this.srchSlctRwLprDivision01ViewLpdDivisionView, 'DivisionNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkDivisionViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprDivision01View and PhbkDivisionView
        for (let fld in this.reqHiddenProps['LprDivision01View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprDivision01View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprDivision01View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprDivision01View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprDivision01View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprDivision01ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprDivision01View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprDivision01View.getm2cKeyfm()['PhbkDivisionView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Division'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkDivisionViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprDivision01View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkDivisionViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkDivisionView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkDivisionView | null = null;
                        if(Array.isArray(this.dataSource)) {
                            if(this.dataSource.length > 0) {
                                currow = this.dataSource[0];
                            }
                        }
                        this.onSelectRow(currow);
                        this.cd.detectChanges();
                    },
                    error: (error: any) => {
                        this.clrDs();
                        this.appGlblSettings.showError('http', error);
                    }
                });
            },
            error: (error: any) => {
                this.clrDs();
                this.appGlblSettings.showError('http', error);
            }
        });
    }

    afterObjSelLprDivision01View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprDivision01ViewLpdDivisionView = e.v;
                break;
        }
    }
    tpAheadValLprDivision01View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.divisionName;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprDivision01View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdDivisionViewFilter | any = { page: 0, pagesize: 15 };
          fltr.divisionName = [value]; 
          fltr.divisionNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdDivisionNameUk(fltr)
            .pipe(
                switchMap((rslt: ILpdDivisionViewPage) => {
                    if (!(typeof rslt === 'undefined')) {
                    if (!(rslt === null)) {
                            if (!(typeof rslt.items === 'undefined')) {
                                if (Array.isArray( rslt.items )) {
                                    return of(rslt.items);
                                }
                            }
                        }
                    }
                    return of([]);
                }),
                catchError((x:any) =>of([]))
            );
        }

      }
      return of([]);
    }
    tpAheadCptnLprDivision01View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.divisionName === 'undefined')) {
                if(!(v.divisionName === null)) {
                    retStr = retStr + v.divisionName;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////
/////////////////////////////////////////
    srchSlctRwLprDivision02ViewLpdDivisionView: ILpdDivisionView | any = null;
    
    srchDoSlctRwLprDivision02View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprDivision02ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprDivision02ViewLpdDivisionView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprDivision02View.getHiddenFilterAsFltRslt(this.frmSrvLpdDivisionView.getHiddenFilterByRow(this.srchSlctRwLprDivision02ViewLpdDivisionView, 'DivisionNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkDivisionViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprDivision02View and PhbkDivisionView
        for (let fld in this.reqHiddenProps['LprDivision02View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprDivision02View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprDivision02View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprDivision02View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprDivision02View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprDivision02ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprDivision02View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprDivision02View.getm2cKeyfm()['PhbkDivisionView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Division'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkDivisionViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprDivision02View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkDivisionViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkDivisionView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkDivisionView | null = null;
                        if(Array.isArray(this.dataSource)) {
                            if(this.dataSource.length > 0) {
                                currow = this.dataSource[0];
                            }
                        }
                        this.onSelectRow(currow);
                        this.cd.detectChanges();
                    },
                    error: (error: any) => {
                        this.clrDs();
                        this.appGlblSettings.showError('http', error);
                    }
                });
            },
            error: (error: any) => {
                this.clrDs();
                this.appGlblSettings.showError('http', error);
            }
        });
    }

    afterObjSelLprDivision02View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprDivision02ViewLpdDivisionView = e.v;
                break;
        }
    }
    tpAheadValLprDivision02View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.divisionName;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprDivision02View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdDivisionViewFilter | any = { page: 0, pagesize: 15 };
          fltr.divisionName = [value]; 
          fltr.divisionNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdDivisionNameUk(fltr)
            .pipe(
                switchMap((rslt: ILpdDivisionViewPage) => {
                    if (!(typeof rslt === 'undefined')) {
                    if (!(rslt === null)) {
                            if (!(typeof rslt.items === 'undefined')) {
                                if (Array.isArray( rslt.items )) {
                                    return of(rslt.items);
                                }
                            }
                        }
                    }
                    return of([]);
                }),
                catchError((x:any) =>of([]))
            );
        }

      }
      return of([]);
    }
    tpAheadCptnLprDivision02View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.divisionName === 'undefined')) {
                if(!(v.divisionName === null)) {
                    retStr = retStr + v.divisionName;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////




/////////////////////////////////////////

    srchSlctRwPrimary: IPhbkDivisionView | any = null;
    afterObjSelPrimary(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        if(e.v) {
            this.srchSlctRwPrimary = e.v as IPhbkDivisionView;
        } else {
            this.srchSlctRwPrimary = null;
        }
    }

    tpAheadValPrimary(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                 return v.divisionId;
            }
        } 
        return null;
    }
    tpAheadFncPrimary(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
        let fltr: IPhbkDivisionViewFilter | any = { page: 0, pagesize: 15 };
        if(i > 0) { 
            fltr.divisionId = [wsfd[0].fltrValue.value]; 
            fltr.divisionIdOprtr = ['eq']
         } else if(i === 0) { 
            fltr.divisionId = [value]; 
            fltr.divisionIdOprtr = ['lk']
         }
        return srv.getmanybyrepprim(fltr)
            .pipe(
                switchMap((rslt: IPhbkDivisionViewPage) => {
                    if (!(typeof rslt === 'undefined')) {
                    if (!(rslt === null)) {
                            if (!(typeof rslt.items === 'undefined')) {
                                if (Array.isArray( rslt.items )) {
                                    return of(rslt.items);
                                }
                            }
                        }
                    }
                    return of([]);
                }),
                catchError((x:any) =>of([]))
            );
    }
    tpAheadCptnPrimary(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.divisionId === 'undefined')) {
                if(!(v.divisionId === null)) {
                    retStr = retStr + ' ' + v.divisionId;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////

}


