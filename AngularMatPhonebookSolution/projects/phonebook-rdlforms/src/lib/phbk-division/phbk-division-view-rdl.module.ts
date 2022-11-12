
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AppFlexLayoutModule } from 'common-modules';
import { AppMaterialModule } from 'common-modules';

import { PhbkDivisionViewSModule } from 'phonebook-sforms';
import { PhbkDivisionViewRdlistComponent } from './rdlist/phbk-division-view-rdlist.component';

import { PhbkDivisionViewVModule } from 'phonebook-updforms';
import { PhbkDivisionViewAModule } from 'phonebook-updforms';
import { PhbkDivisionViewUModule } from 'phonebook-updforms';
import { PhbkDivisionViewDModule } from 'phonebook-updforms';





@NgModule({
    declarations: [
        PhbkDivisionViewRdlistComponent,

    ],
    imports: [
        CommonModule,
        RouterModule,
        // BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,

        PhbkDivisionViewSModule,



        PhbkDivisionViewVModule,
        PhbkDivisionViewAModule,
        PhbkDivisionViewUModule,
        PhbkDivisionViewDModule,



    ],
    exports: [
        PhbkDivisionViewRdlistComponent,
    ],
    entryComponents: [
    ]
})
export class PhbkDivisionViewRdlModule { }


