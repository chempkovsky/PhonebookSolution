
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneViewRaModule } from './phbk-phone-view-ra.module';
import { PhbkPhoneViewRaRoutingModule } from './phbk-phone-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneViewRaModule,
        PhbkPhoneViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRaLazyRoutingModule { }


