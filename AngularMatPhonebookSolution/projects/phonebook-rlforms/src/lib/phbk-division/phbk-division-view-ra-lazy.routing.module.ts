
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkDivisionViewRaModule } from './phbk-division-view-ra.module';
import { PhbkDivisionViewRaRoutingModule } from './phbk-division-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkDivisionViewRaModule,
        PhbkDivisionViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRaLazyRoutingModule { }


