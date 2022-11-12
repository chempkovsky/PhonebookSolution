
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneViewRvModule } from './phbk-phone-view-rv.module';
import { PhbkPhoneViewRvRoutingModule } from './phbk-phone-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneViewRvModule,
        PhbkPhoneViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRvLazyRoutingModule { }


