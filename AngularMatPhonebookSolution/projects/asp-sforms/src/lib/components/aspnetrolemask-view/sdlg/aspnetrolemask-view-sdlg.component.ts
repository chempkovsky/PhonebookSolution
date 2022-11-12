
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IaspnetrolemaskViewDlg } from './aspnetrolemask-view-dlg.interface';
import { IaspnetrolemaskView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrolemask-view-sdlg',
  templateUrl: './aspnetrolemask-view-sdlg.component.html',
  styleUrls: ['./aspnetrolemask-view-sdlg.component.css']
})

export class AspnetrolemaskViewSdlgComponent { 
    constructor(public dialogRef: MatDialogRef<AspnetrolemaskViewSdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetrolemaskViewDlg ) { }
    currentRow: IaspnetrolemaskView |null = null;
    showMultiSelectedRow: boolean = false;
    onSelectedRow(row:  IaspnetrolemaskView | null) {
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


