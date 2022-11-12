
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RdListsFeatureFtrModule } from './rd-lists-feature.ftr.module';
import { RdListsFeatureFtrRoutingModule } from './rd-lists-feature.ftr.routing.module';

@NgModule({
    declarations: [
    ],

    imports: [
        RdListsFeatureFtrModule,
        RdListsFeatureFtrRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class RdListsFeatureFtrLazyRoutingModule { }


