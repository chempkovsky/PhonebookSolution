
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkDivisionViewRAComponent } from './raform/phbk-division-view-r-a.component';


import { PhbkDivisionViewAModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkDivisionViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkDivisionViewAModule,


    ],
    exports: [
        PhbkDivisionViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRaModule { }


