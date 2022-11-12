
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetusermaskViewSModule } from 'asp-sforms';
import { AspnetusermaskViewRlistComponent } from './rlist/aspnetusermask-view-rlist.component';








@NgModule({
    declarations: [
        AspnetusermaskViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetusermaskViewSModule,





    ],
    exports: [
        AspnetusermaskViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetusermaskViewRlModule { }


