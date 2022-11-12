import { Component, OnInit, Input, Output, EventEmitter, ViewChild, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router, ParamMap, UrlSegment, ActivatedRouteSnapshot, NavigationStart } from '@angular/router';

import { MatSelectChange } from '@angular/material/select';
import { MatDialog } from '@angular/material/dialog';
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

import { IaspnetroleView } from 'asp-interfaces';
import { AspnetroleViewService } from 'asp-services';
import { AspnetroleViewSformComponent } from 'asp-sforms';


@Component({
  selector: 'app-aspnetrole-view-rlist',
  templateUrl: './aspnetrole-view-rlist.component.html',
  styleUrls: ['./aspnetrole-view-rlist.component.css']
})
export class AspnetroleViewRlistComponent implements OnInit, OnDestroy, IEventEmitterPub, IItemHeightData {
    frases: {[key:string]: string}  = {
        'nvm2mntallwd':  $localize`:Navigating to detail form is not allowed in One-to-Many mode@@AspnetroleViewRlistComponent.nvm2mntallwd:Navigating to detail form is not allowed in One-to-Many mode`,
        'caption': $localize`:Roles@@AspnetroleViewRlistComponent.caption:Roles`,
        'update': $localize`:Modify Item@@AspnetroleViewRlistComponent.update:Modify Item`,
        'delete': $localize`:Delete Item@@AspnetroleViewRlistComponent.delete:Delete Item`,
        'view': $localize`:View Item@@AspnetroleViewRlistComponent.view:View Item`,
        'add': $localize`:Add Item@@AspnetroleViewRlistComponent.add:Add Item`,
        'deletesel': $localize`:Delete Selected@@AspnetroleViewRlistComponent.deletesel:Delete Selected`,
        'permission': $localize`:Permission@@AspnetroleViewRlistComponent.permission:Permission`,
        'accessdenied': $localize`:Access denied@@AspnetroleViewRlistComponent.accessdenied:Access denied`,
        'aspnetrolemaskViewAspNetRole': $localize`:Role Masks(AspNetRole)@@AspnetroleViewRlistComponent.aspnetrolemaskViewAspNetRole:Role Masks(AspNetRole)`,

    };



    public showDetails: boolean = false;
    @Input('show-multi-selected-row') showMultiSelectedRow: boolean = true;
    public appearance: MatFormFieldAppearance = 'outline';

