
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkDivisionViewRlModule } from './phbk-division-view-rl.module';
import { PhbkDivisionViewRlRoutingModule } from './phbk-division-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkDivisionViewRlModule,
        PhbkDivisionViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRlLazyRoutingModule { }


