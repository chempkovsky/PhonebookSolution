
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEmployeeViewRlModule } from './phbk-employee-view-rl.module';
import { PhbkEmployeeViewRlRoutingModule } from './phbk-employee-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEmployeeViewRlModule,
        PhbkEmployeeViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRlLazyRoutingModule { }


