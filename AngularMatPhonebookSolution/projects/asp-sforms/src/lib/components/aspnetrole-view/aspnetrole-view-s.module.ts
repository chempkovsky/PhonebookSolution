
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { AspnetroleViewSformComponent } from './sform/aspnetrole-view-sform.component';
import { AspnetroleViewSdlgComponent } from './sdlg/aspnetrole-view-sdlg.component';


@NgModule({
    declarations: [
        AspnetroleViewSformComponent,
        AspnetroleViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        AspnetroleViewSformComponent,
        AspnetroleViewSdlgComponent
    ],
    entryComponents: [
        AspnetroleViewSdlgComponent
    ]
})
export class AspnetroleViewSModule { }


