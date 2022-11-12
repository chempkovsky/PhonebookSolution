


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetroleViewRVComponent } from './rvform/aspnetrole-view-r-v.component';

const rvllzaspnetroleView: {[key:string]: string} = {
        'ViewaspnetuserrolesView': $localize`:View User Roles@@rvllzaspnetroleView.ViewaspnetuserrolesView:View User Role`,
        'AddaspnetuserrolesView': $localize`:Add User Role  @@rvllzaspnetroleView.AddaspnetuserrolesView:Add User Role`,
        'UpdateaspnetuserrolesView': $localize`:Update User Role  @@rvllzaspnetroleView.UpdateaspnetuserrolesView:Update User Role`,
        'DeleteaspnetuserrolesView': $localize`:Delete User Role  @@rvllzaspnetroleView.DeleteaspnetuserrolesView:Delete User Role`,
        'ListaspnetuserrolesView': $localize`:User Roles  @@rvllzaspnetroleView.ListaspnetuserrolesView:User Roles`,
        'ViewaspnetrolemaskView': $localize`:View Role Masks@@rvllzaspnetroleView.ViewaspnetrolemaskView:View Role Mask`,
        'AddaspnetrolemaskView': $localize`:Add Role Mask  @@rvllzaspnetroleView.AddaspnetrolemaskView:Add Role Mask`,
        'UpdateaspnetrolemaskView': $localize`:Update Role Mask  @@rvllzaspnetroleView.UpdateaspnetrolemaskView:Update Role Mask`,
        'DeleteaspnetrolemaskView': $localize`:Delete Role Mask  @@rvllzaspnetroleView.DeleteaspnetrolemaskView:Delete Role Mask`,
        'ListaspnetrolemaskView': $localize`:Role Masks  @@rvllzaspnetroleView.ListaspnetrolemaskView:Role Masks`,
} 

const routes: Routes = [
 {
    path: '',
    component: AspnetroleViewRVComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [

//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2ViewaspnetuserrolesView/:hf103/:id103', 
        path: 'oltnmaspnetroleView2aspnetuserrolesView/:hf102/ViewaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module').then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'v', /* oltp: 'oltnmaspnetroleView2aspnetuserrolesView',  oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['ViewaspnetuserrolesView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2AddaspnetuserrolesView/:hf103', 
        path: 'oltnmaspnetroleView2aspnetuserrolesView/:hf102/AddaspnetuserrolesView/:hf103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module').then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'a', /* oltp: 'oltnmaspnetroleView2aspnetuserrolesView',  oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['AddaspnetuserrolesView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2UpdaspnetuserrolesView/:hf103/:id103', 
        path: 'oltnmaspnetroleView2aspnetuserrolesView/:hf102/UpdaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module').then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'u', /* oltp: 'oltnmaspnetroleView2aspnetuserrolesView',  oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['UpdateaspnetuserrolesView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2DelaspnetuserrolesView/:hf103/:id103', 
        path: 'oltnmaspnetroleView2aspnetuserrolesView/:hf102/DelaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module').then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'd', /* oltp: 'oltnmaspnetroleView2aspnetuserrolesView', oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['DeleteaspnetuserrolesView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        path: 'oltnmaspnetroleView2aspnetuserrolesView/:hf102', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rl.routing.module').then(m => m.AspnetuserrolesViewRlRoutingModule),
        data: {  isdtl: true, vn: 'aspnetuserrolesView', va: 'l', ms: true,  /* oltn: 'oltnmaspnetroleView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzaspnetroleView['ListaspnetuserrolesView'], hf: 'hf102',  dp: 2, uid: '5ad429d5a5684962b6d9ab8e47a8e087' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetrolemaskView] 
//
    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2ViewaspnetrolemaskView/:hf103/:id103', 
        path: 'oltnmaspnetroleView2aspnetrolemaskView/:hf102/ViewaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module').then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'v', /* oltp: 'oltnmaspnetroleView2aspnetrolemaskView',  oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['ViewaspnetrolemaskView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2AddaspnetrolemaskView/:hf103', 
        path: 'oltnmaspnetroleView2aspnetrolemaskView/:hf102/AddaspnetrolemaskView/:hf103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module').then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'a', /* oltp: 'oltnmaspnetroleView2aspnetrolemaskView',  oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['AddaspnetrolemaskView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2UpdaspnetrolemaskView/:hf103/:id103', 
        path: 'oltnmaspnetroleView2aspnetrolemaskView/:hf102/UpdaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module').then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'u', /* oltp: 'oltnmaspnetroleView2aspnetrolemaskView',  oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['UpdateaspnetrolemaskView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        // path: 'oltnmaspnetroleView2DelaspnetrolemaskView/:hf103/:id103', 
        path: 'oltnmaspnetroleView2aspnetrolemaskView/:hf102/DelaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module').then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'd', /* oltp: 'oltnmaspnetroleView2aspnetrolemaskView', oltn: 'oltnmaspnetroleView', */ np: '', /* sf: true, */ title: rvllzaspnetroleView['DeleteaspnetrolemaskView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
        // outlet: 'oltnmaspnetroleView',
        path: 'oltnmaspnetroleView2aspnetrolemaskView/:hf102', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rl.routing.module').then(m => m.AspnetrolemaskViewRlRoutingModule),
        data: {  isdtl: true, vn: 'aspnetrolemaskView', va: 'l', ms: true,  /* oltn: 'oltnmaspnetroleView', */ np: '', fh: 2, mh: 10, sf: true, title: rvllzaspnetroleView['ListaspnetrolemaskView'], hf: 'hf102',  dp: 2, uid: '1f11ab2d8a6b4044a9590aed26664ef6' },
        canActivate: [AppGlblSettingsServiceActivator],
    },

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetroleViewRvRoutingModule { }


