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


import { IPhbkEmployeeView } from 'phonebook-interfaces';
import { IPhbkEmployeeViewPage } from 'phonebook-interfaces';
import { IPhbkEmployeeViewFilter } from 'phonebook-interfaces';
import { PhbkEmployeeViewService } from 'phonebook-services';
import { LpdEmpLastNameViewService } from 'phonebook-services';
import { ILpdEmpLastNameView } from 'phonebook-interfaces';
import { ILpdEmpLastNameViewPage } from 'phonebook-interfaces';
import { ILpdEmpLastNameViewFilter } from 'phonebook-interfaces';
import { LpdEmpFirstNameViewService } from 'phonebook-services';
import { ILpdEmpFirstNameView } from 'phonebook-interfaces';
import { ILpdEmpFirstNameViewPage } from 'phonebook-interfaces';
import { ILpdEmpFirstNameViewFilter } from 'phonebook-interfaces';
import { LpdEmpSecondNameViewService } from 'phonebook-services';
import { ILpdEmpSecondNameView } from 'phonebook-interfaces';
import { ILpdEmpSecondNameViewPage } from 'phonebook-interfaces';
import { ILpdEmpSecondNameViewFilter } from 'phonebook-interfaces';
import { LprEmployee01ViewService } from 'phonebook-services';
import { ILprEmployee01View } from 'phonebook-interfaces';
import { ILprEmployee01ViewPage } from 'phonebook-interfaces';
import { ILprEmployee01ViewFilter } from 'phonebook-interfaces';
import { LprEmployee02ViewService } from 'phonebook-services';
import { ILprEmployee02View } from 'phonebook-interfaces';
import { ILprEmployee02ViewPage } from 'phonebook-interfaces';
import { ILprEmployee02ViewFilter } from 'phonebook-interfaces';


