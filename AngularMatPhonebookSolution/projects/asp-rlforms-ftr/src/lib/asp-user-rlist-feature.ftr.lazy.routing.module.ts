
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AspUserRlistFeatureFtrModule } from './asp-user-rlist-feature.ftr.module';
import { AspUserRlistFeatureFtrRoutingModule } from './asp-user-rlist-feature.ftr.routing.module';

@NgModule({
    declarations: [
    ],

    imports: [
        AspUserRlistFeatureFtrModule,
        AspUserRlistFeatureFtrRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspUserRlistFeatureFtrLazyRoutingModule { }


