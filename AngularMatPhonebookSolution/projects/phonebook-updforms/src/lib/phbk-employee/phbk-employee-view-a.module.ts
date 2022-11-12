
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEmployeeViewAformComponent } from './aform/phbk-employee-view-aform.component';
import { PhbkEmployeeViewAdlgComponent } from './adlg/phbk-employee-view-adlg.component';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';

@NgModule({
    declarations: [
        PhbkEmployeeViewAformComponent,
        PhbkEmployeeViewAdlgComponent
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
        PhbkEmployeeViewAformComponent,
        PhbkEmployeeViewAdlgComponent
    ],
    entryComponents: [
        PhbkEmployeeViewAdlgComponent
    ]
})
export class PhbkEmployeeViewAModule { }


