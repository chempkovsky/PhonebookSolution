


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetrolemaskViewRlistComponent } from './rlist/aspnetrolemask-view-rlist.component';

const rllzaspnetrolemaskView: {[key:string]: string} = {
} 


const routes: Routes = [
 {
    path: '',
    component: AspnetrolemaskViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [




    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetrolemaskViewRlRoutingModule { }


