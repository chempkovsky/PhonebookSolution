
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetuserViewRUComponent } from './ruform/aspnetuser-view-r-u.component';


import { AspnetuserViewUModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetuserViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetuserViewUModule,


    ],
    exports: [
        AspnetuserViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRuModule { }


