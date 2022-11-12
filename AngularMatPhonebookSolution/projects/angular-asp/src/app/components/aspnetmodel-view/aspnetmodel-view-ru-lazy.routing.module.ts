
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetmodelViewRuModule } from './aspnetmodel-view-ru.module';
import { AspnetmodelViewRuRoutingModule } from './aspnetmodel-view-ru.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetmodelViewRuModule,
        AspnetmodelViewRuRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRuLazyRoutingModule { }


