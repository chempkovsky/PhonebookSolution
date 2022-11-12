
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEnterpriseViewRDComponent } from './rdform/phbk-enterprise-view-r-d.component';


import { PhbkEnterpriseViewDModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkEnterpriseViewRDComponent,
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,


        PhbkEnterpriseViewDModule,


    ],
    exports: [
        PhbkEnterpriseViewRDComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRdModule { }


