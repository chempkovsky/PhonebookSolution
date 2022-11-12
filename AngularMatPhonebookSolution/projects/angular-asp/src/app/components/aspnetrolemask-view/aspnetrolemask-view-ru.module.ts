
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetrolemaskViewRUComponent } from './ruform/aspnetrolemask-view-r-u.component';


import { AspnetrolemaskViewUModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetrolemaskViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetrolemaskViewUModule,


    ],
    exports: [
        AspnetrolemaskViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetrolemaskViewRuModule { }


