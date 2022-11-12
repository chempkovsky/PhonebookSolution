
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { AspnetmodelViewRUComponent } from './ruform/aspnetmodel-view-r-u.component';


import { AspnetmodelViewUModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetmodelViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        AspnetmodelViewUModule,


    ],
    exports: [
        AspnetmodelViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRuModule { }


