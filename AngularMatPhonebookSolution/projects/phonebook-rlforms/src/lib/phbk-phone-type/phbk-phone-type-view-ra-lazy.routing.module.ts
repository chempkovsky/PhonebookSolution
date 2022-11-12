
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneTypeViewRaModule } from './phbk-phone-type-view-ra.module';
import { PhbkPhoneTypeViewRaRoutingModule } from './phbk-phone-type-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneTypeViewRaModule,
        PhbkPhoneTypeViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRaLazyRoutingModule { }


