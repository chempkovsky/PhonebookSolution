


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEnterpriseViewRVComponent } from './rvform/phbk-enterprise-view-r-v.component';

const rvllzPhbkEnterpriseView: {[key:string]: string} = {
        'ViewPhbkDivisionView': $localize`:View Divisions@@rvllzPhbkEnterpriseView.ViewPhbkDivisionView:View Division`,
        'AddPhbkDivisionView': $localize`:Add Division  @@rvllzPhbkEnterpriseView.AddPhbkDivisionView:Add Division`,
        'UpdatePhbkDivisionView': $localize`:Update Division  @@rvllzPhbkEnterpriseView.UpdatePhbkDivisionView:Update Division`,
        'DeletePhbkDivisionView': $localize`:Delete Division  @@rvllzPhbkEnterpriseView.DeletePhbkDivisionView:Delete Division`,
        'ListPhbkDivisionView': $localize`:Divisions  @@rvllzPhbkEnterpriseView.ListPhbkDivisionView:Divisions`,
} 

const routes: Routes = [
 {
    path: '',
    component: PhbkEnterpriseViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkDivisionView] 
//
    { 
        // outlet: 'oltnmPhbkEnterpriseView',
        // path: 'oltnmPhbkEnterpriseView2ViewPhbkDivisionView/:hf103/:id103', 
        path: 'oltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/ViewPhbkDivisionView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rv-lazy.routing.module').then(m => m.PhbkDivisionViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'v', /* oltp: 'oltnmPhbkEnterpriseView2PhbkDivisionView',  oltn: 'oltnmPhbkEnterpriseView', */ np: '', /* sf: true, */ title: rvllzPhbkEnterpriseView['ViewPhbkDivisionView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkEnterpriseView',
        // path: 'oltnmPhbkEnterpriseView2AddPhbkDivisionView/:hf103', 
        path: 'oltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/AddPhbkDivisionView/:hf103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-ra-lazy.routing.module').then(m => m.PhbkDivisionViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkDivisionView', va: 'a', /* oltp: 'oltnmPhbkEnterpriseView2PhbkDivisionView',  oltn: 'oltnmPhbkEnterpriseView', */ np: '', /* sf: true, */ title: rvllzPhbkEnterpriseView['AddPhbkDivisionView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkEnterpriseView',
        // path: 'oltnmPhbkEnterpriseView2UpdPhbkDivisionView/:hf103/:id103', 
        path: 'oltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/UpdPhbkDivisionView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-ru-lazy.routing.module').then(m => m.PhbkDivisionViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkDivisionView', va: 'u', /* oltp: 'oltnmPhbkEnterpriseView2PhbkDivisionView',  oltn: 'oltnmPhbkEnterpriseView', */ np: '', /* sf: true, */ title: rvllzPhbkEnterpriseView['UpdatePhbkDivisionView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkEnterpriseView',
        // path: 'oltnmPhbkEnterpriseView2DelPhbkDivisionView/:hf103/:id103', 
        path: 'oltnmPhbkEnterpriseView2PhbkDivisionView/:hf102/DelPhbkDivisionView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rd-lazy.routing.module').then(m => m.PhbkDivisionViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkDivisionView', va: 'd', /* oltp: 'oltnmPhbkEnterpriseView2PhbkDivisionView', oltn: 'oltnmPhbkEnterpriseView', */ np: '', /* sf: true, */ title: rvllzPhbkEnterpriseView['DeletePhbkDivisionView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkEnterpriseView',
        path: 'oltnmPhbkEnterpriseView2PhbkDivisionView/:hf102', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rl.routing.module').then(m => m.PhbkDivisionViewRlRoutingModule),
        data: {  isdtl: true, vn: 'PhbkDivisionView', va: 'l', ms: true,  /* oltn: 'oltnmPhbkEnterpriseView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzPhbkEnterpriseView['ListPhbkDivisionView'], hf: 'hf102',  dp: 2, uid: '6a7df0b0c8124196b48fa2d66c4585b6' },
        canActivate: [AppGlblSettingsServiceActivator],
    },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEnterpriseViewRvRoutingModule { }


