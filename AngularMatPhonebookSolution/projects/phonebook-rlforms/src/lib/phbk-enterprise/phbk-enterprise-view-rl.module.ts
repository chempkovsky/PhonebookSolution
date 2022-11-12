
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewRlistComponent } from './rlist/phbk-enterprise-view-rlist.component';








@NgModule({
    declarations: [
        PhbkEnterpriseViewRlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        PhbkEnterpriseViewSModule,





    ],
    exports: [
        PhbkEnterpriseViewRlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRlModule { }


