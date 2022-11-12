


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetroleViewRdlistComponent } from './rdlist/aspnetrole-view-rdlist.component';


const rdllzaspnetroleView: {[key:string]: string} = {
        'ListaspnetuserrolesView': $localize`:User Roles@@rdllzaspnetroleView.aspnetuserrolesView:User Roles`,
        'ListaspnetrolemaskView': $localize`:Role Masks@@rdllzaspnetroleView.aspnetrolemaskView:Role Masks`,
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetroleViewRdlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { 
//        outlet: 'dloltnmaspnetroleView',
        path: 'dloltnmaspnetroleView2aspnetuserrolesView/:hf102', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rdl-lazy.routing.module').then(m => m.AspnetuserrolesViewRdlLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'l', ms: true, /* oltn: 'dloltnmaspnetroleView', */ np: '', fh: 2, mh: 10, sf: true, title: rdllzaspnetroleView['ListaspnetuserrolesView'], hf: 'hf102',  dp: 2, uid: '6cc616ee00cf4e808683f9981b90340b' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetrolemaskView] 
//
    { 
//        outlet: 'dloltnmaspnetroleView',
        path: 'dloltnmaspnetroleView2aspnetrolemaskView/:hf102', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rdl-lazy.routing.module').then(m => m.AspnetrolemaskViewRdlLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'l', ms: true, /* oltn: 'dloltnmaspnetroleView', */ np: '', fh: 2, mh: 10, sf: true, title: rdllzaspnetroleView['ListaspnetrolemaskView'], hf: 'hf102',  dp: 2, uid: '9f49714009b44f5d92b0eb55a2d1c144' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetroleViewRdlRoutingModule { }


