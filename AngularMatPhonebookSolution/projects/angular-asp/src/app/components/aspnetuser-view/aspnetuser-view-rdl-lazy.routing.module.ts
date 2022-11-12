


import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserViewRdlModule } from './aspnetuser-view-rdl.module';
import { AspnetuserViewRdlRoutingModule } from './aspnetuser-view-rdl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserViewRdlModule,
        AspnetuserViewRdlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRdlLazyRoutingModule { }


