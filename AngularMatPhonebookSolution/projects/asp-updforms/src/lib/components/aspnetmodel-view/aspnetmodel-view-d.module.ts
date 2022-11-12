
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetmodelViewDformComponent } from './dform/aspnetmodel-view-dform.component';
import { AspnetmodelViewDdlgComponent } from './ddlg/aspnetmodel-view-ddlg.component';


@NgModule({
    declarations: [
        AspnetmodelViewDformComponent,
        AspnetmodelViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetmodelViewDformComponent,
        AspnetmodelViewDdlgComponent
    ],
    entryComponents: [
        AspnetmodelViewDdlgComponent
    ]
})
export class AspnetmodelViewDModule { }


