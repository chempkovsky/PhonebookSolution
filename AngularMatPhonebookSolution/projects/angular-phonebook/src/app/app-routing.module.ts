
import { loadRemoteModule } from '@angular-architects/module-federation';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblHomeComponent } from './shared/components/app-glbl-home/app-glbl-home.component';
import { AppGlblPagenotfoundComponent } from './shared/components/app-glbl-pagenotfound/app-glbl-pagenotfound.component';

const routes: Routes = [
  // { path: 'authentication', loadChildren: () => import('./common-auth/lib/modules/app-glbl-security.module').then(m => m.AppGlblSecurityModule) },  
  { path: 'authentication', loadChildren: () => import('common-auth').then(m => m.AppGlblSecurityModule) },  

/////////////////////////////////////////////
{  path: 'asprdlfeature01', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/asp-rdlforms-ftr01/asp-rdl-feature01.ftr.lazy.routing.module'}).then(m => m.AspRdlFeature01FtrLazyRoutingModule), 
data: { vn: 'AspRdlFeature01FtrComponent', va: 'l'} }, 

/////////////////////////////////////////////

  {  path: 'asprlfeature01', 
  loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/asp-rlforms-ftr01/asp-rl-feature01.ftr.lazy.routing.module'}).then(m => m.AspRlFeature01FtrLazyRoutingModule), 
  data: { vn: 'AspRlFeature01FtrComponent', va: 'l'} }, 


/////////////////////////////////////////////

{  path: 'aspuserrlistfeature', 
loadChildren: () => import('asp-rlforms-ftr').then(m => m.AspUserRlistFeatureFtrLazyRoutingModule), 
data: { vn: 'AspUserRlistFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////
{  path: 'asplformsfeature', 
loadChildren: () => import('asp-lforms-ftr').then(m => m.AspLformsFeatureFtrLazyRoutingModule), 
data: { vn: 'AspLformsFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////

{  path: 'rdlistsfeature', 
loadChildren: () => import('phonebook-features').then(m => m.RdListsFeatureFtrLazyRoutingModule), 
data: { vn: 'RdListsFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////
{  path: 'rlistsfeature', 
loadChildren: () => import('phonebook-features').then(m => m.RListsFeatureFtrLazyRoutingModule), 
data: { vn: 'RListsFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////

  {  path: 'lformsfeature', 
  loadChildren: () => import('phonebook-features').then(m => m.LformsFeatureFtrLazyRoutingModule), 
  data: { vn: 'LformsFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkPhoneView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'PhbkPhoneView/ViewPhbkPhoneView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'v', /* sf: true,  title: 'View Phone', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'PhbkPhoneView/AddPhbkPhoneView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'a', /* sf: true,  title: 'Add Phone', */ hf: 'hf2',  dp: 2}},

{ path: 'PhbkPhoneView/UpdPhbkPhoneView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'u', /* sf: true,  title: 'Update Phone', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkPhoneView/DelPhbkPhoneView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'd', /* sf: true,  title: 'Delete Phone', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkPhoneView', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Phones', */  dp: 1, uid: 'd87a30643e484e91b69c13dae4e37213' }  },

/////////////////////////////////////////////
{ path: 'RDLPhbkPhoneView', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phones', */  dp: 1, uid: '2352ae08e5a1485693a3bc8614140d12' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkEmployeeView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'PhbkEmployeeView/PhbkPhoneView/:hf2/ViewPhbkPhoneView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'v', /* sf: true,  title: 'View Phone', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'PhbkEmployeeView/PhbkPhoneView/:hf2/AddPhbkPhoneView/:hf3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'a', /* sf: true,  title: 'Add Phone', */ hf: 'hf3',  dp: 3}},

{ path: 'PhbkEmployeeView/PhbkPhoneView/:hf2/UpdPhbkPhoneView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'u', /* sf: true,  title: 'Update Phone', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkEmployeeView/PhbkPhoneView/:hf2/DelPhbkPhoneView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'd', /* sf: true,  title: 'Delete Phone', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkEmployeeView/PhbkPhoneView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Phones', */ hf: 'hf2',  dp: 2, uid: '709b1df35b854ccabcfafea3e548fcfa' }  },


//
// Info: Root Master View  [PhbkEmployeeView] 
// Info: Detail View  [PhbkEmployeeView] 
//
{ path: 'PhbkEmployeeView/ViewPhbkEmployeeView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRvLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'v', /* sf: true,  title: 'View Employee', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'PhbkEmployeeView/AddPhbkEmployeeView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRaLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'a', /* sf: true,  title: 'Add Employee', */ hf: 'hf2',  dp: 2}},

{ path: 'PhbkEmployeeView/UpdPhbkEmployeeView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRuLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'u', /* sf: true,  title: 'Update Employee', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkEmployeeView/DelPhbkEmployeeView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRdLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'd', /* sf: true,  title: 'Delete Employee', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkEmployeeView', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRlLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Employees', */  dp: 1, uid: '64f243becdeb4140bf342662ecec6cbb' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkEmployeeView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'RDLPhbkEmployeeView/RDLPhbkPhoneView/:hf2', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phones', */ hf: 'hf2',  dp: 2, uid: '6a7e8eafb9b5488385cf1fd5d8d16149' }  },


//
// Info: Root Master View  [PhbkEmployeeView] 
// Info: Detail View  [PhbkEmployeeView] 
//
{ path: 'RDLPhbkEmployeeView', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkEmployeeViewRdlLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Employees', */  dp: 1, uid: '84ea62c8f03f44c4b0147926bef06949' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/PhbkPhoneView/:hf3/ViewPhbkPhoneView/:hf4/:id4', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'v', /* sf: true,  title: 'View Phone', */ hf: 'hf4',  id: 'id4', dp: 4}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/PhbkPhoneView/:hf3/AddPhbkPhoneView/:hf4', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'a', /* sf: true,  title: 'Add Phone', */ hf: 'hf4',  dp: 4}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/PhbkPhoneView/:hf3/UpdPhbkPhoneView/:hf4/:id4', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'u', /* sf: true,  title: 'Update Phone', */ hf: 'hf4',  id: 'id4',  dp: 4}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/PhbkPhoneView/:hf3/DelPhbkPhoneView/:hf4/:id4', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'd', /* sf: true,  title: 'Delete Phone', */ hf: 'hf4',  id: 'id4',  dp: 4}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/PhbkPhoneView/:hf3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Phones', */ hf: 'hf3',  dp: 3, uid: '230e5f12df954d0ca26e333522d6ac35' }  },


//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkEmployeeView] 
//
{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/ViewPhbkEmployeeView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRvLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'v', /* sf: true,  title: 'View Employee', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/AddPhbkEmployeeView/:hf3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRaLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'a', /* sf: true,  title: 'Add Employee', */ hf: 'hf3',  dp: 3}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/UpdPhbkEmployeeView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRuLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'u', /* sf: true,  title: 'Update Employee', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2/DelPhbkEmployeeView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRdLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'd', /* sf: true,  title: 'Delete Employee', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkDivisionView/PhbkEmployeeView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRlLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Employees', */ hf: 'hf2',  dp: 2, uid: '80f530011ea64f0382016582634dc698' }  },


//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkDivisionView] 
//
{ path: 'PhbkDivisionView/ViewPhbkDivisionView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRvLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'v', /* sf: true,  title: 'View Division', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'PhbkDivisionView/AddPhbkDivisionView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRaLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'a', /* sf: true,  title: 'Add Division', */ hf: 'hf2',  dp: 2}},

{ path: 'PhbkDivisionView/UpdPhbkDivisionView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRuLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'u', /* sf: true,  title: 'Update Division', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkDivisionView/DelPhbkDivisionView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRdLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'd', /* sf: true,  title: 'Delete Division', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkDivisionView', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRlLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Divisions', */  dp: 1, uid: 'b0d3bb96cdd24431a3d32258a9173390' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'RDLPhbkDivisionView/RDLPhbkEmployeeView/:hf2/RDLPhbkPhoneView/:hf3', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phones', */ hf: 'hf3',  dp: 3, uid: '261ef4d6c376407289bf6af72f5a65b8' }  },


//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkEmployeeView] 
//
{ path: 'RDLPhbkDivisionView/RDLPhbkEmployeeView/:hf2', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkEmployeeViewRdlLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Employees', */ hf: 'hf2',  dp: 2, uid: 'fd2cf7226bb14e4ab026e17c39f71716' }  },


//
// Info: Root Master View  [PhbkDivisionView] 
// Info: Detail View  [PhbkDivisionView] 
//
{ path: 'RDLPhbkDivisionView', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkDivisionViewRdlLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Divisions', */  dp: 1, uid: '3be3535fe8ca4e7f91bfd5b773321d12' }  },

/////////////////////////////////////////////
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
data: { vn: 'PhbkPhoneView', va: 'd', /* sf: true,  title: 'Delete Phone', */ hf: 'hf5',  id: 'id5',  dp: 5}},

{ path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3/PhbkPhoneView/:hf4', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Phones', */ hf: 'hf4',  dp: 4, uid: 'd88c9d522b5e4614906664076400b8f3' }  },


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
data: { vn: 'PhbkEmployeeView', va: 'd', /* sf: true,  title: 'Delete Employee', */ hf: 'hf4',  id: 'id4',  dp: 4}},

{ path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2/PhbkEmployeeView/:hf3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEmployeeViewRlLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Employees', */ hf: 'hf3',  dp: 3, uid: '4409406875cb41728cd939b66a961c92' }  },


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
data: { vn: 'PhbkDivisionView', va: 'd', /* sf: true,  title: 'Delete Division', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkEnterpriseView/PhbkDivisionView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkDivisionViewRlLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Divisions', */ hf: 'hf2',  dp: 2, uid: 'd9b6e1abf30d4b73940eae0b3c65d85f' }  },


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
data: { vn: 'PhbkEnterpriseView', va: 'd', /* sf: true,  title: 'Delete Enterprise', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkEnterpriseView', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkEnterpriseViewRlLazyRoutingModule),
data: { vn: 'PhbkEnterpriseView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Enterprises', */  dp: 1, uid: '5ec8dd0f25684ea386fbbb8a5872a86e' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'RDLPhbkEnterpriseView/RDLPhbkDivisionView/:hf2/RDLPhbkEmployeeView/:hf3/RDLPhbkPhoneView/:hf4', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phones', */ hf: 'hf4',  dp: 4, uid: '149cdc7816c7499cbf3198453dd6e558' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkEmployeeView] 
//
{ path: 'RDLPhbkEnterpriseView/RDLPhbkDivisionView/:hf2/RDLPhbkEmployeeView/:hf3', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkEmployeeViewRdlLazyRoutingModule),
data: { vn: 'PhbkEmployeeView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Employees', */ hf: 'hf3',  dp: 3, uid: '9e59fd9c617c44b3bb13b83e3029063d' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkDivisionView] 
//
{ path: 'RDLPhbkEnterpriseView/RDLPhbkDivisionView/:hf2', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkDivisionViewRdlLazyRoutingModule),
data: { vn: 'PhbkDivisionView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Divisions', */ hf: 'hf2',  dp: 2, uid: 'b21b2fe6ee7b459d80cf5639fb85a2e0' }  },


//
// Info: Root Master View  [PhbkEnterpriseView] 
// Info: Detail View  [PhbkEnterpriseView] 
//
{ path: 'RDLPhbkEnterpriseView', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkEnterpriseViewRdlLazyRoutingModule),
data: { vn: 'PhbkEnterpriseView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Enterprises', */  dp: 1, uid: '631f179fd171473bb2f9334f2d9d958e' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkPhoneTypeView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'PhbkPhoneTypeView/PhbkPhoneView/:hf2/ViewPhbkPhoneView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRvLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'v', /* sf: true,  title: 'View Phone', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'PhbkPhoneTypeView/PhbkPhoneView/:hf2/AddPhbkPhoneView/:hf3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRaLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'a', /* sf: true,  title: 'Add Phone', */ hf: 'hf3',  dp: 3}},

{ path: 'PhbkPhoneTypeView/PhbkPhoneView/:hf2/UpdPhbkPhoneView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRuLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'u', /* sf: true,  title: 'Update Phone', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkPhoneTypeView/PhbkPhoneView/:hf2/DelPhbkPhoneView/:hf3/:id3', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRdLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'd', /* sf: true,  title: 'Delete Phone', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'PhbkPhoneTypeView/PhbkPhoneView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneViewRlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Phones', */ hf: 'hf2',  dp: 2, uid: 'a35cf038dc1c484bad13af21c2503e17' }  },


//
// Info: Root Master View  [PhbkPhoneTypeView] 
// Info: Detail View  [PhbkPhoneTypeView] 
//
{ path: 'PhbkPhoneTypeView/ViewPhbkPhoneTypeView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneTypeViewRvLazyRoutingModule),
data: { vn: 'PhbkPhoneTypeView', va: 'v', /* sf: true,  title: 'View Phone Type', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'PhbkPhoneTypeView/AddPhbkPhoneTypeView/:hf2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneTypeViewRaLazyRoutingModule),
data: { vn: 'PhbkPhoneTypeView', va: 'a', /* sf: true,  title: 'Add Phone Type', */ hf: 'hf2',  dp: 2}},

{ path: 'PhbkPhoneTypeView/UpdPhbkPhoneTypeView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneTypeViewRuLazyRoutingModule),
data: { vn: 'PhbkPhoneTypeView', va: 'u', /* sf: true,  title: 'Update Phone Type', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkPhoneTypeView/DelPhbkPhoneTypeView/:hf2/:id2', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneTypeViewRdLazyRoutingModule),
data: { vn: 'PhbkPhoneTypeView', va: 'd', /* sf: true,  title: 'Delete Phone Type', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'PhbkPhoneTypeView', 
loadChildren: () => import('phonebook-rlforms').then(m => m.PhbkPhoneTypeViewRlLazyRoutingModule),
data: { vn: 'PhbkPhoneTypeView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Phone Types', */  dp: 1, uid: 'db87f00f6e3d44c69eb5ed5367f0960e' }  },

/////////////////////////////////////////////
//
// Info: Root Master View  [PhbkPhoneTypeView] 
// Info: Detail View  [PhbkPhoneView] 
//
{ path: 'RDLPhbkPhoneTypeView/RDLPhbkPhoneView/:hf2', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneViewRdlLazyRoutingModule),
data: { vn: 'PhbkPhoneView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phones', */ hf: 'hf2',  dp: 2, uid: '4a6e6aec86c046fe86dfdcbef0922160' }  },


//
// Info: Root Master View  [PhbkPhoneTypeView] 
// Info: Detail View  [PhbkPhoneTypeView] 
//
{ path: 'RDLPhbkPhoneTypeView', 
loadChildren: () => import('phonebook-rdlforms').then(m => m.PhbkPhoneTypeViewRdlLazyRoutingModule),
data: { vn: 'PhbkPhoneTypeView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Phone Types', */  dp: 1, uid: '4ba98c154b6242f0b085021be835e0bf' }  },

/////////////////////////////////////////////
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
{ path: 'aspnetmodelView/aspnetusermaskView/:hf2', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetusermask-view/aspnetusermask-view-rl-lazy.routing.module'}).then(m => m.AspnetusermaskViewRlLazyRoutingModule),
data: { vn: 'aspnetusermaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '7a40b1a672d945dd8281999e3f87c069' }  },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetrolemaskView] 
//
{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/ViewaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module'}).then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'v', /* sf: true,  title: 'View Role Mask', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/AddaspnetrolemaskView/:hf3', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module'}).then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'a', /* sf: true,  title: 'Add Role Mask', */ hf: 'hf3',  dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/UpdaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module'}).then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'u', /* sf: true,  title: 'Update Role Mask', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/DelaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module'}).then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'd', /* sf: true,  title: 'Delete Role Mask', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetrolemask-view/aspnetrolemask-view-rl-lazy.routing.module'}).then(m => m.AspnetrolemaskViewRlLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Role Masks', */ hf: 'hf2',  dp: 2, uid: 'c8b2fa342d344b6f84f3666e6a639785' }  },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetmodelView] 
//
{ path: 'aspnetmodelView/ViewaspnetmodelView/:hf2/:id2', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetmodel-view/aspnetmodel-view-rv-lazy.routing.module'}).then(m => m.AspnetmodelViewRvLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'v', /* sf: true,  title: 'View Model', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'aspnetmodelView/AddaspnetmodelView/:hf2', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetmodel-view/aspnetmodel-view-ra-lazy.routing.module'}).then(m => m.AspnetmodelViewRaLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'a', /* sf: true,  title: 'Add Model', */ hf: 'hf2',  dp: 2}},

{ path: 'aspnetmodelView/UpdaspnetmodelView/:hf2/:id2', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetmodel-view/aspnetmodel-view-ru-lazy.routing.module'}).then(m => m.AspnetmodelViewRuLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'u', /* sf: true,  title: 'Update Model', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetmodelView/DelaspnetmodelView/:hf2/:id2', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetmodel-view/aspnetmodel-view-rd-lazy.routing.module'}).then(m => m.AspnetmodelViewRdLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'd', /* sf: true,  title: 'Delete Model', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetmodelView', 
loadChildren: () => loadRemoteModule({type: 'manifest', remoteName: 'AngularAsp', exposedModule: './projects/angular-asp/src/app/components/aspnetmodel-view/aspnetmodel-view-rl-lazy.routing.module'}).then(m => m.AspnetmodelViewRlLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Models', */  dp: 1, uid: '2a8dccc47a7e4157984993954edc21ad' }  },

/////////////////////////////////////////////
/////////////////////////////////////////////
/////////////////////////////////////////////
/////////////////////////////////////////////
/////////////////////////////////////////////
/////////////////////////////////////////////



  { path: 'home', component: AppGlblHomeComponent }, 
  { path: '',   redirectTo: '/home', pathMatch: 'full' }, 
  { path: '**', component: AppGlblHomeComponent },
  { path: '**', component: AppGlblPagenotfoundComponent },

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

