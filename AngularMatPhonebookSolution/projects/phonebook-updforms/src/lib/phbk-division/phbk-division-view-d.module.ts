
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkDivisionViewDformComponent } from './dform/phbk-division-view-dform.component';
import { PhbkDivisionViewDdlgComponent } from './ddlg/phbk-division-view-ddlg.component';


@NgModule({
    declarations: [
        PhbkDivisionViewDformComponent,
        PhbkDivisionViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkDivisionViewDformComponent,
        PhbkDivisionViewDdlgComponent
    ],
    entryComponents: [
        PhbkDivisionViewDdlgComponent
    ]
})
export class PhbkDivisionViewDModule { }