    @Output('multi-selected-row') multiSelectedRow: EventEmitter<Array<IaspnetroleView>> = new EventEmitter<Array<IaspnetroleView>>();
    onMultiSelectedRow(e: Array<IaspnetroleView>): void {
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
         {id: 'view',   caption: this.frases['view'], iconName: 'preview', iconColor: 'primary', enabled: true},
      ];
    tableMenuItemsData: Array<IMenuItemData> = [
         {id: 'add', caption: this.frases['add'], iconName: 'create', iconColor: 'primary', enabled: true},
         {id: 'deletesel', caption: this.frases['deletesel'], iconName: 'delete_forever', iconColor: 'warn', enabled: true},
      ];
    constructor(protected route: ActivatedRoute, protected router: Router, protected  frmRootSrv: AspnetroleViewService, protected appGlblSettings: AppGlblSettingsService, 
    
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
        let luid = 'AspnetroleViewRlistComponent';
        this.permMask = this.appGlblSettings.getViewModelMask('aspnetroleView');
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
/*
                if (!(typeof this.route.snapshot.data['oltn'] === 'undefined')) {
                    this.outletNm = this.route.snapshot.data['oltn'];
                }
*/
                if (!(typeof this.route.snapshot.data['isdtl'] === 'undefined')) {
                    this.isdtl = this.route.snapshot.data['isdtl'];
                }
                if (!(typeof this.route.snapshot.data['showMultiSelect'] === 'undefined')) {
                    this.showMultiSelectedRow = this.route.snapshot.data['showMultiSelect'];
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
            msk = this.appGlblSettings.getViewModelMask('aspnetrolemaskView');
            if((msk & 1) === 1) {
                this.rowMenuItemsData.push(
                 { id: '1', caption: this.frases['aspnetrolemaskViewAspNetRole'], iconName: 'arrow_forward', iconColor: 'primary', enabled: true, 
                    data: {
                        view: 'aspnetrolemaskView',
                        nav: 'AspNetRole',
                    }
                 }
                );
            }
        }
        this.selectedDetail = this.detailViews[0];
        this.showDetails = !this.isdtl;
        this.isOnInitCalled = true;
    }
    @Output('on-row-command') onRowCommand: EventEmitter<IEventEmitterData> = new EventEmitter<IEventEmitterData>();
    @Output('on-table-command') onTableCommand: EventEmitter<IEventEmitterData> = new EventEmitter<IEventEmitterData>();
    @Output('selected-row') selectedRow: EventEmitter<IaspnetroleView> = new EventEmitter<IaspnetroleView>();
    onSelectRow(e: IaspnetroleView|any) {
        this.toDetail();
        this.selectedRow.emit(e);
    }
    @ViewChild(AspnetroleViewSformComponent) childForm!: AspnetroleViewSformComponent;
    public selectedDetail: {caption: string, vw: string|null, nv: string|null, addon: string|null}|null = null;
    public detailViews: Array<{caption: string, vw: string|null, nv: string|null, addon: string|null}> = [
        {caption:'Hide details', vw:null, nv:null, addon: null},
        {caption: this.frases['aspnetrolemaskViewAspNetRole'], vw: 'aspnetrolemaskView', nv: 'AspNetRole', addon: 'aspnetrolemaskView'},
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
        isNtDef = isNtDef ? isNtDef : ((this.selectedDetail!.vw === null) || (this.selectedDetail!.nv === null) || (this.childForm.currentRow === null));
/*
        if(isNtDef) {
            this.router.navigate([{outlets: { 'loltnmaspnetroleView': null}}], {relativeTo: this.route}).then(()=>{
                this.router.navigate([{outlets: { 'loltnmaspnetroleView': null}}], {relativeTo: this.route});
            });
        } else {
            this.router.navigate([{outlets: { 'loltnmaspnetroleView': null}}], {relativeTo: this.route}).then(
                () => {
                    let qp: string[] = [];
                    qp.push( 'loltnmaspnetroleView2' + this.selectedDetail!.vw );
                    qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow(this.childForm.currentRow, this.selectedDetail!.nv)));
                    this.router.navigate([{ outlets: { 'loltnmaspnetroleView' : qp } }], {relativeTo: this.route});
                }
            );
        }
*/
        // for the named router-outlet uncomment the lines above and comment the lines below. Do not forget about html-file.
        if(isNtDef) {
            this.router.navigate(['./'], {relativeTo: this.route});
        } else {
            let qp: string[] = [];
            qp.push( 'loltnmaspnetroleView2' + this.selectedDetail!.vw );
            qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow(this.childForm.currentRow, this.selectedDetail!.nv)));
            this.router.navigate(qp, {relativeTo: this.route});
        }

    }

    onDeleteMultiple(sender: AspnetroleViewSformComponent) {
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
            let currRowsCp: Array<IaspnetroleView> = sender.currentMultiRow.slice();
            let deletedRows: Array<IaspnetroleView> = [];
            for(let row of currRowsCp) {
                try {
                    // let data: IaspnetroleView  =  
                    await firstValueFrom<IaspnetroleView>(this.frmRootSrv.deleteone(  row.id ));
                    deletedRows.push(row);
                } catch (error) {
                    this.appGlblSettings.showError('http', error)
                }
            }
            sender.deselectRows(deletedRows);
            deletedRows.forEach((r: IaspnetroleView) => {
                let i: number = sender.dataSource.indexOf(r); 
                if(i > -1) sender.dataSource.splice(i, 1);
            });
            sender.dataSource = sender.dataSource.slice(0);
            if ((deletedRows.indexOf( sender.currentRow  as IaspnetroleView) > -1) && (sender.dataSource.length > 0)) sender.onSelectRow(sender.dataSource[0]);
        });
    }

    rowCommand(v: IEventEmitterData) {
        let id = this.rowMenuItemsData.findIndex(e => { return e.id === v.id; });
        if(id < 0) return;
        if (!(this.rowMenuItemsData[id].enabled)) {
            this.appGlblSettings.showError(this.frases['permission'], this.frases['accessdenied']);
            return;
        }
        let qp: string[] = [];
      
        let flt: any = {
      
          id: v.value.id,
        };
        if(v.id === 'view') {
            qp.push( 'View' + 'aspnetroleView' );
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp.push(this.route.snapshot.params[this.hf]);
            } else {
                qp.push(JSON.stringify({}));
            }
            qp.push(JSON.stringify(flt));
        } else if(v.id === 'update') {
            qp.push( 'Upd' + 'aspnetroleView' );
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp.push(this.route.snapshot.params[this.hf]);
            } else {
                qp.push(JSON.stringify({}));
            }
            qp.push(JSON.stringify(flt));
        } else if(v.id === 'delete') {
            qp.push( 'Del' + 'aspnetroleView' );
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp.push(this.route.snapshot.params[this.hf]);
            } else {
                qp.push(JSON.stringify({}));
            }
            qp.push(JSON.stringify(flt));
        } else {
            let id = this.rowMenuItemsData.findIndex(e => { return e.id === v.id; })
            if(id < 0) return;
            let mnItm: IMenuItemData = this.rowMenuItemsData[id];
            if (!(typeof mnItm.data === 'undefined')) {
                if(this.outletNm === 'primary') {
                    qp.push( this.np +  mnItm.data.view );
                    qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow(v.value, mnItm.data.nav)));
                } else {
                    this.appGlblSettings.showError('navigation', {message: this.frases['nvm2mntallwd']});
                    return;
                }
            } else {
                this.onRowCommand.emit(v);
                return;
            }
        }

        this.router.navigate(qp, {relativeTo: this.route});
        // for the named router-outlet uncomment the lines above and comment the lines below. Do not forget about html-file.
/*
        if(this.outletNm === 'primary') {
            this.router.navigate([{outlets: { 'loltnmaspnetroleView': null}}], {relativeTo: this.route}).then(()=>{
                this.router.navigate(qp, {relativeTo: this.route})
            });
        } else {
            qp[0] = this.outletNm + '2' + qp[0];
            this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route.parent!.parent}).then(
                ()=> {
                    this.router.navigate([{ outlets: { [this.outletNm]: qp }}], {relativeTo: this.route.parent!.parent});
                }
            );
        }
*/
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
            let qp: string[] = [];
            qp.push( 'Add' + 'aspnetroleView' );
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp.push(this.route.snapshot.params[this.hf]);
            } else {
                qp.push(JSON.stringify({}));
            }

             this.router.navigate(qp, {relativeTo: this.route});
            // for the named router-outlet comment the line above and uncomment the lines below. Do not forget about html-file.
/*
            if(this.outletNm === 'primary') {
                this.router.navigate([{outlets: { 'loltnmaspnetroleView': null}}], {relativeTo: this.route}).then(()=>{
                    this.router.navigate(qp, {relativeTo: this.route});
                });
            } else {
                qp[0] = this.outletNm + '2' + qp[0];
                this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route.parent!.parent}).then(
                    ()=> {
                        this.router.navigate([{ outlets: { [this.outletNm]: qp }}], {relativeTo: this.route.parent!.parent});
                    }
                );
            }
*/
        } else {
            this.onTableCommand.emit(v);
            return;
        }
    }
    applyFilter(frm: AspnetroleViewSformComponent | any) {
        if(this.isPostNavApplied) {
            return;
        }
        this.isPostNavApplied = true;

        
        let act: string | any = undefined;
        if (!(typeof this.route.snapshot.queryParams['mode'] === 'undefined')) {
            act = this.route.snapshot.queryParams['mode'];
        }
        if(typeof act === 'undefined') return;
        if(act === null) return;

        let flt: IaspnetroleView | any = JSON.parse(this.route.snapshot.queryParams['item']);
        if(typeof flt === 'undefined') return;
        if(flt === null) return;

        if ((act === 'Add') ||
            (act === 'Upd')) {
            if(typeof flt['id'] === 'undefined') {
                return;
            }
            let pkpId: any = flt['id'];
            this.frmRootSrv.getone(
                  pkpId
 
            ).subscribe({
                   next: (data: IaspnetroleView ) => { // success path
                        if (typeof data === 'undefined') return;
                        if (data === null) return;
                        if(typeof frm.dataSource === 'undefined') return;
                        if(!Array.isArray(frm.dataSource)) return;
                        let i: number = frm.dataSource.findIndex((e:any) => {
                            return  (e.id === data.id)                        });
                        if(i < 0) {
                            frm.dataSource.splice(0, 0, data);
                            frm.dataSource = frm.dataSource.slice(0);
                            let isNDef = true;
                            if (!(typeof frm.currentRow === 'undefined')) {
                                if (!(frm.currentRow === null)) {
                                    isNDef = false;
                                }
                            }
                            if(isNDef) {
                                frm.onSelectRow(data);
                            }
                        } else { 
                            frm.onSelectRow(frm.dataSource[i]); 
                        }
                   },
                   error: (error) => { // error path
                        this.appGlblSettings.showError('http', error);
                        this.onBackBtn(); // navigation is correct: onBackBtn is correct method here
                   } 
                });
            return;
        }
    }
    onBackBtn(e?: any) {
        if (this.depth > 1) {
//            this.appGlblSettings.removeStorageItem(this.uid as string);

            this.router.navigate(['../../'], {relativeTo: this.route});
            // for the named router-outlet comment the line above and uncomment the lines below. Do not forget about html-file.
/*
            if(this.outletNm === 'primary') {
                this.router.navigate([{outlets: { 'loltnmaspnetroleView': null}}], {relativeTo: this.route}).then(()=>{
                    this.router.navigate(['../../'], {relativeTo: this.route});
                });
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
        this.appGlblSettings.setStorageItem(this.uid, cfs);
    }

}


