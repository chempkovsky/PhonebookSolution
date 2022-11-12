


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserViewRUComponent } from './ruform/aspnetuser-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetuserViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserViewRuRoutingModule { }


