
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RListsFeatureFtrModule } from './r-lists-feature.ftr.module';
import { RListsFeatureFtrRoutingModule } from './r-lists-feature.ftr.routing.module';

@NgModule({
    declarations: [
    ],

    imports: [
        RListsFeatureFtrModule,
        RListsFeatureFtrRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class RListsFeatureFtrLazyRoutingModule { }


