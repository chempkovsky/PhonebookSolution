
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserViewDformComponent } from './dform/aspnetuser-view-dform.component';
import { AspnetuserViewDdlgComponent } from './ddlg/aspnetuser-view-ddlg.component';


@NgModule({
    declarations: [
        AspnetuserViewDformComponent,
        AspnetuserViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetuserViewDformComponent,
        AspnetuserViewDdlgComponent
    ],
    entryComponents: [
        AspnetuserViewDdlgComponent
    ]
})
export class AspnetuserViewDModule { }


