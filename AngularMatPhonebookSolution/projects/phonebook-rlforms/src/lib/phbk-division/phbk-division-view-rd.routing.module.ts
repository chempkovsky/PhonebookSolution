


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { PhbkDivisionViewRDComponent } from './rdform/phbk-division-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: PhbkDivisionViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhbkDivisionViewRdRoutingModule { }


