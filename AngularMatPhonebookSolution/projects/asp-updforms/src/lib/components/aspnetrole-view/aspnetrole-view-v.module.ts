
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetroleViewVformComponent } from './vform/aspnetrole-view-vform.component';
import { AspnetroleViewVdlgComponent } from './vdlg/aspnetrole-view-vdlg.component';



@NgModule({
    declarations: [
        AspnetroleViewVformComponent,
        AspnetroleViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetroleViewVformComponent,
        AspnetroleViewVdlgComponent
    ],
    entryComponents: [
        AspnetroleViewVdlgComponent
    ]
})
export class AspnetroleViewVModule { }


