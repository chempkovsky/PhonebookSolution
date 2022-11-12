
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkPhoneViewRUComponent } from './ruform/phbk-phone-view-r-u.component';


import { PhbkPhoneViewUModule } from 'phonebook-updforms';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkPhoneViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkEmployeeViewSModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkPhoneViewUModule,


    ],
    exports: [
        PhbkPhoneViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRuModule { }


