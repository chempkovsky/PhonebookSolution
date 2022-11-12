


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetroleViewRAComponent } from './raform/aspnetrole-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetroleViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetroleViewRaRoutingModule { }


