


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetmodelViewRlistComponent } from './rlist/aspnetmodel-view-rlist.component';

const rllzaspnetmodelView: {[key:string]: string} = {
        'ViewaspnetusermaskView': $localize`:View User Masks@@rllzaspnetmodelView.ViewaspnetusermaskView:View User Mask`,
        'AddaspnetusermaskView': $localize`:Add User Mask  @@rllzaspnetmodelView.AddaspnetusermaskView:Add User Mask`,
        'UpdateaspnetusermaskView': $localize`:Update User Mask  @@rllzaspnetmodelView.UpdateaspnetusermaskView:Update User Mask`,
        'DeleteaspnetusermaskView': $localize`:Delete User Mask  @@rllzaspnetmodelView.DeleteaspnetusermaskView:Delete User Mask`,
        'ListaspnetusermaskView': $localize`:User Masks  @@rllzaspnetmodelView.ListaspnetusermaskView:User Masks`,
        'ViewaspnetrolemaskView': $localize`:View Role Masks@@rllzaspnetmodelView.ViewaspnetrolemaskView:View Role Mask`,
        'AddaspnetrolemaskView': $localize`:Add Role Mask  @@rllzaspnetmodelView.AddaspnetrolemaskView:Add Role Mask`,
        'UpdateaspnetrolemaskView': $localize`:Update Role Mask  @@rllzaspnetmodelView.UpdateaspnetrolemaskView:Update Role Mask`,
        'DeleteaspnetrolemaskView': $localize`:Delete Role Mask  @@rllzaspnetmodelView.DeleteaspnetrolemaskView:Delete Role Mask`,
        'ListaspnetrolemaskView': $localize`:Role Masks  @@rllzaspnetmodelView.ListaspnetrolemaskView:Role Masks`,
} 


const routes: Routes = [
 {
    path: '',
    component: AspnetmodelViewRlistComponent,
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
//        outlet: 'loltnmaspnetmodelView',
        path: 'loltnmaspnetmodelView2aspnetusermaskView/:hf102', 
        loadChildren: () => import('./../aspnetusermask-view/aspnetusermask-view-rl.routing.module').then(m => m.AspnetusermaskViewRlRoutingModule),
        data: { isdtl: true, vn: 'aspnetusermaskView', va: 'l', ms: true,  /* oltn: 'loltnmaspnetmodelView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzaspnetmodelView['ListaspnetusermaskView'],  hf: 'hf102',  dp: 2, uid: '3495933931ed4c88bf09149c7f462383' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetrolemaskView] 
//
    { 
//        outlet: 'loltnmaspnetmodelView',
//        path: 'loltnmaspnetmodelView2ViewaspnetrolemaskView/:hf103/:id103', 
        path: 'loltnmaspnetmodelView2aspnetrolemaskView/:hf102/ViewaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module').then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'v', /* oltp: 'loltnmaspnetmodelView2aspnetrolemaskView', oltn: 'loltnmaspnetmodelView', */ np: '', /* sf: true, */   title: rllzaspnetmodelView['ViewaspnetrolemaskView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetmodelView',
//        path: 'loltnmaspnetmodelView2AddaspnetrolemaskView/:hf103', 
        path: 'loltnmaspnetmodelView2aspnetrolemaskView/:hf102/AddaspnetrolemaskView/:hf103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module').then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'a', /* oltp: 'loltnmaspnetmodelView2aspnetrolemaskView', oltn: 'loltnmaspnetmodelView', */ np: '', /* sf: true, */  title: rllzaspnetmodelView['AddaspnetrolemaskView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetmodelView',
//        path: 'loltnmaspnetmodelView2UpdaspnetrolemaskView/:hf103/:id103', 
        path: 'loltnmaspnetmodelView2aspnetrolemaskView/:hf102/UpdaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module').then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'u', /* oltp: 'loltnmaspnetmodelView2aspnetrolemaskView', oltn: 'loltnmaspnetmodelView', */  np: '', /* sf: true, */   title: rllzaspnetmodelView['UpdateaspnetrolemaskView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetmodelView',
//        path: 'loltnmaspnetmodelView2DelaspnetrolemaskView/:hf103/:id103', 
        path: 'loltnmaspnetmodelView2aspnetrolemaskView/:hf102/DelaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module').then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'd', /* oltp: 'loltnmaspnetmodelView2aspnetrolemaskView', oltn: 'loltnmaspnetmodelView', */ np: '', /* sf: true, */  title: rllzaspnetmodelView['DeleteaspnetrolemaskView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetmodelView',
        path: 'loltnmaspnetmodelView2aspnetrolemaskView/:hf102', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rl.routing.module').then(m => m.AspnetrolemaskViewRlRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'l', ms: true,  /* oltn: 'loltnmaspnetmodelView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzaspnetmodelView['ListaspnetrolemaskView'],  hf: 'hf102',  dp: 2, uid: 'dace1625a1324bce836f59a3620fb706' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetmodelViewRlRoutingModule { }


