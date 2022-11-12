
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneViewRuModule } from './phbk-phone-view-ru.module';
import { PhbkPhoneViewRuRoutingModule } from './phbk-phone-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneViewRuModule,
        PhbkPhoneViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRuLazyRoutingModule { }


