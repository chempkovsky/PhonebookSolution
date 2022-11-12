
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEnterpriseViewDformComponent } from './dform/phbk-enterprise-view-dform.component';
import { PhbkEnterpriseViewDdlgComponent } from './ddlg/phbk-enterprise-view-ddlg.component';


@NgModule({
    declarations: [
        PhbkEnterpriseViewDformComponent,
        PhbkEnterpriseViewDdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkEnterpriseViewDformComponent,
        PhbkEnterpriseViewDdlgComponent
    ],
    entryComponents: [
        PhbkEnterpriseViewDdlgComponent
    ]
})
export class PhbkEnterpriseViewDModule { }


