
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkDivisionViewAformComponent } from './aform/phbk-division-view-aform.component';
import { PhbkDivisionViewAdlgComponent } from './adlg/phbk-division-view-adlg.component';



@NgModule({
    declarations: [
        PhbkDivisionViewAformComponent,
        PhbkDivisionViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkDivisionViewAformComponent,
        PhbkDivisionViewAdlgComponent
    ],
    entryComponents: [
        PhbkDivisionViewAdlgComponent
    ]
})
export class PhbkDivisionViewAModule { }


