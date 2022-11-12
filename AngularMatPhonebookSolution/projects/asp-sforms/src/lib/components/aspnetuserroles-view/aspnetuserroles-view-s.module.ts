
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { AspnetuserrolesViewSformComponent } from './sform/aspnetuserroles-view-sform.component';
import { AspnetuserrolesViewSdlgComponent } from './sdlg/aspnetuserroles-view-sdlg.component';


@NgModule({
    declarations: [
        AspnetuserrolesViewSformComponent,
        AspnetuserrolesViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        AspnetuserrolesViewSformComponent,
        AspnetuserrolesViewSdlgComponent
    ],
    entryComponents: [
        AspnetuserrolesViewSdlgComponent
    ]
})
export class AspnetuserrolesViewSModule { }


