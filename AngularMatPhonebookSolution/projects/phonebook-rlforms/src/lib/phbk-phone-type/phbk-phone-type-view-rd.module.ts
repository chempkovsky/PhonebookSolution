
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneTypeViewRDComponent } from './rdform/phbk-phone-type-view-r-d.component';


import { PhbkPhoneTypeViewDModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkPhoneTypeViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkPhoneTypeViewDModule,


    ],
    exports: [
        PhbkPhoneTypeViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRdModule { }


