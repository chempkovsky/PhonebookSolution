


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEnterpriseViewRdlistComponent } from './rdlist/phbk-enterprise-view-rdlist.component';


const rdllzPhbkEnterpriseView: {[key:string]: string} = {
        'ListPhbkDivisionView': $localize`:Divisions@@rdllzPhbkEnterpriseView.PhbkDivisionView:Divisions`,
} 

const routes: Routes = [
 {
    path: '',
    component: PhbkEnterpriseViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkDivisionView] 
//
    { 
//        outlet: 'dloltnmPhbkEnterpriseView',
        path: 'dloltnmPhbkEnterpriseView2PhbkDivisionView/:hf102', 
        loadChildren: () => import('./../phbk-division/phbk-division-view-rdl-lazy.routing.module').then(m => m.PhbkDivisionViewRdlLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkDivisionView', va: 'l', ms: true, /* oltn: 'dloltnmPhbkEnterpriseView', */ np: '', fh: 2, mh: 10, sf: true, title: rdllzPhbkEnterpriseView['ListPhbkDivisionView'], hf: 'hf102',  dp: 2, uid: '9c3656bb21fa43d6abbecab0ab77f5bd' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEnterpriseViewRdlRoutingModule { }


