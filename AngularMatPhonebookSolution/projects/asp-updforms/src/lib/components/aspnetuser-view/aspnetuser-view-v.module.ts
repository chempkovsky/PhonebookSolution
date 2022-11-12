
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserViewVformComponent } from './vform/aspnetuser-view-vform.component';
import { AspnetuserViewVdlgComponent } from './vdlg/aspnetuser-view-vdlg.component';



@NgModule({
    declarations: [
        AspnetuserViewVformComponent,
        AspnetuserViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetuserViewVformComponent,
        AspnetuserViewVdlgComponent
    ],
    entryComponents: [
        AspnetuserViewVdlgComponent
    ]
})
export class AspnetuserViewVModule { }


