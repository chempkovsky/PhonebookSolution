
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetroleViewRVComponent } from './rvform/aspnetrole-view-r-v.component';


import { AspnetroleViewVModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetroleViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        AspnetroleViewVModule,


    ],
    exports: [
        AspnetroleViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRvModule { }


