


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneViewRDComponent } from './rdform/phbk-phone-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneViewRdRoutingModule { }


