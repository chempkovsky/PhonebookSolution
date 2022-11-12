
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetroleViewSModule } from 'asp-sforms';
import { AspnetroleViewRdlistComponent } from './rdlist/aspnetrole-view-rdlist.component';

import { AspnetroleViewVModule } from 'asp-updforms';
import { AspnetroleViewAModule } from 'asp-updforms';
import { AspnetroleViewUModule } from 'asp-updforms';
import { AspnetroleViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetroleViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetroleViewSModule,



        AspnetroleViewVModule,
        AspnetroleViewAModule,
        AspnetroleViewUModule,
        AspnetroleViewDModule,



    ],
    exports: [
        AspnetroleViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetroleViewRdlModule { }


