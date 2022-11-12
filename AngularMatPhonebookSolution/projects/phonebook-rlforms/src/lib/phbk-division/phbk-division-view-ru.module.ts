
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkDivisionViewRUComponent } from './ruform/phbk-division-view-r-u.component';


import { PhbkDivisionViewUModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkDivisionViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkDivisionViewUModule,


    ],
    exports: [
        PhbkDivisionViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRuModule { }


