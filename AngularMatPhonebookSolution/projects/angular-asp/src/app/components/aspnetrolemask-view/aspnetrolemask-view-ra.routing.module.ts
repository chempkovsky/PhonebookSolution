


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetrolemaskViewRAComponent } from './raform/aspnetrolemask-view-r-a.component';


const routes: Routes = [
 {
    path: '',
    component: AspnetrolemaskViewRAComponent,
    canActivate: [AppGlblSettingsServiceActivator]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetrolemaskViewRaRoutingModule { }


