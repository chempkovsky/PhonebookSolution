
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkEmployeeViewRUComponent } from './ruform/phbk-employee-view-r-u.component';


import { PhbkEmployeeViewUModule } from 'phonebook-updforms';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkEmployeeViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkEmployeeViewUModule,


    ],
    exports: [
        PhbkEmployeeViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRuModule { }


