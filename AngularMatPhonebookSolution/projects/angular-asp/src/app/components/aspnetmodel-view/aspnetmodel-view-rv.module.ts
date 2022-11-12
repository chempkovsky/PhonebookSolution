
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetmodelViewRVComponent } from './rvform/aspnetmodel-view-r-v.component';


import { AspnetmodelViewVModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetmodelViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        AspnetmodelViewVModule,


    ],
    exports: [
        AspnetmodelViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRvModule { }


