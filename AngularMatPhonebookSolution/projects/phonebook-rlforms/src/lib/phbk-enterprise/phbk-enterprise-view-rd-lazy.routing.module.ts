
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEnterpriseViewRdModule } from './phbk-enterprise-view-rd.module';
import { PhbkEnterpriseViewRdRoutingModule } from './phbk-enterprise-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEnterpriseViewRdModule,
        PhbkEnterpriseViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRdLazyRoutingModule { }


