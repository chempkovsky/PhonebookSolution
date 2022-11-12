
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneViewRdModule } from './phbk-phone-view-rd.module';
import { PhbkPhoneViewRdRoutingModule } from './phbk-phone-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneViewRdModule,
        PhbkPhoneViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRdLazyRoutingModule { }


