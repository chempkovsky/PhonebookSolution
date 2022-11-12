
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneTypeViewRlModule } from './phbk-phone-type-view-rl.module';
import { PhbkPhoneTypeViewRlRoutingModule } from './phbk-phone-type-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneTypeViewRlModule,
        PhbkPhoneTypeViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneTypeViewRlLazyRoutingModule { }


