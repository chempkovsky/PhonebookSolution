
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewVModule } from 'phonebook-updforms';
import { PhbkEnterpriseViewAModule } from 'phonebook-updforms';
import { PhbkEnterpriseViewUModule } from 'phonebook-updforms';
import { PhbkEnterpriseViewDModule } from 'phonebook-updforms';

import { PhbkEnterpriseViewLformComponent } from './lform/phbk-enterprise-view-lform.component';
import { PhbkEnterpriseViewLdlgComponent } from './ldlg/phbk-enterprise-view-ldlg.component';


@NgModule({
    declarations: [
        PhbkEnterpriseViewLformComponent,
        PhbkEnterpriseViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        PhbkEnterpriseViewSModule,

        PhbkEnterpriseViewVModule,
        PhbkEnterpriseViewAModule,
        PhbkEnterpriseViewUModule,
        PhbkEnterpriseViewDModule,
    ],
    exports: [
        PhbkEnterpriseViewLformComponent,
        PhbkEnterpriseViewLdlgComponent
    ],
    entryComponents: [
        PhbkEnterpriseViewLdlgComponent
    ]
})
export class PhbkEnterpriseViewLModule { }


