


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneTypeViewRAComponent } from './raform/phbk-phone-type-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneTypeViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneTypeViewRaRoutingModule { }


