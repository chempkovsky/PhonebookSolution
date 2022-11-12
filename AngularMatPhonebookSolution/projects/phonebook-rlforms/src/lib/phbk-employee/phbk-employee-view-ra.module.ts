
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEmployeeViewRAComponent } from './raform/phbk-employee-view-r-a.component';


import { PhbkEmployeeViewAModule } from 'phonebook-updforms';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkEmployeeViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkEmployeeViewAModule,


    ],
    exports: [
        PhbkEmployeeViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRaModule { }


