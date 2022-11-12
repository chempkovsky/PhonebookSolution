
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetrolemaskViewUdlg } from './aspnetrolemask-view-udlg.interface';
import { AspnetrolemaskViewUformComponent } from './../uform/aspnetrolemask-view-uform.component';
import { IaspnetrolemaskView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrolemask-view-udlg',
  templateUrl: './aspnetrolemask-view-udlg.component.html',
  styleUrls: ['./aspnetrolemask-view-udlg.component.css']
})
export class AspnetrolemaskViewUdlgComponent  {
    @ViewChild(AspnetrolemaskViewUformComponent) childForm: AspnetrolemaskViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetrolemaskViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetrolemaskViewUdlg ) { }
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

