
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserrolesViewRvModule } from './aspnetuserroles-view-rv.module';
import { AspnetuserrolesViewRvRoutingModule } from './aspnetuserroles-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserrolesViewRvModule,
        AspnetuserrolesViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRvLazyRoutingModule { }


