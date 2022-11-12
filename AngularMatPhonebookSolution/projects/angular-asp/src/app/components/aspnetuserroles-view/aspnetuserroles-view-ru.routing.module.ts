


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserrolesViewRUComponent } from './ruform/aspnetuserroles-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetuserrolesViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserrolesViewRuRoutingModule { }


