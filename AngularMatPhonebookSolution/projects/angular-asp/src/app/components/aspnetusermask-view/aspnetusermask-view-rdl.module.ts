
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { AspnetusermaskViewSModule } from 'asp-sforms';
import { AspnetusermaskViewRdlistComponent } from './rdlist/aspnetusermask-view-rdlist.component';






@NgModule({
    declarations: [
        AspnetusermaskViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        AspnetusermaskViewSModule,






    ],
    exports: [
        AspnetusermaskViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class AspnetusermaskViewRdlModule { }


