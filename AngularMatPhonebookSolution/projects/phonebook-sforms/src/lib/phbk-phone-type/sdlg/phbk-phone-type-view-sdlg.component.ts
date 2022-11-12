
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IPhbkPhoneTypeViewDlg } from './../interfaces/phbk-phone-type-view-dlg.interface';
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-type-view-sdlg',
  templateUrl: './phbk-phone-type-view-sdlg.component.html',
  styleUrls: ['./phbk-phone-type-view-sdlg.component.css']
})

export class PhbkPhoneTypeViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<PhbkPhoneTypeViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneTypeViewDlg ) { }
    currentRow: IPhbkPhoneTypeView |null = null;
    showMultiSelectedRow: boolean = false;
    onSelectedRow(row:  IPhbkPhoneTypeView | null) {
        this.currentRow = row;
    }
    onCancel() {
        this.dialogRef.close(null);
    }
    onOk() {
        if(typeof this.currentRow == 'undefined') return;
        if(this.currentRow == null) return;
        this.data.selectedItems =  [this.currentRow];
        this.dialogRef.close(this.data);
    }
}


