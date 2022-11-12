

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';
import { AspRlFeature01FtrComponent } from './asp-rl-feature01.ftr.component';




@NgModule({
    declarations: [
        AspRlFeature01FtrComponent,
    ],
    imports: [
        CommonModule,
        RouterModule,
        AppMaterialModule,
        AppFlexLayoutModule,
    ],
    exports: [
        AspRlFeature01FtrComponent,
    ],
    entryComponents: [
    ]
})
export class AspRlFeature01FtrModule { }


