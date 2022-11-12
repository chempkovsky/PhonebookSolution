
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserrolesViewRAComponent } from './raform/aspnetuserroles-view-r-a.component';


import { AspnetuserrolesViewAModule } from 'asp-updforms';


import { AspnetuserViewSModule } from 'asp-sforms';



@NgModule({
    declarations: [
        AspnetuserrolesViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetuserViewSModule,

        AspnetuserrolesViewAModule,


    ],
    exports: [
        AspnetuserrolesViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRaModule { }


