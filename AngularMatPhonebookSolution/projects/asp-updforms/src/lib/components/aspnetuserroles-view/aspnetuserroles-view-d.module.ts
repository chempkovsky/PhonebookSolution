
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserrolesViewDformComponent } from './dform/aspnetuserroles-view-dform.component';
import { AspnetuserrolesViewDdlgComponent } from './ddlg/aspnetuserroles-view-ddlg.component';

import { AspnetuserViewSModule } from 'asp-sforms';

@NgModule({
    declarations: [
        AspnetuserrolesViewDformComponent,
        AspnetuserrolesViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        AspnetuserViewSModule,

    ],
    exports: [
        AspnetuserrolesViewDformComponent,
        AspnetuserrolesViewDdlgComponent
    ],
    entryComponents: [
        AspnetuserrolesViewDdlgComponent
    ]
})
export class AspnetuserrolesViewDModule { }