// begin: internationalization of the mat-paginator
/*
class PhbkEmployeeViewMtPgntrIntl implements MatPaginatorIntl {
    changes = new Subject<void>();
    firstPageLabel = $localize`First page@@PhbkEmployeeViewSformComponent.firstPageLabel:First page`;
    itemsPerPageLabel = $localize`Items per page@@PhbkEmployeeViewSformComponent.itemsPerPageLabel:Items per page`;
    lastPageLabel = $localize`Last page@@PhbkEmployeeViewSformComponent.lastPageLabel:Last page`;
    nextPageLabel = $localize`Next page@@PhbkEmployeeViewSformComponent.nextPageLabel:Next page`;
    previousPageLabel = $localize`Previous page@@PhbkEmployeeViewSformComponent.previousPageLabel:Previous page`;
    ofLabel = $localize`of@@PhbkEmployeeViewSformComponent.ofLabel:of`;
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
  selector: 'app-phbk-employee-view-sform',
  templateUrl: './phbk-employee-view-sform.component.html',
  styleUrls: ['./phbk-employee-view-sform.component.css'],
//  providers: [{ provide: MatPaginatorIntl, useClass: PhbkEmployeeViewMtPgntrIntl }]
})
export class PhbkEmployeeViewSformComponent implements OnInit, AfterViewInit,  IEventEmitterPub, IItemHeightData {

    @Input('caption') caption: string = $localize`:Employees@@PhbkEmployeeViewSformComponent.caption:Employees`;


    clmnCptnsPhbkEmployeeView: {[key:string]: string}  = {
        'employeeId': $localize`:Id of the Employee@@PhbkEmployeeView.employeeId-Name:Id of the Employee`,
        'empFirstName': $localize`:Employee First Name@@PhbkEmployeeView.empFirstName-Name:Employee First Name`,
        'empLastName': $localize`:Employee Last Name@@PhbkEmployeeView.empLastName-Name:Employee Last Name`,
        'empSecondName': $localize`:Employee Second Name@@PhbkEmployeeView.empSecondName-Name:Employee Second Name`,
        'divisionIdRef': $localize`:Id of the Division@@PhbkEmployeeView.divisionIdRef-Name:Id of the Division`,
        'dDivisionName': $localize`:Name of the Division@@PhbkEmployeeView.dDivisionName-Name:Name of the Division`,
        'dEEntrprsName': $localize`:Name of the Enterprise@@PhbkEmployeeView.dEEntrprsName-Name:Name of the Enterprise`,
    };

    clmnCptnsLpdEmpLastNameView: {[key:string]: string}  = {
        'empLastName': $localize`:Employee Last Name@@PhbkEmployeeViewSformComponent.LpdEmpLastNameView-empLastName-Name:Employee Last Name`,
    };
    clmnCptnsLpdEmpFirstNameView: {[key:string]: string}  = {
        'empFirstName': $localize`:Employee First Name@@PhbkEmployeeViewSformComponent.LpdEmpFirstNameView-empFirstName-Name:Employee First Name`,
    };
    clmnCptnsLpdEmpSecondNameView: {[key:string]: string}  = {
        'empSecondName': $localize`:Employee Second Name@@PhbkEmployeeViewSformComponent.LpdEmpSecondNameView-empSecondName-Name:Employee Second Name`,
    };

    menuCptns: {[key:string]: string}  = {
        'fullscann': $localize`:full scan@@PhbkEmployeeViewSformComponent.fullscann-menu:full scan`,
        'scannByPrimary': $localize`:filter by Primary@@PhbkEmployeeViewSformComponent.scannByPrimary-menu:filter by Primary`,
        'LprEmployee01View': $localize`:filter by Employee Dict Ref@@PhbkEmployeeViewSformComponent.LprEmployee01View-menu:filter by Employee Dict Ref`,
        'LprEmployee02View': $localize`:filter by Employee Dict Ref@@PhbkEmployeeViewSformComponent.LprEmployee02View-menu:filter by Employee Dict Ref`,
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


    public currentMultiRow: Array<IPhbkEmployeeView> = [];
    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IPhbkEmployeeView>> = new EventEmitter<Array<IPhbkEmployeeView>>();
    public multSelection: SelectionModel<IPhbkEmployeeView> = new SelectionModel<IPhbkEmployeeView>(true, []);
    selectRows(e: Array<IPhbkEmployeeView>) {
        if((typeof e === 'undefined') || (typeof this.dataSource  === 'undefined')) return;
        if((e === null) || (this.dataSource  === null)) return;
        if(!Array.isArray(e)) return;
        let rslt: Array<IPhbkEmployeeView>=[];
        e.forEach(row => { if(this.dataSource.indexOf(row) > -1) rslt.push(row) });
        this.multSelection.select(...rslt);
    }
    deselectRows(e: Array<IPhbkEmployeeView>) {
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
    onMultiSelectRow(e: Array<IPhbkEmployeeView>) {
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
            (e: SelectionChange<IPhbkEmployeeView>) => {
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
    public dataSource: Array<IPhbkEmployeeView> = [];
    matPaginatorLen: number = 0;
    matPaginatorPageSize: number = 10;
    matPaginatorPageSizeOptions: Array<number> = [10, 25, 50, 100];
    displayedColumns:  Array<string> = ['selectAction', 'selectMultAction', 'employeeId', 'empFirstName', 'empLastName', 'empSecondName', 'dDivisionName', 'menuAction'];
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
        doIns = crrMDFP.length === this.reqHiddenProps['LprEmployee01View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprEmployee01View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprEmployee01View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprEmployee01View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprEmployee01View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprEmployee01View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprEmployee01View', caption: this.menuCptns['LprEmployee01View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'empLastName', fltrCaption: this.clmnCptnsLpdEmpLastNameView['empLastName'], fltrDataType: 'string', fltrMaxLen: 40, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 3) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdEmpLastNameView},
              {fltrName: 'empFirstName', fltrCaption: this.clmnCptnsLpdEmpFirstNameView['empFirstName'], fltrDataType: 'string', fltrMaxLen: 25, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 3) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdEmpFirstNameView},
              {fltrName: 'empSecondName', fltrCaption: this.clmnCptnsLpdEmpSecondNameView['empSecondName'], fltrDataType: 'string', fltrMaxLen: 25, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 3) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdEmpSecondNameView},
        ]})};
        doIns = crrMDFP.length === this.reqHiddenProps['LprEmployee02View'].length;
        if(doIns) {
            doIns = (this.reqHiddenProps['LprEmployee02View'].filter(s => crrMDFP.includes(s))).length === crrMDFP.length;
            if(doIns) {
                if(hasNtExternal) {
                    for (let fld in this.extHiddenProps['LprEmployee02View']) { 
                        doIns = this.hiddenFilterEx.some((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprEmployee02View'][fld]});
                        if(!doIns) break;
                    }
                } else {
                    doIns = extHiddflt.length === this.extHiddenProps['LprEmployee02View'].length;
                    if(doIns) doIns = extHiddflt.filter(s => this.extHiddenProps['LprEmployee02View'].includes(s)).length === extHiddflt.length;
                }
            }
        }
        if(doIns) { rslt.push(
            {id: 'LprEmployee02View', caption: this.menuCptns['LprEmployee02View'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'empLastName', fltrCaption: this.clmnCptnsLpdEmpLastNameView['empLastName'], fltrDataType: 'string', fltrMaxLen: 40, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 3) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdEmpLastNameView},
              {fltrName: 'empFirstName', fltrCaption: this.clmnCptnsLpdEmpFirstNameView['empFirstName'], fltrDataType: 'string', fltrMaxLen: 25, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 3) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdEmpFirstNameView},
              {fltrName: 'empSecondName', fltrCaption: this.clmnCptnsLpdEmpSecondNameView['empSecondName'], fltrDataType: 'string', fltrMaxLen: 25, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 3) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmSrvLpdEmpSecondNameView},
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
                  {fltrName: 'employeeId', fltrCaption: this.clmnCptnsPhbkEmployeeView['employeeId'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd: (100 / 1) - 1, fltrSm: (100 / 1) - 1, fltrXs: 100, fltrSrv: this.frmRootSrv},
                ]});
              }
            }
        }
        if(hasNtExternal && this.cnFllscn) {
          rslt.push(
            {id: 'fullscann', caption: this.menuCptns['fullscann'], iconName: 'search', iconColor: 'primary', enabled: true, data: [
              {fltrName: 'employeeId', fltrCaption: this.clmnCptnsPhbkEmployeeView['employeeId'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'empFirstName', fltrCaption: this.clmnCptnsPhbkEmployeeView['empFirstName'], fltrDataType: 'string', fltrMaxLen: 25, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'empLastName', fltrCaption: this.clmnCptnsPhbkEmployeeView['empLastName'], fltrDataType: 'string', fltrMaxLen: 40, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
              {fltrName: 'divisionIdRef', fltrCaption: this.clmnCptnsPhbkEmployeeView['divisionIdRef'], fltrDataType: 'int32', fltrMaxLen: null, fltrMin: null, fltrMax: null, fltrFlx:100, fltrMd:24, fltrSm:49, fltrXs: 100, fltrSrv: this.frmRootSrv },
          ]});
        }
      return rslt;
    }
    mdlDrctFkProps: Array<string> = [ 'divisionIdRef'];
    mdlMptProps: Array<string> = [ 'employeeId', 'empFirstName', 'empLastName', 'divisionIdRef'];
    reqHiddenProps: {[key: string]: Array<string>} = {
                    'LprEmployee01View': [],
                    'LprEmployee02View': [ 'divisionIdRef'],
    };
    extHiddenProps: {[key: string]: Array<string>} = {
                    'LprEmployee01View': [],
                    'LprEmployee02View': [],
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
            this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView = null;
            this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView = null;
            this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView = null;
            this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView = null;
            this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView = null;
            this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView = null;

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
            case 'LprEmployee01View':  
                if(ef.f['LpdEmpLastNameView']) {
                    this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView = JSON.parse(ef.f['LpdEmpLastNameView']);
                    if(this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView) {
                        if(!(typeof this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdEmpLastNameView.row2FilterRslt(this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView));
                        }
                    }
                }
                if(ef.f['LpdEmpFirstNameView']) {
                    this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView = JSON.parse(ef.f['LpdEmpFirstNameView']);
                    if(this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView) {
                        if(!(typeof this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdEmpFirstNameView.row2FilterRslt(this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView));
                        }
                    }
                }
                if(ef.f['LpdEmpSecondNameView']) {
                    this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView = JSON.parse(ef.f['LpdEmpSecondNameView']);
                    if(this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView) {
                        if(!(typeof this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdEmpSecondNameView.row2FilterRslt(this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView));
                        }
                    }
                }
                break;           
            case 'LprEmployee02View':  
                if(ef.f['LpdEmpLastNameView']) {
                    this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView = JSON.parse(ef.f['LpdEmpLastNameView']);
                    if(this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView) {
                        if(!(typeof this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdEmpLastNameView.row2FilterRslt(this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView));
                        }
                    }
                }
                if(ef.f['LpdEmpFirstNameView']) {
                    this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView = JSON.parse(ef.f['LpdEmpFirstNameView']);
                    if(this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView) {
                        if(!(typeof this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdEmpFirstNameView.row2FilterRslt(this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView));
                        }
                    }
                }
                if(ef.f['LpdEmpSecondNameView']) {
                    this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView = JSON.parse(ef.f['LpdEmpSecondNameView']);
                    if(this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView) {
                        if(!(typeof this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView === 'undefined')) {
                            r = r.concat(this.frmSrvLpdEmpSecondNameView.row2FilterRslt(this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView));
                        }
                    }
                }
                break;           
            default:
                let flt: IPhbkEmployeeViewFilter|any = JSON.parse(ef.f['data']);
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

    public currentRow: IPhbkEmployeeView | null = null;
    @Output('selected-row') selectedRow: EventEmitter<IPhbkEmployeeView|null> = new EventEmitter<IPhbkEmployeeView|null>();
    @Output('apply-filter') applyFilter: EventEmitter<PhbkEmployeeViewSformComponent|null> = new EventEmitter<PhbkEmployeeViewSformComponent|null>();

    cnFllscn: boolean = false;
    constructor(public  frmRootSrv: PhbkEmployeeViewService, public appGlblSettings: AppGlblSettingsService, 
                public  frmSrvLprEmployee01View: LprEmployee01ViewService,
                public  frmSrvLpdEmpLastNameView: LpdEmpLastNameViewService,
                public  frmSrvLpdEmpFirstNameView: LpdEmpFirstNameViewService,
                public  frmSrvLpdEmpSecondNameView: LpdEmpSecondNameViewService,
                public  frmSrvLprEmployee02View: LprEmployee02ViewService,
    
            protected dialog: MatDialog, private cd: ChangeDetectorRef) {
            this.cnFllscn = (appGlblSettings.getViewModelMask('PhbkEmployeeView') & 16) === 16;
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
    
    onBeforeSquery(flt: IPhbkEmployeeViewFilter|any) {
        if(typeof this.curIndexMenuItemsData === 'undefined') return;
        if(this.curIndexMenuItemsData === null) return;
        let r: {id: string; f: {[key: string]: string}|any; csc: string; pgi: number; pgsz: number} = {id: this.curIndexMenuItemsData.id, f: undefined, csc:this.currentSortColumn, pgi: this.currentPageIndex, pgsz: this.currentPageSize};
        let kyvl: {[key: string]: string} = {};
        switch (r.id) {
            case 'LprEmployee01View':  
                if(this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView) {
                    kyvl['LpdEmpLastNameView'] = JSON.stringify(this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView);
                }
                if(this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView) {
                    kyvl['LpdEmpFirstNameView'] = JSON.stringify(this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView);
                }
                if(this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView) {
                    kyvl['LpdEmpSecondNameView'] = JSON.stringify(this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView);
                }
                r.f = kyvl;
                break;           
            case 'LprEmployee02View':  
                if(this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView) {
                    kyvl['LpdEmpLastNameView'] = JSON.stringify(this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView);
                }
                if(this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView) {
                    kyvl['LpdEmpFirstNameView'] = JSON.stringify(this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView);
                }
                if(this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView) {
                    kyvl['LpdEmpSecondNameView'] = JSON.stringify(this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView);
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
            case 'LprEmployee01View':  
                this.srchDoSlctRwLprEmployee01View();
                return;
            case 'LprEmployee02View':  
                this.srchDoSlctRwLprEmployee02View();
                return;
        }
        let flt: IPhbkEmployeeViewFilter|any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
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
        let mc: Observable<IPhbkEmployeeViewPage> | any;
        switch (this.curIndexMenuItemsData.id) {


            case 'scannByPrimary':  
                mc = this.frmRootSrv.getmanybyrepprim(flt);
                break;
            default:
                mc = this.frmRootSrv.getwithfilter(flt);
        }
        mc.subscribe({
                next: (v: IPhbkEmployeeViewPage) =>{
                    this.inQuery = false;
                    let pl: number = 0;
                    if (!(typeof v.total === 'undefined')) {
                        if(!(v.total === null)) {
                            pl = v.total;
                        }
                    }
                    this.matPaginatorLen = pl;
                    let rslt: Array<IPhbkEmployeeView> = [];
                    if (!(typeof v.items === 'undefined')) {
                        if(!(v.items === null)) {
                            rslt = v.items;
                        }
                    }
                    this.dataSource = rslt;
                    this.applyFilter.emit(this);
                    let currow: IPhbkEmployeeView | null = null;
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

    onSelectRow(e: IPhbkEmployeeView|any) {
        if (typeof e === 'undefined') {
            this.currentRow = null;
        } else {
            this.currentRow = e;
        }
        this.cd.detectChanges();
        this.selectedRow.emit(this.currentRow);
    }
    rowCommand(e: IPhbkEmployeeView, id: string) {
        let v: IEventEmitterData = {
            id: id,
            sender: this,
            value: e
        };
        this.onRowCommand.emit(v);
    }
    tableCommand(id: string) {
        if(
           (id === 'LprEmployee01View') ||
           (id === 'LprEmployee02View') ||
           (id === 'scannByPrimary') ||
           (id === 'fullscann'))
        {
            let mi: IMenuItemData|any = this.tableIndexMenuItemsData.find((e: IMenuItemData) => e.id === id);
            if(mi) {
                this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView = null;
                this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView = null;
                this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView = null;
                this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView = null;
                this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView = null;
                this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView = null;
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
            { name: 'employeeId', caption: this.clmnCptnsPhbkEmployeeView['employeeId'], checked: false },
            { name: 'empFirstName', caption: this.clmnCptnsPhbkEmployeeView['empFirstName'], checked: false },
            { name: 'empLastName', caption: this.clmnCptnsPhbkEmployeeView['empLastName'], checked: false },
            { name: 'empSecondName', caption: this.clmnCptnsPhbkEmployeeView['empSecondName'], checked: false },
            { name: 'dDivisionName', caption: this.clmnCptnsPhbkEmployeeView['dDivisionName'], checked: false },
            { name: 'dEEntrprsName', caption: this.clmnCptnsPhbkEmployeeView['dEEntrprsName'], checked: false },
            { name: 'divisionIdRef', caption: this.clmnCptnsPhbkEmployeeView['divisionIdRef'], checked: false },
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
    srchSlctRwLprEmployee01ViewLpdEmpLastNameView: ILpdEmpLastNameView | any = null;
    
    srchSlctRwLprEmployee01ViewLpdEmpFirstNameView: ILpdEmpFirstNameView | any = null;
    
    srchSlctRwLprEmployee01ViewLpdEmpSecondNameView: ILpdEmpSecondNameView | any = null;
    
    srchDoSlctRwLprEmployee01View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprEmployee01ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprEmployee01View.getHiddenFilterAsFltRslt(this.frmSrvLpdEmpLastNameView.getHiddenFilterByRow(this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView, 'EmpLastNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(isFltSet) {
            if (this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprEmployee01View.getHiddenFilterAsFltRslt(this.frmSrvLpdEmpFirstNameView.getHiddenFilterByRow(this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView, 'EmpFirstNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(isFltSet) {
            if (this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprEmployee01View.getHiddenFilterAsFltRslt(this.frmSrvLpdEmpSecondNameView.getHiddenFilterByRow(this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView, 'EmpSecondNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkEmployeeViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprEmployee01View and PhbkEmployeeView
        for (let fld in this.reqHiddenProps['LprEmployee01View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprEmployee01View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprEmployee01View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprEmployee01View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprEmployee01View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprEmployee01ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprEmployee01View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprEmployee01View.getm2cKeyfm()['PhbkEmployeeView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Employee'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkEmployeeViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprEmployee01View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkEmployeeViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkEmployeeView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkEmployeeView | null = null;
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

    afterObjSelLprEmployee01View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprEmployee01ViewLpdEmpLastNameView = e.v;
                break;
            case 1:
                this.srchSlctRwLprEmployee01ViewLpdEmpFirstNameView = e.v;
                break;
            case 2:
                this.srchSlctRwLprEmployee01ViewLpdEmpSecondNameView = e.v;
                break;
        }
    }
    tpAheadValLprEmployee01View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.empLastName;
                    break;
                case 1: 
                    return v.empFirstName;
                    break;
                case 2: 
                    return v.empSecondName;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprEmployee01View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdEmpLastNameViewFilter | any = { page: 0, pagesize: 15 };
          fltr.empLastName = [value]; 
          fltr.empLastNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdEmpLastNameUK(fltr)
            .pipe(
                switchMap((rslt: ILpdEmpLastNameViewPage) => {
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
        case 1: {
          let fltr: ILpdEmpFirstNameViewFilter | any = { page: 0, pagesize: 15 };
          fltr.empFirstName = [value]; 
          fltr.empFirstNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdEmpFirstNameUK(fltr)
            .pipe(
                switchMap((rslt: ILpdEmpFirstNameViewPage) => {
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
        case 2: {
          let fltr: ILpdEmpSecondNameViewFilter | any = { page: 0, pagesize: 15 };
          fltr.empSecondName = [value]; 
          fltr.empSecondNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdEmpSecondNameUK(fltr)
            .pipe(
                switchMap((rslt: ILpdEmpSecondNameViewPage) => {
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
    tpAheadCptnLprEmployee01View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.empLastName === 'undefined')) {
                if(!(v.empLastName === null)) {
                    retStr = retStr + v.empLastName;
                }
            }
            if (!(typeof v.empFirstName === 'undefined')) {
                if(!(v.empFirstName === null)) {
                    retStr = retStr + v.empFirstName;
                }
            }
            if (!(typeof v.empSecondName === 'undefined')) {
                if(!(v.empSecondName === null)) {
                    retStr = retStr + v.empSecondName;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////
/////////////////////////////////////////
    srchSlctRwLprEmployee02ViewLpdEmpLastNameView: ILpdEmpLastNameView | any = null;
    
    srchSlctRwLprEmployee02ViewLpdEmpFirstNameView: ILpdEmpFirstNameView | any = null;
    
    srchSlctRwLprEmployee02ViewLpdEmpSecondNameView: ILpdEmpSecondNameView | any = null;
    
    srchDoSlctRwLprEmployee02View() {
        if(!this.isOnInitCalled) return;
        let dtlflt: ILprEmployee02ViewFilter | any = { page: this.currentPageIndex, pagesize: this.currentPageSize };
        let isFltSet: boolean = true;
        if(isFltSet) {
            if (this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprEmployee02View.getHiddenFilterAsFltRslt(this.frmSrvLpdEmpLastNameView.getHiddenFilterByRow(this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView, 'EmpLastNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(isFltSet) {
            if (this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprEmployee02View.getHiddenFilterAsFltRslt(this.frmSrvLpdEmpFirstNameView.getHiddenFilterByRow(this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView, 'EmpFirstNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(isFltSet) {
            if (this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView) {
                let dfltrslt: Array<IWebServiceFilterRslt> = 
                    this.frmSrvLprEmployee02View.getHiddenFilterAsFltRslt(this.frmSrvLpdEmpSecondNameView.getHiddenFilterByRow(this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView, 'EmpSecondNameDict'));
                if (Array.isArray(dfltrslt)) {
                    dfltrslt.forEach(e => { if(typeof dtlflt[e.fltrName] === 'undefined') { dtlflt[e.fltrName] = []; } dtlflt[e.fltrName].push(e.fltrValue); });
                } else { isFltSet = false; }
            } else { isFltSet = false; }
        }
        if(!isFltSet) {
            this.appGlblSettings.showError('http', {message: $localize`:Could not apply filter as not all attributes are set@@PhbkEmployeeViewSformComponent.filter-msg:Could not apply filter as not all attributes are set` });
        }
        // by requirements all common foreignkey props have the same names for LprEmployee02View and PhbkEmployeeView
        for (let fld in this.reqHiddenProps['LprEmployee02View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.reqHiddenProps['LprEmployee02View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        for (let fld in this.extHiddenProps['LprEmployee02View']) { 
            let hf: IWebServiceFilterRslt|any = this.hiddenFilterEx.find((f: IWebServiceFilterRslt) => { return f.fltrName === this.extHiddenProps['LprEmployee02View'][fld]});
            if(hf) {
                if(typeof dtlflt[hf.fltrName] === 'undefined') {
                    dtlflt[hf.fltrName] = [];
                }
                dtlflt[hf.fltrName].push(hf.fltrValue);
            }
        }
        
        this.inQuery = true;
        this.onBeforeSquery(null);
        this.frmSrvLprEmployee02View.getmanybyrepprim(dtlflt).subscribe({
            next: (vd: ILprEmployee02ViewPage) => {
                let pl: number = 0;
                if (!(typeof vd.total === 'undefined')) {
                    if(!(vd.total === null)) {
                        pl = vd.total;
                    }
                }
                this.matPaginatorLen = pl;
                let rsltd: Array<ILprEmployee02View> = [];
                if (!(typeof vd.items === 'undefined')) {
                    if(!(vd.items === null)) {
                        rsltd = vd.items;
                    }
                }
                if(rsltd.length < 1) {
                    this.clrDs();
                    return;
                }
                let mp1: {[key: string]: {[key: string]: {isMstrReq: boolean ,propNm:string}}} = this.frmSrvLprEmployee02View.getm2cKeyfm()['PhbkEmployeeView'];
                if(typeof mp1 === 'undefined') {
                    this.clrDs();
                    return;
                }
                let mp2: {[key: string]: {isMstrReq: boolean ,propNm:string}} = mp1['Employee'];
                if(typeof mp2 === 'undefined') {
                    this.clrDs();
                    return;
                }
                // it must be this.currentPageIndex == 0
                let flt: IPhbkEmployeeViewFilter|any = { page: 0, pagesize: this.currentPageSize };
                rsltd.forEach((src: ILprEmployee02View | any) => {
                    for(let i in mp2) {
                        if(typeof flt[i] === 'undefined') {
                            flt[i] = [];
                        }
                        flt[i].push(src[mp2[i].propNm]);
                    }
                });
                this.frmRootSrv.getmanybyrepprim(flt).subscribe({
                    next: (v: IPhbkEmployeeViewPage) =>{
                        this.inQuery = false;
                        let rslt: Array<IPhbkEmployeeView> = [];
                        if (!(typeof v.items === 'undefined')) {
                            if(!(v.items === null)) {
                                rslt = v.items;
                            }
                        }
                        this.dataSource = rslt;
                        this.applyFilter.emit(this);
                        let currow: IPhbkEmployeeView | null = null;
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

    afterObjSelLprEmployee02View(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        switch(e.i) {
            case 0:
                this.srchSlctRwLprEmployee02ViewLpdEmpLastNameView = e.v;
                break;
            case 1:
                this.srchSlctRwLprEmployee02ViewLpdEmpFirstNameView = e.v;
                break;
            case 2:
                this.srchSlctRwLprEmployee02ViewLpdEmpSecondNameView = e.v;
                break;
        }
    }
    tpAheadValLprEmployee02View(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                    return v.empLastName;
                    break;
                case 1: 
                    return v.empFirstName;
                    break;
                case 2: 
                    return v.empSecondName;
                    break;
            }
        }
        return null;
    }
    tpAheadFncLprEmployee02View(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
      switch(i) {
        case 0: {
          let fltr: ILpdEmpLastNameViewFilter | any = { page: 0, pagesize: 15 };
          fltr.empLastName = [value]; 
          fltr.empLastNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdEmpLastNameUK(fltr)
            .pipe(
                switchMap((rslt: ILpdEmpLastNameViewPage) => {
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
        case 1: {
          let fltr: ILpdEmpFirstNameViewFilter | any = { page: 0, pagesize: 15 };
          fltr.empFirstName = [value]; 
          fltr.empFirstNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdEmpFirstNameUK(fltr)
            .pipe(
                switchMap((rslt: ILpdEmpFirstNameViewPage) => {
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
        case 2: {
          let fltr: ILpdEmpSecondNameViewFilter | any = { page: 0, pagesize: 15 };
          fltr.empSecondName = [value]; 
          fltr.empSecondNameOprtr = ['lk']
          return srv.getmanybyrepunqLpdEmpSecondNameUK(fltr)
            .pipe(
                switchMap((rslt: ILpdEmpSecondNameViewPage) => {
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
    tpAheadCptnLprEmployee02View(v: any, i: number): string {
        let retStr = '';
        if(v) {
            if (!(typeof v.empLastName === 'undefined')) {
                if(!(v.empLastName === null)) {
                    retStr = retStr + v.empLastName;
                }
            }
            if (!(typeof v.empFirstName === 'undefined')) {
                if(!(v.empFirstName === null)) {
                    retStr = retStr + v.empFirstName;
                }
            }
            if (!(typeof v.empSecondName === 'undefined')) {
                if(!(v.empSecondName === null)) {
                    retStr = retStr + v.empSecondName;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////




/////////////////////////////////////////

    srchSlctRwPrimary: IPhbkEmployeeView | any = null;
    afterObjSelPrimary(e:{v: any, i: number}) {
        if(typeof e === 'undefined') return;
        if(e === null) return;
        if(e.v) {
            this.srchSlctRwPrimary = e.v as IPhbkEmployeeView;
        } else {
            this.srchSlctRwPrimary = null;
        }
    }

    tpAheadValPrimary(v: any, i: number): any {
        if(v) {
            switch(i) {
                case 0: 
                 return v.employeeId;
            }
        } 
        return null;
    }
    tpAheadFncPrimary(srv: any, wsfd: Array<IUniqServiceFilter>, value: any, i: number): Observable<Array<any>> {
        let fltr: IPhbkEmployeeViewFilter | any = { page: 0, pagesize: 15 };
        if(i > 0) { 
            fltr.employeeId = [wsfd[0].fltrValue.value]; 
            fltr.employeeIdOprtr = ['eq']
         } else if(i === 0) { 
            fltr.employeeId = [value]; 
            fltr.employeeIdOprtr = ['lk']
         }
        return srv.getmanybyrepprim(fltr)
            .pipe(
                switchMap((rslt: IPhbkEmployeeViewPage) => {
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
            if (!(typeof v.employeeId === 'undefined')) {
                if(!(v.employeeId === null)) {
                    retStr = retStr + ' ' + v.employeeId;
                }
            }
        } 
        return retStr;
    }
/////////////////////////////////////////

}


