
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEnterpriseViewRlModule } from './phbk-enterprise-view-rl.module';
import { PhbkEnterpriseViewRlRoutingModule } from './phbk-enterprise-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEnterpriseViewRlModule,
        PhbkEnterpriseViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRlLazyRoutingModule { }


