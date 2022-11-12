
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetrolemaskViewSModule } from 'asp-sforms';
import { AspnetrolemaskViewRlistComponent } from './rlist/aspnetrolemask-view-rlist.component';








@NgModule({
    declarations: [
        AspnetrolemaskViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetrolemaskViewSModule,





    ],
    exports: [
        AspnetrolemaskViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetrolemaskViewRlModule { }


