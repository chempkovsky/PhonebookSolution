


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkDivisionViewRVComponent } from './rvform/phbk-division-view-r-v.component';

const rvllzPhbkDivisionView: {[key:string]: string} = {
        'ViewPhbkEmployeeView': $localize`:View Employees@@rvllzPhbkDivisionView.ViewPhbkEmployeeView:View Employee`,
        'AddPhbkEmployeeView': $localize`:Add Employee  @@rvllzPhbkDivisionView.AddPhbkEmployeeView:Add Employee`,
        'UpdatePhbkEmployeeView': $localize`:Update Employee  @@rvllzPhbkDivisionView.UpdatePhbkEmployeeView:Update Employee`,
        'DeletePhbkEmployeeView': $localize`:Delete Employee  @@rvllzPhbkDivisionView.DeletePhbkEmployeeView:Delete Employee`,
        'ListPhbkEmployeeView': $localize`:Employees  @@rvllzPhbkDivisionView.ListPhbkEmployeeView:Employees`,
} 

const routes: Routes = [
 {
    path: '',
    component: PhbkDivisionViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkEmployeeView] 
//
    { 
        // outlet: 'oltnmPhbkDivisionView',
        // path: 'oltnmPhbkDivisionView2ViewPhbkEmployeeView/:hf103/:id103', 
        path: 'oltnmPhbkDivisionView2PhbkEmployeeView/:hf102/ViewPhbkEmployeeView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-rv-lazy.routing.module').then(m => m.PhbkEmployeeViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkEmployeeView', va: 'v', /* oltp: 'oltnmPhbkDivisionView2PhbkEmployeeView',  oltn: 'oltnmPhbkDivisionView', */ np: '', /* sf: true, */ title: rvllzPhbkDivisionView['ViewPhbkEmployeeView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkDivisionView',
        // path: 'oltnmPhbkDivisionView2AddPhbkEmployeeView/:hf103', 
        path: 'oltnmPhbkDivisionView2PhbkEmployeeView/:hf102/AddPhbkEmployeeView/:hf103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-ra-lazy.routing.module').then(m => m.PhbkEmployeeViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkEmployeeView', va: 'a', /* oltp: 'oltnmPhbkDivisionView2PhbkEmployeeView',  oltn: 'oltnmPhbkDivisionView', */ np: '', /* sf: true, */ title: rvllzPhbkDivisionView['AddPhbkEmployeeView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkDivisionView',
        // path: 'oltnmPhbkDivisionView2UpdPhbkEmployeeView/:hf103/:id103', 
        path: 'oltnmPhbkDivisionView2PhbkEmployeeView/:hf102/UpdPhbkEmployeeView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-ru-lazy.routing.module').then(m => m.PhbkEmployeeViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkEmployeeView', va: 'u', /* oltp: 'oltnmPhbkDivisionView2PhbkEmployeeView',  oltn: 'oltnmPhbkDivisionView', */ np: '', /* sf: true, */ title: rvllzPhbkDivisionView['UpdatePhbkEmployeeView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkDivisionView',
        // path: 'oltnmPhbkDivisionView2DelPhbkEmployeeView/:hf103/:id103', 
        path: 'oltnmPhbkDivisionView2PhbkEmployeeView/:hf102/DelPhbkEmployeeView/:hf103/:id103', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-rd-lazy.routing.module').then(m => m.PhbkEmployeeViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'PhbkEmployeeView', va: 'd', /* oltp: 'oltnmPhbkDivisionView2PhbkEmployeeView', oltn: 'oltnmPhbkDivisionView', */ np: '', /* sf: true, */ title: rvllzPhbkDivisionView['DeletePhbkEmployeeView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmPhbkDivisionView',
        path: 'oltnmPhbkDivisionView2PhbkEmployeeView/:hf102', 
        loadChildren: () => import('./../phbk-employee/phbk-employee-view-rl.routing.module').then(m => m.PhbkEmployeeViewRlRoutingModule),
        data: {  isdtl: true, vn: 'PhbkEmployeeView', va: 'l', ms: true,  /* oltn: 'oltnmPhbkDivisionView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzPhbkDivisionView['ListPhbkEmployeeView'], hf: 'hf102',  dp: 2, uid: '538b520bf4154421977b56a073d12fc8' },
        canActivate: [AppGlblSettingsServiceActivator],
    },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkDivisionViewRvRoutingModule { }


