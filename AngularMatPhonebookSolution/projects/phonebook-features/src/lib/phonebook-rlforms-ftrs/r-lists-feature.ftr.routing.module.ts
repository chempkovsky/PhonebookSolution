

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblSettingsService } from 'common-services';
import { AppGlblSettingsServiceActivator } from 'common-services';
import { RListsFeatureFtrComponent } from './r-lists-feature.ftr.component';


const routes: Routes = [
    { path: '',   redirectTo: 'PhbkEnterpriseView', pathMatch: 'full' },
    {
        path: '',
        component: RListsFeatureFtrComponent,
        canActivate: [AppGlblSettingsServiceActivator],
        canActivateChild: [AppGlblSettingsService],
        children: [
// r-routing

//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkPhoneView] 
//
    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/PhbkPhoneView/:hf4/ViewPhbkPhoneView/:hf5/:id5', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
        data: { vn: 'PhbkPhoneView', va: 'v', /* sf: true,  title: 'View Phone', */ hf: 'hf5',  id: 'id5', dp: 5}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/PhbkPhoneView/:hf4/AddPhbkPhoneView/:hf5', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
        data: { vn: 'PhbkPhoneView', va: 'a', /* sf: true,  title: 'Add Phone', */ hf: 'hf5',  dp: 5}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/PhbkPhoneView/:hf4/UpdPhbkPhoneView/:hf5/:id5', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
        data: { vn: 'PhbkPhoneView', va: 'u', /* sf: true,  title: 'Update Phone', */ hf: 'hf5',  id: 'id5',  dp: 5}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/PhbkPhoneView/:hf4/DelPhbkPhoneView/:hf5/:id5', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
        data: { vn: 'PhbkPhoneView', va: 'd', /* sf: true, title: 'Delete Phone', */ hf: 'hf5',  id: 'id5',  dp: 5}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/PhbkPhoneView/:hf4', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRlLazyRoutingModule),
        data: { vn: 'PhbkPhoneView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Phones', */ hf: 'hf4',  dp: 4, uid: 'ba9d8c85d1174b04b32fe992d4746477' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkEmployeeView] 
//
    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/ViewPhbkEmployeeView/:hf4/:id4', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRvLazyRoutingModule),
        data: { vn: 'PhbkEmployeeView', va: 'v', /* sf: true,  title: 'View Employee', */ hf: 'hf4',  id: 'id4', dp: 4}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/AddPhbkEmployeeView/:hf4', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRaLazyRoutingModule),
        data: { vn: 'PhbkEmployeeView', va: 'a', /* sf: true,  title: 'Add Employee', */ hf: 'hf4',  dp: 4}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/UpdPhbkEmployeeView/:hf4/:id4', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRuLazyRoutingModule),
        data: { vn: 'PhbkEmployeeView', va: 'u', /* sf: true,  title: 'Update Employee', */ hf: 'hf4',  id: 'id4',  dp: 4}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/DelPhbkEmployeeView/:hf4/:id4', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRdLazyRoutingModule),
        data: { vn: 'PhbkEmployeeView', va: 'd', /* sf: true, title: 'Delete Employee', */ hf: 'hf4',  id: 'id4',  dp: 4}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRlLazyRoutingModule),
        data: { vn: 'PhbkEmployeeView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Employees', */ hf: 'hf3',  dp: 3, uid: 'e966832ad37444d29c7dd22e19006c14' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkDivisionView] 
//
    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/ViewPhbkDivisionView/:hf3/:id3', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRvLazyRoutingModule),
        data: { vn: 'PhbkDivisionView', va: 'v', /* sf: true,  title: 'View Division', */ hf: 'hf3',  id: 'id3', dp: 3}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/AddPhbkDivisionView/:hf3', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRaLazyRoutingModule),
        data: { vn: 'PhbkDivisionView', va: 'a', /* sf: true,  title: 'Add Division', */ hf: 'hf3',  dp: 3}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/UpdPhbkDivisionView/:hf3/:id3', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRuLazyRoutingModule),
        data: { vn: 'PhbkDivisionView', va: 'u', /* sf: true,  title: 'Update Division', */ hf: 'hf3',  id: 'id3',  dp: 3}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/DelPhbkDivisionView/:hf3/:id3', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRdLazyRoutingModule),
        data: { vn: 'PhbkDivisionView', va: 'd', /* sf: true, title: 'Delete Division', */ hf: 'hf3',  id: 'id3',  dp: 3}},

    { path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRlLazyRoutingModule),
        data: { vn: 'PhbkDivisionView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Divisions', */ hf: 'hf2',  dp: 2, uid: '2f1d032b876b46b08302b2096498f2f8' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkEnterpriseView] 
//
    { path: 'PhbkEnterpriseView/ViewPhbkEnterpriseView/:hf2/:id2', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEnterpriseViewRvLazyRoutingModule),
        data: { vn: 'PhbkEnterpriseView', va: 'v', /* sf: true,  title: 'View Enterprise', */ hf: 'hf2',  id: 'id2', dp: 2}},

    { path: 'PhbkEnterpriseView/AddPhbkEnterpriseView/:hf2', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEnterpriseViewRaLazyRoutingModule),
        data: { vn: 'PhbkEnterpriseView', va: 'a', /* sf: true,  title: 'Add Enterprise', */ hf: 'hf2',  dp: 2}},

    { path: 'PhbkEnterpriseView/UpdPhbkEnterpriseView/:hf2/:id2', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEnterpriseViewRuLazyRoutingModule),
        data: { vn: 'PhbkEnterpriseView', va: 'u', /* sf: true,  title: 'Update Enterprise', */ hf: 'hf2',  id: 'id2',  dp: 2}},

    { path: 'PhbkEnterpriseView/DelPhbkEnterpriseView/:hf2/:id2', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEnterpriseViewRdLazyRoutingModule),
        data: { vn: 'PhbkEnterpriseView', va: 'd', /* sf: true, title: 'Delete Enterprise', */ hf: 'hf2',  id: 'id2',  dp: 2}},

    { path: 'PhbkEnterpriseView', 
        loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEnterpriseViewRlLazyRoutingModule),
        data: { vn: 'PhbkEnterpriseView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Enterprises', */  dp: 1, uid: '593e8c8e5f284a61898777450f9d1486' }  },


// rd-routing
        ] // children: [...]

    },
]; // const routes: Routes = [...]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RListsFeatureFtrRoutingModule { }


