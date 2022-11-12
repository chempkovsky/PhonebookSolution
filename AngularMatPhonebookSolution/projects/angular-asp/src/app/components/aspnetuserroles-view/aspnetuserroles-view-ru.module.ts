
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetuserrolesViewRUComponent } from './ruform/aspnetuserroles-view-r-u.component';


import { AspnetuserrolesViewUModule } from 'asp-updforms';


import { AspnetuserViewSModule } from 'asp-sforms';



@NgModule({
    declarations: [
        AspnetuserrolesViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetuserViewSModule,

        AspnetuserrolesViewUModule,


    ],
    exports: [
        AspnetuserrolesViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRuModule { }


