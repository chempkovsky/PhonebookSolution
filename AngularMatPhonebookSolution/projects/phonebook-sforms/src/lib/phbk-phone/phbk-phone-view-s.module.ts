
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { PhbkPhoneViewSformComponent } from './sform/phbk-phone-view-sform.component';
import { PhbkPhoneViewSdlgComponent } from './sdlg/phbk-phone-view-sdlg.component';


@NgModule({
    declarations: [
        PhbkPhoneViewSformComponent,
        PhbkPhoneViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        PhbkPhoneViewSformComponent,
        PhbkPhoneViewSdlgComponent
    ],
    entryComponents: [
        PhbkPhoneViewSdlgComponent
    ]
})
export class PhbkPhoneViewSModule { }


