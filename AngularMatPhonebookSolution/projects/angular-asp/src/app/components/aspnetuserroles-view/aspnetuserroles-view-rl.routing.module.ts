


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserrolesViewRlistComponent } from './rlist/aspnetuserroles-view-rlist.component';

const rllzaspnetuserrolesView: {[key:string]: string} = {
} 


const routes: Routes = [
 {
    path: '',
    component: AspnetuserrolesViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [




    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserrolesViewRlRoutingModule { }


