


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetroleViewRUComponent } from './ruform/aspnetrole-view-r-u.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetroleViewRUComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetroleViewRuRoutingModule { }


