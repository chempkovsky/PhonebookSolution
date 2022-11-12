

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { AspLformsFeatureFtrComponent } from './asp-lforms-feature.ftr.component';


import { AspnetmodelViewLModule } from 'asp-lforms';
import { AspnetroleViewLModule } from 'asp-lforms';
import { AspnetuserViewLModule } from 'asp-lforms';


@NgModule({
    declarations: [
        AspLformsFeatureFtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AspnetmodelViewLModule,
        AspnetroleViewLModule,
        AspnetuserViewLModule,
    ],
    exports: [
        AspLformsFeatureFtrComponent,
    ],
    entryComponents: [
    ]
})
export class AspLformsFeatureFtrModule { }


