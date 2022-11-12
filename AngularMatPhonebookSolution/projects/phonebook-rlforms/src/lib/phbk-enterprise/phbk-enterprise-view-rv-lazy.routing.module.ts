
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEnterpriseViewRvModule } from './phbk-enterprise-view-rv.module';
import { PhbkEnterpriseViewRvRoutingModule } from './phbk-enterprise-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEnterpriseViewRvModule,
        PhbkEnterpriseViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRvLazyRoutingModule { }


