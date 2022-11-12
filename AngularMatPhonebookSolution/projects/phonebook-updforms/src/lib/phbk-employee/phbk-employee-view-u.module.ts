
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEmployeeViewUformComponent } from './uform/phbk-employee-view-uform.component';
import { PhbkEmployeeViewUdlgComponent } from './udlg/phbk-employee-view-udlg.component';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';

@NgModule({
    declarations: [
        PhbkEmployeeViewUformComponent,
        PhbkEmployeeViewUdlgComponent
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
        PhbkEmployeeViewUformComponent,
        PhbkEmployeeViewUdlgComponent
    ],
    entryComponents: [
        PhbkEmployeeViewUdlgComponent
    ]
})
export class PhbkEmployeeViewUModule { }


