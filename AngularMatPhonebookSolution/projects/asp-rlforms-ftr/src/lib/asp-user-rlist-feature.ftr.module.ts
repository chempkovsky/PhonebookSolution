

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { AspUserRlistFeatureFtrComponent } from './asp-user-rlist-feature.ftr.component';




@NgModule({
    declarations: [
        AspUserRlistFeatureFtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
    ],
    exports: [
        AspUserRlistFeatureFtrComponent,
    ],
    entryComponents: [
    ]
})
export class AspUserRlistFeatureFtrModule { }


