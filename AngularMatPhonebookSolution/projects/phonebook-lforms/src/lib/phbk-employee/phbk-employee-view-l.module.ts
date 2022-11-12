
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkEmployeeViewVModule } from 'phonebook-updforms';
import { PhbkEmployeeViewAModule } from 'phonebook-updforms';
import { PhbkEmployeeViewUModule } from 'phonebook-updforms';
import { PhbkEmployeeViewDModule } from 'phonebook-updforms';

import { PhbkEmployeeViewLformComponent } from './lform/phbk-employee-view-lform.component';
import { PhbkEmployeeViewLdlgComponent } from './ldlg/phbk-employee-view-ldlg.component';


@NgModule({
    declarations: [
        PhbkEmployeeViewLformComponent,
        PhbkEmployeeViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        PhbkEmployeeViewSModule,

        PhbkEmployeeViewVModule,
        PhbkEmployeeViewAModule,
        PhbkEmployeeViewUModule,
        PhbkEmployeeViewDModule,
    ],
    exports: [
        PhbkEmployeeViewLformComponent,
        PhbkEmployeeViewLdlgComponent
    ],
    entryComponents: [
        PhbkEmployeeViewLdlgComponent
    ]
})
export class PhbkEmployeeViewLModule { }


