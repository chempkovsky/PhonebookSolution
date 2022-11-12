
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserrolesViewUformComponent } from './uform/aspnetuserroles-view-uform.component';
import { AspnetuserrolesViewUdlgComponent } from './udlg/aspnetuserroles-view-udlg.component';


import { AspnetuserViewSModule } from 'asp-sforms';

@NgModule({
    declarations: [
        AspnetuserrolesViewUformComponent,
        AspnetuserrolesViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        AspnetuserViewSModule,

    ],
    exports: [
        AspnetuserrolesViewUformComponent,
        AspnetuserrolesViewUdlgComponent
    ],
    entryComponents: [
        AspnetuserrolesViewUdlgComponent
    ]
})
export class AspnetuserrolesViewUModule { }


