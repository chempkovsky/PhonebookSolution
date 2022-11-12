
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserViewRDComponent } from './rdform/aspnetuser-view-r-d.component';


import { AspnetuserViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetuserViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetuserViewDModule,


    ],
    exports: [
        AspnetuserViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRdModule { }


