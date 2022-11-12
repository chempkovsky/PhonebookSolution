
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEnterpriseViewRaModule } from './phbk-enterprise-view-ra.module';
import { PhbkEnterpriseViewRaRoutingModule } from './phbk-enterprise-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEnterpriseViewRaModule,
        PhbkEnterpriseViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRaLazyRoutingModule { }


