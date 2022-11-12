
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetmodelViewSModule } from 'asp-sforms';
import { AspnetmodelViewRdlistComponent } from './rdlist/aspnetmodel-view-rdlist.component';

import { AspnetmodelViewVModule } from 'asp-updforms';
import { AspnetmodelViewAModule } from 'asp-updforms';
import { AspnetmodelViewUModule } from 'asp-updforms';
import { AspnetmodelViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetmodelViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetmodelViewSModule,



        AspnetmodelViewVModule,
        AspnetmodelViewAModule,
        AspnetmodelViewUModule,
        AspnetmodelViewDModule,



    ],
    exports: [
        AspnetmodelViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetmodelViewRdlModule { }


