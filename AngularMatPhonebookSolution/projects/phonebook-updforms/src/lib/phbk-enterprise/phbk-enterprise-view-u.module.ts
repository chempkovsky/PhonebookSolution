
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEnterpriseViewUformComponent } from './uform/phbk-enterprise-view-uform.component';
import { PhbkEnterpriseViewUdlgComponent } from './udlg/phbk-enterprise-view-udlg.component';



@NgModule({
    declarations: [
        PhbkEnterpriseViewUformComponent,
        PhbkEnterpriseViewUdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkEnterpriseViewUformComponent,
        PhbkEnterpriseViewUdlgComponent
    ],
    entryComponents: [
        PhbkEnterpriseViewUdlgComponent
    ]
})
export class PhbkEnterpriseViewUModule { }


