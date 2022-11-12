
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { PhbkPhoneTypeViewSformComponent } from './sform/phbk-phone-type-view-sform.component';
import { PhbkPhoneTypeViewSdlgComponent } from './sdlg/phbk-phone-type-view-sdlg.component';


@NgModule({
    declarations: [
        PhbkPhoneTypeViewSformComponent,
        PhbkPhoneTypeViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        PhbkPhoneTypeViewSformComponent,
        PhbkPhoneTypeViewSdlgComponent
    ],
    entryComponents: [
        PhbkPhoneTypeViewSdlgComponent
    ]
})
export class PhbkPhoneTypeViewSModule { }


