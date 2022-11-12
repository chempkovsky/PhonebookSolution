
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserViewSModule } from 'asp-sforms';
import { AspnetuserViewVModule } from 'asp-updforms';
import { AspnetuserViewAModule } from 'asp-updforms';
import { AspnetuserViewUModule } from 'asp-updforms';
import { AspnetuserViewDModule } from 'asp-updforms';

import { AspnetuserViewLformComponent } from './lform/aspnetuser-view-lform.component';
import { AspnetuserViewLdlgComponent } from './ldlg/aspnetuser-view-ldlg.component';


@NgModule({
    declarations: [
        AspnetuserViewLformComponent,
        AspnetuserViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        AspnetuserViewSModule,

        AspnetuserViewVModule,
        AspnetuserViewAModule,
        AspnetuserViewUModule,
        AspnetuserViewDModule,
    ],
    exports: [
        AspnetuserViewLformComponent,
        AspnetuserViewLdlgComponent
    ],
    entryComponents: [
        AspnetuserViewLdlgComponent
    ]
})
export class AspnetuserViewLModule { }


