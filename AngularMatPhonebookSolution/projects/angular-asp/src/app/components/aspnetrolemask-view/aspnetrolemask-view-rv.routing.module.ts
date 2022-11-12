


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetrolemaskViewRVComponent } from './rvform/aspnetrolemask-view-r-v.component';

const rvllzaspnetrolemaskView: {[key:string]: string} = {
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetrolemaskViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetrolemaskViewRvRoutingModule { }


