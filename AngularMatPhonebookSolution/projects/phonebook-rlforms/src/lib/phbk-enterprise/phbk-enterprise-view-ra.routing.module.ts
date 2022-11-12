


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEnterpriseViewRAComponent } from './raform/phbk-enterprise-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkEnterpriseViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEnterpriseViewRaRoutingModule { }


