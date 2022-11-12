


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneViewRlistComponent } from './rlist/phbk-phone-view-rlist.component';

const rllzPhbkPhoneView: {[key:string]: string} = {
} 


const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [




    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneViewRlRoutingModule { }


