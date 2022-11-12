import { Component, OnInit, Input, Output, EventEmitter, ViewChild, AfterViewInit, ChangeDetectorRef } from '@angular/core';
import { FormControl, Validators, ValidatorFn } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
import { firstValueFrom } from 'rxjs';

import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatRow } from '@angular/material/table';
import { ProgressBarMode } from '@angular/material/progress-bar';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';
import { IItemHeightData } from 'common-interfaces';
import { IMessageDialog } from 'common-interfaces';
import { MessageDialogComponent } from 'common-components';
import { PhbkPhoneViewSformComponent } from 'phonebook-sforms';


import { IPhbkPhoneView } from 'phonebook-interfaces';
// import { IPhbkPhoneViewPage } from 'phonebook-interfaces';
// import { IPhbkPhoneViewFilter } from 'phonebook-interfaces';
import { PhbkPhoneViewService } from 'phonebook-services';


import { IPhbkPhoneViewVdlg } from 'phonebook-updforms';
import { PhbkPhoneViewVdlgComponent } from 'phonebook-updforms';
import { IPhbkPhoneViewAdlg } from 'phonebook-updforms';
import { PhbkPhoneViewAdlgComponent } from 'phonebook-updforms';
import { IPhbkPhoneViewUdlg } from 'phonebook-updforms';
import { PhbkPhoneViewUdlgComponent } from 'phonebook-updforms';
import { IPhbkPhoneViewDdlg } from 'phonebook-updforms';
import { PhbkPhoneViewDdlgComponent } from 'phonebook-updforms';

@Component({
  selector: 'app-phbk-phone-view-lform',
  templateUrl: './phbk-phone-view-lform.component.html',
  styleUrls: ['./phbk-phone-view-lform.component.css']
})
export class PhbkPhoneViewLformComponent implements OnInit, AfterViewInit, IEventEmitterPub, IItemHeightData {
    frases: {[key:string]: string}  = {
        'caption': $localize`:Phones@@PhbkPhoneViewLformComponent.caption:Phones`,
        'update': $localize`:Modify Item@@PhbkPhoneViewLformComponent.update:Modify Item`,
        'delete': $localize`:Delete Item@@PhbkPhoneViewLformComponent.delete:Delete Item`,
        'view': $localize`:View Item@@PhbkPhoneViewLformComponent.view:View Item`,
        'add': $localize`:Add Item@@PhbkPhoneViewLformComponent.add:Add Item`,
        'deletesel': $localize`:Delete Selected@@PhbkPhoneViewLformComponent.deletesel:Delete Selected`,
        'permission': $localize`:Permission@@PhbkPhoneViewLformComponent.permission:Permission`,
        'accessdenied': $localize`:Access denied@@PhbkPhoneViewLformComponent.accessdenied:Access denied`,
    }

    @Input('show-multi-selected-row') showMultiSelectedRow: boolean = true;

    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IPhbkPhoneView>> = new EventEmitter<Array<IPhbkPhoneView>>();
    onMultiSelectedRow(e: Array<IPhbkPhoneView>): void {
        this.multiSelectedRow.emit(e);
    }

    @Input('caption') caption: string = this.frases['caption'];

    @Input('filter-max-height')  filterMaxHeight: number | any = null;
    @Input('max-height') maxHeight: number | any = null;

    @Output('on-cont-menu-item-click') onContMenuItemEmitter = new EventEmitter<IEventEmitterData>();
    @Input('cont-menu-items') contMenuItems: Array<IMenuItemData> = [];
    onContMenuItemClicked(v: IEventEmitterData)  {
        this.onContMenuItemEmitter.emit(v);
    }


    isOnInitCalled: boolean = false;
    @Input('show-filter') showFilter: boolean = true;
    @Input('show-add-flt-item') showAddFltItem: boolean = true;

    protected _rowCommands: Array<IMenuItemData> = [];
    @Input('row-commands')  
        get rowCommands():Array<IMenuItemData> {
            return this._rowCommands;
        }
        set rowCommands(v :Array<IMenuItemData>) {
            if (typeof v === 'undefined') {
                this._rowCommands = [];
            } else if (!Array.isArray(v)) {
                this._rowCommands = [];
            } else {
                this._rowCommands =  v;
            }
            if(this.isOnInitCalled) {
                this.onRowMenuItemsData();
                this.cd.detectChanges();
            }
        }

    protected _tableCommands: Array<IMenuItemData> = [];
    @Input('table-commands')  
        get tableCommands(): Array<IMenuItemData> {
            return this._tableCommands;
        }
        set tableCommands(v :Array<IMenuItemData>) {
            if (typeof v === 'undefined') {
                this._tableCommands = [];
            } else if (!Array.isArray(v)) {
                this._tableCommands = [];
            } else {
                this._tableCommands =  v;
            }
            if(this.isOnInitCalled) {
                this.onTableMenuItemsData();
                this.cd.detectChanges();
            }
        }
    

    @Input('hidden-filter') hiddenFilter: Array<IWebServiceFilterRslt>|any = [];


    public currentRow: IPhbkPhoneView | null = null;
    @Output('selected-row') selectedRow: EventEmitter<IPhbkPhoneView> = new EventEmitter<IPhbkPhoneView>();

    protected _canView: boolean = true;
    @Input('can-view') 
        get canView(): boolean|any {
            return this._canView;
        }
        set canView(v: boolean|any) {
            if(typeof v === 'undefined') return;
            if(v === null) return;
            if (v !== this._canView) {
                this._canView = v;
                if(this.isOnInitCalled) {
                    this.tableMenuItemsData[0].enabled = v;
                    this.cd.detectChanges();
                }
            }
        }

    protected _canAdd: boolean = true;
    @Input('can-add') 
        get canAdd(): boolean|any {
            return this._canAdd;
        }
        set canAdd(v: boolean|any) {
            if(typeof v === 'undefined') return;
            if(v === null) return;
            if (v !== this._canAdd) {
                this._canAdd = v;
                if(this.isOnInitCalled) {
                    this.tableMenuItemsData[0].enabled = v;
                    this.cd.detectChanges();
                }
            }
        }
    
    protected _canUpdate: boolean = true;
    @Input('can-update') 
        get canUpdate(): boolean|any {
            return this._canUpdate;
        }
        set canUpdate(v: boolean|any) {

            if(typeof v === 'undefined') return;
            if(v === null) return;
            if (v !== this._canUpdate) {
                this._canUpdate = v;
                if(this.isOnInitCalled) {
                    this.rowMenuItemsData[0].enabled = v;
                    this.cd.detectChanges();
                }
            }
        }

    protected _canDelete: boolean = true;
    @Input('can-delete') 
        get canDelete(): boolean|any {
            return this._canDelete;
        }
        set canDelete(v: boolean|any) {
            if(typeof v === 'undefined') return;
            if(v === null) return;
            if (v !== this._canDelete) {
                this._canDelete = v;
                if(this.isOnInitCalled) {
                    this.rowMenuItemsData[1].enabled = v;
                    this.cd.detectChanges();
                }
            }
        }


    rowMenuItemsData = [
          {id: 'update', caption: this.frases['update'], iconName: 'edit', iconColor: 'primary', enabled: true},
          {id: 'delete', caption: this.frases['delete'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
          {id: 'view', caption: this.frases['view'], iconName: 'preview', iconColor: 'primary', enabled: true},
        ];
    tableMenuItemsData = [
        {id: 'add', caption: this.frases['add'], iconName: 'create', iconColor: 'primary', enabled: true},
        {id: 'delete', caption: this.frases['deletesel'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
      ];

    constructor(private  frmRootSrv: PhbkPhoneViewService, protected appGlblSettings: AppGlblSettingsService, public dialog: MatDialog, private cd: ChangeDetectorRef) {
    }
    permMask: number = 0;
    ngOnInit() {
        this.permMask = this.appGlblSettings.getViewModelMask('PhbkPhoneView');
    
        this.onRowMenuItemsData();
        this.onTableMenuItemsData();
        this.isOnInitCalled = true;
    }

    onRowMenuItemsData() {
        let tmp: Array<IMenuItemData> = [
          {id: 'update', caption: this.frases['update'], iconName: 'edit', iconColor: 'primary', enabled: true },
          {id: 'delete', caption: this.frases['delete'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
          {id: 'view', caption: this.frases['view'], iconName: 'preview', iconColor: 'primary', enabled: true },
        ];
        tmp = tmp.concat(this._rowCommands);
        tmp[0].enabled = this._canUpdate && ((this.permMask & 4) === 4)  ;
        tmp[1].enabled = this._canDelete && ((this.permMask & 2) === 2) ;
        tmp[2].enabled = this._canView ;
        this.rowMenuItemsData = tmp;
    }
    onTableMenuItemsData() {
        let tmp: Array<IMenuItemData> = [
            {id: 'add', caption: this.frases['add'], iconName: 'create', iconColor: 'primary', enabled: true},
            {id: 'delete', caption: this.frases['delete'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
        ];
        tmp = tmp.concat(this._tableCommands);
        tmp[0].enabled = this._canAdd && ((this.permMask & 8) === 8) ;
        tmp[1].enabled = this._canDelete && ((this.permMask & 2) === 2) ;
        this.tableMenuItemsData = tmp;
    }
    
    ngAfterViewInit() {
    }    


    onSelectRow(e: IPhbkPhoneView|any) {
        this.selectedRow.emit(e);
    }


    onView(e: IPhbkPhoneView) {
        let locdata: IPhbkPhoneViewVdlg = {
            title: this.frases['view'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: e,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkPhoneViewVdlgComponent, {
              data: locdata,
              maxWidth: mw,
              width: w,
            });
        dialogRef.afterClosed().subscribe(rslt => {
        });
    }


    onAdd(sender: PhbkPhoneViewSformComponent) {
        let locdata: IPhbkPhoneViewAdlg = {
            title: this.frases['add'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: null,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkPhoneViewAdlgComponent, {
              data: locdata,
              maxWidth: mw,
              width: w,
            });
        dialogRef.afterClosed().subscribe(rslt => {
            if (!(typeof rslt === 'undefined')) {
                if (!(rslt === null)) {
                    if (!( typeof rslt.eformNewControlModel === 'undefined') ) {
                        if (!( rslt.eformNewControlModel === null) ) {
                            if (!Array.isArray(sender.dataSource)) {
                                sender.dataSource = [];
                            }
                            sender.dataSource.splice(0, 0, rslt.eformNewControlModel);
                            sender.dataSource = sender.dataSource.slice(0);
                            let isNDef = true;
                            if (!(typeof sender.currentRow === 'undefined')) {
                                if (!(sender.currentRow === null)) {
                                    isNDef = false;
                                }
                            }
                            if(isNDef) {
                                sender.onSelectRow(rslt.eformNewControlModel);
                            }
                        }
                    }
                }
            }
        });
    }

    onEdit(e: IPhbkPhoneView) {
        let locdata: IPhbkPhoneViewUdlg = {
            title: this.frases['update'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: e,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkPhoneViewUdlgComponent, {
              data: locdata,
              maxWidth: mw,
              width: w,
            });
        dialogRef.afterClosed().subscribe(rslt => {
            if (!(typeof rslt === 'undefined')) {
                if (!(rslt === null)) {
                    if (!((typeof rslt.eformControlModel === 'undefined') || (typeof rslt.eformNewControlModel === 'undefined'))) {
                        if (!((rslt.eformControlModel === null) || (rslt.eformNewControlModel === null))) {
                            this.frmRootSrv.src2dest(rslt.eformNewControlModel, rslt.eformControlModel);
                        }
                    }
                }
            }
        });
    }

    onDelete(e: IPhbkPhoneView , sender: PhbkPhoneViewSformComponent ) {
        let locdata: IPhbkPhoneViewDdlg = {
            title: this.frases['delete'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: e,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('PhbkPhoneView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('PhbkPhoneView');
        let dialogRef = this.dialog.open(PhbkPhoneViewDdlgComponent, {
              data: locdata,
              maxWidth: mw,
              width: w,
            });
        dialogRef.afterClosed().subscribe(rslt => {
            if (!(typeof rslt === 'undefined')) {
                if (!(rslt === null)) {
                    if (!((typeof rslt.eformControlModel === 'undefined') || (typeof rslt.eformNewControlModel === 'undefined'))) {
                        if (!((rslt.eformControlModel === null) || (rslt.eformNewControlModel === null))) {
                            if (!Array.isArray(sender.dataSource)) {
                                sender.dataSource = [];
                            }
                            let i: number = sender.dataSource.indexOf(rslt.eformControlModel);
                            if (i > -1) {
                                if (!(sender.currentRow === null)) {
                                    if (sender.currentRow === rslt.eformControlModel) {
                                        if (i > 0) {
                                            sender.onSelectRow(sender.dataSource[i-1]);
                                        } else if (i < sender.dataSource.length-1) {
                                            sender.onSelectRow(sender.dataSource[i+1]);
                                        } else {
                                            sender.onSelectRow(null);
                                        }
                                    }
                                }
                                sender.dataSource.splice(i, 1);
                                sender.dataSource = sender.dataSource.slice(0);
                            } 
                        }
                    }
                }
            }
        });
    }

    @Output('on-row-command') onRowCommand: EventEmitter<IEventEmitterData> = new EventEmitter<IEventEmitterData>();
    @Output('on-table-command') onTableCommand: EventEmitter<IEventEmitterData> = new EventEmitter<IEventEmitterData>();

    onDeleteMultiple(sender: PhbkPhoneViewSformComponent) {
        let locdata: IMessageDialog = {
            title: 'Delete Items',
            message: 'Delete Selected Items ?',
            iconname: 'warning',
            iconcolor: 'warn'
        };
        let dialogRef = this.dialog.open(MessageDialogComponent, {
              data: locdata,
            });
        dialogRef.afterClosed().subscribe(async rslt => {
            if (typeof rslt === 'undefined') return;
            if (rslt === null) return;
            let currRowsCp: Array<IPhbkPhoneView> = sender.currentMultiRow.slice();
            let deletedRows: Array<IPhbkPhoneView> = [];
            for(let row of currRowsCp) {
                try {
                    // let data: IPhbkPhoneView  =  
                    await firstValueFrom<IPhbkPhoneView>(this.frmRootSrv.deleteone(  row.phoneId ));
                    deletedRows.push(row);
                } catch (error) {
                    this.appGlblSettings.showError('http', error)
                }
            }
            sender.deselectRows(deletedRows);
            deletedRows.forEach((r: IPhbkPhoneView) => {
                let i: number = sender.dataSource.indexOf(r); 
                if(i > -1) sender.dataSource.splice(i, 1);
            });
            sender.dataSource = sender.dataSource.slice(0);
            if ((deletedRows.indexOf( sender.currentRow  as IPhbkPhoneView) > -1) && (sender.dataSource.length > 0)) sender.onSelectRow(sender.dataSource[0]);
        });
    }

    rowCommand(v: IEventEmitterData) {
        let id = this.rowMenuItemsData.findIndex(e => { return e.id === v.id; });
        if(id < 0) return;
        if (!(this.rowMenuItemsData[id].enabled)) {
            this.appGlblSettings.showError(this.frases['permission'], this.frases['accessdenied']);
            return;
        }
        if(v.id === 'update') {
            this.onEdit(v.value);
        } else if(v.id === 'delete') {
            this.onDelete(v.value, v.sender);
        } else if(v.id === 'view') {
            this.onView(v.value);
        } else {
            this.onRowCommand.emit(v);
        }
    }
    tableCommand(v: IEventEmitterData) {
        let id = this.tableMenuItemsData.findIndex(e => { return e.id === v.id; });
        if(id < 0) return;
        if (!(this.tableMenuItemsData[id].enabled)) {
            this.appGlblSettings.showError(this.frases['permission'], this.frases['accessdenied']);
            return;
        }
        if(v.id === 'add') {
           this.onAdd( v.sender );
        } else if (v.id === 'delete') {
            this.onDeleteMultiple( v.sender );
        } else {
            this.onTableCommand.emit(v);
        }
    }
}


