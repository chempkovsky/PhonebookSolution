


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetmodelViewRDComponent } from './rdform/aspnetmodel-view-r-d.component';

const routes: Routes = [
 {
    path: '',
    component: AspnetmodelViewRDComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetmodelViewRdRoutingModule { }


