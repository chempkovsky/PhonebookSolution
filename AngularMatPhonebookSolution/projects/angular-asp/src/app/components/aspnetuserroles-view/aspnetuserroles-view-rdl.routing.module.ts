


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserrolesViewRdlistComponent } from './rdlist/aspnetuserroles-view-rdlist.component';


const rdllzaspnetuserrolesView: {[key:string]: string} = {
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetuserrolesViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserrolesViewRdlRoutingModule { }


