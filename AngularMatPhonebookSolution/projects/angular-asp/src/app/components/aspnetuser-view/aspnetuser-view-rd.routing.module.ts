


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserViewRDComponent } from './rdform/aspnetuser-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: AspnetuserViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserViewRdRoutingModule { }


