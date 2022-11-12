
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetuserrolesViewSModule } from 'asp-sforms';
import { AspnetuserrolesViewRdlistComponent } from './rdlist/aspnetuserroles-view-rdlist.component';

import { AspnetuserrolesViewVModule } from 'asp-updforms';
import { AspnetuserrolesViewAModule } from 'asp-updforms';
import { AspnetuserrolesViewUModule } from 'asp-updforms';
import { AspnetuserrolesViewDModule } from 'asp-updforms';


import { AspnetuserViewSModule } from 'asp-sforms';



@NgModule({
    declarations: [
        AspnetuserrolesViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetuserrolesViewSModule,



        AspnetuserrolesViewVModule,
        AspnetuserrolesViewAModule,
        AspnetuserrolesViewUModule,
        AspnetuserrolesViewDModule,


        AspnetuserViewSModule,

    ],
    exports: [
        AspnetuserrolesViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetuserrolesViewRdlModule { }


