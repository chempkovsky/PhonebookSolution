
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetuserrolesViewRVComponent } from './rvform/aspnetuserroles-view-r-v.component';


import { AspnetuserrolesViewVModule } from 'asp-updforms';


import { AspnetuserViewSModule } from 'asp-sforms';



@NgModule({
    declarations: [
        AspnetuserrolesViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        

        AspnetuserViewSModule,

        AspnetuserrolesViewVModule,


    ],
    exports: [
        AspnetuserrolesViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRvModule { }


