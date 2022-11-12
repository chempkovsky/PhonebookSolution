import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, ParamMap, UrlSegment, ActivatedRouteSnapshot, NavigationStart } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSelectChange } from '@angular/material/select';
import { firstValueFrom, takeWhile } from 'rxjs';
import { MatFormFieldAppearance } from '@angular/material/form-field';


import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';
import { IItemHeightData } from 'common-interfaces';
import { IMessageDialog } from 'common-interfaces';
import { MessageDialogComponent } from 'common-components';

import { IaspnetuserView } from 'asp-interfaces';
import { AspnetuserViewSformComponent } from 'asp-sforms';
import { AspnetuserViewService } from 'asp-services';



import { IaspnetuserViewVdlg } from 'asp-updforms';
import { AspnetuserViewVdlgComponent } from 'asp-updforms';

import { IaspnetuserViewAdlg } from 'asp-updforms';
import { AspnetuserViewAdlgComponent } from 'asp-updforms';

import { IaspnetuserViewUdlg } from 'asp-updforms';
import { AspnetuserViewUdlgComponent } from 'asp-updforms';

import { IaspnetuserViewDdlg } from 'asp-updforms';
import { AspnetuserViewDdlgComponent } from 'asp-updforms';

@Component({
  selector: 'app-aspnetuser-view-rdlist',
  templateUrl: './aspnetuser-view-rdlist.component.html',
  styleUrls: ['./aspnetuser-view-rdlist.component.css']
})
export class AspnetuserViewRdlistComponent implements OnInit, OnDestroy, IEventEmitterPub, IItemHeightData {
    frases: {[key:string]: string}  = {
        'Hide-details': $localize`:Hide details@@AspnetuserViewRdlistComponent.Hide-details:Hide details`,
        'nvm2mntallwd':  $localize`:Navigating to detail form is not allowed in One-to-Many mode@@AspnetuserViewRdlistComponent.nvm2mntallwd:Navigating to detail form is not allowed in One-to-Many mode`,
        'caption': $localize`:Users@@AspnetuserViewRdlistComponent.caption:Users`,
        'update': $localize`:Modify Item@@AspnetuserViewRdlistComponent.update:Modify Item`,
        'delete': $localize`:Delete Item@@AspnetuserViewRdlistComponent.delete:Delete Item`,
        'view': $localize`:View Item@@AspnetuserViewRdlistComponent.view:View Item`,
        'add': $localize`:Add Item@@AspnetuserViewRdlistComponent.add:Add Item`,
        'deletesel': $localize`:Delete Selected@@AspnetuserViewRdlistComponent.deletesel:Delete Selected`,
        'permission': $localize`:Permission@@AspnetuserViewRdlistComponent.permission:Permission`,
        'accessdenied': $localize`:Access denied@@AspnetuserViewRdlistComponent.accessdenied:Access denied`,
        'aspnetusermaskViewAspNetUser': $localize`:User Masks(AspNetUser)@@AspnetuserViewRdlistComponent.aspnetusermaskViewAspNetUser:User Masks(AspNetUser)`,
        'aspnetuserrolesViewAspNetUser': $localize`:User Roles(AspNetUser)@@AspnetuserViewRdlistComponent.aspnetuserrolesViewAspNetUser:User Roles(AspNetUser)`,

    };

    public showDetails: boolean = false;
    @Input('show-multi-selected-row') showMultiSelectedRow: boolean = true;
    public appearance: MatFormFieldAppearance = 'outline';

    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IaspnetuserView>> = new EventEmitter<Array<IaspnetuserView>>();
    onMultiSelectedRow(e: Array<IaspnetuserView>): void {
        this.multiSelectedRow.emit(e);
    }

    @Input('caption') caption: string = this.frases['caption'];
    np: string|any = '';
    outletNm : string = 'primary';

    isPostNavApplied: boolean = false;
    isOnInitCalled: boolean = false;
    depth: number = 1;
    hf: string = 'hf1';
    uid: string|null = null;
    showBackBtn: boolean = false;
    @Input('filter-max-height')  filterMaxHeight: number | null = null;
    @Input('max-height') maxHeight: number | null = null;
    @Output('on-cont-menu-item-click') onContMenuItemEmitter = new EventEmitter<IEventEmitterData>();
    @Input('cont-menu-items') contMenuItems: Array<IMenuItemData> = [];
    onContMenuItemClicked(e: IEventEmitterData)  {
        this.onContMenuItemEmitter.emit(e);
    }
    @Input('show-filter') showFilter: boolean = true;
    protected _hiddenFilter: Array<IWebServiceFilterRslt> = [];
    @Input('hidden-filter') 
        get hiddenFilter(): Array<IWebServiceFilterRslt> {
            return this._hiddenFilter;
        }
        set hiddenFilter(v :Array<IWebServiceFilterRslt>) {
            if (typeof v === 'undefined') {
                this._hiddenFilter = [];
            } else if (!Array.isArray(v)) {
                this._hiddenFilter = [];
            } else {
                this._hiddenFilter =  v;
            }
            if(this.isOnInitCalled) {
                this.cd.detectChanges();
            }
        }
    rowMenuItemsData: Array<IMenuItemData> = [
         {id: 'update', caption: this.frases['update'], iconName: 'edit', iconColor: 'primary', enabled: true},
         {id: 'delete', caption: this.frases['delete'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
         {id: 'view', caption: this.frases['view'], iconName: 'preview', iconColor: 'primary', enabled: true},
      ];
    tableMenuItemsData: Array<IMenuItemData> = [
         {id: 'add', caption: this.frases['add'], iconName: 'create', iconColor: 'primary', enabled: true},
         {id: 'deletesel', caption: this.frases['deletesel'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
      ];
    constructor(protected route: ActivatedRoute, protected router: Router, protected  frmRootSrv: AspnetuserViewService, protected appGlblSettings: AppGlblSettingsService, 
    

        public dialog: MatDialog, 
        protected cd: ChangeDetectorRef) {
    }
    permMask: number = 0;
    extfltrOn: boolean = false;
    isdtl: boolean = false;
    currPath: string = '';
    isNtDstrd: boolean = true;
    ngOnDestroy(): void {
        this.isNtDstrd = false;
    }
    ngOnInit() {
        this.router.events.pipe(
            takeWhile(v => this.isNtDstrd)
        ).subscribe(event =>{
            if (event instanceof NavigationStart){
                if(!event.url.includes(this.currPath)) {
                    if(this.uid) this.appGlblSettings.removeStorageItem(this.uid as string);
                }
            }
        });
        this.currPath = this.router.url;
        this.appearance = this.appGlblSettings.appearance;
        let luid = 'AspnetuserViewRdlistComponent';
        this.permMask = this.appGlblSettings.getViewModelMask('aspnetuserView');
        this.isPostNavApplied = false;
        if (!(typeof this.route.snapshot.data === 'undefined')) {
            if (!(this.route.snapshot.data === null)) {
                if (!(typeof this.route.snapshot.data['sf'] === 'undefined')) {
                    this.showFilter = this.route.snapshot.data['sf'];
                }
                if (!(typeof this.route.snapshot.data['mh'] === 'undefined')) {
                    this.maxHeight = this.route.snapshot.data['mh'];
                }
                if (!(typeof this.route.snapshot.data['fh'] === 'undefined')) {
                    this.filterMaxHeight = this.route.snapshot.data['fh'];
                }
                if (!(typeof this.route.snapshot.data['hf'] === 'undefined')) {
                    this.hf = this.route.snapshot.data['hf'];
                }
                if (!(typeof this.route.snapshot.data['dp'] === 'undefined')) {
                    this.depth = this.route.snapshot.data['dp'];
                }
                if (!(typeof this.route.snapshot.data['uid'] === 'undefined')) {
                    luid = this.route.snapshot.data['uid'];
                }
                if (!(typeof this.route.snapshot.data['np'] === 'undefined')) {
                    this.np = this.route.snapshot.data['np'];
                }
                // for the named router-outlet uncomment the lines below
/*
                if (!(typeof this.route.snapshot.data['oltn'] === 'undefined')) {
                    this.outletNm = this.route.snapshot.data['oltn'];
                }
*/
                if (!(typeof this.route.snapshot.data['isdtl'] === 'undefined')) {
                    this.isdtl = this.route.snapshot.data['isdtl'];
                }

                if (!(typeof this.route.snapshot.data['ms'] === 'undefined')) {
                    this.showMultiSelectedRow = this.route.snapshot.data['ms'];
                }
            }
        }
        luid = luid + ':' +this.depth;
        if(this.depth > 1) {
          this.route.paramMap.subscribe(prms => {
            let lhf: Array<IWebServiceFilterRslt> = [];
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                let phf: {[key: string]: {[key: string]: {[key: string]: any}}} | any =  JSON.parse(this.route.snapshot.params[this.hf]);
                lhf = this.frmRootSrv.getHiddenFilterAsFltRslt(phf);
            }
            if(Array.isArray(lhf)) {
                lhf.forEach((v:{fltrName: string, fltrValue: any}) => {
                    luid = luid + ':' + v.fltrName + ':' + v.fltrValue
                });
            }
            this.hiddenFilter = lhf;
            this.showBackBtn = !this.isdtl;
          });
        } else {
            this.showBackBtn = false;
        }
        this.uid = luid;
        let si: string|any = this.appGlblSettings.getStorageItem(this.uid);
        if(!(typeof si === 'undefined')) {
            if(!(si === null)) {
                this.externalFilter = si;
            }
        }
        
        this.tableMenuItemsData[0].enabled = ((this.permMask & 8) === 8) && (!this.extfltrOn) ;
        this.tableMenuItemsData[1].enabled = ((this.permMask & 2) === 2) && (!this.extfltrOn) ;

        this.rowMenuItemsData[0].enabled = this.rowMenuItemsData[0].enabled && (!this.extfltrOn) && ((this.permMask & 4) === 4) ; // modify
        this.rowMenuItemsData[1].enabled = this.rowMenuItemsData[1].enabled && (!this.extfltrOn) && ((this.permMask & 2) === 2) ; // delete
        this.rowMenuItemsData[2].enabled = this.rowMenuItemsData[2].enabled && (!this.extfltrOn) ; // view
        if(!this.isdtl) {
            let msk: number = 0;
            msk = this.appGlblSettings.getViewModelMask('aspnetusermaskView');
            if((msk & 1) === 1) {
                this.rowMenuItemsData.push(
                 { id: '1', caption: this.frases['aspnetusermaskViewAspNetUser'], iconName: 'arrow_forward', iconColor: 'primary', enabled: true, 
                    data: {
                        view: 'aspnetusermaskView',
                        nav: 'AspNetUser',
                        addon: 'aspnetusermaskView'
                    }
                 }
                );
            }
            msk = this.appGlblSettings.getViewModelMask('aspnetuserrolesView');
            if((msk & 1) === 1) {
                this.rowMenuItemsData.push(
                 { id: '2', caption: this.frases['aspnetuserrolesViewAspNetUser'], iconName: 'arrow_forward', iconColor: 'primary', enabled: true, 
                    data: {
                        view: 'aspnetuserrolesView',
                        nav: 'AspNetUser',
                        addon: 'aspnetuserrolesView'
                    }
                 }
                );
            }
        }
        this.selectedDetail = this.detailViews[0];
        this.showDetails = !this.isdtl;
        this.isOnInitCalled = true;
    }
    @Output('selected-row') selectedRow: EventEmitter<IaspnetuserView> = new EventEmitter<IaspnetuserView>();
    onSelectRow(e: IaspnetuserView|any) {
        this.toDetail();
        this.selectedRow.emit(e);
    }
    @ViewChild(AspnetuserViewSformComponent) childForm!: AspnetuserViewSformComponent;
    public selectedDetail: {caption: string, vw: string|null, nv: string|null, addon: string|null}|null = null;
    public detailViews: Array<{caption: string, vw: string|null, nv: string|null, addon: string|null}> = [
        {caption:this.frases['Hide-details'], vw:null, nv:null, addon: null},
        {caption: this.frases['aspnetusermaskViewAspNetUser'], vw: 'aspnetusermaskView', nv: 'AspNetUser', addon: 'aspnetusermaskView'},
        {caption: this.frases['aspnetuserrolesViewAspNetUser'], vw: 'aspnetuserrolesView', nv: 'AspNetUser', addon: 'aspnetuserrolesView'},
    ];
    public onDetailChanged(v: MatSelectChange) {
        if(v) {
            this.selectedDetail = v.value;
        } else {
            this.selectedDetail = this.detailViews[0];
        }
        this.toDetail();
    }
    public toDetail() {
        if(!this.showDetails) return;
        let isNtDef: boolean = (this.selectedDetail === null) || (typeof this.childForm.currentRow === 'undefined');
        isNtDef = isNtDef ? isNtDef : ((this.selectedDetail!.vw === null) || (this.selectedDetail!.nv === null) || (this.childForm.currentRow === null))
/*
        if(isNtDef) {
            this.router.navigate([{outlets: { 'dloltnmaspnetuserView': null}}], {relativeTo: this.route}).then(()=>{
                this.router.navigate([{outlets: { 'dloltnmaspnetuserView': null}}], {relativeTo: this.route});
            });
        } else {
            this.router.navigate([{outlets: { 'dloltnmaspnetuserView': null}}], {relativeTo: this.route}).then(
                () => {
                    let qp: string[] = [];
                    qp.push( 'dloltnmaspnetuserView2' + this.selectedDetail!.vw ); 
                    qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow(this.childForm.currentRow, this.selectedDetail!.nv)));
                    this.router.navigate([{ outlets: { 'dloltnmaspnetuserView' : qp } }], {relativeTo: this.route});
                }
            );
        }
*/
        // for the named router-outlet uncomment the lines above and comment the lines below. Do not forget about html-file.
        if(isNtDef) {
            this.router.navigate(['./'], {relativeTo: this.route});
        } else {
            let qp: string[] = [];
            qp.push( 'dloltnmaspnetuserView2' + this.selectedDetail!.vw ); 
            qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow(this.childForm.currentRow, this.selectedDetail!.nv)));
            this.router.navigate(qp, {relativeTo: this.route});
        }
    }


    onBackBtn(e?: any) {
        if (this.depth > 1) {
//            this.appGlblSettings.removeStorageItem(this.uid as string);

            this.router.navigate(['../../'], {relativeTo: this.route}); 
            // for the named router-outlet comment the line above and uncomment the lines below. Do not forget about html-file.
/*
            if(this.outletNm === 'primary') {
                this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route}).then(
                    ()=> {
                        this.router.navigate(['../../'], {relativeTo: this.route});
                    }
                );
            } else {
                // there is no parant, so do just hide detail component
                this.router.navigate([{ outlets: { [this.outletNm]: null }}], {relativeTo: this.route.parent!.parent});
            }
*/
        }
    }

    public externalFilter: string | any;

    onBeforeSquery(cf: string | any): void {
        if (this.uid === null) return;
        let cfs: string = '';
        if(!(typeof cf === 'undefined')) {
            if(!(cf === null)) {
                cfs = cf;
            }
        }
        this.appGlblSettings.setStorageItem(this.uid as string, cfs);
    }


    onView(e: IaspnetuserView) {
        let locdata: IaspnetuserViewVdlg = {
            title: this.frases['view'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: e,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('aspnetuserView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('aspnetuserView');
        let dialogRef = this.dialog.open(AspnetuserViewVdlgComponent, {
              data: locdata,
              maxWidth: mw,
              width: w,
            });
        dialogRef.afterClosed().subscribe(rslt => {
        });
    }

    onAdd(sender: AspnetuserViewSformComponent) {
        let locdata: IaspnetuserViewAdlg = {
            title: this.frases['add'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: null,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('aspnetuserView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('aspnetuserView');
        let dialogRef = this.dialog.open(AspnetuserViewAdlgComponent, {
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

    onEdit(e: IaspnetuserView) {
        let locdata: IaspnetuserViewUdlg = {
            title: this.frases['update'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: e,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('aspnetuserView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('aspnetuserView');
        let dialogRef = this.dialog.open(AspnetuserViewUdlgComponent, {
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

    onDelete(e: IaspnetuserView , sender: AspnetuserViewSformComponent ) {
        let locdata: IaspnetuserViewDdlg = {
            title: this.frases['delete'],
            hiddenFilter: this.hiddenFilter,
            eformControlModel: e,
            eformNewControlModel: null
        };
        let w: string = this.appGlblSettings.getDialogWidth('aspnetuserView');
        let mw: string = this.appGlblSettings.getDialogMaxWidth('aspnetuserView');
        let dialogRef = this.dialog.open(AspnetuserViewDdlgComponent, {
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

    onDeleteMultiple(sender: AspnetuserViewSformComponent) {
        let locdata: IMessageDialog = {
            title: this.frases['delete'],
            message: this.frases['deletesel'] + ' ?',
            iconname: 'warning',
            iconcolor: 'warn'
        };
        let dialogRef = this.dialog.open(MessageDialogComponent, {
              data: locdata,
            });
        dialogRef.afterClosed().subscribe(async rslt => {
            if (typeof rslt === 'undefined') return;
            if (rslt === null) return;
            let currRowsCp: Array<IaspnetuserView> = sender.currentMultiRow.slice();
            let deletedRows: Array<IaspnetuserView> = [];
            for(let row of currRowsCp) {
                try {
                    // let data: IaspnetuserView  =  
                    await firstValueFrom<IaspnetuserView>(this.frmRootSrv.deleteone(  row.id ));
                    deletedRows.push(row);
                } catch (error) {
                    this.appGlblSettings.showError('http', error)
                }
            }
            sender.deselectRows(deletedRows);
            deletedRows.forEach((r: IaspnetuserView) => {
                let i: number = sender.dataSource.indexOf(r); 
                if(i > -1) sender.dataSource.splice(i, 1);
            });
            sender.dataSource = sender.dataSource.slice(0);
            if ((deletedRows.indexOf( sender.currentRow as IaspnetuserView) > -1) && (sender.dataSource.length > 0)) sender.onSelectRow(sender.dataSource[0]);
        });
    }

    rowCommand(v: IEventEmitterData) {
        let id = this.rowMenuItemsData.findIndex(e => { return e.id === v.id; });
        if(id < 0) return;
        if (!(this.rowMenuItemsData[id].enabled)) {
            this.appGlblSettings.showError(this.frases['permission'], this.frases['accessdenied']);
            return;
        }
      
        let flt: any = {
      
          id: v.value.id,
        };
        if(v.id === 'update') {
            this.onEdit(v.value);
        } else if(v.id === 'delete') {
            this.onDelete(v.value, v.sender);
        } else if(v.id === 'view') {
            this.onView(v.value);
        } else {
            let id = this.rowMenuItemsData.findIndex(e => { return e.id === v.id; })
            if(id < 0) return;
            let mnItm: IMenuItemData = this.rowMenuItemsData[id];
            if (!(typeof mnItm.data === 'undefined')) {
                let qp: string[] = [];
                qp.push( this.np + mnItm.data.view );
                qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow(v.value, mnItm.data.nav)));

                this.router.navigate(qp, {relativeTo: this.route});
                // for the named router-outlet comment the line above and uncomment the lines below. Do not forget about html-file.
/*
                if(this.outletNm === 'primary') {
                    this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route}).then(
                        ()=> {
                            this.router.navigate(qp, {relativeTo: this.route});
                        }
                    );
                } else {
                    this.appGlblSettings.showError('navigation', {message: this.frases['nvm2mntallwd']});
                }
*/
            } else {
                this.onRowCommand.emit(v);
                return;
            }
        }
    }
    tableCommand(v: IEventEmitterData) {
        let id = this.tableMenuItemsData.findIndex(e => { return e.id === v.id; });
        if(id < 0) return;
        if (!(this.tableMenuItemsData[id].enabled)) {
            this.appGlblSettings.showError(this.frases['permission'], this.frases['accessdenied']);
            return;
        }
        if(v.id === 'deletesel') {
            this.onDeleteMultiple( v.sender );
        } else if(v.id === 'add') {
           this.onAdd( v.sender );
        } else {
            this.onTableCommand.emit(v);
        }
    }

}


