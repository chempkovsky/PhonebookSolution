
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetmodelViewRvModule } from './aspnetmodel-view-rv.module';
import { AspnetmodelViewRvRoutingModule } from './aspnetmodel-view-rv.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetmodelViewRvModule,
        AspnetmodelViewRvRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRvLazyRoutingModule { }


