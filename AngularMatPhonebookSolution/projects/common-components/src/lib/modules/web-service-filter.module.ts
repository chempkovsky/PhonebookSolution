
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { BrowserModule } from '@angular/platform-browser';

import { AppMaterialModule } from 'common-modules';
import { AppFlexLayoutModule } from 'common-modules';

// import { IUniqServiceFilterDef } from 'common-interfaces';
// import { IUniqServiceFilter } from 'common-interfaces';
// import { IWebServiceFilter } from 'common-interfaces';
// import { IWebServiceFilterDef } from 'common-interfaces';
// import { IWebServiceFilterOperator } from 'common-interfaces';
// import { IWebServiceFilterRslt } from 'common-interfaces';
// import { AppGlblSettingsService } from 'common-services';

import { WebServiceFilterComponent } from './../web-service-filter/web-service-filter.component';
import { UniqServiceFilterComponent } from './../uniq-service-filter/uniq-service-filter.component';

import { ColumnSelectorComponent } from './../column-selector/column-selector.component';
import { ColumnSelectorDlgComponent } from './../column-selector-dlg/column-selector-dlg.component';
import { MessageDialogComponent } from './../message-dialog/message-dialog.component';



@NgModule({
    declarations: [
     //   IWebServiceFilter,
     //   IWebServiceFilterDef,
     //   IWebServiceFilterOperator,
     //   IWebServiceFilterRslt,
     //   AppGlblSettingsService,
        UniqServiceFilterComponent,
        WebServiceFilterComponent,
        ColumnSelectorComponent,
        ColumnSelectorDlgComponent,
        MessageDialogComponent,
    ],
    imports: [
        CommonModule,
//        BrowserModule,
        AppMaterialModule,
        AppFlexLayoutModule,
    ],
    exports: [
        UniqServiceFilterComponent,
        WebServiceFilterComponent,
        ColumnSelectorComponent,
        ColumnSelectorDlgComponent,
        MessageDialogComponent,
    ],
    entryComponents: [
        ColumnSelectorDlgComponent,
        MessageDialogComponent,
    ]
})
export class WebServiceFilterModule { }


