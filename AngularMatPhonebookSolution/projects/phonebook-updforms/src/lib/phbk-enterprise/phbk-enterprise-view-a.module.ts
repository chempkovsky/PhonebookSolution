
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';
import { AppFormatterModule } from 'common-formatters';

import { PhbkEnterpriseViewAformComponent } from './aform/phbk-enterprise-view-aform.component';
import { PhbkEnterpriseViewAdlgComponent } from './adlg/phbk-enterprise-view-adlg.component';



@NgModule({
    declarations: [
        PhbkEnterpriseViewAformComponent,
        PhbkEnterpriseViewAdlgComponent
    ],
    imports: [
        CommonModule,
        AppMaterialModule,
        AppFlexLayoutModule,
        AppFormatterModule,

    ],
    exports: [
        PhbkEnterpriseViewAformComponent,
        PhbkEnterpriseViewAdlgComponent
    ],
    entryComponents: [
        PhbkEnterpriseViewAdlgComponent
    ]
})
export class PhbkEnterpriseViewAModule { }


