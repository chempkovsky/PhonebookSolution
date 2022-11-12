


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetusermaskViewRdlistComponent } from './rdlist/aspnetusermask-view-rdlist.component';


const rdllzaspnetusermaskView: {[key:string]: string} = {
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetusermaskViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetusermaskViewRdlRoutingModule { }


