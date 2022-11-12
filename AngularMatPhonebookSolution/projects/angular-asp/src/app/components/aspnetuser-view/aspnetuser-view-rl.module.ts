
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserViewSModule } from 'asp-sforms';
import { AspnetuserViewRlistComponent } from './rlist/aspnetuser-view-rlist.component';








@NgModule({
    declarations: [
        AspnetuserViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetuserViewSModule,





    ],
    exports: [
        AspnetuserViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRlModule { }


