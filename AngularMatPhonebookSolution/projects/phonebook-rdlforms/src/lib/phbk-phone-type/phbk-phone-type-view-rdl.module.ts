
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneTypeViewSModule } from 'phonebook-sforms';
import { PhbkPhoneTypeViewRdlistComponent } from './rdlist/phbk-phone-type-view-rdlist.component';

import { PhbkPhoneTypeViewVModule } from 'phonebook-updforms';
import { PhbkPhoneTypeViewAModule } from 'phonebook-updforms';
import { PhbkPhoneTypeViewUModule } from 'phonebook-updforms';
import { PhbkPhoneTypeViewDModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkPhoneTypeViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkPhoneTypeViewSModule,



        PhbkPhoneTypeViewVModule,
        PhbkPhoneTypeViewAModule,
        PhbkPhoneTypeViewUModule,
        PhbkPhoneTypeViewDModule,



    ],
    exports: [
        PhbkPhoneTypeViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRdlModule { }


