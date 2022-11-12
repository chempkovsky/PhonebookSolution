
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetroleViewDformComponent } from './dform/aspnetrole-view-dform.component';
import { AspnetroleViewDdlgComponent } from './ddlg/aspnetrole-view-ddlg.component';


@NgModule({
    declarations: [
        AspnetroleViewDformComponent,
        AspnetroleViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetroleViewDformComponent,
        AspnetroleViewDdlgComponent
    ],
    entryComponents: [
        AspnetroleViewDdlgComponent
    ]
})
export class AspnetroleViewDModule { }


