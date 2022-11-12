
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetmodelViewSModule } from 'asp-sforms';
import { AspnetmodelViewRlistComponent } from './rlist/aspnetmodel-view-rlist.component';








@NgModule({
    declarations: [
        AspnetmodelViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetmodelViewSModule,





    ],
    exports: [
        AspnetmodelViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRlModule { }


