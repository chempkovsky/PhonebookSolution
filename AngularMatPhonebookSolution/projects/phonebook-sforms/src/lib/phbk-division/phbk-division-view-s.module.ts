
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { PhbkDivisionViewSformComponent } from './sform/phbk-division-view-sform.component';
import { PhbkDivisionViewSdlgComponent } from './sdlg/phbk-division-view-sdlg.component';


@NgModule({
    declarations: [
        PhbkDivisionViewSformComponent,
        PhbkDivisionViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        PhbkDivisionViewSformComponent,
        PhbkDivisionViewSdlgComponent
    ],
    entryComponents: [
        PhbkDivisionViewSdlgComponent
    ]
})
export class PhbkDivisionViewSModule { }


