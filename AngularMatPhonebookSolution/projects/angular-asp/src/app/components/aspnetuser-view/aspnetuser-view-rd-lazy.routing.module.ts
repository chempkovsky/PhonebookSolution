
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserViewRdModule } from './aspnetuser-view-rd.module';
import { AspnetuserViewRdRoutingModule } from './aspnetuser-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserViewRdModule,
        AspnetuserViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRdLazyRoutingModule { }


