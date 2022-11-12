


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetroleViewRlistComponent } from './rlist/aspnetrole-view-rlist.component';

const rllzaspnetroleView: {[key:string]: string} = {
        'ViewaspnetuserrolesView': $localize`:View User Roles@@rllzaspnetroleView.ViewaspnetuserrolesView:View User Role`,
        'AddaspnetuserrolesView': $localize`:Add User Role  @@rllzaspnetroleView.AddaspnetuserrolesView:Add User Role`,
        'UpdateaspnetuserrolesView': $localize`:Update User Role  @@rllzaspnetroleView.UpdateaspnetuserrolesView:Update User Role`,
        'DeleteaspnetuserrolesView': $localize`:Delete User Role  @@rllzaspnetroleView.DeleteaspnetuserrolesView:Delete User Role`,
        'ListaspnetuserrolesView': $localize`:User Roles  @@rllzaspnetroleView.ListaspnetuserrolesView:User Roles`,
        'ViewaspnetrolemaskView': $localize`:View Role Masks@@rllzaspnetroleView.ViewaspnetrolemaskView:View Role Mask`,
        'AddaspnetrolemaskView': $localize`:Add Role Mask  @@rllzaspnetroleView.AddaspnetrolemaskView:Add Role Mask`,
        'UpdateaspnetrolemaskView': $localize`:Update Role Mask  @@rllzaspnetroleView.UpdateaspnetrolemaskView:Update Role Mask`,
        'DeleteaspnetrolemaskView': $localize`:Delete Role Mask  @@rllzaspnetroleView.DeleteaspnetrolemaskView:Delete Role Mask`,
        'ListaspnetrolemaskView': $localize`:Role Masks  @@rllzaspnetroleView.ListaspnetrolemaskView:Role Masks`,
} 


const routes: Routes = [
 {
    path: '',
    component: AspnetroleViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [



//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2ViewaspnetuserrolesView/:hf103/:id103', 
        path: 'loltnmaspnetroleView2aspnetuserrolesView/:hf102/ViewaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module').then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'v', /* oltp: 'loltnmaspnetroleView2aspnetuserrolesView', oltn: 'loltnmaspnetroleView', */ np: '', /* sf: true, */   title: rllzaspnetroleView['ViewaspnetuserrolesView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2AddaspnetuserrolesView/:hf103', 
        path: 'loltnmaspnetroleView2aspnetuserrolesView/:hf102/AddaspnetuserrolesView/:hf103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module').then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'a', /* oltp: 'loltnmaspnetroleView2aspnetuserrolesView', oltn: 'loltnmaspnetroleView', */ np: '', /* sf: true, */  title: rllzaspnetroleView['AddaspnetuserrolesView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2UpdaspnetuserrolesView/:hf103/:id103', 
        path: 'loltnmaspnetroleView2aspnetuserrolesView/:hf102/UpdaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module').then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'u', /* oltp: 'loltnmaspnetroleView2aspnetuserrolesView', oltn: 'loltnmaspnetroleView', */  np: '', /* sf: true, */   title: rllzaspnetroleView['UpdateaspnetuserrolesView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2DelaspnetuserrolesView/:hf103/:id103', 
        path: 'loltnmaspnetroleView2aspnetuserrolesView/:hf102/DelaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module').then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'd', /* oltp: 'loltnmaspnetroleView2aspnetuserrolesView', oltn: 'loltnmaspnetroleView', */ np: '', /* sf: true, */  title: rllzaspnetroleView['DeleteaspnetuserrolesView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
        path: 'loltnmaspnetroleView2aspnetuserrolesView/:hf102', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rl.routing.module').then(m => m.AspnetuserrolesViewRlRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'l', ms: true,  /* oltn: 'loltnmaspnetroleView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzaspnetroleView['ListaspnetuserrolesView'],  hf: 'hf102',  dp: 2, uid: '5917bcba4ca44dbbba9f2d7c7c7b4582' },
        canActivate: [AppGlblSettingsServiceActivator],
    },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetrolemaskView] 
//
    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2ViewaspnetrolemaskView/:hf103/:id103', 
        path: 'loltnmaspnetroleView2aspnetrolemaskView/:hf102/ViewaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module').then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'v', /* oltp: 'loltnmaspnetroleView2aspnetrolemaskView', oltn: 'loltnmaspnetroleView', */ np: '', /* sf: true, */   title: rllzaspnetroleView['ViewaspnetrolemaskView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2AddaspnetrolemaskView/:hf103', 
        path: 'loltnmaspnetroleView2aspnetrolemaskView/:hf102/AddaspnetrolemaskView/:hf103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module').then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'a', /* oltp: 'loltnmaspnetroleView2aspnetrolemaskView', oltn: 'loltnmaspnetroleView', */ np: '', /* sf: true, */  title: rllzaspnetroleView['AddaspnetrolemaskView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2UpdaspnetrolemaskView/:hf103/:id103', 
        path: 'loltnmaspnetroleView2aspnetrolemaskView/:hf102/UpdaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module').then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'u', /* oltp: 'loltnmaspnetroleView2aspnetrolemaskView', oltn: 'loltnmaspnetroleView', */  np: '', /* sf: true, */   title: rllzaspnetroleView['UpdateaspnetrolemaskView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
//        path: 'loltnmaspnetroleView2DelaspnetrolemaskView/:hf103/:id103', 
        path: 'loltnmaspnetroleView2aspnetrolemaskView/:hf102/DelaspnetrolemaskView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module').then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'd', /* oltp: 'loltnmaspnetroleView2aspnetrolemaskView', oltn: 'loltnmaspnetroleView', */ np: '', /* sf: true, */  title: rllzaspnetroleView['DeleteaspnetrolemaskView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetroleView',
        path: 'loltnmaspnetroleView2aspnetrolemaskView/:hf102', 
        loadChildren: () => import('./../aspnetrolemask-view/aspnetrolemask-view-rl.routing.module').then(m => m.AspnetrolemaskViewRlRoutingModule),
        data: { isdtl: true, vn: 'aspnetrolemaskView', va: 'l', ms: true,  /* oltn: 'loltnmaspnetroleView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzaspnetroleView['ListaspnetrolemaskView'],  hf: 'hf102',  dp: 2, uid: 'a9035109e93d4a7bb1d205e48d4b009d' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetroleViewRlRoutingModule { }


