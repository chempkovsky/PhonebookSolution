

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { RListsFeatureFtrComponent } from './r-lists-feature.ftr.component';




@NgModule({
    declarations: [
        RListsFeatureFtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
    ],
    exports: [
        RListsFeatureFtrComponent,
    ],
    entryComponents: [
    ]
})
export class RListsFeatureFtrModule { }


