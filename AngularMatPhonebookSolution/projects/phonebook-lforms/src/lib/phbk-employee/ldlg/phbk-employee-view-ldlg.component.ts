
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IPhbkEmployeeView } from 'phonebook-interfaces';
import { IPhbkEmployeeViewDlg } from 'phonebook-sforms';

@Component({
  selector: 'app-phbk-employee-view-ldlg',
  templateUrl: './phbk-employee-view-ldlg.component.html',
  styleUrls: ['./phbk-employee-view-ldlg.component.css']
})
export class PhbkEmployeeViewLdlgComponent { 
    constructor(public dialogRef: MatDialogRef<PhbkEmployeeViewLdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEmployeeViewDlg ) { }
    currentRow: IPhbkEmployeeView |null = null;
    onSelectedRow(row:  IPhbkEmployeeView | null) {
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


