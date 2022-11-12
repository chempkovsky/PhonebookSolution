
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkEmployeeViewRVComponent } from './rvform/phbk-employee-view-r-v.component';


import { PhbkEmployeeViewVModule } from 'phonebook-updforms';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkEmployeeViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        

        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

        PhbkEmployeeViewVModule,


    ],
    exports: [
        PhbkEmployeeViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRvModule { }


