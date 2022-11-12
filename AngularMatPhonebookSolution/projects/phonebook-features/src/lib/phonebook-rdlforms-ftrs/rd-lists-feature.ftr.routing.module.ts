

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblSettingsService } from 'common-services';
import { AppGlblSettingsServiceActivator } from 'common-services';
import { RdListsFeatureFtrComponent } from './rd-lists-feature.ftr.component';


const routes: Routes = [
    { path: '',   redirectTo: 'RDLPhbkEnterpriseView', pathMatch: 'full' },
    {
        path: '',
        component: RdListsFeatureFtrComponent,
        canActivate: [AppGlblSettingsServiceActivator],
        canActivateChild: [AppGlblSettingsService],
        children: [
// r-routing

// rd-routing

//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkPhoneView] 
//
    { path: 'RDLPhbkEnterpriseView/RDLPhbkDivisionView/:hf2/RDLPhbkEmployeeView/:hf3/RDLPhbkPhoneView/:hf4', 
        loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
        data: { vn: 'PhbkPhoneView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phones', */ hf: 'hf4',  dp: 4, uid: 'e74ab0c371c1439fba45604b7017636e' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkEmployeeView] 
//
    { path: 'RDLPhbkEnterpriseView/RDLPhbkDivisionView/:hf2/RDLPhbkEmployeeView/:hf3', 
        loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkEmployeeViewRdlLazyRoutingModule),
        data: { vn: 'PhbkEmployeeView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Employees', */ hf: 'hf3',  dp: 3, uid: 'e047dd736dda4879aaa282790c062371' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkDivisionView] 
//
    { path: 'RDLPhbkEnterpriseView/RDLPhbkDivisionView/:hf2', 
        loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkDivisionViewRdlLazyRoutingModule),
        data: { vn: 'PhbkDivisionView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Divisions', */ hf: 'hf2',  dp: 2, uid: 'be5fa411ea084fe69d1f652f6c43ea58' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkEnterpriseView] 
//
    { path: 'RDLPhbkEnterpriseView', 
        loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkEnterpriseViewRdlLazyRoutingModule),
        data: { vn: 'PhbkEnterpriseView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Enterprises', */  dp: 1, uid: '828371aa4cdf4a4f905ebac1985be1c6' }  },

        ] // children: [...]

    },
]; // const routes: Routes = [...]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RdListsFeatureFtrRoutingModule { }


