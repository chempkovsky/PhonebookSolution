
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkEnterpriseViewSModule } from 'phonebook-sforms';
import { PhbkEnterpriseViewRdlistComponent } from './rdlist/phbk-enterprise-view-rdlist.component';

import { PhbkEnterpriseViewVModule } from 'phonebook-updforms';
import { PhbkEnterpriseViewAModule } from 'phonebook-updforms';
import { PhbkEnterpriseViewUModule } from 'phonebook-updforms';
import { PhbkEnterpriseViewDModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkEnterpriseViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkEnterpriseViewSModule,



        PhbkEnterpriseViewVModule,
        PhbkEnterpriseViewAModule,
        PhbkEnterpriseViewUModule,
        PhbkEnterpriseViewDModule,



    ],
    exports: [
        PhbkEnterpriseViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkEnterpriseViewRdlModule { }


