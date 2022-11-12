
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkDivisionViewUformComponent } from './uform/phbk-division-view-uform.component';
import { PhbkDivisionViewUdlgComponent } from './udlg/phbk-division-view-udlg.component';



@NgModule({
    declarations: [
        PhbkDivisionViewUformComponent,
        PhbkDivisionViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkDivisionViewUformComponent,
        PhbkDivisionViewUdlgComponent
    ],
    entryComponents: [
        PhbkDivisionViewUdlgComponent
    ]
})
export class PhbkDivisionViewUModule { }


