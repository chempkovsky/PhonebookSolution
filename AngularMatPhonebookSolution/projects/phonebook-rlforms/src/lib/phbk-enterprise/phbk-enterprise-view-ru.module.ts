
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkEnterpriseViewRUComponent } from './ruform/phbk-enterprise-view-r-u.component';


import { PhbkEnterpriseViewUModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkEnterpriseViewRUComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkEnterpriseViewUModule,


    ],
    exports: [
        PhbkEnterpriseViewRUComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRuModule { }


