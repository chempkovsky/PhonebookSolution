


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEmployeeViewRlistComponent } from './rlist/phbk-employee-view-rlist.component';

const rllzPhbkEmployeeView: {[key:string]: string} = {
        'ViewPhbkPhoneView': $localize`:View Phones@@rllzPhbkEmployeeView.ViewPhbkPhoneView:View Phone`,
        'AddPhbkPhoneView': $localize`:Add Phone  @@rllzPhbkEmployeeView.AddPhbkPhoneView:Add Phone`,
        'UpdatePhbkPhoneView': $localize`:Update Phone  @@rllzPhbkEmployeeView.UpdatePhbkPhoneView:Update Phone`,
        'DeletePhbkPhoneView': $localize`:Delete Phone  @@rllzPhbkEmployeeView.DeletePhbkPhoneView:Delete Phone`,
        'ListPhbkPhoneView': $localize`:Phones  @@rllzPhbkEmployeeView.ListPhbkPhoneView:Phones`,
} 


const routes: Routes = [
 {
    path: '',
    component: PhbkEmployeeViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [



//
// Info: Root Master View  [PhbkEmployeeView] 
// Info: Detail View  [PhbkPhoneView] 
//
    { 
//        outlet: 'loltnmPhbkEmployeeView',
//        path: 'loltnmPhbkEmployeeView2ViewPhbkPhoneView/:hf103/:id103', 
        path: 'loltnmPhbkEmployeeView2PhbkPhoneView/:hf102/ViewPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rv-lazy.routing.module').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'v', /* oltp: 'loltnmPhbkEmployeeView2PhbkPhoneView', oltn: 'loltnmPhbkEmployeeView', */ np: '', /* sf: true, */   title: rllzPhbkEmployeeView['ViewPhbkPhoneView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEmployeeView',
//        path: 'loltnmPhbkEmployeeView2AddPhbkPhoneView/:hf103', 
        path: 'loltnmPhbkEmployeeView2PhbkPhoneView/:hf102/AddPhbkPhoneView/:hf103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-ra-lazy.routing.module').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'a', /* oltp: 'loltnmPhbkEmployeeView2PhbkPhoneView', oltn: 'loltnmPhbkEmployeeView', */ np: '', /* sf: true, */  title: rllzPhbkEmployeeView['AddPhbkPhoneView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEmployeeView',
//        path: 'loltnmPhbkEmployeeView2UpdPhbkPhoneView/:hf103/:id103', 
        path: 'loltnmPhbkEmployeeView2PhbkPhoneView/:hf102/UpdPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-ru-lazy.routing.module').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'u', /* oltp: 'loltnmPhbkEmployeeView2PhbkPhoneView', oltn: 'loltnmPhbkEmployeeView', */  np: '', /* sf: true, */   title: rllzPhbkEmployeeView['UpdatePhbkPhoneView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEmployeeView',
//        path: 'loltnmPhbkEmployeeView2DelPhbkPhoneView/:hf103/:id103', 
        path: 'loltnmPhbkEmployeeView2PhbkPhoneView/:hf102/DelPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rd-lazy.routing.module').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'd', /* oltp: 'loltnmPhbkEmployeeView2PhbkPhoneView', oltn: 'loltnmPhbkEmployeeView', */ np: '', /* sf: true, */  title: rllzPhbkEmployeeView['DeletePhbkPhoneView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEmployeeView',
        path: 'loltnmPhbkEmployeeView2PhbkPhoneView/:hf102', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rl.routing.module').then(m => m.PhbkPhoneViewRlRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'l', ms: true,  /* oltn: 'loltnmPhbkEmployeeView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzPhbkEmployeeView['ListPhbkPhoneView'],  hf: 'hf102',  dp: 2, uid: 'a5f90299ce4d458fb1f991fbe2d08fb1' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEmployeeViewRlRoutingModule { }


