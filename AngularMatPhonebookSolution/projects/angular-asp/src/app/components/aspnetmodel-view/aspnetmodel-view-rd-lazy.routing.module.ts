
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetmodelViewRdModule } from './aspnetmodel-view-rd.module';
import { AspnetmodelViewRdRoutingModule } from './aspnetmodel-view-rd.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetmodelViewRdModule,
        AspnetmodelViewRdRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRdLazyRoutingModule { }


