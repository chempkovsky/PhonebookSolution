
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetmodelViewAformComponent } from './aform/aspnetmodel-view-aform.component';
import { AspnetmodelViewAdlgComponent } from './adlg/aspnetmodel-view-adlg.component';



@NgModule({
    declarations: [
        AspnetmodelViewAformComponent,
        AspnetmodelViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetmodelViewAformComponent,
        AspnetmodelViewAdlgComponent
    ],
    entryComponents: [
        AspnetmodelViewAdlgComponent
    ]
})
export class AspnetmodelViewAModule { }


