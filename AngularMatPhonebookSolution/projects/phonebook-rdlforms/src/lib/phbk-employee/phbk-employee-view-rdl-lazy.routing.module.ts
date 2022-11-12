


import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEmployeeViewRdlModule } from './phbk-employee-view-rdl.module';
import { PhbkEmployeeViewRdlRoutingModule } from './phbk-employee-view-rdl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEmployeeViewRdlModule,
        PhbkEmployeeViewRdlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRdlLazyRoutingModule { }


