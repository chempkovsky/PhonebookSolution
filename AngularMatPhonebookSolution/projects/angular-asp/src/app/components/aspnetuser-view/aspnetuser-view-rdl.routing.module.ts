


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserViewRdlistComponent } from './rdlist/aspnetuser-view-rdlist.component';


const rdllzaspnetuserView: {[key:string]: string} = {
        'ListaspnetuserrolesView': $localize`:User Roles@@rdllzaspnetuserView.aspnetuserrolesView:User Roles`,
        'ListaspnetusermaskView': $localize`:User Masks@@rdllzaspnetuserView.aspnetusermaskView:User Masks`,
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetuserViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { 
//        outlet: 'dloltnmaspnetuserView',
        path: 'dloltnmaspnetuserView2aspnetuserrolesView/:hf102', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rdl-lazy.routing.module').then(m => m.AspnetuserrolesViewRdlLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'l', ms: true, /* oltn: 'dloltnmaspnetuserView', */ np: '', fh: 2, mh: 10, sf: true, title: rdllzaspnetuserView['ListaspnetuserrolesView'], hf: 'hf102',  dp: 2, uid: 'e4c367ffe4a74c0794a2a35aa71ae254' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetusermaskView] 
//
    { 
//        outlet: 'dloltnmaspnetuserView',
        path: 'dloltnmaspnetuserView2aspnetusermaskView/:hf102', 
        loadChildren: () => import('./../aspnetusermask-view/aspnetusermask-view-rdl-lazy.routing.module').then(m => m.AspnetusermaskViewRdlLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetusermaskView', va: 'l', ms: true, /* oltn: 'dloltnmaspnetuserView', */ np: '', fh: 2, mh: 10, sf: true, title: rdllzaspnetuserView['ListaspnetusermaskView'], hf: 'hf102',  dp: 2, uid: '88ca1ba9eba145bf9408c7ec9f532c27' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserViewRdlRoutingModule { }


