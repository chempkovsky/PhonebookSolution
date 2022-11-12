
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkDivisionViewRDComponent } from './rdform/phbk-division-view-r-d.component';


import { PhbkDivisionViewDModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkDivisionViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkDivisionViewDModule,


    ],
    exports: [
        PhbkDivisionViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRdModule { }


