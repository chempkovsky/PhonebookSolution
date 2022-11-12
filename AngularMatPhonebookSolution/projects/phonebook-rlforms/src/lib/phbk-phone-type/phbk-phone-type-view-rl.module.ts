
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneTypeViewSModule } from 'phonebook-sforms';
import { PhbkPhoneTypeViewRlistComponent } from './rlist/phbk-phone-type-view-rlist.component';








@NgModule({
    declarations: [
        PhbkPhoneTypeViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        PhbkPhoneTypeViewSModule,





    ],
    exports: [
        PhbkPhoneTypeViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRlModule { }


