
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { AspnetusermaskViewSformComponent } from './sform/aspnetusermask-view-sform.component';
import { AspnetusermaskViewSdlgComponent } from './sdlg/aspnetusermask-view-sdlg.component';


@NgModule({
    declarations: [
        AspnetusermaskViewSformComponent,
        AspnetusermaskViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        AspnetusermaskViewSformComponent,
        AspnetusermaskViewSdlgComponent
    ],
    entryComponents: [
        AspnetusermaskViewSdlgComponent
    ]
})
export class AspnetusermaskViewSModule { }


