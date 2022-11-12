
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetroleViewUformComponent } from './uform/aspnetrole-view-uform.component';
import { AspnetroleViewUdlgComponent } from './udlg/aspnetrole-view-udlg.component';



@NgModule({
    declarations: [
        AspnetroleViewUformComponent,
        AspnetroleViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetroleViewUformComponent,
        AspnetroleViewUdlgComponent
    ],
    entryComponents: [
        AspnetroleViewUdlgComponent
    ]
})
export class AspnetroleViewUModule { }


