
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { AspnetmodelViewSformComponent } from './sform/aspnetmodel-view-sform.component';
import { AspnetmodelViewSdlgComponent } from './sdlg/aspnetmodel-view-sdlg.component';


@NgModule({
    declarations: [
        AspnetmodelViewSformComponent,
        AspnetmodelViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        AspnetmodelViewSformComponent,
        AspnetmodelViewSdlgComponent
    ],
    entryComponents: [
        AspnetmodelViewSdlgComponent
    ]
})
export class AspnetmodelViewSModule { }


