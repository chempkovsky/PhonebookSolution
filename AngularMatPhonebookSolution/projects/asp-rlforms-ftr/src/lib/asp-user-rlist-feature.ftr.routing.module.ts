

import { loadRemoteModule } from '@angular-architects/module-federation';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblSettingsService } from 'common-services';
import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspUserRlistFeatureFtrComponent } from './asp-user-rlist-feature.ftr.component';


const routes: Routes = [
    { path: '',   redirectTo: 'aspnetuserView', pathMatch: 'full' },
    {
        path: '',
        component: AspUserRlistFeatureFtrComponent,
        canActivate: [AppGlblSettingsServiceActivator],
        canActivateChild: [AppGlblSettingsService],
        children: [
// r-routing

//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { path: 'aspnetuserView/aspnetuserrolesView/:hf2/ViewaspnetuserrolesView/:hf3/:id3', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module'}).then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
        data: { vn: 'aspnetuserrolesView', va: 'v', /* sf: true,  title: 'View User Role', */ hf: 'hf3',  id: 'id3', dp: 3}},

    { path: 'aspnetuserView/aspnetuserrolesView/:hf2/AddaspnetuserrolesView/:hf3', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module'}).then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
        data: { vn: 'aspnetuserrolesView', va: 'a', /* sf: true,  title: 'Add User Role', */ hf: 'hf3',  dp: 3}},

    { path: 'aspnetuserView/aspnetuserrolesView/:hf2/UpdaspnetuserrolesView/:hf3/:id3', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module'}).then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
        data: { vn: 'aspnetuserrolesView', va: 'u', /* sf: true,  title: 'Update User Role', */ hf: 'hf3',  id: 'id3',  dp: 3}},

    { path: 'aspnetuserView/aspnetuserrolesView/:hf2/DelaspnetuserrolesView/:hf3/:id3', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module'}).then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
        data: { vn: 'aspnetuserrolesView', va: 'd', /* sf: true, title: 'Delete User Role', */ hf: 'hf3',  id: 'id3',  dp: 3}},

    { path: 'aspnetuserView/aspnetuserrolesView/:hf2', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuserroles-view/aspnetuserroles-view-rl-lazy.routing.module'}).then(m => m.AspnetuserrolesViewRlLazyRoutingModule),
        data: { vn: 'aspnetuserrolesView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Roles', */ hf: 'hf2',  dp: 2, uid: '75dbefd21e674957bb756dcbb268677d' }  },


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
    { path: 'aspnetuserView/aspnetusermaskView/:hf2', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetusermask-view/aspnetusermask-view-rl-lazy.routing.module'}).then(m => m.AspnetusermaskViewRlLazyRoutingModule),
        data: { vn: 'aspnetusermaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '8ff3a292bddb4bb7b6b31de1c4f1aa4d' }  },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserView] 
//
    { path: 'aspnetuserView/ViewaspnetuserView/:hf2/:id2', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuser-view/aspnetuser-view-rv-lazy.routing.module'}).then(m => m.AspnetuserViewRvLazyRoutingModule),
        data: { vn: 'aspnetuserView', va: 'v', /* sf: true,  title: 'View User', */ hf: 'hf2',  id: 'id2', dp: 2}},

    { path: 'aspnetuserView/AddaspnetuserView/:hf2', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuser-view/aspnetuser-view-ra-lazy.routing.module'}).then(m => m.AspnetuserViewRaLazyRoutingModule),
        data: { vn: 'aspnetuserView', va: 'a', /* sf: true,  title: 'Add User', */ hf: 'hf2',  dp: 2}},

    { path: 'aspnetuserView/UpdaspnetuserView/:hf2/:id2', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuser-view/aspnetuser-view-ru-lazy.routing.module'}).then(m => m.AspnetuserViewRuLazyRoutingModule),
        data: { vn: 'aspnetuserView', va: 'u', /* sf: true,  title: 'Update User', */ hf: 'hf2',  id: 'id2',  dp: 2}},

    { path: 'aspnetuserView/DelaspnetuserView/:hf2/:id2', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuser-view/aspnetuser-view-rd-lazy.routing.module'}).then(m => m.AspnetuserViewRdLazyRoutingModule),
        data: { vn: 'aspnetuserView', va: 'd', /* sf: true, title: 'Delete User', */ hf: 'hf2',  id: 'id2',  dp: 2}},

    { path: 'aspnetuserView', 
        loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetuser-view/aspnetuser-view-rl-lazy.routing.module'}).then(m => m.AspnetuserViewRlLazyRoutingModule),
        data: { vn: 'aspnetuserView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Users', */  dp: 1, uid: 'e36c130e901a4ed49141cf47ab4a97c6' }  },


// rd-routing
        ] // children: [...]

    },
]; // const routes: Routes = [...]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspUserRlistFeatureFtrRoutingModule { }


