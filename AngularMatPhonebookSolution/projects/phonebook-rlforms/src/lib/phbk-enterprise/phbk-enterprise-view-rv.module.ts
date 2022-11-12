
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkEnterpriseViewRVComponent } from './rvform/phbk-enterprise-view-r-v.component';


import { PhbkEnterpriseViewVModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkEnterpriseViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        PhbkEnterpriseViewVModule,


    ],
    exports: [
        PhbkEnterpriseViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRvModule { }


