
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEmployeeViewRuModule } from './phbk-employee-view-ru.module';
import { PhbkEmployeeViewRuRoutingModule } from './phbk-employee-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEmployeeViewRuModule,
        PhbkEmployeeViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRuLazyRoutingModule { }


