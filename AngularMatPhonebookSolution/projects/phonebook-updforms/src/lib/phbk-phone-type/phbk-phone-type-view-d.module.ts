
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkPhoneTypeViewDformComponent } from './dform/phbk-phone-type-view-dform.component';
import { PhbkPhoneTypeViewDdlgComponent } from './ddlg/phbk-phone-type-view-ddlg.component';


@NgModule({
    declarations: [
        PhbkPhoneTypeViewDformComponent,
        PhbkPhoneTypeViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkPhoneTypeViewDformComponent,
        PhbkPhoneTypeViewDdlgComponent
    ],
    entryComponents: [
        PhbkPhoneTypeViewDdlgComponent
    ]
})
export class PhbkPhoneTypeViewDModule { }


