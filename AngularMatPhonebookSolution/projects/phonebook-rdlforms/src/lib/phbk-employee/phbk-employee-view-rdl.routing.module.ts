


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEmployeeViewRdlistComponent } from './rdlist/phbk-employee-view-rdlist.component';


const rdllzPhbkEmployeeView: {[key:string]: string} = {
        'ListPhbkPhoneView': $localize`:Phones@@rdllzPhbkEmployeeView.PhbkPhoneView:Phones`,
} 

const routes: Routes = [
 {
    path: '',
    component: PhbkEmployeeViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [PhbkEmployeeView] 
// Info: Detail View  [PhbkPhoneView] 
//
    { 
//        outlet: 'dloltnmPhbkEmployeeView',
        path: 'dloltnmPhbkEmployeeView2PhbkPhoneView/:hf102', 
        loadChildren: () => import('./../phbk-phone/phbk-phone-view-rdl-lazy.routing.module').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
        data: { isdtl: true, vn: 'PhbkPhoneView', va: 'l', ms: true, /* oltn: 'dloltnmPhbkEmployeeView', */ np: '', fh: 2, mh: 10, sf: true, title: rdllzPhbkEmployeeView['ListPhbkPhoneView'], hf: 'hf102',  dp: 2, uid: '8cca3ecbdb9d42d28c3de82a89199c3a' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEmployeeViewRdlRoutingModule { }


