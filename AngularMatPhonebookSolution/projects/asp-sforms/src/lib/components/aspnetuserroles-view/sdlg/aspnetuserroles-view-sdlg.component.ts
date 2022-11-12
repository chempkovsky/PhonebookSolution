
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IaspnetuserrolesViewDlg } from './aspnetuserroles-view-dlg.interface';
import { IaspnetuserrolesView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuserroles-view-sdlg',
  templateUrl: './aspnetuserroles-view-sdlg.component.html',
  styleUrls: ['./aspnetuserroles-view-sdlg.component.css']
})

export class AspnetuserrolesViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<AspnetuserrolesViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserrolesViewDlg ) { }
    currentRow: IaspnetuserrolesView |null = null;
    showMultiSelectedRow: boolean = false;
    onSelectedRow(row:  IaspnetuserrolesView | null) {
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


