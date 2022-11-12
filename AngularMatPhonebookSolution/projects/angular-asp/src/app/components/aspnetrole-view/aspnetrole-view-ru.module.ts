
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetroleViewRUComponent } from './ruform/aspnetrole-view-r-u.component';


import { AspnetroleViewUModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetroleViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetroleViewUModule,


    ],
    exports: [
        AspnetroleViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRuModule { }


