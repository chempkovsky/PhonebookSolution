
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserrolesViewRDComponent } from './rdform/aspnetuserroles-view-r-d.component';


import { AspnetuserrolesViewDModule } from 'asp-updforms';


import { AspnetuserViewSModule } from 'asp-sforms';



@NgModule({
    declarations: [
        AspnetuserrolesViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetuserViewSModule,

        AspnetuserrolesViewDModule,


    ],
    exports: [
        AspnetuserrolesViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRdModule { }


