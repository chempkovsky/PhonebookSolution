
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetuserrolesViewAdlg } from './aspnetuserroles-view-adlg.interface';
import { AspnetuserrolesViewAformComponent } from './../aform/aspnetuserroles-view-aform.component';
import { IaspnetuserrolesView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuserroles-view-adlg',
  templateUrl: './aspnetuserroles-view-adlg.component.html',
  styleUrls: ['./aspnetuserroles-view-adlg.component.css']
})
export class AspnetuserrolesViewAdlgComponent  {
    @ViewChild(AspnetuserrolesViewAformComponent) childForm: AspnetuserrolesViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserrolesViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserrolesViewAdlg ) { }
    onAfterSubmit(newVal: IaspnetuserrolesView) {
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

