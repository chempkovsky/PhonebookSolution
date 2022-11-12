
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEnterpriseViewRAComponent } from './raform/phbk-enterprise-view-r-a.component';


import { PhbkEnterpriseViewAModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkEnterpriseViewRAComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkEnterpriseViewAModule,


    ],
    exports: [
        PhbkEnterpriseViewRAComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRaModule { }


