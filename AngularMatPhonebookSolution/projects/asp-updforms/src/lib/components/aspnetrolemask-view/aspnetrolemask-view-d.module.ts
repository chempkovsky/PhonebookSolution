
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetrolemaskViewDformComponent } from './dform/aspnetrolemask-view-dform.component';
import { AspnetrolemaskViewDdlgComponent } from './ddlg/aspnetrolemask-view-ddlg.component';


@NgModule({
    declarations: [
        AspnetrolemaskViewDformComponent,
        AspnetrolemaskViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetrolemaskViewDformComponent,
        AspnetrolemaskViewDdlgComponent
    ],
    entryComponents: [
        AspnetrolemaskViewDdlgComponent
    ]
})
export class AspnetrolemaskViewDModule { }


