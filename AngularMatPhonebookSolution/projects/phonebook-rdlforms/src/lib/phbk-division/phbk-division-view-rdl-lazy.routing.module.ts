


import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkDivisionViewRdlModule } from './phbk-division-view-rdl.module';
import { PhbkDivisionViewRdlRoutingModule } from './phbk-division-view-rdl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkDivisionViewRdlModule,
        PhbkDivisionViewRdlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRdlLazyRoutingModule { }


