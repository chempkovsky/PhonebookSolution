
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { AspnetuserViewAformComponent } from './aform/aspnetuser-view-aform.component';
import { AspnetuserViewAdlgComponent } from './adlg/aspnetuser-view-adlg.component';



@NgModule({
    declarations: [
        AspnetuserViewAformComponent,
        AspnetuserViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        AspnetuserViewAformComponent,
        AspnetuserViewAdlgComponent
    ],
    entryComponents: [
        AspnetuserViewAdlgComponent
    ]
})
export class AspnetuserViewAModule { }


