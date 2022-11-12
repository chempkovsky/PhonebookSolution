
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IaspnetuserView } from 'asp-interfaces';
import { IaspnetuserViewDlg } from 'asp-sforms';

@Component({
  selector: 'app-aspnetuser-view-ldlg',
  templateUrl: './aspnetuser-view-ldlg.component.html',
  styleUrls: ['./aspnetuser-view-ldlg.component.css']
})
export class AspnetuserViewLdlgComponent { 
    constructor(public dialogRef: MatDialogRef<AspnetuserViewLdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserViewDlg ) { }
    currentRow: IaspnetuserView |null = null;
    onSelectedRow(row:  IaspnetuserView | null) {
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


