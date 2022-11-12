


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneTypeViewRVComponent } from './rvform/phbk-phone-type-view-r-v.component';

const rvllzPhbkPhoneTypeView: {[key:string]: string} = {
        'ViewPhbkPhoneView': $localize`:View Phones@@rvllzPhbkPhoneTypeView.ViewPhbkPhoneView:View Phone`,
        'AddPhbkPhoneView': $localize`:Add Phone  @@rvllzPhbkPhoneTypeView.AddPhbkPhoneView:Add Phone`,
        'UpdatePhbkPhoneView': $localize`:Update Phone  @@rvllzPhbkPhoneTypeView.UpdatePhbkPhoneView:Update Phone`,
        'DeletePhbkPhoneView': $localize`:Delete Phone  @@rvllzPhbkPhoneTypeView.DeletePhbkPhoneView:Delete Phone`,
        'ListPhbkPhoneView': $localize`:Phones  @@rvllzPhbkPhoneTypeView.ListPhbkPhoneView:Phones`,
} 

const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneTypeViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [PhbkPhoneTypeView] 
// Info: Detail View  [PhbkPhoneView] 
//
    { 
        // outlet: 'oltnmPhbkPhoneTypeView',
        // path: 'oltnmPhbkPhoneTypeView2ViewPhbkPhoneView/:hf103/:id103', 
        path: 'oltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/ViewPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rv-lazy.routing.module').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'v', /* oltp: 'oltnmPhbkPhoneTypeView2PhbkPhoneView',  oltn: 'oltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */ title: rvllzPhbkPhoneTypeView['ViewPhbkPhoneView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkPhoneTypeView',
        // path: 'oltnmPhbkPhoneTypeView2AddPhbkPhoneView/:hf103', 
        path: 'oltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/AddPhbkPhoneView/:hf103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-ra-lazy.routing.module').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkPhoneView', va: 'a', /* oltp: 'oltnmPhbkPhoneTypeView2PhbkPhoneView',  oltn: 'oltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */ title: rvllzPhbkPhoneTypeView['AddPhbkPhoneView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkPhoneTypeView',
        // path: 'oltnmPhbkPhoneTypeView2UpdPhbkPhoneView/:hf103/:id103', 
        path: 'oltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/UpdPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-ru-lazy.routing.module').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkPhoneView', va: 'u', /* oltp: 'oltnmPhbkPhoneTypeView2PhbkPhoneView',  oltn: 'oltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */ title: rvllzPhbkPhoneTypeView['UpdatePhbkPhoneView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkPhoneTypeView',
        // path: 'oltnmPhbkPhoneTypeView2DelPhbkPhoneView/:hf103/:id103', 
        path: 'oltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/DelPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rd-lazy.routing.module').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkPhoneView', va: 'd', /* oltp: 'oltnmPhbkPhoneTypeView2PhbkPhoneView', oltn: 'oltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */ title: rvllzPhbkPhoneTypeView['DeletePhbkPhoneView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkPhoneTypeView',
        path: 'oltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rl.routing.module').then(m => m.PhbkPhoneViewRlRoutingModule),
        data: {  isdtl: true, vn: 'PhbkPhoneView', va: 'l', ms: true,  /* oltn: 'oltnmPhbkPhoneTypeView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzPhbkPhoneTypeView['ListPhbkPhoneView'], hf: 'hf102',  dp: 2, uid: '6be0c15c92b44a25b151ce432c2cdb43' },
        canActivate: [AppGlblSettingsServiceActivator],
    },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneTypeViewRvRoutingModule { }


