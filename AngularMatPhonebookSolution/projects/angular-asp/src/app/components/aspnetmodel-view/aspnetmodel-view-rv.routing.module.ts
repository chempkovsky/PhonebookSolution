


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetmodelViewRVComponent } from './rvform/aspnetmodel-view-r-v.component';

const rvllzaspnetmodelView: {[key:string]: string} = {
        'ViewaspnetusermaskView': $localize`:View User Masks@@rvllzaspnetmodelView.ViewaspnetusermaskView:View User Mask`,
        'AddaspnetusermaskView': $localize`:Add User Mask  @@rvllzaspnetmodelView.AddaspnetusermaskView:Add User Mask`,
        'UpdateaspnetusermaskView': $localize`:Update User Mask  @@rvllzaspnetmodelView.UpdateaspnetusermaskView:Update User Mask`,
        'DeleteaspnetusermaskView': $localize`:Delete User Mask  @@rvllzaspnetmodelView.DeleteaspnetusermaskView:Delete User Mask`,
        'ListaspnetusermaskView': $localize`:User Masks  @@rvllzaspnetmodelView.ListaspnetusermaskView:User Masks`,
        'ViewaspnetrolemaskView': $localize`:View Role Masks@@rvllzaspnetmodelView.ViewaspnetrolemaskView:View Role Mask`,
        'AddaspnetrolemaskView': $localize`:Add Role Mask  @@rvllzaspnetmodelView.AddaspnetrolemaskView:Add Role Mask`,
        'UpdateaspnetrolemaskView': $localize`:Update Role Mask  @@rvllzaspnetmodelView.UpdateaspnetrolemaskView:Update Role Mask`,
        'DeleteaspnetrolemaskView': $localize`:Delete Role Mask  @@rvllzaspnetmodelView.DeleteaspnetrolemaskView:Delete Role Mask`,
        'ListaspnetrolemaskView': $localize`:Role Masks  @@rvllzaspnetmodelView.ListaspnetrolemaskView:Role Masks`,
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetmodelViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [aspnetmodelView] 
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
        // outlet: 'oltnmaspnetmodelView',
        path: 'oltnmaspnetmodelView2aspnetusermaskView/:hf102', 
        loadChildren: () => import('./../aspnetusermask-view/aspnetusermask-view-rl.routing.module').then(m => m.AspnetusermaskViewRlRoutingModule),
        data: {  isdtl: true, vn: 'aspnetusermaskView', va: 'l', ms: true,  /* oltn: 'oltnmaspnetmodelView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzaspnetmodelView['ListaspnetusermaskView'], hf: 'hf102',  dp: 2, uid: '0f3632d2eefa4d71a6e250f4356d496d' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetrolemaskView] 
//
    { 
        // outlet: 'oltnmaspnetmodelView',
        // path: 'oltnmaspnetmodelView2ViewaspnetrolemaskView/:hf103/:id103', 
        path: 'oltnmaspnetmodelView2aspnetrolemaskView/:hf102/ViewaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module').then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'v', /* oltp: 'oltnmaspnetmodelView2aspnetrolemaskView',  oltn: 'oltnmaspnetmodelView', */ np: '', /* sf: true, */ title: rvllzaspnetmodelView['ViewaspnetrolemaskView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetmodelView',
        // path: 'oltnmaspnetmodelView2AddaspnetrolemaskView/:hf103', 
        path: 'oltnmaspnetmodelView2aspnetrolemaskView/:hf102/AddaspnetrolemaskView/:hf103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module').then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'a', /* oltp: 'oltnmaspnetmodelView2aspnetrolemaskView',  oltn: 'oltnmaspnetmodelView', */ np: '', /* sf: true, */ title: rvllzaspnetmodelView['AddaspnetrolemaskView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetmodelView',
        // path: 'oltnmaspnetmodelView2UpdaspnetrolemaskView/:hf103/:id103', 
        path: 'oltnmaspnetmodelView2aspnetrolemaskView/:hf102/UpdaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module').then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'u', /* oltp: 'oltnmaspnetmodelView2aspnetrolemaskView',  oltn: 'oltnmaspnetmodelView', */ np: '', /* sf: true, */ title: rvllzaspnetmodelView['UpdateaspnetrolemaskView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetmodelView',
        // path: 'oltnmaspnetmodelView2DelaspnetrolemaskView/:hf103/:id103', 
        path: 'oltnmaspnetmodelView2aspnetrolemaskView/:hf102/DelaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module').then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'd', /* oltp: 'oltnmaspnetmodelView2aspnetrolemaskView', oltn: 'oltnmaspnetmodelView', */ np: '', /* sf: true, */ title: rvllzaspnetmodelView['DeleteaspnetrolemaskView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetmodelView',
        path: 'oltnmaspnetmodelView2aspnetrolemaskView/:hf102', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rl.routing.module').then(m => m.AspnetrolemaskViewRlRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'l', ms: true,  /* oltn: 'oltnmaspnetmodelView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzaspnetmodelView['ListaspnetrolemaskView'], hf: 'hf102',  dp: 2, uid: 'fcb47dd431ee43c8aea29bb3ca4ca26f' },
        canActivate: [AppGlblSettingsServiceActivator],
    },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetmodelViewRvRoutingModule { }


