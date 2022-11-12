
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { AspnetuserViewSformComponent } from './sform/aspnetuser-view-sform.component';
import { AspnetuserViewSdlgComponent } from './sdlg/aspnetuser-view-sdlg.component';


@NgModule({
    declarations: [
        AspnetuserViewSformComponent,
        AspnetuserViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        AspnetuserViewSformComponent,
        AspnetuserViewSdlgComponent
    ],
    entryComponents: [
        AspnetuserViewSdlgComponent
    ]
})
export class AspnetuserViewSModule { }


