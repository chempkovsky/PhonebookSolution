
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneTypeViewRuModule } from './phbk-phone-type-view-ru.module';
import { PhbkPhoneTypeViewRuRoutingModule } from './phbk-phone-type-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneTypeViewRuModule,
        PhbkPhoneTypeViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRuLazyRoutingModule { }


