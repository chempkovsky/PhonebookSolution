
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneViewRlModule } from './phbk-phone-view-rl.module';
import { PhbkPhoneViewRlRoutingModule } from './phbk-phone-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneViewRlModule,
        PhbkPhoneViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRlLazyRoutingModule { }


