
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEmployeeViewRaModule } from './phbk-employee-view-ra.module';
import { PhbkEmployeeViewRaRoutingModule } from './phbk-employee-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEmployeeViewRaModule,
        PhbkEmployeeViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEmployeeViewRaLazyRoutingModule { }


