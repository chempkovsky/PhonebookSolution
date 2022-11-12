
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEnterpriseViewVformComponent } from './vform/phbk-enterprise-view-vform.component';
import { PhbkEnterpriseViewVdlgComponent } from './vdlg/phbk-enterprise-view-vdlg.component';



@NgModule({
    declarations: [
        PhbkEnterpriseViewVformComponent,
        PhbkEnterpriseViewVdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkEnterpriseViewVformComponent,
        PhbkEnterpriseViewVdlgComponent
    ],
    entryComponents: [
        PhbkEnterpriseViewVdlgComponent
    ]
})
export class PhbkEnterpriseViewVModule { }


