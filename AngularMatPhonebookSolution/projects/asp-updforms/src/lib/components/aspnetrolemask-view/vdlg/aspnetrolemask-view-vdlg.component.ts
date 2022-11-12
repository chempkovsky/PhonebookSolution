
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IaspnetrolemaskViewVdlg } from './aspnetrolemask-view-vdlg.interface';
import { AspnetrolemaskViewVformComponent } from './../vform/aspnetrolemask-view-vform.component';
import { IaspnetrolemaskView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrolemask-view-vdlg',
  templateUrl: './aspnetrolemask-view-vdlg.component.html',
  styleUrls: ['./aspnetrolemask-view-vdlg.component.css']
})
export class AspnetrolemaskViewVdlgComponent  {
    @ViewChild(AspnetrolemaskViewVformComponent) childForm: AspnetrolemaskViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetrolemaskViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetrolemaskViewVdlg ) { }
    onAfterSubmit(newVal: IaspnetrolemaskView) {
        this.data.eformNewControlModel = newVal; 
        this.dialogRef.close(this.data);
    }
    onCancel() {
        this.dialogRef.close(null);
    }
    onOk() {
        if (typeof this.childForm === 'undefined') return;
        if (this.childForm === null) return;
        this.childForm.doSubmit();
    }
}

