


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetmodelViewRUComponent } from './ruform/aspnetmodel-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetmodelViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetmodelViewRuRoutingModule { }


