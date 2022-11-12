

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { RdListsFeatureFtrComponent } from './rd-lists-feature.ftr.component';




@NgModule({
    declarations: [
        RdListsFeatureFtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
    ],
    exports: [
        RdListsFeatureFtrComponent,
    ],
    entryComponents: [
    ]
})
export class RdListsFeatureFtrModule { }


