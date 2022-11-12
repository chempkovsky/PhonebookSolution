
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEmployeeViewRDComponent } from './rdform/phbk-employee-view-r-d.component';


import { PhbkEmployeeViewDModule } from 'phonebook-updforms';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkEmployeeViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkEmployeeViewDModule,


    ],
    exports: [
        PhbkEmployeeViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRdModule { }


