
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetmodelViewRAComponent } from './raform/aspnetmodel-view-r-a.component';


import { AspnetmodelViewAModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetmodelViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetmodelViewAModule,


    ],
    exports: [
        AspnetmodelViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRaModule { }


