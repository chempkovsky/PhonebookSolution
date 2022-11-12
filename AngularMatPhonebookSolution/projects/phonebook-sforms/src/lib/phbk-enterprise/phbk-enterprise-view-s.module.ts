
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { WebServiceFilterModule } from 'common-components';
import { AppFormatterModule } from 'common-formatters';
import { PhbkEnterpriseViewSformComponent } from './sform/phbk-enterprise-view-sform.component';
import { PhbkEnterpriseViewSdlgComponent } from './sdlg/phbk-enterprise-view-sdlg.component';


@NgModule({
    declarations: [
        PhbkEnterpriseViewSformComponent,
        PhbkEnterpriseViewSdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,
        WebServiceFilterModule,
    ],
    exports: [
        PhbkEnterpriseViewSformComponent,
        PhbkEnterpriseViewSdlgComponent
    ],
    entryComponents: [
        PhbkEnterpriseViewSdlgComponent
    ]
})
export class PhbkEnterpriseViewSModule { }


