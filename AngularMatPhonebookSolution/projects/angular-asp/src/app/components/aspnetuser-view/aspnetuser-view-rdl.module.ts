
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserViewSModule } from 'asp-sforms';
import { AspnetuserViewRdlistComponent } from './rdlist/aspnetuser-view-rdlist.component';

import { AspnetuserViewVModule } from 'asp-updforms';
import { AspnetuserViewAModule } from 'asp-updforms';
import { AspnetuserViewUModule } from 'asp-updforms';
import { AspnetuserViewDModule } from 'asp-updforms';





@NgModule({
    declarations: [
        AspnetuserViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetuserViewSModule,



        AspnetuserViewVModule,
        AspnetuserViewAModule,
        AspnetuserViewUModule,
        AspnetuserViewDModule,



    ],
    exports: [
        AspnetuserViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserViewRdlModule { }


