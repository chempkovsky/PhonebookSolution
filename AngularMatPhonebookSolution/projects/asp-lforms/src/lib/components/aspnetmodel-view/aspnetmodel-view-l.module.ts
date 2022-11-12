
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetmodelViewSModule } from 'asp-sforms';
import { AspnetmodelViewVModule } from 'asp-updforms';
import { AspnetmodelViewAModule } from 'asp-updforms';
import { AspnetmodelViewUModule } from 'asp-updforms';
import { AspnetmodelViewDModule } from 'asp-updforms';

import { AspnetmodelViewLformComponent } from './lform/aspnetmodel-view-lform.component';
import { AspnetmodelViewLdlgComponent } from './ldlg/aspnetmodel-view-ldlg.component';


@NgModule({
    declarations: [
        AspnetmodelViewLformComponent,
        AspnetmodelViewLdlgComponent
    ],
    imports: [
        CommonModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        // WebServiceFilterModule,
        AspnetmodelViewSModule,

        AspnetmodelViewVModule,
        AspnetmodelViewAModule,
        AspnetmodelViewUModule,
        AspnetmodelViewDModule,
    ],
    exports: [
        AspnetmodelViewLformComponent,
        AspnetmodelViewLdlgComponent
    ],
    entryComponents: [
        AspnetmodelViewLdlgComponent
    ]
})
export class AspnetmodelViewLModule { }


