


import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEnterpriseViewRdlModule } from './phbk-enterprise-view-rdl.module';
import { PhbkEnterpriseViewRdlRoutingModule } from './phbk-enterprise-view-rdl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEnterpriseViewRdlModule,
        PhbkEnterpriseViewRdlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRdlLazyRoutingModule { }


