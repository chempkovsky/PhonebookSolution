


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserrolesViewRVComponent } from './rvform/aspnetuserroles-view-r-v.component';

const rvllzaspnetuserrolesView: {[key:string]: string} = {
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetuserrolesViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserrolesViewRvRoutingModule { }


