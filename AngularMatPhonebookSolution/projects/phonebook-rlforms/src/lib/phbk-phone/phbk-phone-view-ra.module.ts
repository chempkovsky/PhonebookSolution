
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneViewRAComponent } from './raform/phbk-phone-view-r-a.component';


import { PhbkPhoneViewAModule } from 'phonebook-updforms';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkPhoneViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkEmployeeViewSModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkPhoneViewAModule,


    ],
    exports: [
        PhbkPhoneViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRaModule { }


