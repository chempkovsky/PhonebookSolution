
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkPhoneTypeViewRUComponent } from './ruform/phbk-phone-type-view-r-u.component';


import { PhbkPhoneTypeViewUModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkPhoneTypeViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkPhoneTypeViewUModule,


    ],
    exports: [
        PhbkPhoneTypeViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRuModule { }


