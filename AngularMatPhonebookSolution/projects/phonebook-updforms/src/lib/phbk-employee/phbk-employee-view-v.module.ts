
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEmployeeViewVformComponent } from './vform/phbk-employee-view-vform.component';
import { PhbkEmployeeViewVdlgComponent } from './vdlg/phbk-employee-view-vdlg.component';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';

import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';


@NgModule({
    declarations: [
        PhbkEmployeeViewVformComponent,
        PhbkEmployeeViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

    ],
    exports: [
        PhbkEmployeeViewVformComponent,
        PhbkEmployeeViewVdlgComponent
    ],
    entryComponents: [
        PhbkEmployeeViewVdlgComponent
    ]
})
export class PhbkEmployeeViewVModule { }


