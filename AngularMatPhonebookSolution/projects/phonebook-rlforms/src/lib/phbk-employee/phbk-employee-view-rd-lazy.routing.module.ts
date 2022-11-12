
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEmployeeViewRdModule } from './phbk-employee-view-rd.module';
import { PhbkEmployeeViewRdRoutingModule } from './phbk-employee-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEmployeeViewRdModule,
        PhbkEmployeeViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRdLazyRoutingModule { }


