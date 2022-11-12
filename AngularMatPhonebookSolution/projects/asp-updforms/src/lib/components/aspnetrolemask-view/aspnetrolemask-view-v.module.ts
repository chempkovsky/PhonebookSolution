
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetrolemaskViewVformComponent } from './vform/aspnetrolemask-view-vform.component';
import { AspnetrolemaskViewVdlgComponent } from './vdlg/aspnetrolemask-view-vdlg.component';



@NgModule({
    declarations: [
        AspnetrolemaskViewVformComponent,
        AspnetrolemaskViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetrolemaskViewVformComponent,
        AspnetrolemaskViewVdlgComponent
    ],
    entryComponents: [
        AspnetrolemaskViewVdlgComponent
    ]
})
export class AspnetrolemaskViewVModule { }


