
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserrolesViewRdModule } from './aspnetuserroles-view-rd.module';
import { AspnetuserrolesViewRdRoutingModule } from './aspnetuserroles-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserrolesViewRdModule,
        AspnetuserrolesViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRdLazyRoutingModule { }


