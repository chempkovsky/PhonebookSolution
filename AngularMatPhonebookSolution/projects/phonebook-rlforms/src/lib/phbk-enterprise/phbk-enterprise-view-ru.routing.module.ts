


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEnterpriseViewRUComponent } from './ruform/phbk-enterprise-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkEnterpriseViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEnterpriseViewRuRoutingModule { }


