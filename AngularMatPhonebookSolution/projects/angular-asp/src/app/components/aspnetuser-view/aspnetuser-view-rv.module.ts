
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetuserViewRVComponent } from './rvform/aspnetuser-view-r-v.component';


import { AspnetuserViewVModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetuserViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        AspnetuserViewVModule,


    ],
    exports: [
        AspnetuserViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRvModule { }


