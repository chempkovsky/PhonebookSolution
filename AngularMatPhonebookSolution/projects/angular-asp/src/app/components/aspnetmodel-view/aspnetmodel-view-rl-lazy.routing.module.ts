
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetmodelViewRlModule } from './aspnetmodel-view-rl.module';
import { AspnetmodelViewRlRoutingModule } from './aspnetmodel-view-rl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetmodelViewRlModule,
        AspnetmodelViewRlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRlLazyRoutingModule { }


