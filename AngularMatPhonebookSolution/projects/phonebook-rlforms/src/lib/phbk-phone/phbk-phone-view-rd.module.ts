
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneViewRDComponent } from './rdform/phbk-phone-view-r-d.component';


import { PhbkPhoneViewDModule } from 'phonebook-updforms';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkPhoneViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkEmployeeViewSModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkPhoneViewDModule,


    ],
    exports: [
        PhbkPhoneViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRdModule { }


