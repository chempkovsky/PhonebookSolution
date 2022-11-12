
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetrolemaskViewDdlg } from './aspnetrolemask-view-ddlg.interface';
import { AspnetrolemaskViewDformComponent } from './../dform/aspnetrolemask-view-dform.component';
import { IaspnetrolemaskView } from 'asp-interfaces';


@Component({
  selector: 'app-aspnetrolemask-view-ddlg',
  templateUrl: './aspnetrolemask-view-ddlg.component.html',
  styleUrls: ['./aspnetrolemask-view-ddlg.component.css']
})
export class AspnetrolemaskViewDdlgComponent  {
    @ViewChild(AspnetrolemaskViewDformComponent) childForm: AspnetrolemaskViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetrolemaskViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetrolemaskViewDdlg ) { }
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

