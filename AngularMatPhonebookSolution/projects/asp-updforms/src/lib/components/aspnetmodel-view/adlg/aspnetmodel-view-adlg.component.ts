
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetmodelViewAdlg } from './aspnetmodel-view-adlg.interface';
import { AspnetmodelViewAformComponent } from './../aform/aspnetmodel-view-aform.component';
import { IaspnetmodelView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetmodel-view-adlg',
  templateUrl: './aspnetmodel-view-adlg.component.html',
  styleUrls: ['./aspnetmodel-view-adlg.component.css']
})
export class AspnetmodelViewAdlgComponent  {
    @ViewChild(AspnetmodelViewAformComponent) childForm: AspnetmodelViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetmodelViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetmodelViewAdlg ) { }
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

