
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewVModule } from 'phonebook-updforms';
import { PhbkDivisionViewAModule } from 'phonebook-updforms';
import { PhbkDivisionViewUModule } from 'phonebook-updforms';
import { PhbkDivisionViewDModule } from 'phonebook-updforms';

import { PhbkDivisionViewLformComponent } from './lform/phbk-division-view-lform.component';
import { PhbkDivisionViewLdlgComponent } from './ldlg/phbk-division-view-ldlg.component';


@NgModule({
    declarations: [
        PhbkDivisionViewLformComponent,
        PhbkDivisionViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        PhbkDivisionViewSModule,

        PhbkDivisionViewVModule,
        PhbkDivisionViewAModule,
        PhbkDivisionViewUModule,
        PhbkDivisionViewDModule,
    ],
    exports: [
        PhbkDivisionViewLformComponent,
        PhbkDivisionViewLdlgComponent
    ],
    entryComponents: [
        PhbkDivisionViewLdlgComponent
    ]
})
export class PhbkDivisionViewLModule { }


