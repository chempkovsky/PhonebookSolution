
import { Component, OnInit, Input, Output, EventEmitter, ViewChild, Inject, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap, UrlSegment, ActivatedRouteSnapshot } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';
import { MatSelectChange } from '@angular/material/select';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';

import { IaspnetroleView } from 'asp-interfaces';
import { AspnetroleViewService } from 'asp-services';
import { AspnetroleViewVformComponent } from 'asp-updforms';

@Component({
  selector: 'app-aspnetrole-view-r-v',
  templateUrl: './aspnetrole-view-r-v.component.html',
  styleUrls: ['./aspnetrole-view-r-v.component.css']
})

export class AspnetroleViewRVComponent implements OnInit, AfterViewInit, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'title': $localize`:View Role@@AspnetroleViewRVComponent.ViewaspnetroleView:View Role`,
        'NavBackToMaster': $localize`:Navigate back to master@@AspnetroleViewRVComponent.NavBackToMaster:Navigate back to master`,
        'Hide-details': $localize`:Hide details@@AspnetroleViewRVComponent.Hide-details:Hide details`,
        'aspnetrolemaskViewAspNetRole': $localize`:Role Masks(AspNetRole)@@AspnetroleViewRVComponent.Role MasksAspNetRole:Role Masks(AspNetRole)`,

    }


    public showDetails: boolean = false;
    public appearance: MatFormFieldAppearance = 'outline';
    title: string|any = this.frases['title'];
    np: string|any = '';
    outletNm : string = 'primary';
    oltParent: string = '';
    @Output('on-cont-menu-item-click') onContMenuItemEmitter = new EventEmitter<IEventEmitterData>();
    @Input('cont-menu-items') contMenuItems: Array<IMenuItemData> = [];
    onContMenuItemClicked(v: IEventEmitterData)  {
        this.onContMenuItemEmitter.emit(v);
    }
    hf: string = 'hf1';
    id: string = 'id1';
    depth: number = 1;
    hiddenFilter: Array<IWebServiceFilterRslt> = [];
    eformControlModel: IaspnetroleView | null = null;
    constructor(protected route: ActivatedRoute, protected router: Router, protected appGlblSettings: AppGlblSettingsService, protected frmRootSrv: AspnetroleViewService) { }
    isdtl: boolean = false;
    ngOnInit() {
        this.appearance = this.appGlblSettings.appearance;
        if (!(typeof this.route.snapshot.data === 'undefined')) {
            if (!(this.route.snapshot.data === null)) {
                if (!(typeof this.route.snapshot.data['title'] === 'undefined')) {
                    this.title = this.route.snapshot.data['title'];
                }
                if (!(typeof this.route.snapshot.data['dp'] === 'undefined')) {
                    this.depth = this.route.snapshot.data['dp'];
                }
                if (!(typeof this.route.snapshot.data['hf'] === 'undefined')) {
                    this.hf = this.route.snapshot.data['hf'];
                }
                if (!(typeof this.route.snapshot.data['id'] === 'undefined')) {
                    this.id = this.route.snapshot.data['id'];
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
/*
                if (!(typeof this.route.snapshot.data['oltp'] === 'undefined')) {
                    this.oltParent = this.route.snapshot.data['oltp'];
                }
*/
            }
        }
        if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
            this.hiddenFilter = this.frmRootSrv.getHiddenFilterAsFltRslt(JSON.parse(this.route.snapshot.params[this.hf]));
        }
        if (!(typeof this.route.snapshot.params[this.id] === 'undefined')) {
            this.eformControlModel =  JSON.parse(this.route.snapshot.params[this.id]);
        }
        this.showDetails = !this.isdtl;
        this.selectedDetail = this.detailViews[0];
    }
    onAfterSubmit(newVal: IaspnetroleView) {
        this.router.navigate(['../../../'], {relativeTo: this.route});
/*
        if(this.outletNm === 'primary') {
            this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route}).then(
                ()=> {
                    this.router.navigate(['../../../'], {relativeTo: this.route});
                }
            );
        } else {
            let qp: string[] = [];
            qp.push(this.oltParent);

            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp.push(this.route.snapshot.params[this.hf])
            } else {
                qp.push(JSON.stringify({}));
            }

            this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route.parent!.parent}).then(
                ()=> {
                    
                    this.router.navigate([{ outlets: { [this.outletNm]: qp }}], {relativeTo: this.route.parent!.parent})
                }
            );
        }
*/
    }

    onCancel() {
        this.router.navigate(['../../../'], {relativeTo: this.route});
/*
        if(this.outletNm === 'primary') {
            this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route}).then(
                ()=> {
                    this.router.navigate(['../../../'], {relativeTo: this.route});
                }
            );
        } else {
            let qp: string[] = [];
            qp.push(this.oltParent);
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp.push(this.route.snapshot.params[this.hf])
            } else {
                qp.push(JSON.stringify({}));
            }
            this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route.parent!.parent}).then(
                ()=> {
                    this.router.navigate([{ outlets: { [this.outletNm]: qp }}], {relativeTo: this.route.parent!.parent})
                }
            );
        }
*/
    }
    onOk() {
        if (typeof this.childForm === 'undefined') return;
        if (this.childForm === null) return;
        this.childForm.doSubmit();
    }

    @ViewChild(AspnetroleViewVformComponent) childForm!: AspnetroleViewVformComponent;


    public selectedDetail: {caption: string, vw: string|null, nv: string|null, addon: string|null}|null = null;
    public detailViews: Array<{caption: string, vw: string|null, nv: string|null, addon: string|null}> = [
        {caption:this.frases['Hide-details'], vw:null, nv:null, addon: null},
        {caption:this.frases['aspnetrolemaskViewAspNetRole'], vw: 'aspnetrolemaskView', nv: 'AspNetRole', addon: 'aspnetrolemaskView'},
    ];
    public ngAfterViewInit() {
        
    }

    public onDetailChanged(v: MatSelectChange) {
        if(v) {
            this.selectedDetail = v.value;
        } else {
            this.selectedDetail = this.detailViews[0];
        }
        if(this.showDetails) {
            this.toDetail();
        }
    }
    public toDetail() {
        let isNtDef: boolean = this.selectedDetail === null;
        isNtDef = isNtDef ? isNtDef : ((this.selectedDetail!.vw === null) || (this.selectedDetail!.nv === null))
/*
        if(isNtDef) {
            this.router.navigate([{outlets: { 'oltnmaspnetroleView': null}}], {relativeTo: this.route});
        } else {
            this.router.navigate([{outlets: { 'oltnmaspnetroleView': null}}], {relativeTo: this.route}).then(
                () => {
                    let qp: string[] = [];
                    qp.push( 'oltnmaspnetroleView2' + this.selectedDetail!.vw );
                    qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow( this.childForm.rootDataSource.values2Interface(), this.selectedDetail!.nv)));
                    this.router.navigate([{ outlets: { 'oltnmaspnetroleView' : qp } }], {relativeTo: this.route});
                }
            );
        }
*/
        if(isNtDef) {
            this.router.navigate(['./'], {relativeTo: this.route});
        } else {
            let qp: string[] = [];
            qp.push( 'oltnmaspnetroleView2' + this.selectedDetail!.vw );
            qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow( this.childForm.rootDataSource.values2Interface(), this.selectedDetail!.nv)));
            this.router.navigate(qp, {relativeTo: this.route});
        }

    }
}


