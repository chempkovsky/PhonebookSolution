
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetmodelViewRaModule } from './aspnetmodel-view-ra.module';
import { AspnetmodelViewRaRoutingModule } from './aspnetmodel-view-ra.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetmodelViewRaModule,
        AspnetmodelViewRaRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRaLazyRoutingModule { }


