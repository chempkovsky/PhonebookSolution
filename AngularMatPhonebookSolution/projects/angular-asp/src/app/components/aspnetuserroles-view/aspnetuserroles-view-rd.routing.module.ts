


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserrolesViewRDComponent } from './rdform/aspnetuserroles-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: AspnetuserrolesViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserrolesViewRdRoutingModule { }


