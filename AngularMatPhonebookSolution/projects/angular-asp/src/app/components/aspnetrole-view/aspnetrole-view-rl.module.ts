
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetroleViewSModule } from 'asp-sforms';
import { AspnetroleViewRlistComponent } from './rlist/aspnetrole-view-rlist.component';








@NgModule({
    declarations: [
        AspnetroleViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetroleViewSModule,





    ],
    exports: [
        AspnetroleViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRlModule { }


