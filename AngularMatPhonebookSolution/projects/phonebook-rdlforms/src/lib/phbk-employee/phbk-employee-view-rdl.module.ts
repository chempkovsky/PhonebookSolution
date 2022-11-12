
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkEmployeeViewRdlistComponent } from './rdlist/phbk-employee-view-rdlist.component';

import { PhbkEmployeeViewVModule } from 'phonebook-updforms';
import { PhbkEmployeeViewAModule } from 'phonebook-updforms';
import { PhbkEmployeeViewUModule } from 'phonebook-updforms';
import { PhbkEmployeeViewDModule } from 'phonebook-updforms';


import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkEmployeeViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkEmployeeViewSModule,



        PhbkEmployeeViewVModule,
        PhbkEmployeeViewAModule,
        PhbkEmployeeViewUModule,
        PhbkEmployeeViewDModule,


        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

    ],
    exports: [
        PhbkEmployeeViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRdlModule { }


