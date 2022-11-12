
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';


import { PhbkDivisionViewRVComponent } from './rvform/phbk-division-view-r-v.component';


import { PhbkDivisionViewVModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkDivisionViewRVComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        


        PhbkDivisionViewVModule,


    ],
    exports: [
        PhbkDivisionViewRVComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRvModule { }


