
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetroleViewRlModule } from './aspnetrole-view-rl.module';
import { AspnetroleViewRlRoutingModule } from './aspnetrole-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetroleViewRlModule,
        AspnetroleViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRlLazyRoutingModule { }


