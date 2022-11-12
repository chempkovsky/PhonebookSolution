
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkPhoneTypeViewRAComponent } from './raform/phbk-phone-type-view-r-a.component';


import { PhbkPhoneTypeViewAModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkPhoneTypeViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkPhoneTypeViewAModule,


    ],
    exports: [
        PhbkPhoneTypeViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRaModule { }


