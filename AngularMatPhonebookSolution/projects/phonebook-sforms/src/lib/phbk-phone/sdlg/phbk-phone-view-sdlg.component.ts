
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IPhbkPhoneViewDlg } from './../interfaces/phbk-phone-view-dlg.interface';
import { IPhbkPhoneView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-view-sdlg',
  templateUrl: './phbk-phone-view-sdlg.component.html',
  styleUrls: ['./phbk-phone-view-sdlg.component.css']
})

export class PhbkPhoneViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<PhbkPhoneViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneViewDlg ) { }
    currentRow: IPhbkPhoneView |null = null;
    showMultiSelectedRow: boolean = false;
    onSelectedRow(row:  IPhbkPhoneView | null) {
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


