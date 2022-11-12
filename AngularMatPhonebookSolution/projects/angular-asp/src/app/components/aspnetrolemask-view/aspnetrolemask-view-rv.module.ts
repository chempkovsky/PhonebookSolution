
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetrolemaskViewRVComponent } from './rvform/aspnetrolemask-view-r-v.component';


import { AspnetrolemaskViewVModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetrolemaskViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        AspnetrolemaskViewVModule,


    ],
    exports: [
        AspnetrolemaskViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetrolemaskViewRvModule { }


