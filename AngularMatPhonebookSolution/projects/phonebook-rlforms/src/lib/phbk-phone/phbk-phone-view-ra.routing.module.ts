


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneViewRAComponent } from './raform/phbk-phone-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneViewRaRoutingModule { }


