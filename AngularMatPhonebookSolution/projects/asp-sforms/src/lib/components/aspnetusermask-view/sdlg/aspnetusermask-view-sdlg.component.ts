
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IaspnetusermaskViewDlg } from './aspnetusermask-view-dlg.interface';
import { IaspnetusermaskView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetusermask-view-sdlg',
  templateUrl: './aspnetusermask-view-sdlg.component.html',
  styleUrls: ['./aspnetusermask-view-sdlg.component.css']
})

export class AspnetusermaskViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<AspnetusermaskViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetusermaskViewDlg ) { }
    currentRow: IaspnetusermaskView |null = null;
    showMultiSelectedRow: boolean = false;
    onSelectedRow(row:  IaspnetusermaskView | null) {
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


