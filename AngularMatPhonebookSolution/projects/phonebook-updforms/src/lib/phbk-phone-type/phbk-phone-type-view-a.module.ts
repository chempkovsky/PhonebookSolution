
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneTypeViewAformComponent } from './aform/phbk-phone-type-view-aform.component';
import { PhbkPhoneTypeViewAdlgComponent } from './adlg/phbk-phone-type-view-adlg.component';



@NgModule({
    declarations: [
        PhbkPhoneTypeViewAformComponent,
        PhbkPhoneTypeViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkPhoneTypeViewAformComponent,
        PhbkPhoneTypeViewAdlgComponent
    ],
    entryComponents: [
        PhbkPhoneTypeViewAdlgComponent
    ]
})
export class PhbkPhoneTypeViewAModule { }


