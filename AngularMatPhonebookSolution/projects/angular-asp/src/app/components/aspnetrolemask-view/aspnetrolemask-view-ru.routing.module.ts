


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetrolemaskViewRUComponent } from './ruform/aspnetrolemask-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetrolemaskViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetrolemaskViewRuRoutingModule { }


