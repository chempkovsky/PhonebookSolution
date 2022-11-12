
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IPhbkDivisionView } from 'phonebook-interfaces';
import { IPhbkDivisionViewDlg } from 'phonebook-sforms';

@Component({
  selector: 'app-phbk-division-view-ldlg',
  templateUrl: './phbk-division-view-ldlg.component.html',
  styleUrls: ['./phbk-division-view-ldlg.component.css']
})
export class PhbkDivisionViewLdlgComponent { 
    constructor(public dialogRef: MatDialogRef<PhbkDivisionViewLdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkDivisionViewDlg ) { }
    currentRow: IPhbkDivisionView |null = null;
    onSelectedRow(row:  IPhbkDivisionView | null) {
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


