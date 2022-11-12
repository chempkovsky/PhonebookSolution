
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetmodelViewDdlg } from './aspnetmodel-view-ddlg.interface';
import { AspnetmodelViewDformComponent } from './../dform/aspnetmodel-view-dform.component';
import { IaspnetmodelView } from 'asp-interfaces';


@Component({
  selector: 'app-aspnetmodel-view-ddlg',
  templateUrl: './aspnetmodel-view-ddlg.component.html',
  styleUrls: ['./aspnetmodel-view-ddlg.component.css']
})
export class AspnetmodelViewDdlgComponent  {
    @ViewChild(AspnetmodelViewDformComponent) childForm: AspnetmodelViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetmodelViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetmodelViewDdlg ) { }
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

