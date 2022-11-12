
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneViewUformComponent } from './uform/phbk-phone-view-uform.component';
import { PhbkPhoneViewUdlgComponent } from './udlg/phbk-phone-view-udlg.component';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';

@NgModule({
    declarations: [
        PhbkPhoneViewUformComponent,
        PhbkPhoneViewUdlgComponent
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
        PhbkPhoneViewUformComponent,
        PhbkPhoneViewUdlgComponent
    ],
    entryComponents: [
        PhbkPhoneViewUdlgComponent
    ]
})
export class PhbkPhoneViewUModule { }


