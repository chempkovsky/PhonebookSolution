
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneTypeViewUformComponent } from './uform/phbk-phone-type-view-uform.component';
import { PhbkPhoneTypeViewUdlgComponent } from './udlg/phbk-phone-type-view-udlg.component';



@NgModule({
    declarations: [
        PhbkPhoneTypeViewUformComponent,
        PhbkPhoneTypeViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkPhoneTypeViewUformComponent,
        PhbkPhoneTypeViewUdlgComponent
    ],
    entryComponents: [
        PhbkPhoneTypeViewUdlgComponent
    ]
})
export class PhbkPhoneTypeViewUModule { }


