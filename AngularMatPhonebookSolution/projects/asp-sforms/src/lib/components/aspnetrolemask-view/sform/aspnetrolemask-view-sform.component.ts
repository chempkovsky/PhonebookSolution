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


import { IaspnetrolemaskView } from 'asp-interfaces';
import { IaspnetrolemaskViewPage } from 'asp-interfaces';
import { IaspnetrolemaskViewFilter } from 'asp-interfaces';
import { AspnetrolemaskViewService } from 'asp-services';


// begin: internationalization of the mat-paginator
/*
class aspnetrolemaskViewMtPgntrIntl implements MatPaginatorIntl {
    changes = new Subject<void>();
    firstPageLabel = $localize`First page@@AspnetrolemaskViewSformComponent.firstPageLabel:First page`;
    itemsPerPageLabel = $localize`Items per page@@AspnetrolemaskViewSformComponent.itemsPerPageLabel:Items per page`;
    lastPageLabel = $localize`Last page@@AspnetrolemaskViewSformComponent.lastPageLabel:Last page`;
    nextPageLabel = $localize`Next page@@AspnetrolemaskViewSformComponent.nextPageLabel:Next page`;
    previousPageLabel = $localize`Previous page@@AspnetrolemaskViewSformComponent.previousPageLabel:Previous page`;
    ofLabel = $localize`of@@AspnetrolemaskViewSformComponent.ofLabel:of`;
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
  selector: 'app-aspnetrolemask-view-sform',
  templateUrl: './aspnetrolemask-view-sform.component.html',
  styleUrls: ['./aspnetrolemask-view-sform.component.css'],
//  providers: [{ provide: MatPaginatorIntl, useClass: aspnetrolemaskViewMtPgntrIntl }]
})
export class AspnetrolemaskViewSformComponent implements OnInit, AfterViewInit,  IEventEmitterPub, IItemHeightData {

    @Input('caption') caption: string = $localize`:Role Masks@@AspnetrolemaskViewSformComponent.caption:Role Masks`;


    clmnCptnsaspnetrolemaskView: {[key:string]: string}  = {
        'roleDescription': $localize`:Role Description@@aspnetrolemaskView.roleDescription-Name:Role Description`,
        'mask1': $localize`:Permission to Sel@@aspnetrolemaskView.mask1-Name:Permission to Sel`,
        'mask2': $localize`:Permission to Del@@aspnetrolemaskView.mask2-Name:Permission to Del`,
        'mask3': $localize`:Permission to Upd@@aspnetrolemaskView.mask3-Name:Permission to Upd`,
        'mask4': $localize`:Permission to Add@@aspnetrolemaskView.mask4-Name:Permission to Add`,
        'mask5': $localize`:Full scan permission@@aspnetrolemaskView.mask5-Name:Full scan permission`,
        'modelPkRef': $localize`:Model Id@@aspnetrolemaskView.modelPkRef-Name:Model Id`,
        'mModelName': $localize`:Model Name@@aspnetrolemaskView.mModelName-Name:Model Name`,
        'rName': $localize`:Role Name@@aspnetrolemaskView.rName-Name:Role Name`,
    };


    menuCptns: {[key:string]: string}  = {
        'fullscann': $localize`:full scan@@AspnetrolemaskViewSformComponent.fullscann-menu:full scan`,
        'scannByPrimary': $localize`:filter by Primary@@AspnetrolemaskViewSformComponent.scannByPrimary-menu:filter by Primary`,
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


    public currentMultiRow: Array<IaspnetrolemaskView> = [];
    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IaspnetrolemaskView>> = new EventEmitter<Array<IaspnetrolemaskView>>();
    public multSelection: SelectionModel<IaspnetrolemaskView> = new SelectionModel<IaspnetrolemaskView>(true, []);
    selectRows(e: Array<IaspnetrolemaskView>) {
        if((typeof e === 'undefined') || (typeof this.dataSource  === 'undefined')) return;
        if((e === null) || (this.dataSource  === null)) return;
        if(!Array.isArray(e)) return;
        let rslt: Array<IaspnetrolemaskView>=[];
        e.forEach(row => { if(this.dataSource.indexOf(row) > -1) rslt.push(row) });
        this.multSelection.select(...rslt);
    }
    deselectRows(e: Array<IaspnetrolemaskView>) {
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
    onMultiSelectRow(e: Array<IaspnetrolemaskView>) {
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
            (e: SelectionChange<IaspnetrolemaskView>) => {
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
    public dataSource: Array<IaspnetrolemaskView> = [];
    matPaginatorLen: number = 0;
    matPaginatorPageSize: number = 10;
    matPaginatorPageSizeOptions: Array<number> = [10, 25, 50, 100];
    displayedColumns:  Array<string> = ['selectAction', 'selectMultAction', 'rName', 'mModelName', 'mask1', 'mask2', 'mask3', 'mask4', 'mask5', 'roleDescription', 'menuAction'];
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
        if(hasNtExternal && this.cnFllscn) {
          rslt.push(
            {id: 'fullscann', caption: this.menuCptns['fullscann'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'modelPkRef', fltrCaption: this.clmnCptnsaspnetrolemaskView['modelPkRef'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'mModelName', fltrCaption: this.clmnCptnsaspnetrolemaskView['mModelName'], fltrDataType: 'string', fltrMaxLen: 50, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'rName', fltrCaption: this.clmnCptnsaspnetrolemaskView['rName'], fltrDataType: 'string', fltrMaxLen: 128, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
          ]});
        }
      return rslt;
    }
    

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
            default:
                let flt: IaspnetrolemaskViewFilter|any = JSON.parse(ef.f['data']);
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
    }

    public currentRow: IaspnetrolemaskView | null = null;
    @Output('selected-row') selectedRow: EventEmitter<IaspnetrolemaskView|null> = new EventEmitter<IaspnetrolemaskView|null>();
    @Output('apply-filter') applyFilter: EventEmitter<AspnetrolemaskViewSformComponent|null> = new EventEmitter<AspnetrolemaskViewSformComponent|null>();

    cnFllscn: boolean = false;
    constructor(public  frmRootSrv: AspnetrolemaskViewService, public appGlblSettings: AppGlblSettingsService, 
    
            protected dialog: MatDialog, private cd: ChangeDetectorRef) {
            this.cnFllscn = (appGlblSettings.getViewModelMask('aspnetrolemaskView') & 16) === 16;
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
    
    onBeforeSquery(flt: IaspnetrolemaskViewFilter|any) {
        if(typeof this.curIndexMenuItemsData === 'undefined') return;
        if(this.curIndexMenuItemsData === null) return;
        let r: {id: string; f: {[key: string]: string}|any; csc: string; pgi: number; pgsz: number} = {id: this.curIndexMenuItemsData.id, f: undefined, csc:this.currentSortColumn, pgi: this.currentPageIndex, pgsz: this.currentPageSize};
        let kyvl: {[key: string]: string} = {};
        switch (r.id) {
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
        let flt: IaspnetrolemaskViewFilter|any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
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
        let mc: Observable<IaspnetrolemaskViewPage> | any;
        switch (this.curIndexMenuItemsData.id) {


            case 'scannByPrimary':  
                mc = this.frmRootSrv.getmanybyrepprim(flt);
                break;
            default:
                mc = this.frmRootSrv.getwithfilter(flt);
        }
        mc.subscribe({
                next: (v: IaspnetrolemaskViewPage) =>{
                    this.inQuery = false;
                    let pl: number = 0;
                    if (!(typeof v.total === 'undefined')) {
                        if(!(v.total === null)) {
                            pl = v.total;
                        }
                    }
                    this.matPaginatorLen = pl;
                    let rslt: Array<IaspnetrolemaskView> = [];
                    if (!(typeof v.items === 'undefined')) {
                        if(!(v.items === null)) {
                            rslt = v.items;
                        }
                    }
                    this.dataSource = rslt;
                    this.applyFilter.emit(this);
                    let currow: IaspnetrolemaskView | null = null;
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

    onSelectRow(e: IaspnetrolemaskView|any) {
        if (typeof e === 'undefined') {
            this.currentRow = null;
        } else {
            this.currentRow = e;
        }
        this.cd.detectChanges();
        this.selectedRow.emit(this.currentRow);
    }
    rowCommand(e: IaspnetrolemaskView, id: string) {
        let v: IEventEmitterData = {
            id: id,
            sender: this,
            value: e
        };
        this.onRowCommand.emit(v);
    }
    tableCommand(id: string) {
        if(
           (id === 'scannByPrimary') ||
           (id === 'fullscann'))
        {
            let mi: IMenuItemData|any = this.tableIndexMenuItemsData.find((e: IMenuItemData) => e.id === id);
            if(mi) {
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
            { name: 'rName', caption: this.clmnCptnsaspnetrolemaskView['rName'], checked: false },
            { name: 'mModelName', caption: this.clmnCptnsaspnetrolemaskView['mModelName'], checked: false },
            { name: 'mask1', caption: this.clmnCptnsaspnetrolemaskView['mask1'], checked: false },
            { name: 'mask2', caption: this.clmnCptnsaspnetrolemaskView['mask2'], checked: false },
            { name: 'mask3', caption: this.clmnCptnsaspnetrolemaskView['mask3'], checked: false },
            { name: 'mask4', caption: this.clmnCptnsaspnetrolemaskView['mask4'], checked: false },
            { name: 'mask5', caption: this.clmnCptnsaspnetrolemaskView['mask5'], checked: false },
            { name: 'roleDescription', caption: this.clmnCptnsaspnetrolemaskView['roleDescription'], checked: false },
            { name: 'modelPkRef', caption: this.clmnCptnsaspnetrolemaskView['modelPkRef'], checked: false },
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







/////////////////////////////////////////

    srchSlctRwPrimary: IaspnetrolemaskView | any = null;
    afterObjSelPrimary(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        if(e.v) {
            this.srchSlctRwPrimary = e.v as IaspnetrolemaskView;
        } else {
            this.srchSlctRwPrimary = null;
        }
    }

    tpAheadValPrimary(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                 return v.rName;
                case 1: 
                 return v.modelPkRef;
            }
        } 
        return null;
    }
    tpAheadFncPrimary(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
        let fltr: IaspnetrolemaskViewFilter | any = { page: 0, pagesize: 15 };
        return srv.getmanybyrepprim(fltr)
            .pipe(
                switchMap((rslt: IaspnetrolemaskViewPage) => {
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
        } 
        return retStr;
    }
/////////////////////////////////////////

}


