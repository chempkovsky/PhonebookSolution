
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserViewRlModule } from './aspnetuser-view-rl.module';
import { AspnetuserViewRlRoutingModule } from './aspnetuser-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserViewRlModule,
        AspnetuserViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRlLazyRoutingModule { }


