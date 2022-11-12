
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetroleViewRDComponent } from './rdform/aspnetrole-view-r-d.component';


import { AspnetroleViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetroleViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetroleViewDModule,


    ],
    exports: [
        AspnetroleViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRdModule { }


