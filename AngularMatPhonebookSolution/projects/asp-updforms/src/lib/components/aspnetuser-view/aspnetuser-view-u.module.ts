
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserViewUformComponent } from './uform/aspnetuser-view-uform.component';
import { AspnetuserViewUdlgComponent } from './udlg/aspnetuser-view-udlg.component';



@NgModule({
    declarations: [
        AspnetuserViewUformComponent,
        AspnetuserViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetuserViewUformComponent,
        AspnetuserViewUdlgComponent
    ],
    entryComponents: [
        AspnetuserViewUdlgComponent
    ]
})
export class AspnetuserViewUModule { }


