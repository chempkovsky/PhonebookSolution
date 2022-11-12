
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetmodelViewUdlg } from './aspnetmodel-view-udlg.interface';
import { AspnetmodelViewUformComponent } from './../uform/aspnetmodel-view-uform.component';
import { IaspnetmodelView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetmodel-view-udlg',
  templateUrl: './aspnetmodel-view-udlg.component.html',
  styleUrls: ['./aspnetmodel-view-udlg.component.css']
})
export class AspnetmodelViewUdlgComponent  {
    @ViewChild(AspnetmodelViewUformComponent) childForm: AspnetmodelViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetmodelViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetmodelViewUdlg ) { }
    onAfterSubmit(newVal: IaspnetmodelView) {
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

