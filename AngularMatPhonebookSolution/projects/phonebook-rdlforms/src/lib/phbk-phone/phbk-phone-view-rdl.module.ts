
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneViewSModule } from 'phonebook-sforms';
import { PhbkPhoneViewRdlistComponent } from './rdlist/phbk-phone-view-rdlist.component';

import { PhbkPhoneViewVModule } from 'phonebook-updforms';
import { PhbkPhoneViewAModule } from 'phonebook-updforms';
import { PhbkPhoneViewUModule } from 'phonebook-updforms';
import { PhbkPhoneViewDModule } from 'phonebook-updforms';


import { PhbkEmployeeViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';



@NgModule({
    declarations: [
        PhbkPhoneViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkPhoneViewSModule,



        PhbkPhoneViewVModule,
        PhbkPhoneViewAModule,
        PhbkPhoneViewUModule,
        PhbkPhoneViewDModule,


        PhbkEmployeeViewSModule,
        PhbkDivisionViewSModule,
        PhbkEnterpriseViewSModule,

    ],
    exports: [
        PhbkPhoneViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRdlModule { }


