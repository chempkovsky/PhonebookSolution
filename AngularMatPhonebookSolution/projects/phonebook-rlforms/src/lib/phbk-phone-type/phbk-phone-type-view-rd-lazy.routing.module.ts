
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneTypeViewRdModule } from './phbk-phone-type-view-rd.module';
import { PhbkPhoneTypeViewRdRoutingModule } from './phbk-phone-type-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneTypeViewRdModule,
        PhbkPhoneTypeViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRdLazyRoutingModule { }


