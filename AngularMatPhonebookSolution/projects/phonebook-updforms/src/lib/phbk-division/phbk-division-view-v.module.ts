
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkDivisionViewVformComponent } from './vform/phbk-division-view-vform.component';
import { PhbkDivisionViewVdlgComponent } from './vdlg/phbk-division-view-vdlg.component';



@NgModule({
    declarations: [
        PhbkDivisionViewVformComponent,
        PhbkDivisionViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkDivisionViewVformComponent,
        PhbkDivisionViewVdlgComponent
    ],
    entryComponents: [
        PhbkDivisionViewVdlgComponent
    ]
})
export class PhbkDivisionViewVModule { }


