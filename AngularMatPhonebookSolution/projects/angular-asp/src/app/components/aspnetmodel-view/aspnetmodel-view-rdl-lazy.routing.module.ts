


import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AspnetmodelViewRdlModule } from './aspnetmodel-view-rdl.module';
import { AspnetmodelViewRdlRoutingModule } from './aspnetmodel-view-rdl.routing.module';

@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        AspnetmodelViewRdlModule,
        AspnetmodelViewRdlRoutingModule,
    ],
    exports: [
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRdlLazyRoutingModule { }


