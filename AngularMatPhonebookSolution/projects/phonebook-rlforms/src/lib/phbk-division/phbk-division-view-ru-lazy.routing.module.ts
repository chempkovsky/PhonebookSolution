
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkDivisionViewRuModule } from './phbk-division-view-ru.module';
import { PhbkDivisionViewRuRoutingModule } from './phbk-division-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkDivisionViewRuModule,
        PhbkDivisionViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRuLazyRoutingModule { }


