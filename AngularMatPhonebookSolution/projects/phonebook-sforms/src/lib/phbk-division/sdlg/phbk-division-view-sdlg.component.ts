
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IPhbkDivisionViewDlg } from './../interfaces/phbk-division-view-dlg.interface';
import { IPhbkDivisionView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-division-view-sdlg',
  templateUrl: './phbk-division-view-sdlg.component.html',
  styleUrls: ['./phbk-division-view-sdlg.component.css']
})

export class PhbkDivisionViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<PhbkDivisionViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkDivisionViewDlg ) { }
    currentRow: IPhbkDivisionView |null = null;
    showMultiSelectedRow: boolean = false;
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


