
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserViewRvModule } from './aspnetuser-view-rv.module';
import { AspnetuserViewRvRoutingModule } from './aspnetuser-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserViewRvModule,
        AspnetuserViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRvLazyRoutingModule { }


