


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkDivisionViewRUComponent } from './ruform/phbk-division-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: PhbkDivisionViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkDivisionViewRuRoutingModule { }


