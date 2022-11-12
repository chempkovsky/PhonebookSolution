
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetuserViewAdlg } from './aspnetuser-view-adlg.interface';
import { AspnetuserViewAformComponent } from './../aform/aspnetuser-view-aform.component';
import { IaspnetuserView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuser-view-adlg',
  templateUrl: './aspnetuser-view-adlg.component.html',
  styleUrls: ['./aspnetuser-view-adlg.component.css']
})
export class AspnetuserViewAdlgComponent  {
    @ViewChild(AspnetuserViewAformComponent) childForm: AspnetuserViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserViewAdlg ) { }
    onAfterSubmit(newVal: IaspnetuserView) {
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

