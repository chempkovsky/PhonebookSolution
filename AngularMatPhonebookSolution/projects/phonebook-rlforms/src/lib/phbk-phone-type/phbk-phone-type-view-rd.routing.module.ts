


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkPhoneTypeViewRDComponent } from './rdform/phbk-phone-type-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: PhbkPhoneTypeViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkPhoneTypeViewRdRoutingModule { }


