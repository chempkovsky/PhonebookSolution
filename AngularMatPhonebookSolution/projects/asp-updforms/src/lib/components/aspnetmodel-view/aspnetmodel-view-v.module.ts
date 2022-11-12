
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetmodelViewVformComponent } from './vform/aspnetmodel-view-vform.component';
import { AspnetmodelViewVdlgComponent } from './vdlg/aspnetmodel-view-vdlg.component';



@NgModule({
    declarations: [
        AspnetmodelViewVformComponent,
        AspnetmodelViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetmodelViewVformComponent,
        AspnetmodelViewVdlgComponent
    ],
    entryComponents: [
        AspnetmodelViewVdlgComponent
    ]
})
export class AspnetmodelViewVModule { }


