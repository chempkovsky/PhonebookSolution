


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkDivisionViewRlistComponent } from './rlist/phbk-division-view-rlist.component';

const rllzPhbkDivisionView: {[key:string]: string} = {
        'ViewPhbkEmployeeView': $localize`:View Employees@@rllzPhbkDivisionView.ViewPhbkEmployeeView:View Employee`,
        'AddPhbkEmployeeView': $localize`:Add Employee  @@rllzPhbkDivisionView.AddPhbkEmployeeView:Add Employee`,
        'UpdatePhbkEmployeeView': $localize`:Update Employee  @@rllzPhbkDivisionView.UpdatePhbkEmployeeView:Update Employee`,
        'DeletePhbkEmployeeView': $localize`:Delete Employee  @@rllzPhbkDivisionView.DeletePhbkEmployeeView:Delete Employee`,
        'ListPhbkEmployeeView': $localize`:Employees  @@rllzPhbkDivisionView.ListPhbkEmployeeView:Employees`,
} 


const routes: Routes = [
 {
    path: '',
    component: PhbkDivisionViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [



//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkEmployeeView] 
//
    { 
//        outlet: 'loltnmPhbkDivisionView',
//        path: 'loltnmPhbkDivisionView2ViewPhbkEmployeeView/:hf103/:id103', 
        path: 'loltnmPhbkDivisionView2PhbkEmployeeView/:hf102/ViewPhbkEmployeeView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-rv-lazy.routing.module').then(m => m.PhbkEmployeeViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkEmployeeView', va: 'v', /* oltp: 'loltnmPhbkDivisionView2PhbkEmployeeView', oltn: 'loltnmPhbkDivisionView', */ np: '', /* sf: true, */   title: rllzPhbkDivisionView['ViewPhbkEmployeeView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkDivisionView',
//        path: 'loltnmPhbkDivisionView2AddPhbkEmployeeView/:hf103', 
        path: 'loltnmPhbkDivisionView2PhbkEmployeeView/:hf102/AddPhbkEmployeeView/:hf103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-ra-lazy.routing.module').then(m => m.PhbkEmployeeViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkEmployeeView', va: 'a', /* oltp: 'loltnmPhbkDivisionView2PhbkEmployeeView', oltn: 'loltnmPhbkDivisionView', */ np: '', /* sf: true, */  title: rllzPhbkDivisionView['AddPhbkEmployeeView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkDivisionView',
//        path: 'loltnmPhbkDivisionView2UpdPhbkEmployeeView/:hf103/:id103', 
        path: 'loltnmPhbkDivisionView2PhbkEmployeeView/:hf102/UpdPhbkEmployeeView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-ru-lazy.routing.module').then(m => m.PhbkEmployeeViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkEmployeeView', va: 'u', /* oltp: 'loltnmPhbkDivisionView2PhbkEmployeeView', oltn: 'loltnmPhbkDivisionView', */  np: '', /* sf: true, */   title: rllzPhbkDivisionView['UpdatePhbkEmployeeView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkDivisionView',
//        path: 'loltnmPhbkDivisionView2DelPhbkEmployeeView/:hf103/:id103', 
        path: 'loltnmPhbkDivisionView2PhbkEmployeeView/:hf102/DelPhbkEmployeeView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-rd-lazy.routing.module').then(m => m.PhbkEmployeeViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkEmployeeView', va: 'd', /* oltp: 'loltnmPhbkDivisionView2PhbkEmployeeView', oltn: 'loltnmPhbkDivisionView', */ np: '', /* sf: true, */  title: rllzPhbkDivisionView['DeletePhbkEmployeeView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmPhbkDivisionView',
        path: 'loltnmPhbkDivisionView2PhbkEmployeeView/:hf102', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-rl.routing.module').then(m => m.PhbkEmployeeViewRlRoutingModule),
        data: { isdtl: true, vn: 'PhbkEmployeeView', va: 'l', ms: true,  /* oltn: 'loltnmPhbkDivisionView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzPhbkDivisionView['ListPhbkEmployeeView'],  hf: 'hf102',  dp: 2, uid: '6e39d863ada544c08188a37f8338280d' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkDivisionViewRlRoutingModule { }


