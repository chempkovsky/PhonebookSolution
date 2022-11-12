
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkPhoneViewRVComponent } from './rvform/phbk-phone-view-r-v.component';


import { PhbkPhoneViewVModule } from 'phonebook-updforms';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkPhoneViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        

        PhbkEmployeeViewSModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkPhoneViewVModule,


    ],
    exports: [
        PhbkPhoneViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRvModule { }


