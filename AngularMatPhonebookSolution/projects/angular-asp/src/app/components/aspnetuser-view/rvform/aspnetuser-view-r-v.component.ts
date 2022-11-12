
import { Component, OnInit, Input, Output, EventEmitter, ViewChild, Inject, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap, UrlSegment, ActivatedRouteSnapshot } from '@angular/router';
import { MatFormFieldAppearance } from '@angular/material/form-field';
import { MatSelectChange } from '@angular/material/select';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';

import { IaspnetuserView } from 'asp-interfaces';
import { AspnetuserViewService } from 'asp-services';
import { AspnetuserViewVformComponent } from 'asp-updforms';

@Component({
  selector: 'app-aspnetuser-view-r-v',
  templateUrl: './aspnetuser-view-r-v.component.html',
  styleUrls: ['./aspnetuser-view-r-v.component.css']
})

export class AspnetuserViewRVComponent implements OnInit, AfterViewInit, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'title': $localize`:View User@@AspnetuserViewRVComponent.ViewaspnetuserView:View User`,
        'NavBackToMaster': $localize`:Navigate back to master@@AspnetuserViewRVComponent.NavBackToMaster:Navigate back to master`,
        'Hide-details': $localize`:Hide details@@AspnetuserViewRVComponent.Hide-details:Hide details`,
        'aspnetusermaskViewAspNetUser': $localize`:User Masks(AspNetUser)@@AspnetuserViewRVComponent.User MasksAspNetUser:User Masks(AspNetUser)`,
        'aspnetuserrolesViewAspNetUser': $localize`:User Roles(AspNetUser)@@AspnetuserViewRVComponent.User RolesAspNetUser:User Roles(AspNetUser)`,

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
    eformControlModel: IaspnetuserView | null = null;
    constructor(protected route: ActivatedRoute, protected router: Router, protected appGlblSettings: AppGlblSettingsService, protected frmRootSrv: AspnetuserViewService) { }
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
    onAfterSubmit(newVal: IaspnetuserView) {
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

    @ViewChild(AspnetuserViewVformComponent) childForm!: AspnetuserViewVformComponent;


    public selectedDetail: {caption: string, vw: string|null, nv: string|null, addon: string|null}|null = null;
    public detailViews: Array<{caption: string, vw: string|null, nv: string|null, addon: string|null}> = [
        {caption:this.frases['Hide-details'], vw:null, nv:null, addon: null},
        {caption:this.frases['aspnetusermaskViewAspNetUser'], vw: 'aspnetusermaskView', nv: 'AspNetUser', addon: 'aspnetusermaskView'},
        {caption:this.frases['aspnetuserrolesViewAspNetUser'], vw: 'aspnetuserrolesView', nv: 'AspNetUser', addon: 'aspnetuserrolesView'},
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
            this.router.navigate([{outlets: { 'oltnmaspnetuserView': null}}], {relativeTo: this.route});
        } else {
            this.router.navigate([{outlets: { 'oltnmaspnetuserView': null}}], {relativeTo: this.route}).then(
                () => {
                    let qp: string[] = [];
                    qp.push( 'oltnmaspnetuserView2' + this.selectedDetail!.vw );
                    qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow( this.childForm.rootDataSource.values2Interface(), this.selectedDetail!.nv)));
                    this.router.navigate([{ outlets: { 'oltnmaspnetuserView' : qp } }], {relativeTo: this.route});
                }
            );
        }
*/
        if(isNtDef) {
            this.router.navigate(['./'], {relativeTo: this.route});
        } else {
            let qp: string[] = [];
            qp.push( 'oltnmaspnetuserView2' + this.selectedDetail!.vw );
            qp.push(JSON.stringify(this.frmRootSrv.getHiddenFilterByRow( this.childForm.rootDataSource.values2Interface(), this.selectedDetail!.nv)));
            this.router.navigate(qp, {relativeTo: this.route});
        }

    }
}


