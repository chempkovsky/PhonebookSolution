
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneViewSModule } from 'phonebook-sforms';
import { PhbkPhoneViewRlistComponent } from './rlist/phbk-phone-view-rlist.component';








@NgModule({
    declarations: [
        PhbkPhoneViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        PhbkPhoneViewSModule,





    ],
    exports: [
        PhbkPhoneViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRlModule { }


