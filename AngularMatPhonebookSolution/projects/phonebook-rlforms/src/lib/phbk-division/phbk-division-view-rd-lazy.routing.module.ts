
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkDivisionViewRdModule } from './phbk-division-view-rd.module';
import { PhbkDivisionViewRdRoutingModule } from './phbk-division-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkDivisionViewRdModule,
        PhbkDivisionViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRdLazyRoutingModule { }


