
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { PhbkEmployeeViewSformComponent } from './sform/phbk-employee-view-sform.component';
import { PhbkEmployeeViewSdlgComponent } from './sdlg/phbk-employee-view-sdlg.component';


@NgModule({
    declarations: [
        PhbkEmployeeViewSformComponent,
        PhbkEmployeeViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        PhbkEmployeeViewSformComponent,
        PhbkEmployeeViewSdlgComponent
    ],
    entryComponents: [
        PhbkEmployeeViewSdlgComponent
    ]
})
export class PhbkEmployeeViewSModule { }


