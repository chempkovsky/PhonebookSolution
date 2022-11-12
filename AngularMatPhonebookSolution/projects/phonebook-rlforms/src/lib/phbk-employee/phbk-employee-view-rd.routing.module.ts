


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEmployeeViewRDComponent } from './rdform/phbk-employee-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: PhbkEmployeeViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEmployeeViewRdRoutingModule { }


