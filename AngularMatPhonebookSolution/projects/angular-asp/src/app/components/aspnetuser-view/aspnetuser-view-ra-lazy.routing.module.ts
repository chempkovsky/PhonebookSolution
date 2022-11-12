
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserViewRaModule } from './aspnetuser-view-ra.module';
import { AspnetuserViewRaRoutingModule } from './aspnetuser-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserViewRaModule,
        AspnetuserViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRaLazyRoutingModule { }


