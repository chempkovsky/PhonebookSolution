
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetroleViewRdModule } from './aspnetrole-view-rd.module';
import { AspnetroleViewRdRoutingModule } from './aspnetrole-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetroleViewRdModule,
        AspnetroleViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRdLazyRoutingModule { }


