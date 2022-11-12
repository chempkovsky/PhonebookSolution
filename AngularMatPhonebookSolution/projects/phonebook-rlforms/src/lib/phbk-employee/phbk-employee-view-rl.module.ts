
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkEmployeeViewRlistComponent } from './rlist/phbk-employee-view-rlist.component';








@NgModule({
    declarations: [
        PhbkEmployeeViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        PhbkEmployeeViewSModule,





    ],
    exports: [
        PhbkEmployeeViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRlModule { }


