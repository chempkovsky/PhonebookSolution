
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneTypeViewSModule } from 'phonebook-sforms';
import { PhbkPhoneTypeViewVModule } from 'phonebook-updforms';
import { PhbkPhoneTypeViewAModule } from 'phonebook-updforms';
import { PhbkPhoneTypeViewUModule } from 'phonebook-updforms';
import { PhbkPhoneTypeViewDModule } from 'phonebook-updforms';

import { PhbkPhoneTypeViewLformComponent } from './lform/phbk-phone-type-view-lform.component';
import { PhbkPhoneTypeViewLdlgComponent } from './ldlg/phbk-phone-type-view-ldlg.component';


@NgModule({
    declarations: [
        PhbkPhoneTypeViewLformComponent,
        PhbkPhoneTypeViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        PhbkPhoneTypeViewSModule,

        PhbkPhoneTypeViewVModule,
        PhbkPhoneTypeViewAModule,
        PhbkPhoneTypeViewUModule,
        PhbkPhoneTypeViewDModule,
    ],
    exports: [
        PhbkPhoneTypeViewLformComponent,
        PhbkPhoneTypeViewLdlgComponent
    ],
    entryComponents: [
        PhbkPhoneTypeViewLdlgComponent
    ]
})
export class PhbkPhoneTypeViewLModule { }


