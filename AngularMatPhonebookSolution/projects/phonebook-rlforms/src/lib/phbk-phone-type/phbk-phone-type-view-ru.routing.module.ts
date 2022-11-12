


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneTypeViewRUComponent } from './ruform/phbk-phone-type-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneTypeViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneTypeViewRuRoutingModule { }


