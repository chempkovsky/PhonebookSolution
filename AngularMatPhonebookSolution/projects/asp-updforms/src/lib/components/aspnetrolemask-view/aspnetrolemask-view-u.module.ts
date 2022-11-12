
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetrolemaskViewUformComponent } from './uform/aspnetrolemask-view-uform.component';
import { AspnetrolemaskViewUdlgComponent } from './udlg/aspnetrolemask-view-udlg.component';



@NgModule({
    declarations: [
        AspnetrolemaskViewUformComponent,
        AspnetrolemaskViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetrolemaskViewUformComponent,
        AspnetrolemaskViewUdlgComponent
    ],
    entryComponents: [
        AspnetrolemaskViewUdlgComponent
    ]
})
export class AspnetrolemaskViewUModule { }


