
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEmployeeViewRvModule } from './phbk-employee-view-rv.module';
import { PhbkEmployeeViewRvRoutingModule } from './phbk-employee-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEmployeeViewRvModule,
        PhbkEmployeeViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRvLazyRoutingModule { }


