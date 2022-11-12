
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetmodelViewUformComponent } from './uform/aspnetmodel-view-uform.component';
import { AspnetmodelViewUdlgComponent } from './udlg/aspnetmodel-view-udlg.component';



@NgModule({
    declarations: [
        AspnetmodelViewUformComponent,
        AspnetmodelViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetmodelViewUformComponent,
        AspnetmodelViewUdlgComponent
    ],
    entryComponents: [
        AspnetmodelViewUdlgComponent
    ]
})
export class AspnetmodelViewUModule { }


