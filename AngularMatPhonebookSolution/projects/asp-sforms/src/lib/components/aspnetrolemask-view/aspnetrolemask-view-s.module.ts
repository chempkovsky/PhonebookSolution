
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { AspnetrolemaskViewSformComponent } from './sform/aspnetrolemask-view-sform.component';
import { AspnetrolemaskViewSdlgComponent } from './sdlg/aspnetrolemask-view-sdlg.component';


@NgModule({
    declarations: [
        AspnetrolemaskViewSformComponent,
        AspnetrolemaskViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        AspnetrolemaskViewSformComponent,
        AspnetrolemaskViewSdlgComponent
    ],
    entryComponents: [
        AspnetrolemaskViewSdlgComponent
    ]
})
export class AspnetrolemaskViewSModule { }


