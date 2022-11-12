
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetroleViewRAComponent } from './raform/aspnetrole-view-r-a.component';


import { AspnetroleViewAModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetroleViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetroleViewAModule,


    ],
    exports: [
        AspnetroleViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRaModule { }


