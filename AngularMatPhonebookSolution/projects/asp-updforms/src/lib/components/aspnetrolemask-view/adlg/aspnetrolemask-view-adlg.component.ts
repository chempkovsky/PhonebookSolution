
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetrolemaskViewAdlg } from './aspnetrolemask-view-adlg.interface';
import { AspnetrolemaskViewAformComponent } from './../aform/aspnetrolemask-view-aform.component';
import { IaspnetrolemaskView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrolemask-view-adlg',
  templateUrl: './aspnetrolemask-view-adlg.component.html',
  styleUrls: ['./aspnetrolemask-view-adlg.component.css']
})
export class AspnetrolemaskViewAdlgComponent  {
    @ViewChild(AspnetrolemaskViewAformComponent) childForm: AspnetrolemaskViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetrolemaskViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetrolemaskViewAdlg ) { }
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

