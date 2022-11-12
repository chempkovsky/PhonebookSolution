

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { AspRdlFeature01FtrComponent } from './asp-rdl-feature01.ftr.component';




@NgModule({
    declarations: [
        AspRdlFeature01FtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
    ],
    exports: [
        AspRdlFeature01FtrComponent,
    ],
    entryComponents: [
    ]
})
export class AspRdlFeature01FtrModule { }


