
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserrolesViewSModule } from 'asp-sforms';
import { AspnetuserrolesViewRlistComponent } from './rlist/aspnetuserroles-view-rlist.component';








@NgModule({
    declarations: [
        AspnetuserrolesViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetuserrolesViewSModule,





    ],
    exports: [
        AspnetuserrolesViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRlModule { }


