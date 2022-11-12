
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserrolesViewVformComponent } from './vform/aspnetuserroles-view-vform.component';
import { AspnetuserrolesViewVdlgComponent } from './vdlg/aspnetuserroles-view-vdlg.component';


import { AspnetuserViewSModule } from 'asp-sforms';


@NgModule({
    declarations: [
        AspnetuserrolesViewVformComponent,
        AspnetuserrolesViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        AspnetuserViewSModule,

    ],
    exports: [
        AspnetuserrolesViewVformComponent,
        AspnetuserrolesViewVdlgComponent
    ],
    entryComponents: [
        AspnetuserrolesViewVdlgComponent
    ]
})
export class AspnetuserrolesViewVModule { }


