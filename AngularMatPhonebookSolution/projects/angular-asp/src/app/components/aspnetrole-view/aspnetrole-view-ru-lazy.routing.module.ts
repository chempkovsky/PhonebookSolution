
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetroleViewRuModule } from './aspnetrole-view-ru.module';
import { AspnetroleViewRuRoutingModule } from './aspnetrole-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetroleViewRuModule,
        AspnetroleViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRuLazyRoutingModule { }


