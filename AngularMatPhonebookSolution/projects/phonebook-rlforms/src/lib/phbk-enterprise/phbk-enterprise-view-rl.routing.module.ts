


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEnterpriseViewRlistComponent } from './rlist/phbk-enterprise-view-rlist.component';

const rllzPhbkEnterpriseView: {[key:string]: string} = {
        'ViewPhbkDivisionView': $localize`:View Divisions@@rllzPhbkEnterpriseView.ViewPhbkDivisionView:View Division`,
        'AddPhbkDivisionView': $localize`:Add Division  @@rllzPhbkEnterpriseView.AddPhbkDivisionView:Add Division`,
        'UpdatePhbkDivisionView': $localize`:Update Division  @@rllzPhbkEnterpriseView.UpdatePhbkDivisionView:Update Division`,
        'DeletePhbkDivisionView': $localize`:Delete Division  @@rllzPhbkEnterpriseView.DeletePhbkDivisionView:Delete Division`,
        'ListPhbkDivisionView': $localize`:Divisions  @@rllzPhbkEnterpriseView.ListPhbkDivisionView:Divisions`,
} 


const routes: Routes = [
 {
    path: '',
    component: PhbkEnterpriseViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [



//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkDivisionView] 
//
    { 
//        outlet: 'loltnmPhbkEnterpriseView',
//        path: 'loltnmPhbkEnterpriseView2ViewPhbkDivisionView/:hf103/:id103', 
        path: 'loltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/ViewPhbkDivisionView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rv-lazy.routing.module').then(m => m.PhbkDivisionViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'v', /* oltp: 'loltnmPhbkEnterpriseView2PhbkDivisionView', oltn: 'loltnmPhbkEnterpriseView', */ np: '', /* sf: true, */   title: rllzPhbkEnterpriseView['ViewPhbkDivisionView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEnterpriseView',
//        path: 'loltnmPhbkEnterpriseView2AddPhbkDivisionView/:hf103', 
        path: 'loltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/AddPhbkDivisionView/:hf103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-ra-lazy.routing.module').then(m => m.PhbkDivisionViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'a', /* oltp: 'loltnmPhbkEnterpriseView2PhbkDivisionView', oltn: 'loltnmPhbkEnterpriseView', */ np: '', /* sf: true, */  title: rllzPhbkEnterpriseView['AddPhbkDivisionView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEnterpriseView',
//        path: 'loltnmPhbkEnterpriseView2UpdPhbkDivisionView/:hf103/:id103', 
        path: 'loltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/UpdPhbkDivisionView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-ru-lazy.routing.module').then(m => m.PhbkDivisionViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'u', /* oltp: 'loltnmPhbkEnterpriseView2PhbkDivisionView', oltn: 'loltnmPhbkEnterpriseView', */  np: '', /* sf: true, */   title: rllzPhbkEnterpriseView['UpdatePhbkDivisionView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEnterpriseView',
//        path: 'loltnmPhbkEnterpriseView2DelPhbkDivisionView/:hf103/:id103', 
        path: 'loltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/DelPhbkDivisionView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rd-lazy.routing.module').then(m => m.PhbkDivisionViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'd', /* oltp: 'loltnmPhbkEnterpriseView2PhbkDivisionView', oltn: 'loltnmPhbkEnterpriseView', */ np: '', /* sf: true, */  title: rllzPhbkEnterpriseView['DeletePhbkDivisionView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkEnterpriseView',
        path: 'loltnmPhbkEnterpriseView2PhbkDivisionView/:hf102', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rl.routing.module').then(m => m.PhbkDivisionViewRlRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'l', ms: true,  /* oltn: 'loltnmPhbkEnterpriseView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzPhbkEnterpriseView['ListPhbkDivisionView'],  hf: 'hf102',  dp: 2, uid: 'dc9ed40e9aee47fda5d7981a90832fce' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEnterpriseViewRlRoutingModule { }


