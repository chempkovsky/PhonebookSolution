


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkEmployeeViewRAComponent } from './raform/phbk-employee-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkEmployeeViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkEmployeeViewRaRoutingModule { }


