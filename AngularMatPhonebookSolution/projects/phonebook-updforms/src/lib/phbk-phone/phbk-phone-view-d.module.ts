
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneViewDformComponent } from './dform/phbk-phone-view-dform.component';
import { PhbkPhoneViewDdlgComponent } from './ddlg/phbk-phone-view-ddlg.component';

import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';

@NgModule({
    declarations: [
        PhbkPhoneViewDformComponent,
        PhbkPhoneViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        PhbkEmployeeViewSModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

    ],
    exports: [
        PhbkPhoneViewDformComponent,
        PhbkPhoneViewDdlgComponent
    ],
    entryComponents: [
        PhbkPhoneViewDdlgComponent
    ]
})
export class PhbkPhoneViewDModule { }


