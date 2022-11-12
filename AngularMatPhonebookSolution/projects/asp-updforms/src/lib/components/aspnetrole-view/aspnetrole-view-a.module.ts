
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetroleViewAformComponent } from './aform/aspnetrole-view-aform.component';
import { AspnetroleViewAdlgComponent } from './adlg/aspnetrole-view-adlg.component';



@NgModule({
    declarations: [
        AspnetroleViewAformComponent,
        AspnetroleViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetroleViewAformComponent,
        AspnetroleViewAdlgComponent
    ],
    entryComponents: [
        AspnetroleViewAdlgComponent
    ]
})
export class AspnetroleViewAModule { }


