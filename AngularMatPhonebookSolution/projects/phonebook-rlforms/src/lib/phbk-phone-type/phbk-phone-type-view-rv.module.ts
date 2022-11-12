
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkPhoneTypeViewRVComponent } from './rvform/phbk-phone-type-view-r-v.component';


import { PhbkPhoneTypeViewVModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkPhoneTypeViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        PhbkPhoneTypeViewVModule,


    ],
    exports: [
        PhbkPhoneTypeViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRvModule { }


