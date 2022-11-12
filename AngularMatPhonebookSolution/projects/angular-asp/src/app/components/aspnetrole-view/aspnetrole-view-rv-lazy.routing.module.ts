
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetroleViewRvModule } from './aspnetrole-view-rv.module';
import { AspnetroleViewRvRoutingModule } from './aspnetrole-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetroleViewRvModule,
        AspnetroleViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRvLazyRoutingModule { }


