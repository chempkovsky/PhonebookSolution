
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserrolesViewAformComponent } from './aform/aspnetuserroles-view-aform.component';
import { AspnetuserrolesViewAdlgComponent } from './adlg/aspnetuserroles-view-adlg.component';


import { AspnetuserViewSModule } from 'asp-sforms';

@NgModule({
    declarations: [
        AspnetuserrolesViewAformComponent,
        AspnetuserrolesViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        AspnetuserViewSModule,

    ],
    exports: [
        AspnetuserrolesViewAformComponent,
        AspnetuserrolesViewAdlgComponent
    ],
    entryComponents: [
        AspnetuserrolesViewAdlgComponent
    ]
})
export class AspnetuserrolesViewAModule { }


