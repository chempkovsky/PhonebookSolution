


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetusermaskViewRlistComponent } from './rlist/aspnetusermask-view-rlist.component';

const rllzaspnetusermaskView: {[key:string]: string} = {
} 


const routes: Routes = [
 {
    path: '',
    component: AspnetusermaskViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [




    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetusermaskViewRlRoutingModule { }


