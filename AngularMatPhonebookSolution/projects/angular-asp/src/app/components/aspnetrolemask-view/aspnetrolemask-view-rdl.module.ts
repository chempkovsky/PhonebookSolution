
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetrolemaskViewSModule } from 'asp-sforms';
import { AspnetrolemaskViewRdlistComponent } from './rdlist/aspnetrolemask-view-rdlist.component';

import { AspnetrolemaskViewVModule } from 'asp-updforms';
import { AspnetrolemaskViewAModule } from 'asp-updforms';
import { AspnetrolemaskViewUModule } from 'asp-updforms';
import { AspnetrolemaskViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetrolemaskViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetrolemaskViewSModule,



        AspnetrolemaskViewVModule,
        AspnetrolemaskViewAModule,
        AspnetrolemaskViewUModule,
        AspnetrolemaskViewDModule,



    ],
    exports: [
        AspnetrolemaskViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetrolemaskViewRdlModule { }


