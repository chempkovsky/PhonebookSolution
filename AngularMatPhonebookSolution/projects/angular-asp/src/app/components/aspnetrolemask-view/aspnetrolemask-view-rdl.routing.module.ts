


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetrolemaskViewRdlistComponent } from './rdlist/aspnetrolemask-view-rdlist.component';


const rdllzaspnetrolemaskView: {[key:string]: string} = {
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetrolemaskViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetrolemaskViewRdlRoutingModule { }


