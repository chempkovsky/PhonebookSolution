


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserViewRVComponent } from './rvform/aspnetuser-view-r-v.component';

const rvllzaspnetuserView: {[key:string]: string} = {
        'ViewaspnetuserrolesView': $localize`:View User Roles@@rvllzaspnetuserView.ViewaspnetuserrolesView:View User Role`,
        'AddaspnetuserrolesView': $localize`:Add User Role  @@rvllzaspnetuserView.AddaspnetuserrolesView:Add User Role`,
        'UpdateaspnetuserrolesView': $localize`:Update User Role  @@rvllzaspnetuserView.UpdateaspnetuserrolesView:Update User Role`,
        'DeleteaspnetuserrolesView': $localize`:Delete User Role  @@rvllzaspnetuserView.DeleteaspnetuserrolesView:Delete User Role`,
        'ListaspnetuserrolesView': $localize`:User Roles  @@rvllzaspnetuserView.ListaspnetuserrolesView:User Roles`,
        'ViewaspnetusermaskView': $localize`:View User Masks@@rvllzaspnetuserView.ViewaspnetusermaskView:View User Mask`,
        'AddaspnetusermaskView': $localize`:Add User Mask  @@rvllzaspnetuserView.AddaspnetusermaskView:Add User Mask`,
        'UpdateaspnetusermaskView': $localize`:Update User Mask  @@rvllzaspnetuserView.UpdateaspnetusermaskView:Update User Mask`,
        'DeleteaspnetusermaskView': $localize`:Delete User Mask  @@rvllzaspnetuserView.DeleteaspnetusermaskView:Delete User Mask`,
        'ListaspnetusermaskView': $localize`:User Masks  @@rvllzaspnetuserView.ListaspnetusermaskView:User Masks`,
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetuserViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { 
        // outlet: 'oltnmaspnetuserView',
        // path: 'oltnmaspnetuserView2ViewaspnetuserrolesView/:hf103/:id103', 
        path: 'oltnmaspnetuserView2aspnetuserrolesView/:hf102/ViewaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module').then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'v', /* oltp: 'oltnmaspnetuserView2aspnetuserrolesView',  oltn: 'oltnmaspnetuserView', */ np: '', /* sf: true, */ title: rvllzaspnetuserView['ViewaspnetuserrolesView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetuserView',
        // path: 'oltnmaspnetuserView2AddaspnetuserrolesView/:hf103', 
        path: 'oltnmaspnetuserView2aspnetuserrolesView/:hf102/AddaspnetuserrolesView/:hf103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module').then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'a', /* oltp: 'oltnmaspnetuserView2aspnetuserrolesView',  oltn: 'oltnmaspnetuserView', */ np: '', /* sf: true, */ title: rvllzaspnetuserView['AddaspnetuserrolesView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetuserView',
        // path: 'oltnmaspnetuserView2UpdaspnetuserrolesView/:hf103/:id103', 
        path: 'oltnmaspnetuserView2aspnetuserrolesView/:hf102/UpdaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module').then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'u', /* oltp: 'oltnmaspnetuserView2aspnetuserrolesView',  oltn: 'oltnmaspnetuserView', */ np: '', /* sf: true, */ title: rvllzaspnetuserView['UpdateaspnetuserrolesView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetuserView',
        // path: 'oltnmaspnetuserView2DelaspnetuserrolesView/:hf103/:id103', 
        path: 'oltnmaspnetuserView2aspnetuserrolesView/:hf102/DelaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module').then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'd', /* oltp: 'oltnmaspnetuserView2aspnetuserrolesView', oltn: 'oltnmaspnetuserView', */ np: '', /* sf: true, */ title: rvllzaspnetuserView['DeleteaspnetuserrolesView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetuserView',
        path: 'oltnmaspnetuserView2aspnetuserrolesView/:hf102', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rl.routing.module').then(m => m.AspnetuserrolesViewRlRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'l', ms: true,  /* oltn: 'oltnmaspnetuserView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzaspnetuserView['ListaspnetuserrolesView'], hf: 'hf102',  dp: 2, uid: '04c2b55248334754a813bb83ddc5a705' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetusermaskView] 
//
//
//warning: for the View   [aspnetusermaskView] SelectOneByPrimarykey is set to false
//
//
//warning: for the View   [aspnetusermaskView] WebApiAdd is set to false
//
//
//warning: for the View   [aspnetusermaskView] WebApiUpdate is set to false
//
//
//warning: for the View   [aspnetusermaskView] WebApiDelete is set to false
//
    { 
        // outlet: 'oltnmaspnetuserView',
        path: 'oltnmaspnetuserView2aspnetusermaskView/:hf102', 
        loadChildren: () => import('./../aspnetusermask-view/aspnetusermask-view-rl.routing.module').then(m => m.AspnetusermaskViewRlRoutingModule),
        data: {  isdtl: true, vn: 'aspnetusermaskView', va: 'l', ms: true,  /* oltn: 'oltnmaspnetuserView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzaspnetuserView['ListaspnetusermaskView'], hf: 'hf102',  dp: 2, uid: '685016b5f0b54d3e9b91948d95a5fa01' },
        canActivate: [AppGlblSettingsServiceActivator],
    },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserViewRvRoutingModule { }


