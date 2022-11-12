
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetrolemaskViewRDComponent } from './rdform/aspnetrolemask-view-r-d.component';


import { AspnetrolemaskViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetrolemaskViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetrolemaskViewDModule,


    ],
    exports: [
        AspnetrolemaskViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetrolemaskViewRdModule { }


