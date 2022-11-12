
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetuserViewRuModule } from './aspnetuser-view-ru.module';
import { AspnetuserViewRuRoutingModule } from './aspnetuser-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetuserViewRuModule,
        AspnetuserViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRuLazyRoutingModule { }


