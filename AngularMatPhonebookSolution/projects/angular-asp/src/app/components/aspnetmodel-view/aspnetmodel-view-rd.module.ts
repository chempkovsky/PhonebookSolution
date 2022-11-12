
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetmodelViewRDComponent } from './rdform/aspnetmodel-view-r-d.component';


import { AspnetmodelViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetmodelViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetmodelViewDModule,


    ],
    exports: [
        AspnetmodelViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRdModule { }


