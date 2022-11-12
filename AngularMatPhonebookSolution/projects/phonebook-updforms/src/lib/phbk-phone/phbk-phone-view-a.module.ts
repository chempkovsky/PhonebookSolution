
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneViewAformComponent } from './aform/phbk-phone-view-aform.component';
import { PhbkPhoneViewAdlgComponent } from './adlg/phbk-phone-view-adlg.component';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';

@NgModule({
    declarations: [
        PhbkPhoneViewAformComponent,
        PhbkPhoneViewAdlgComponent
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
        PhbkPhoneViewAformComponent,
        PhbkPhoneViewAdlgComponent
    ],
    entryComponents: [
        PhbkPhoneViewAdlgComponent
    ]
})
export class PhbkPhoneViewAModule { }


