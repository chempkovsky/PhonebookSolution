
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IPhbkEmployeeViewDlg } from './../interfaces/phbk-employee-view-dlg.interface';
import { IPhbkEmployeeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-employee-view-sdlg',
  templateUrl: './phbk-employee-view-sdlg.component.html',
  styleUrls: ['./phbk-employee-view-sdlg.component.css']
})

export class PhbkEmployeeViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<PhbkEmployeeViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEmployeeViewDlg ) { }
    currentRow: IPhbkEmployeeView |null = null;
    showMultiSelectedRow: boolean = false;
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


