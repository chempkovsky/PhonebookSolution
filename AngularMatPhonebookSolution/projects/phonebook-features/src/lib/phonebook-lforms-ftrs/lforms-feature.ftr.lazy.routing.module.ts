
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { LformsFeatureFtrModule } from './lforms-feature.ftr.module';
import { LformsFeatureFtrRoutingModule } from './lforms-feature.ftr.routing.module';

@NgModule({
    declarations: [
    ],

    imports: [
        LformsFeatureFtrModule,
        LformsFeatureFtrRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class LformsFeatureFtrLazyRoutingModule { }


