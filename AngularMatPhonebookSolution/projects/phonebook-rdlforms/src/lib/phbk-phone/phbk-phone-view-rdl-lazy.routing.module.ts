


import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkPhoneViewRdlModule } from './phbk-phone-view-rdl.module';
import { PhbkPhoneViewRdlRoutingModule } from './phbk-phone-view-rdl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkPhoneViewRdlModule,
        PhbkPhoneViewRdlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkPhoneViewRdlLazyRoutingModule { }


