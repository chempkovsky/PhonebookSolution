
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneTypeViewVformComponent } from './vform/phbk-phone-type-view-vform.component';
import { PhbkPhoneTypeViewVdlgComponent } from './vdlg/phbk-phone-type-view-vdlg.component';



@NgModule({
    declarations: [
        PhbkPhoneTypeViewVformComponent,
        PhbkPhoneTypeViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkPhoneTypeViewVformComponent,
        PhbkPhoneTypeViewVdlgComponent
    ],
    entryComponents: [
        PhbkPhoneTypeViewVdlgComponent
    ]
})
export class PhbkPhoneTypeViewVModule { }


