

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblSettingsService } from 'common-services';
import { AppGlblSettingsServiceActivator } from 'common-services';
import { AspRdlFeature01FtrComponent } from './asp-rdl-feature01.ftr.component';


const routes: Routes = [
    { path: '',   redirectTo: 'RDLaspnetuserView', pathMatch: 'full' },
    {
        path: '',
        component: AspRdlFeature01FtrComponent,
        canActivate: [AppGlblSettingsServiceActivator],
        canActivateChild: [AppGlblSettingsService],
        children: [
// r-routing

// rd-routing

//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
    { path: 'RDLaspnetuserView/RDLaspnetuserrolesView/:hf2', 
        loadChildren: () => import('./../aspnetuserroles-view/aspnetuserroles-view-rdl-lazy.routing.module').then(m => m.AspnetuserrolesViewRdlLazyRoutingModule),
        data: { vn: 'aspnetuserrolesView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'User Roles', */ hf: 'hf2',  dp: 2, uid: '055dbf8a83194e32bee773dbcfa71a1d' }  },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetusermaskView] 
//
    { path: 'RDLaspnetuserView/RDLaspnetusermaskView/:hf2', 
        loadChildren: () => import('./../aspnetusermask-view/aspnetusermask-view-rdl-lazy.routing.module').then(m => m.AspnetusermaskViewRdlLazyRoutingModule),
        data: { vn: 'aspnetusermaskView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '33317a1f86ff4276b3faaa9bdbdaa9e1' }  },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserView] 
//
    { path: 'RDLaspnetuserView', 
        loadChildren: () => import('./../aspnetuser-view/aspnetuser-view-rdl-lazy.routing.module').then(m => m.AspnetuserViewRdlLazyRoutingModule),
        data: { vn: 'aspnetuserView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Users', */  dp: 1, uid: '401f96cd590d4d6599fa79712c0dfeeb' }  },

        ] // children: [...]

    },
]; // const routes: Routes = [...]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AspRdlFeature01FtrRoutingModule { }


