


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneViewRUComponent } from './ruform/phbk-phone-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneViewRuRoutingModule { }


