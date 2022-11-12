
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetrolemaskViewRAComponent } from './raform/aspnetrolemask-view-r-a.component';


import { AspnetrolemaskViewAModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetrolemaskViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetrolemaskViewAModule,


    ],
    exports: [
        AspnetrolemaskViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetrolemaskViewRaModule { }


