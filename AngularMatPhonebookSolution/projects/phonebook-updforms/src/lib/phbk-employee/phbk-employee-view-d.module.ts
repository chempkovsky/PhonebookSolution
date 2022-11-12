
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEmployeeViewDformComponent } from './dform/phbk-employee-view-dform.component';
import { PhbkEmployeeViewDdlgComponent } from './ddlg/phbk-employee-view-ddlg.component';

import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';

@NgModule({
    declarations: [
        PhbkEmployeeViewDformComponent,
        PhbkEmployeeViewDdlgComponent
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
        PhbkEmployeeViewDformComponent,
        PhbkEmployeeViewDdlgComponent
    ],
    entryComponents: [
        PhbkEmployeeViewDdlgComponent
    ]
})
export class PhbkEmployeeViewDModule { }


