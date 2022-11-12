


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEnterpriseViewRDComponent } from './rdform/phbk-enterprise-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: PhbkEnterpriseViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEnterpriseViewRdRoutingModule { }


