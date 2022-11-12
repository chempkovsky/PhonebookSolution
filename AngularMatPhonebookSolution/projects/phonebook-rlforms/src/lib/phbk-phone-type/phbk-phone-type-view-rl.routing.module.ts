


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneTypeViewRlistComponent } from './rlist/phbk-phone-type-view-rlist.component';

const rllzPhbkPhoneTypeView: {[key:string]: string} = {
        'ViewPhbkPhoneView': $localize`:View Phones@@rllzPhbkPhoneTypeView.ViewPhbkPhoneView:View Phone`,
        'AddPhbkPhoneView': $localize`:Add Phone  @@rllzPhbkPhoneTypeView.AddPhbkPhoneView:Add Phone`,
        'UpdatePhbkPhoneView': $localize`:Update Phone  @@rllzPhbkPhoneTypeView.UpdatePhbkPhoneView:Update Phone`,
        'DeletePhbkPhoneView': $localize`:Delete Phone  @@rllzPhbkPhoneTypeView.DeletePhbkPhoneView:Delete Phone`,
        'ListPhbkPhoneView': $localize`:Phones  @@rllzPhbkPhoneTypeView.ListPhbkPhoneView:Phones`,
} 


const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneTypeViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [



//
// Info: Root Master View  [PhbkPhoneTypeView] 
// Info: Detail View  [PhbkPhoneView] 
//
    { 
//        outlet: 'loltnmPhbkPhoneTypeView',
//        path: 'loltnmPhbkPhoneTypeView2ViewPhbkPhoneView/:hf103/:id103', 
        path: 'loltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/ViewPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rv-lazy.routing.module').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'v', /* oltp: 'loltnmPhbkPhoneTypeView2PhbkPhoneView', oltn: 'loltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */   title: rllzPhbkPhoneTypeView['ViewPhbkPhoneView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkPhoneTypeView',
//        path: 'loltnmPhbkPhoneTypeView2AddPhbkPhoneView/:hf103', 
        path: 'loltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/AddPhbkPhoneView/:hf103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-ra-lazy.routing.module').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'a', /* oltp: 'loltnmPhbkPhoneTypeView2PhbkPhoneView', oltn: 'loltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */  title: rllzPhbkPhoneTypeView['AddPhbkPhoneView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkPhoneTypeView',
//        path: 'loltnmPhbkPhoneTypeView2UpdPhbkPhoneView/:hf103/:id103', 
        path: 'loltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/UpdPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-ru-lazy.routing.module').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'u', /* oltp: 'loltnmPhbkPhoneTypeView2PhbkPhoneView', oltn: 'loltnmPhbkPhoneTypeView', */  np: '', /* sf: true, */   title: rllzPhbkPhoneTypeView['UpdatePhbkPhoneView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkPhoneTypeView',
//        path: 'loltnmPhbkPhoneTypeView2DelPhbkPhoneView/:hf103/:id103', 
        path: 'loltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102/DelPhbkPhoneView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rd-lazy.routing.module').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'd', /* oltp: 'loltnmPhbkPhoneTypeView2PhbkPhoneView', oltn: 'loltnmPhbkPhoneTypeView', */ np: '', /* sf: true, */  title: rllzPhbkPhoneTypeView['DeletePhbkPhoneView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkPhoneTypeView',
        path: 'loltnmPhbkPhoneTypeView2PhbkPhoneView/:hf102', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rl.routing.module').then(m => m.PhbkPhoneViewRlRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'l', ms: true,  /* oltn: 'loltnmPhbkPhoneTypeView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzPhbkPhoneTypeView['ListPhbkPhoneView'],  hf: 'hf102',  dp: 2, uid: '0e480a4520494463b973ef174e4f7be7' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneTypeViewRlRoutingModule { }


