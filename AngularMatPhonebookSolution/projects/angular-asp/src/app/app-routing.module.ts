
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppGlblHomeComponent } from './shared/components/app-glbl-home/app-glbl-home.component';
import { AppGlblPagenotfoundComponent } from './shared/components/app-glbl-pagenotfound/app-glbl-pagenotfound.component';

const routes: Routes = [
  // { path: 'authentication', loadChildren: () => import('./common-auth/lib/modules/app-glbl-security.module').then(m => m.AppGlblSecurityModule) },  
  { path: 'authentication', loadChildren: () => import('common-auth').then(m => m.AppGlblSecurityModule) },  

/////////////////////////////////////////////////////////
{  path: 'asprdlfeature01', 
loadChildren: () => import('./components/asp-rdlforms-ftr01/asp-rdl-feature01.ftr.lazy.routing.module').then(m => m.AspRdlFeature01FtrLazyRoutingModule), 
data: { vn: 'AspRdlFeature01FtrComponent', va: 'l'} }, 

/////////////////////////////////////////////////////////
{  path: 'asprlfeature01', 
loadChildren: () => import('./components/asp-rlforms-ftr01/asp-rl-feature01.ftr.lazy.routing.module').then(m => m.AspRlFeature01FtrLazyRoutingModule), 
data: { vn: 'AspRlFeature01FtrComponent', va: 'l'} }, 


/////////////////////////////////////////////////////////

  {  path: 'aspuserrlistfeature', 
  loadChildren: () => import('asp-rlforms-ftr').then(m => m.AspUserRlistFeatureFtrLazyRoutingModule), 
  data: { vn: 'AspUserRlistFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////////////////
{  path: 'asplformsfeature', 
loadChildren: () => import('asp-lforms-ftr').then(m => m.AspLformsFeatureFtrLazyRoutingModule), 
data: { vn: 'AspLformsFeatureFtrComponent', va: 'l'} }, 


/////////////////////////////////////////////////////////
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
loadChildren: () => import('./components/aspnetusermask-view/aspnetusermask-view-rl-lazy.routing.module').then(m => m.AspnetusermaskViewRlLazyRoutingModule),
data: { vn: 'aspnetusermaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '49d2dbd3169e4541a36fd01a554975fc' }  },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetrolemaskView] 
//
{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/ViewaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module').then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'v', /* sf: true,  title: 'View Role Mask', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/AddaspnetrolemaskView/:hf3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module').then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'a', /* sf: true,  title: 'Add Role Mask', */ hf: 'hf3',  dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/UpdaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module').then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'u', /* sf: true,  title: 'Update Role Mask', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2/DelaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module').then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'd', /* sf: true,  title: 'Delete Role Mask', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetmodelView/aspnetrolemaskView/:hf2', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rl-lazy.routing.module').then(m => m.AspnetrolemaskViewRlLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Role Masks', */ hf: 'hf2',  dp: 2, uid: '59989cd10fc840faa6ca79e3ad945ab8' }  },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetmodelView] 
//
{ path: 'aspnetmodelView/ViewaspnetmodelView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetmodel-view/aspnetmodel-view-rv-lazy.routing.module').then(m => m.AspnetmodelViewRvLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'v', /* sf: true,  title: 'View Model', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'aspnetmodelView/AddaspnetmodelView/:hf2', 
loadChildren: () => import('./components/aspnetmodel-view/aspnetmodel-view-ra-lazy.routing.module').then(m => m.AspnetmodelViewRaLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'a', /* sf: true,  title: 'Add Model', */ hf: 'hf2',  dp: 2}},

{ path: 'aspnetmodelView/UpdaspnetmodelView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetmodel-view/aspnetmodel-view-ru-lazy.routing.module').then(m => m.AspnetmodelViewRuLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'u', /* sf: true,  title: 'Update Model', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetmodelView/DelaspnetmodelView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetmodel-view/aspnetmodel-view-rd-lazy.routing.module').then(m => m.AspnetmodelViewRdLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'd', /* sf: true,  title: 'Delete Model', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetmodelView', 
loadChildren: () => import('./components/aspnetmodel-view/aspnetmodel-view-rl-lazy.routing.module').then(m => m.AspnetmodelViewRlLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Models', */  dp: 1, uid: 'a8c27d1fb4d74a1ba7b96683c39feb2a' }  },

/////////////////////////////////////////////////////////
//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetusermaskView] 
//
{ path: 'RDLaspnetmodelView/RDLaspnetusermaskView/:hf2', 
loadChildren: () => import('./components/aspnetusermask-view/aspnetusermask-view-rdl-lazy.routing.module').then(m => m.AspnetusermaskViewRdlLazyRoutingModule),
data: { vn: 'aspnetusermaskView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '177615cb10684b39a03dc3da9ed533fa' }  },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetrolemaskView] 
//
{ path: 'RDLaspnetmodelView/RDLaspnetrolemaskView/:hf2', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rdl-lazy.routing.module').then(m => m.AspnetrolemaskViewRdlLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Role Masks', */ hf: 'hf2',  dp: 2, uid: '7cc428c481374d9999c4aa257f8af72d' }  },


//
// Info: Root Master View  [aspnetmodelView] 
// Info: Detail View  [aspnetmodelView] 
//
{ path: 'RDLaspnetmodelView', 
loadChildren: () => import('./components/aspnetmodel-view/aspnetmodel-view-rdl-lazy.routing.module').then(m => m.AspnetmodelViewRdlLazyRoutingModule),
data: { vn: 'aspnetmodelView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Models', */  dp: 1, uid: 'c132f820849e40bdb0c86f6cd4d146e6' }  },

/////////////////////////////////////////////////////////
//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetuserrolesView] 
//
{ path: 'aspnetroleView/aspnetuserrolesView/:hf2/ViewaspnetuserrolesView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module').then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'v', /* sf: true,  title: 'View User Role', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'aspnetroleView/aspnetuserrolesView/:hf2/AddaspnetuserrolesView/:hf3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module').then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'a', /* sf: true,  title: 'Add User Role', */ hf: 'hf3',  dp: 3}},

{ path: 'aspnetroleView/aspnetuserrolesView/:hf2/UpdaspnetuserrolesView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module').then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'u', /* sf: true,  title: 'Update User Role', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetroleView/aspnetuserrolesView/:hf2/DelaspnetuserrolesView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module').then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'd', /* sf: true,  title: 'Delete User Role', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetroleView/aspnetuserrolesView/:hf2', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rl-lazy.routing.module').then(m => m.AspnetuserrolesViewRlLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Roles', */ hf: 'hf2',  dp: 2, uid: 'f000538b58f844d8bc68f65887122fc0' }  },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetrolemaskView] 
//
{ path: 'aspnetroleView/aspnetrolemaskView/:hf2/ViewaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rv-lazy.routing.module').then(m => m.AspnetrolemaskViewRvLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'v', /* sf: true,  title: 'View Role Mask', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'aspnetroleView/aspnetrolemaskView/:hf2/AddaspnetrolemaskView/:hf3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-ra-lazy.routing.module').then(m => m.AspnetrolemaskViewRaLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'a', /* sf: true,  title: 'Add Role Mask', */ hf: 'hf3',  dp: 3}},

{ path: 'aspnetroleView/aspnetrolemaskView/:hf2/UpdaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-ru-lazy.routing.module').then(m => m.AspnetrolemaskViewRuLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'u', /* sf: true,  title: 'Update Role Mask', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetroleView/aspnetrolemaskView/:hf2/DelaspnetrolemaskView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rd-lazy.routing.module').then(m => m.AspnetrolemaskViewRdLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'd', /* sf: true,  title: 'Delete Role Mask', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetroleView/aspnetrolemaskView/:hf2', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rl-lazy.routing.module').then(m => m.AspnetrolemaskViewRlLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'Role Masks', */ hf: 'hf2',  dp: 2, uid: '84203b1b50d54f57b92b489111295fbe' }  },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetroleView] 
//
{ path: 'aspnetroleView/ViewaspnetroleView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetrole-view/aspnetrole-view-rv-lazy.routing.module').then(m => m.AspnetroleViewRvLazyRoutingModule),
data: { vn: 'aspnetroleView', va: 'v', /* sf: true,  title: 'View Role', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'aspnetroleView/AddaspnetroleView/:hf2', 
loadChildren: () => import('./components/aspnetrole-view/aspnetrole-view-ra-lazy.routing.module').then(m => m.AspnetroleViewRaLazyRoutingModule),
data: { vn: 'aspnetroleView', va: 'a', /* sf: true,  title: 'Add Role', */ hf: 'hf2',  dp: 2}},

{ path: 'aspnetroleView/UpdaspnetroleView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetrole-view/aspnetrole-view-ru-lazy.routing.module').then(m => m.AspnetroleViewRuLazyRoutingModule),
data: { vn: 'aspnetroleView', va: 'u', /* sf: true,  title: 'Update Role', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetroleView/DelaspnetroleView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetrole-view/aspnetrole-view-rd-lazy.routing.module').then(m => m.AspnetroleViewRdLazyRoutingModule),
data: { vn: 'aspnetroleView', va: 'd', /* sf: true,  title: 'Delete Role', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetroleView', 
loadChildren: () => import('./components/aspnetrole-view/aspnetrole-view-rl-lazy.routing.module').then(m => m.AspnetroleViewRlLazyRoutingModule),
data: { vn: 'aspnetroleView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Roles', */  dp: 1, uid: '70ed6f8ff75f48088092835a7487e020' }  },

/////////////////////////////////////////////////////////
//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetuserrolesView] 
//
{ path: 'RDLaspnetroleView/RDLaspnetuserrolesView/:hf2', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rdl-lazy.routing.module').then(m => m.AspnetuserrolesViewRdlLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'User Roles', */ hf: 'hf2',  dp: 2, uid: '49f7fb5f25b642da94168e1b9e73c2b0' }  },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetrolemaskView] 
//
{ path: 'RDLaspnetroleView/RDLaspnetrolemaskView/:hf2', 
loadChildren: () => import('./components/aspnetrolemask-view/aspnetrolemask-view-rdl-lazy.routing.module').then(m => m.AspnetrolemaskViewRdlLazyRoutingModule),
data: { vn: 'aspnetrolemaskView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Role Masks', */ hf: 'hf2',  dp: 2, uid: '72cf86cb98b243fc9e8cef7598235b8c' }  },


//
// Info: Root Master View  [aspnetroleView] 
// Info: Detail View  [aspnetroleView] 
//
{ path: 'RDLaspnetroleView', 
loadChildren: () => import('./components/aspnetrole-view/aspnetrole-view-rdl-lazy.routing.module').then(m => m.AspnetroleViewRdlLazyRoutingModule),
data: { vn: 'aspnetroleView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Roles', */  dp: 1, uid: 'ae47b3d55d7b471da961d6bee3d8b788' }  },

/////////////////////////////////////////////////////////
//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
{ path: 'aspnetuserView/aspnetuserrolesView/:hf2/ViewaspnetuserrolesView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rv-lazy.routing.module').then(m => m.AspnetuserrolesViewRvLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'v', /* sf: true,  title: 'View User Role', */ hf: 'hf3',  id: 'id3', dp: 3}},

{ path: 'aspnetuserView/aspnetuserrolesView/:hf2/AddaspnetuserrolesView/:hf3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-ra-lazy.routing.module').then(m => m.AspnetuserrolesViewRaLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'a', /* sf: true,  title: 'Add User Role', */ hf: 'hf3',  dp: 3}},

{ path: 'aspnetuserView/aspnetuserrolesView/:hf2/UpdaspnetuserrolesView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-ru-lazy.routing.module').then(m => m.AspnetuserrolesViewRuLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'u', /* sf: true,  title: 'Update User Role', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetuserView/aspnetuserrolesView/:hf2/DelaspnetuserrolesView/:hf3/:id3', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rd-lazy.routing.module').then(m => m.AspnetuserrolesViewRdLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'd', /* sf: true,  title: 'Delete User Role', */ hf: 'hf3',  id: 'id3',  dp: 3}},

{ path: 'aspnetuserView/aspnetuserrolesView/:hf2', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rl-lazy.routing.module').then(m => m.AspnetuserrolesViewRlLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Roles', */ hf: 'hf2',  dp: 2, uid: '4f1f0be1d0dc4c84899d056b70eab445' }  },


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
loadChildren: () => import('./components/aspnetusermask-view/aspnetusermask-view-rl-lazy.routing.module').then(m => m.AspnetusermaskViewRlLazyRoutingModule),
data: { vn: 'aspnetusermaskView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /*  title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '2704b7c4c78a4475bda1732c4e1cd23c' }  },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserView] 
//
{ path: 'aspnetuserView/ViewaspnetuserView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetuser-view/aspnetuser-view-rv-lazy.routing.module').then(m => m.AspnetuserViewRvLazyRoutingModule),
data: { vn: 'aspnetuserView', va: 'v', /* sf: true,  title: 'View User', */ hf: 'hf2',  id: 'id2', dp: 2}},

{ path: 'aspnetuserView/AddaspnetuserView/:hf2', 
loadChildren: () => import('./components/aspnetuser-view/aspnetuser-view-ra-lazy.routing.module').then(m => m.AspnetuserViewRaLazyRoutingModule),
data: { vn: 'aspnetuserView', va: 'a', /* sf: true,  title: 'Add User', */ hf: 'hf2',  dp: 2}},

{ path: 'aspnetuserView/UpdaspnetuserView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetuser-view/aspnetuser-view-ru-lazy.routing.module').then(m => m.AspnetuserViewRuLazyRoutingModule),
data: { vn: 'aspnetuserView', va: 'u', /* sf: true,  title: 'Update User', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetuserView/DelaspnetuserView/:hf2/:id2', 
loadChildren: () => import('./components/aspnetuser-view/aspnetuser-view-rd-lazy.routing.module').then(m => m.AspnetuserViewRdLazyRoutingModule),
data: { vn: 'aspnetuserView', va: 'd', /* sf: true,  title: 'Delete User', */ hf: 'hf2',  id: 'id2',  dp: 2}},

{ path: 'aspnetuserView', 
loadChildren: () => import('./components/aspnetuser-view/aspnetuser-view-rl-lazy.routing.module').then(m => m.AspnetuserViewRlLazyRoutingModule),
data: { vn: 'aspnetuserView', va: 'l', ms: true,  fh: 2, mh: 10, sf: true, /* title: 'Users', */  dp: 1, uid: '4c0ba9b224f04948819e824d6c289fa2' }  },

/////////////////////////////////////////////////////////
//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserrolesView] 
//
{ path: 'RDLaspnetuserView/RDLaspnetuserrolesView/:hf2', 
loadChildren: () => import('./components/aspnetuserroles-view/aspnetuserroles-view-rdl-lazy.routing.module').then(m => m.AspnetuserrolesViewRdlLazyRoutingModule),
data: { vn: 'aspnetuserrolesView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'User Roles', */ hf: 'hf2',  dp: 2, uid: 'b1337875d96f40ee8c28b26e172c3a6c' }  },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetusermaskView] 
//
{ path: 'RDLaspnetuserView/RDLaspnetusermaskView/:hf2', 
loadChildren: () => import('./components/aspnetusermask-view/aspnetusermask-view-rdl-lazy.routing.module').then(m => m.AspnetusermaskViewRdlLazyRoutingModule),
data: { vn: 'aspnetusermaskView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'User Masks', */ hf: 'hf2',  dp: 2, uid: '8e44c7f19e2744cd93a07a63d76f7d9f' }  },


//
// Info: Root Master View  [aspnetuserView] 
// Info: Detail View  [aspnetuserView] 
//
{ path: 'RDLaspnetuserView', 
loadChildren: () => import('./components/aspnetuser-view/aspnetuser-view-rdl-lazy.routing.module').then(m => m.AspnetuserViewRdlLazyRoutingModule),
data: { vn: 'aspnetuserView', va: 'l', ms: true, np: 'RDL', fh: 2, mh: 10, sf: true, /* title: 'Users', */  dp: 1, uid: '573df116bbd0494cb07299499f34c70f' }  },

/////////////////////////////////////////////////////////


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

