
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetrolemaskViewAformComponent } from './aform/aspnetrolemask-view-aform.component';
import { AspnetrolemaskViewAdlgComponent } from './adlg/aspnetrolemask-view-adlg.component';



@NgModule({
    declarations: [
        AspnetrolemaskViewAformComponent,
        AspnetrolemaskViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetrolemaskViewAformComponent,
        AspnetrolemaskViewAdlgComponent
    ],
    entryComponents: [
        AspnetrolemaskViewAdlgComponent
    ]
})
export class AspnetrolemaskViewAModule { }


