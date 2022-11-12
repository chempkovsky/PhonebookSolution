
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetroleViewSModule } from 'asp-sforms';
import { AspnetroleViewVModule } from 'asp-updforms';
import { AspnetroleViewAModule } from 'asp-updforms';
import { AspnetroleViewUModule } from 'asp-updforms';
import { AspnetroleViewDModule } from 'asp-updforms';

import { AspnetroleViewLformComponent } from './lform/aspnetrole-view-lform.component';
import { AspnetroleViewLdlgComponent } from './ldlg/aspnetrole-view-ldlg.component';


@NgModule({
    declarations: [
        AspnetroleViewLformComponent,
        AspnetroleViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        AspnetroleViewSModule,

        AspnetroleViewVModule,
        AspnetroleViewAModule,
        AspnetroleViewUModule,
        AspnetroleViewDModule,
    ],
    exports: [
        AspnetroleViewLformComponent,
        AspnetroleViewLdlgComponent
    ],
    entryComponents: [
        AspnetroleViewLdlgComponent
    ]
})
export class AspnetroleViewLModule { }


