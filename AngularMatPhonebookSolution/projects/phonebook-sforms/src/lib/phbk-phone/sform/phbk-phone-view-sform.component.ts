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


import { IPhbkPhoneView } from 'phonebook-interfaces';
import { IPhbkPhoneViewPage } from 'phonebook-interfaces';
import { IPhbkPhoneViewFilter } from 'phonebook-interfaces';
import { PhbkPhoneViewService } from 'phonebook-services';
import { LpdPhoneViewService } from 'phonebook-services';
import { ILpdPhoneView } from 'phonebook-interfaces';
import { ILpdPhoneViewPage } from 'phonebook-interfaces';
import { ILpdPhoneViewFilter } from 'phonebook-interfaces';
import { LprPhone01ViewService } from 'phonebook-services';
import { ILprPhone01View } from 'phonebook-interfaces';
import { ILprPhone01ViewPage } from 'phonebook-interfaces';
import { ILprPhone01ViewFilter } from 'phonebook-interfaces';
import { LprPhone02ViewService } from 'phonebook-services';
import { ILprPhone02View } from 'phonebook-interfaces';
import { ILprPhone02ViewPage } from 'phonebook-interfaces';
import { ILprPhone02ViewFilter } from 'phonebook-interfaces';
import { LprPhone03ViewService } from 'phonebook-services';
import { ILprPhone03View } from 'phonebook-interfaces';
import { ILprPhone03ViewPage } from 'phonebook-interfaces';
import { ILprPhone03ViewFilter } from 'phonebook-interfaces';
import { LprPhone04ViewService } from 'phonebook-services';
import { ILprPhone04View } from 'phonebook-interfaces';
import { ILprPhone04ViewPage } from 'phonebook-interfaces';
import { ILprPhone04ViewFilter } from 'phonebook-interfaces';


// begin: internationalization of the mat-paginator
/*
class PhbkPhoneViewMtPgntrIntl implements MatPaginatorIntl {
    changes = new Subject<void>();
    firstPageLabel = $localize`First page@@PhbkPhoneViewSformComponent.firstPageLabel:First page`;
    itemsPerPageLabel = $localize`Items per page@@PhbkPhoneViewSformComponent.itemsPerPageLabel:Items per page`;
    lastPageLabel = $localize`Last page@@PhbkPhoneViewSformComponent.lastPageLabel:Last page`;
    nextPageLabel = $localize`Next page@@PhbkPhoneViewSformComponent.nextPageLabel:Next page`;
    previousPageLabel = $localize`Previous page@@PhbkPhoneViewSformComponent.previousPageLabel:Previous page`;
    ofLabel = $localize`of@@PhbkPhoneViewSformComponent.ofLabel:of`;
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
  selector: 'app-phbk-phone-view-sform',
  templateUrl: './phbk-phone-view-sform.component.html',
  styleUrls: ['./phbk-phone-view-sform.component.css'],
//  providers: [{ provide: MatPaginatorIntl, useClass: PhbkPhoneViewMtPgntrIntl }]
})
export class PhbkPhoneViewSformComponent implements OnInit, AfterViewInit,  IEventEmitterPub, IItemHeightData {

    @Input('caption') caption: string = $localize`:Phones@@PhbkPhoneViewSformComponent.caption:Phones`;


    clmnCptnsPhbkPhoneView: {[key:string]: string}  = {
        'phoneId': $localize`:Phone Id@@PhbkPhoneView.phoneId-Name:Phone Id`,
        'phone': $localize`:Phone@@PhbkPhoneView.phone-Name:Phone`,
        'phoneTypeIdRef': $localize`:Phone Type Id@@PhbkPhoneView.phoneTypeIdRef-Name:Phone Type Id`,
        'employeeIdRef': $localize`:Id of the Employee@@PhbkPhoneView.employeeIdRef-Name:Id of the Employee`,
        'pPhoneTypeName': $localize`:Phone Type Name@@PhbkPhoneView.pPhoneTypeName-Name:Phone Type Name`,
        'eEmpFirstName': $localize`:Employee First Name@@PhbkPhoneView.eEmpFirstName-Name:Employee First Name`,
        'eEmpLastName': $localize`:Employee Last Name@@PhbkPhoneView.eEmpLastName-Name:Employee Last Name`,
        'eEmpSecondName': $localize`:Employee Second Name@@PhbkPhoneView.eEmpSecondName-Name:Employee Second Name`,
        'eDDivisionName': $localize`:Name of the Division@@PhbkPhoneView.eDDivisionName-Name:Name of the Division`,
        'eDEEntrprsName': $localize`:Name of the Enterprise@@PhbkPhoneView.eDEEntrprsName-Name:Name of the Enterprise`,
    };

    clmnCptnsLpdPhoneView: {[key:string]: string}  = {
        'phone': $localize`:Phone@@PhbkPhoneViewSformComponent.LpdPhoneView-phone-Name:Phone`,
    };

    menuCptns: {[key:string]: string}  = {
        'fullscann': $localize`:full scan@@PhbkPhoneViewSformComponent.fullscann-menu:full scan`,
        'scannByPrimary': $localize`:filter by Primary@@PhbkPhoneViewSformComponent.scannByPrimary-menu:filter by Primary`,
        'LprPhone01View': $localize`:filter by Phone Dict Ref@@PhbkPhoneViewSformComponent.LprPhone01View-menu:filter by Phone Dict Ref`,
        'LprPhone02View': $localize`:filter by Phone Dict Ref@@PhbkPhoneViewSformComponent.LprPhone02View-menu:filter by Phone Dict Ref`,
        'LprPhone03View': $localize`:filter by Phone Dict Ref@@PhbkPhoneViewSformComponent.LprPhone03View-menu:filter by Phone Dict Ref`,
        'LprPhone04View': $localize`:filter by Phone Dict Ref@@PhbkPhoneViewSformComponent.LprPhone04View-menu:filter by Phone Dict Ref`,
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


    public currentMultiRow: Array<IPhbkPhoneView> = [];
    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IPhbkPhoneView>> = new EventEmitter<Array<IPhbkPhoneView>>();
    public multSelection: SelectionModel<IPhbkPhoneView> = new SelectionModel<IPhbkPhoneView>(true, []);
    selectRows(e: Array<IPhbkPhoneView>) {
        if((typeof e === 'undefined') || (typeof this.dataSource  === 'undefined')) return;
        if((e === null) || (this.dataSource  === null)) return;
        if(!Array.isArray(e)) return;
        let rslt: Array<IPhbkPhoneView>=[];
        e.forEach(row => { if(this.dataSource.indexOf(row) > -1) rslt.push(row) });
        this.multSelection.select(...rslt);
    }
    deselectRows(e: Array<IPhbkPhoneView>) {
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
    onMultiSelectRow(e: Array<IPhbkPhoneView>) {
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
            (e: SelectionChange<IPhbkPhoneView>) => {
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
    public dataSource: Array<IPhbkPhoneView> = [];
    matPaginatorLen: number = 0;
    matPaginatorPageSize: number = 10;
    matPaginatorPageSizeOptions: Array<number> = [10, 25, 50, 100];
    displayedColumns:  Array<string> = ['selectAction', 'selectMultAction', 'phoneId', 'phone', 'pPhoneTypeName', 'eEmpLastName', 'eEmpFirstName', 'eDDivisionName', 'eDEEntrprsName', 'menuAction'];
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
        doIns = crrMDFP.length === this.reqHiddenProps['LprPhone01View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprPhone01View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprPhone01View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone01View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprPhone01View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprPhone01View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprPhone01View', caption: this.menuCptns['LprPhone01View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'phone', fltrCaption: this.clmnCptnsLpdPhoneView['phone'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdPhoneView},
        ]})};
        doIns = crrMDFP.length === this.reqHiddenProps['LprPhone02View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprPhone02View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprPhone02View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone02View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprPhone02View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprPhone02View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprPhone02View', caption: this.menuCptns['LprPhone02View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'phone', fltrCaption: this.clmnCptnsLpdPhoneView['phone'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdPhoneView},
        ]})};
        doIns = crrMDFP.length === this.reqHiddenProps['LprPhone03View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprPhone03View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprPhone03View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone03View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprPhone03View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprPhone03View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprPhone03View', caption: this.menuCptns['LprPhone03View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'phone', fltrCaption: this.clmnCptnsLpdPhoneView['phone'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdPhoneView},
        ]})};
        doIns = crrMDFP.length === this.reqHiddenProps['LprPhone04View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprPhone04View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprPhone04View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone04View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprPhone04View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprPhone04View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprPhone04View', caption: this.menuCptns['LprPhone04View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'phone', fltrCaption: this.clmnCptnsLpdPhoneView['phone'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdPhoneView},
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
                  {fltrName: 'phoneId', fltrCaption: this.clmnCptnsPhbkPhoneView['phoneId'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmRootSrv},
                ]});
              }
            }
        }
        if(hasNtExternal && this.cnFllscn) {
          rslt.push(
            {id: 'fullscann', caption: this.menuCptns['fullscann'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'phoneId', fltrCaption: this.clmnCptnsPhbkPhoneView['phoneId'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'phone', fltrCaption: this.clmnCptnsPhbkPhoneView['phone'], fltrDataType: 'string', fltrMaxLen: 20, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'phoneTypeIdRef', fltrCaption: this.clmnCptnsPhbkPhoneView['phoneTypeIdRef'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'employeeIdRef', fltrCaption: this.clmnCptnsPhbkPhoneView['employeeIdRef'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
          ]});
        }
      return rslt;
    }
    mdlDrctFkProps: Array<string> = [ 'phoneTypeIdRef', 'employeeIdRef'];
    mdlMptProps: Array<string> = [ 'phoneId', 'phone', 'phoneTypeIdRef', 'employeeIdRef'];
    reqHiddenProps: {[key: string]: Array<string>} = {
                    'LprPhone01View': [],
                    'LprPhone02View': [ 'employeeIdRef'],
                    'LprPhone03View': [ 'phoneTypeIdRef'],
                    'LprPhone04View': [ 'employeeIdRef', 'phoneTypeIdRef'],
    };
    extHiddenProps: {[key: string]: Array<string>} = {
                    'LprPhone01View': [],
                    'LprPhone02View': [],
                    'LprPhone03View': [],
                    'LprPhone04View': [],
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
            this.srchSlctRwLprPhone01ViewLpdPhoneView = null;
            this.srchSlctRwLprPhone02ViewLpdPhoneView = null;
            this.srchSlctRwLprPhone03ViewLpdPhoneView = null;
            this.srchSlctRwLprPhone04ViewLpdPhoneView = null;

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
            case 'LprPhone01View':  
                if(ef.f['LpdPhoneView']) {
                    this.srchSlctRwLprPhone01ViewLpdPhoneView = JSON.parse(ef.f['LpdPhoneView']);
                    if(this.srchSlctRwLprPhone01ViewLpdPhoneView) {
                        if(!(typeof this.srchSlctRwLprPhone01ViewLpdPhoneView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdPhoneView.row2FilterRslt(this.srchSlctRwLprPhone01ViewLpdPhoneView));
                        }
                    }
                }
                break;           
            case 'LprPhone02View':  
                if(ef.f['LpdPhoneView']) {
                    this.srchSlctRwLprPhone02ViewLpdPhoneView = JSON.parse(ef.f['LpdPhoneView']);
                    if(this.srchSlctRwLprPhone02ViewLpdPhoneView) {
                        if(!(typeof this.srchSlctRwLprPhone02ViewLpdPhoneView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdPhoneView.row2FilterRslt(this.srchSlctRwLprPhone02ViewLpdPhoneView));
                        }
                    }
                }
                break;           
            case 'LprPhone03View':  
                if(ef.f['LpdPhoneView']) {
                    this.srchSlctRwLprPhone03ViewLpdPhoneView = JSON.parse(ef.f['LpdPhoneView']);
                    if(this.srchSlctRwLprPhone03ViewLpdPhoneView) {
                        if(!(typeof this.srchSlctRwLprPhone03ViewLpdPhoneView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdPhoneView.row2FilterRslt(this.srchSlctRwLprPhone03ViewLpdPhoneView));
                        }
                    }
                }
                break;           
            case 'LprPhone04View':  
                if(ef.f['LpdPhoneView']) {
                    this.srchSlctRwLprPhone04ViewLpdPhoneView = JSON.parse(ef.f['LpdPhoneView']);
                    if(this.srchSlctRwLprPhone04ViewLpdPhoneView) {
                        if(!(typeof this.srchSlctRwLprPhone04ViewLpdPhoneView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdPhoneView.row2FilterRslt(this.srchSlctRwLprPhone04ViewLpdPhoneView));
                        }
                    }
                }
                break;           
            default:
                let flt: IPhbkPhoneViewFilter|any = JSON.parse(ef.f['data']);
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

    public currentRow: IPhbkPhoneView | null = null;
    @Output('selected-row') selectedRow: EventEmitter<IPhbkPhoneView|null> = new EventEmitter<IPhbkPhoneView|null>();
    @Output('apply-filter') applyFilter: EventEmitter<PhbkPhoneViewSformComponent|null> = new EventEmitter<PhbkPhoneViewSformComponent|null>();

    cnFllscn: boolean = false;
    constructor(public  frmRootSrv: PhbkPhoneViewService, public appGlblSettings: AppGlblSettingsService, 
                public  frmSrvLprPhone01View: LprPhone01ViewService,
                public  frmSrvLpdPhoneView: LpdPhoneViewService,
                public  frmSrvLprPhone02View: LprPhone02ViewService,
                public  frmSrvLprPhone03View: LprPhone03ViewService,
                public  frmSrvLprPhone04View: LprPhone04ViewService,
    
            protected dialog: MatDialog, private cd: ChangeDetectorRef) {
            this.cnFllscn = (appGlblSettings.getViewModelMask('PhbkPhoneView') & 16) === 16;
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
    
    onBeforeSquery(flt: IPhbkPhoneViewFilter|any) {
        if(typeof this.curIndexMenuItemsData === 'undefined') return;
        if(this.curIndexMenuItemsData === null) return;
        let r: {id: string; f: {[key: string]: string}|any; csc: string; pgi: number; pgsz: number} = {id: this.curIndexMenuItemsData.id, f: undefined, csc:this.currentSortColumn, pgi: this.currentPageIndex, pgsz: this.currentPageSize};
        let kyvl: {[key: string]: string} = {};
        switch (r.id) {
            case 'LprPhone01View':  
                if(this.srchSlctRwLprPhone01ViewLpdPhoneView) {
                    kyvl['LpdPhoneView'] = JSON.stringify(this.srchSlctRwLprPhone01ViewLpdPhoneView);
                }
                r.f = kyvl;
                break;           
            case 'LprPhone02View':  
                if(this.srchSlctRwLprPhone02ViewLpdPhoneView) {
                    kyvl['LpdPhoneView'] = JSON.stringify(this.srchSlctRwLprPhone02ViewLpdPhoneView);
                }
                r.f = kyvl;
                break;           
            case 'LprPhone03View':  
                if(this.srchSlctRwLprPhone03ViewLpdPhoneView) {
                    kyvl['LpdPhoneView'] = JSON.stringify(this.srchSlctRwLprPhone03ViewLpdPhoneView);
                }
                r.f = kyvl;
                break;           
            case 'LprPhone04View':  
                if(this.srchSlctRwLprPhone04ViewLpdPhoneView) {
                    kyvl['LpdPhoneView'] = JSON.stringify(this.srchSlctRwLprPhone04ViewLpdPhoneView);
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
            case 'LprPhone01View':  
                this.srchDoSlctRwLprPhone01View();
                return;
            case 'LprPhone02View':  
                this.srchDoSlctRwLprPhone02View();
                return;
            case 'LprPhone03View':  
                this.srchDoSlctRwLprPhone03View();
                return;
            case 'LprPhone04View':  
                this.srchDoSlctRwLprPhone04View();
                return;
        }
        let flt: IPhbkPhoneViewFilter|any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
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
        let mc: Observable<IPhbkPhoneViewPage> | any;
        switch (this.curIndexMenuItemsData.id) {


            case 'scannByPrimary':  
                mc = this.frmRootSrv.getmanybyrepprim(flt);
                break;
            default:
                mc = this.frmRootSrv.getwithfilter(flt);
        }
        mc.subscribe({
                next: (v: IPhbkPhoneViewPage) =>{
                    this.inQuery = false;
                    let pl: number = 0;
                    if (!(typeof v.total === 'undefined')) {
                        if(!(v.total === null)) {
                            pl = v.total;
                        }
                    }
                    this.matPaginatorLen = pl;
                    let rslt: Array<IPhbkPhoneView> = [];
                    if (!(typeof v.items === 'undefined')) {
                        if(!(v.items === null)) {
                            rslt = v.items;
                        }
                    }
                    this.dataSource = rslt;
                    this.applyFilter.emit(this);
                    let currow: IPhbkPhoneView | null = null;
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

    onSelectRow(e: IPhbkPhoneView|any) {
        if (typeof e === 'undefined') {
            this.currentRow = null;
        } else {
            this.currentRow = e;
        }
        this.cd.detectChanges();
        this.selectedRow.emit(this.currentRow);
    }
    rowCommand(e: IPhbkPhoneView, id: string) {
        let v: IEventEmitterData = {
            id: id,
            sender: this,
            value: e
        };
        this.onRowCommand.emit(v);
    }
    tableCommand(id: string) {
        if(
           (id === 'LprPhone01View') ||
           (id === 'LprPhone02View') ||
           (id === 'LprPhone03View') ||
           (id === 'LprPhone04View') ||
           (id === 'scannByPrimary') ||
           (id === 'fullscann'))
        {
            let mi: IMenuItemData|any = this.tableIndexMenuItemsData.find((e: IMenuItemData) => e.id === id);
            if(mi) {
                this.srchSlctRwLprPhone01ViewLpdPhoneView = null;
                this.srchSlctRwLprPhone02ViewLpdPhoneView = null;
                this.srchSlctRwLprPhone03ViewLpdPhoneView = null;
                this.srchSlctRwLprPhone04ViewLpdPhoneView = null;
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
            { name: 'phoneId', caption: this.clmnCptnsPhbkPhoneView['phoneId'], checked: false },
            { name: 'phone', caption: this.clmnCptnsPhbkPhoneView['phone'], checked: false },
            { name: 'pPhoneTypeName', caption: this.clmnCptnsPhbkPhoneView['pPhoneTypeName'], checked: false },
            { name: 'eEmpLastName', caption: this.clmnCptnsPhbkPhoneView['eEmpLastName'], checked: false },
            { name: 'eEmpFirstName', caption: this.clmnCptnsPhbkPhoneView['eEmpFirstName'], checked: false },
            { name: 'eDDivisionName', caption: this.clmnCptnsPhbkPhoneView['eDDivisionName'], checked: false },
            { name: 'eDEEntrprsName', caption: this.clmnCptnsPhbkPhoneView['eDEEntrprsName'], checked: false },
            { name: 'eEmpSecondName', caption: this.clmnCptnsPhbkPhoneView['eEmpSecondName'], checked: false },
            { name: 'phoneTypeIdRef', caption: this.clmnCptnsPhbkPhoneView['phoneTypeIdRef'], checked: false },
            { name: 'employeeIdRef', caption: this.clmnCptnsPhbkPhoneView['employeeIdRef'], checked: false },
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
    srchSlctRwLprPhone01ViewLpdPhoneView: ILpdPhoneView | any = null;
    
    srchDoSlctRwLprPhone01View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprPhone01ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprPhone01ViewLpdPhoneView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprPhone01View.getHiddenFilterAsFltRslt(this.frmSrvLpdPhoneView.getHiddenFilterByRow(this.srchSlctRwLprPhone01ViewLpdPhoneView, 'PhoneDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkPhoneViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprPhone01View and PhbkPhoneView
        for (let fld in this.reqHiddenProps['LprPhone01View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprPhone01View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprPhone01View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone01View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprPhone01View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprPhone01ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprPhone01View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprPhone01View.getm2cKeyfm()['PhbkPhoneView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Phone'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkPhoneViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprPhone01View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkPhoneViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkPhoneView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkPhoneView | null = null;
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

    afterObjSelLprPhone01View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprPhone01ViewLpdPhoneView = e.v;
                break;
        }
    }
    tpAheadValLprPhone01View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.phone;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprPhone01View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdPhoneViewFilter | any = { page: 0, pagesize: 15 };
          fltr.phone = [value]; 
          fltr.phoneOprtr = ['lk']
          return srv.getmanybyrepunqLpdPhoneUK(fltr)
            .pipe(
                switchMap((rslt: ILpdPhoneViewPage) => {
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
    tpAheadCptnLprPhone01View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.phone === 'undefined')) {
                if(!(v.phone === null)) {
                    retStr = retStr + v.phone;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////
/////////////////////////////////////////
    srchSlctRwLprPhone02ViewLpdPhoneView: ILpdPhoneView | any = null;
    
    srchDoSlctRwLprPhone02View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprPhone02ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprPhone02ViewLpdPhoneView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprPhone02View.getHiddenFilterAsFltRslt(this.frmSrvLpdPhoneView.getHiddenFilterByRow(this.srchSlctRwLprPhone02ViewLpdPhoneView, 'PhoneDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkPhoneViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprPhone02View and PhbkPhoneView
        for (let fld in this.reqHiddenProps['LprPhone02View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprPhone02View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprPhone02View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone02View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprPhone02View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprPhone02ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprPhone02View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprPhone02View.getm2cKeyfm()['PhbkPhoneView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Phone'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkPhoneViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprPhone02View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkPhoneViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkPhoneView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkPhoneView | null = null;
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

    afterObjSelLprPhone02View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprPhone02ViewLpdPhoneView = e.v;
                break;
        }
    }
    tpAheadValLprPhone02View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.phone;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprPhone02View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdPhoneViewFilter | any = { page: 0, pagesize: 15 };
          fltr.phone = [value]; 
          fltr.phoneOprtr = ['lk']
          return srv.getmanybyrepunqLpdPhoneUK(fltr)
            .pipe(
                switchMap((rslt: ILpdPhoneViewPage) => {
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
    tpAheadCptnLprPhone02View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.phone === 'undefined')) {
                if(!(v.phone === null)) {
                    retStr = retStr + v.phone;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////
/////////////////////////////////////////
    srchSlctRwLprPhone03ViewLpdPhoneView: ILpdPhoneView | any = null;
    
    srchDoSlctRwLprPhone03View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprPhone03ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprPhone03ViewLpdPhoneView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprPhone03View.getHiddenFilterAsFltRslt(this.frmSrvLpdPhoneView.getHiddenFilterByRow(this.srchSlctRwLprPhone03ViewLpdPhoneView, 'PhoneDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkPhoneViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprPhone03View and PhbkPhoneView
        for (let fld in this.reqHiddenProps['LprPhone03View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprPhone03View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprPhone03View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone03View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprPhone03View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprPhone03ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprPhone03View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprPhone03View.getm2cKeyfm()['PhbkPhoneView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Phone'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkPhoneViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprPhone03View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkPhoneViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkPhoneView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkPhoneView | null = null;
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

    afterObjSelLprPhone03View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprPhone03ViewLpdPhoneView = e.v;
                break;
        }
    }
    tpAheadValLprPhone03View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.phone;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprPhone03View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdPhoneViewFilter | any = { page: 0, pagesize: 15 };
          fltr.phone = [value]; 
          fltr.phoneOprtr = ['lk']
          return srv.getmanybyrepunqLpdPhoneUK(fltr)
            .pipe(
                switchMap((rslt: ILpdPhoneViewPage) => {
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
    tpAheadCptnLprPhone03View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.phone === 'undefined')) {
                if(!(v.phone === null)) {
                    retStr = retStr + v.phone;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////
/////////////////////////////////////////
    srchSlctRwLprPhone04ViewLpdPhoneView: ILpdPhoneView | any = null;
    
    srchDoSlctRwLprPhone04View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprPhone04ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprPhone04ViewLpdPhoneView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprPhone04View.getHiddenFilterAsFltRslt(this.frmSrvLpdPhoneView.getHiddenFilterByRow(this.srchSlctRwLprPhone04ViewLpdPhoneView, 'PhoneDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkPhoneViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprPhone04View and PhbkPhoneView
        for (let fld in this.reqHiddenProps['LprPhone04View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprPhone04View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprPhone04View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprPhone04View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprPhone04View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprPhone04ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprPhone04View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprPhone04View.getm2cKeyfm()['PhbkPhoneView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Phone'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkPhoneViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprPhone04View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkPhoneViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkPhoneView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkPhoneView | null = null;
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

    afterObjSelLprPhone04View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprPhone04ViewLpdPhoneView = e.v;
                break;
        }
    }
    tpAheadValLprPhone04View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.phone;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprPhone04View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdPhoneViewFilter | any = { page: 0, pagesize: 15 };
          fltr.phone = [value]; 
          fltr.phoneOprtr = ['lk']
          return srv.getmanybyrepunqLpdPhoneUK(fltr)
            .pipe(
                switchMap((rslt: ILpdPhoneViewPage) => {
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
    tpAheadCptnLprPhone04View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.phone === 'undefined')) {
                if(!(v.phone === null)) {
                    retStr = retStr + v.phone;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////




/////////////////////////////////////////

    srchSlctRwPrimary: IPhbkPhoneView | any = null;
    afterObjSelPrimary(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        if(e.v) {
            this.srchSlctRwPrimary = e.v as IPhbkPhoneView;
        } else {
            this.srchSlctRwPrimary = null;
        }
    }

    tpAheadValPrimary(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                 return v.phoneId;
            }
        } 
        return null;
    }
    tpAheadFncPrimary(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
        let fltr: IPhbkPhoneViewFilter | any = { page: 0, pagesize: 15 };
        if(i > 0) { 
            fltr.phoneId = [wsfd[0].fltrValue.value]; 
            fltr.phoneIdOprtr = ['eq']
         } else if(i === 0) { 
            fltr.phoneId = [value]; 
            fltr.phoneIdOprtr = ['lk']
         }
        return srv.getmanybyrepprim(fltr)
            .pipe(
                switchMap((rslt: IPhbkPhoneViewPage) => {
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
            if (!(typeof v.phoneId === 'undefined')) {
                if(!(v.phoneId === null)) {
                    retStr = retStr + ' ' + v.phoneId;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////

}


