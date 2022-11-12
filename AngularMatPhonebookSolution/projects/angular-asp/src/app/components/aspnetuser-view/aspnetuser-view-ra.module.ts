
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserViewRAComponent } from './raform/aspnetuser-view-r-a.component';


import { AspnetuserViewAModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetuserViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetuserViewAModule,


    ],
    exports: [
        AspnetuserViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRaModule { }


