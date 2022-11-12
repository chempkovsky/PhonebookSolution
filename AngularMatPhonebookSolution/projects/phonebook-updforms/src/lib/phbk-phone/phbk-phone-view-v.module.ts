
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneViewVformComponent } from './vform/phbk-phone-view-vform.component';
import { PhbkPhoneViewVdlgComponent } from './vdlg/phbk-phone-view-vdlg.component';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';

import { PhbkDivisionViewSModule } from 'phonebook-sforms';

import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';


@NgModule({
    declarations: [
        PhbkPhoneViewVformComponent,
        PhbkPhoneViewVdlgComponent
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
        PhbkPhoneViewVformComponent,
        PhbkPhoneViewVdlgComponent
    ],
    entryComponents: [
        PhbkPhoneViewVdlgComponent
    ]
})
export class PhbkPhoneViewVModule { }


