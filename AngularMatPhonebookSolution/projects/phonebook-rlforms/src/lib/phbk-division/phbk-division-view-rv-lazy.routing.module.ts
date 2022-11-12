
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkDivisionViewRvModule } from './phbk-division-view-rv.module';
import { PhbkDivisionViewRvRoutingModule } from './phbk-division-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkDivisionViewRvModule,
        PhbkDivisionViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRvLazyRoutingModule { }


