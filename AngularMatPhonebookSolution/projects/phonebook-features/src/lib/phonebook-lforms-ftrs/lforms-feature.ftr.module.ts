

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { LformsFeatureFtrComponent } from './lforms-feature.ftr.component';


import { PhbkPhoneTypeViewLModule } from 'phonebook-lforms';
import { PhbkEnterpriseViewLModule } from 'phonebook-lforms';
import { PhbkDivisionViewLModule } from 'phonebook-lforms';
import { PhbkEmployeeViewLModule } from 'phonebook-lforms';
import { PhbkPhoneViewLModule } from 'phonebook-lforms';


@NgModule({
    declarations: [
        LformsFeatureFtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        PhbkPhoneTypeViewLModule,
        PhbkEnterpriseViewLModule,
        PhbkDivisionViewLModule,
        PhbkEmployeeViewLModule,
        PhbkPhoneViewLModule,
    ],
    exports: [
        LformsFeatureFtrComponent,
    ],
    entryComponents: [
    ]
})
export class LformsFeatureFtrModule { }


