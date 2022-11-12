
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewRlistComponent } from './rlist/phbk-division-view-rlist.component';








@NgModule({
    declarations: [
        PhbkDivisionViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        PhbkDivisionViewSModule,





    ],
    exports: [
        PhbkDivisionViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRlModule { }


