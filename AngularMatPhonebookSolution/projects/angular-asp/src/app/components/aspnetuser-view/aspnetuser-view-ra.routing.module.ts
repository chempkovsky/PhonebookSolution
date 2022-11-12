


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserViewRAComponent } from './raform/aspnetuser-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetuserViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserViewRaRoutingModule { }


