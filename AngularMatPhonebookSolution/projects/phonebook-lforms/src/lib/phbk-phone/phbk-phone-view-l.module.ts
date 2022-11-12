
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneViewSModule } from 'phonebook-sforms';
import { PhbkPhoneViewVModule } from 'phonebook-updforms';
import { PhbkPhoneViewAModule } from 'phonebook-updforms';
import { PhbkPhoneViewUModule } from 'phonebook-updforms';
import { PhbkPhoneViewDModule } from 'phonebook-updforms';

import { PhbkPhoneViewLformComponent } from './lform/phbk-phone-view-lform.component';
import { PhbkPhoneViewLdlgComponent } from './ldlg/phbk-phone-view-ldlg.component';


@NgModule({
    declarations: [
        PhbkPhoneViewLformComponent,
        PhbkPhoneViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        PhbkPhoneViewSModule,

        PhbkPhoneViewVModule,
        PhbkPhoneViewAModule,
        PhbkPhoneViewUModule,
        PhbkPhoneViewDModule,
    ],
    exports: [
        PhbkPhoneViewLformComponent,
        PhbkPhoneViewLdlgComponent
    ],
    entryComponents: [
        PhbkPhoneViewLdlgComponent
    ]
})
export class PhbkPhoneViewLModule { }


