


import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspnetuserViewRlistComponent } from './rlist/aspnetuser-view-rlist.component';

const rllzaspnetuserView: {[key:string]: string} = {
        'ViewaspnetuserrolesView': $localize`:View User Roles@@rllzaspnetuserView.ViewaspnetuserrolesView:View User Role`,
        'AddaspnetuserrolesView': $localize`:Add User Role  @@rllzaspnetuserView.AddaspnetuserrolesView:Add User Role`,
        'UpdateaspnetuserrolesView': $localize`:Update User Role  @@rllzaspnetuserView.UpdateaspnetuserrolesView:Update User Role`,
        'DeleteaspnetuserrolesView': $localize`:Delete User Role  @@rllzaspnetuserView.DeleteaspnetuserrolesView:Delete User Role`,
        'ListaspnetuserrolesView': $localize`:User Roles  @@rllzaspnetuserView.ListaspnetuserrolesView:User Roles`,
        'ViewaspnetusermaskView': $localize`:View User Masks@@rllzaspnetuserView.ViewaspnetusermaskView:View User Mask`,
        'AddaspnetusermaskView': $localize`:Add User Mask  @@rllzaspnetuserView.AddaspnetusermaskView:Add User Mask`,
        'UpdateaspnetusermaskView': $localize`:Update User Mask  @@rllzaspnetuserView.UpdateaspnetusermaskView:Update User Mask`,
        'DeleteaspnetusermaskView': $localize`:Delete User Mask  @@rllzaspnetuserView.DeleteaspnetusermaskView:Delete User Mask`,
        'ListaspnetusermaskView': $localize`:User Masks  @@rllzaspnetuserView.ListaspnetusermaskView:User Masks`,
} 


const routes: Routes = [
 {
    path: '',
    component: AspnetuserViewRlistComponent,
    canActivate: [AppGlblSettingsServiceActivator],
    children: [



//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { 
//        outlet: 'loltnmaspnetuserView',
//        path: 'loltnmaspnetuserView2ViewaspnetuserrolesView/:hf103/:id103', 
        path: 'loltnmaspnetuserView2aspnetuserrolesView/:hf102/ViewaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module').then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'v', /* oltp: 'loltnmaspnetuserView2aspnetuserrolesView', oltn: 'loltnmaspnetuserView', */ np: '', /* sf: true, */   title: rllzaspnetuserView['ViewaspnetuserrolesView'], hf: 'hf103',  id: 'id103', dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetuserView',
//        path: 'loltnmaspnetuserView2AddaspnetuserrolesView/:hf103', 
        path: 'loltnmaspnetuserView2aspnetuserrolesView/:hf102/AddaspnetuserrolesView/:hf103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module').then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'a', /* oltp: 'loltnmaspnetuserView2aspnetuserrolesView', oltn: 'loltnmaspnetuserView', */ np: '', /* sf: true, */  title: rllzaspnetuserView['AddaspnetuserrolesView'], hf: 'hf103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetuserView',
//        path: 'loltnmaspnetuserView2UpdaspnetuserrolesView/:hf103/:id103', 
        path: 'loltnmaspnetuserView2aspnetuserrolesView/:hf102/UpdaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module').then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'u', /* oltp: 'loltnmaspnetuserView2aspnetuserrolesView', oltn: 'loltnmaspnetuserView', */  np: '', /* sf: true, */   title: rllzaspnetuserView['UpdateaspnetuserrolesView'], hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetuserView',
//        path: 'loltnmaspnetuserView2DelaspnetuserrolesView/:hf103/:id103', 
        path: 'loltnmaspnetuserView2aspnetuserrolesView/:hf102/DelaspnetuserrolesView/:hf103/:id103', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module').then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'd', /* oltp: 'loltnmaspnetuserView2aspnetuserrolesView', oltn: 'loltnmaspnetuserView', */ np: '', /* sf: true, */  title: rllzaspnetuserView['DeleteaspnetuserrolesView'],  hf: 'hf103',  id: 'id103',  dp: 3},
        canActivate: [AppGlblSettingsServiceActivator],
    },

    { 
//        outlet: 'loltnmaspnetuserView',
        path: 'loltnmaspnetuserView2aspnetuserrolesView/:hf102', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rl.routing.module').then(m => m.AspnetuserrolesViewRlRoutingModule),
        data: { isdtl: true, vn: 'aspnetuserrolesView', va: 'l', ms: true,  /* oltn: 'loltnmaspnetuserView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzaspnetuserView['ListaspnetuserrolesView'],  hf: 'hf102',  dp: 2, uid: 'e7217f9bc4f04c18bf95be76f99318a3' },
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
//        outlet: 'loltnmaspnetuserView',
        path: 'loltnmaspnetuserView2aspnetusermaskView/:hf102', 
        loadChildren: () => import('./../aspnetusermask-view/aspnetusermask-view-rl.routing.module').then(m => m.AspnetusermaskViewRlRoutingModule),
        data: { isdtl: true, vn: 'aspnetusermaskView', va: 'l', ms: true,  /* oltn: 'loltnmaspnetuserView', */ np: '', fh: 2, mh: 10, sf: true,  title: rllzaspnetuserView['ListaspnetusermaskView'],  hf: 'hf102',  dp: 2, uid: '453376be073143b2a177366310d5768a' },
        canActivate: [AppGlblSettingsServiceActivator],
    },



    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspnetuserViewRlRoutingModule { }


