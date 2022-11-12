
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PhbkEnterpriseViewRuModule } from './phbk-enterprise-view-ru.module';
import { PhbkEnterpriseViewRuRoutingModule } from './phbk-enterprise-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        PhbkEnterpriseViewRuModule,
        PhbkEnterpriseViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRuLazyRoutingModule { }


