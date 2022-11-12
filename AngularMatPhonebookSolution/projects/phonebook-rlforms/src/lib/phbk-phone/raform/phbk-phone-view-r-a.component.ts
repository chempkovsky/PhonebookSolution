
import { Component, OnInit, Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { ActivatedRoute, Router, ParamMap, UrlSegment, ActivatedRouteSnapshot } from '@angular/router';

import { AppGlblSettingsService } from 'common-services';
import { IWebServiceFilterRslt } from 'common-interfaces';
import { IEventEmitterData } from 'common-interfaces';
import { IMenuItemData } from 'common-interfaces';
import { IEventEmitterPub } from 'common-interfaces';

import { IPhbkPhoneView } from 'phonebook-interfaces';
import { PhbkPhoneViewService } from 'phonebook-services';
import { PhbkPhoneViewAformComponent } from 'phonebook-updforms';


@Component({
  selector: 'app-phbk-phone-view-r-a',
  templateUrl: './phbk-phone-view-r-a.component.html',
  styleUrls: ['./phbk-phone-view-r-a.component.css']
})

export class PhbkPhoneViewRAComponent implements OnInit, IEventEmitterPub {
    frases: {[key:string]: string}  = {
        'title': $localize`:Add Phone@@PhbkPhoneViewRAComponent.AddPhbkPhoneView:Add Phone`,
    };
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
    depth: number = 1;
    @ViewChild(PhbkPhoneViewAformComponent) childForm: PhbkPhoneViewAformComponent | any;
    hiddenFilter: Array<IWebServiceFilterRslt> = [];
    eformControlModel: IPhbkPhoneView | null = null;
    constructor(protected route: ActivatedRoute, protected router: Router, protected appGlblSettings: AppGlblSettingsService, protected frmRootSrv: PhbkPhoneViewService) { }
    isdtl: boolean = false;
    ngOnInit() {
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
        let lhf: Array<IWebServiceFilterRslt> = [];
        if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
            lhf = this.frmRootSrv.getHiddenFilterAsFltRslt(JSON.parse(this.route.snapshot.params[this.hf]));
        }
        this.hiddenFilter = lhf;
    }
    onAfterSubmit(newVal: IPhbkPhoneView) {
      
        let flt: any = {};
      
        flt['phoneId'] = newVal.phoneId;
      
        let qp: any = {
            mode: 'Add',
            item:  JSON.stringify(flt)
        };
        this.router.navigate(['../../'], {queryParams: qp, relativeTo: this.route});
/*
        if(this.outletNm === 'primary') {
            this.router.navigate(['../../'], {queryParams: qp, relativeTo: this.route});
        } else {
            let qp0: string[] = [];
            qp0.push(this.oltParent);
            if (!(typeof this.route.snapshot.params[this.hf] === 'undefined')) {
                qp0.push(this.route.snapshot.params[this.hf])
            } else {
                qp0.push(JSON.stringify({}));
            }
            this.router.navigate([{outlets: { [this.outletNm]: null}}], {relativeTo: this.route.parent!.parent}).then(
                ()=> {
                    this.router.navigate([{ outlets: { [this.outletNm]: qp0 }}], {queryParams: qp, relativeTo: this.route.parent!.parent})
                }
            );
        }
*/
    }
    onCancel() {
        this.router.navigate(['../../'], {relativeTo: this.route});
/*
        if(this.outletNm === 'primary') {
            this.router.navigate(['../../'], {relativeTo: this.route});
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
}


