
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneTypeViewRvModule } from './phbk-phone-type-view-rv.module';
import { PhbkPhoneTypeViewRvRoutingModule } from './phbk-phone-type-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneTypeViewRvModule,
        PhbkPhoneTypeViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRvLazyRoutingModule { }


