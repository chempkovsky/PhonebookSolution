
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetuserrolesViewUdlg } from './aspnetuserroles-view-udlg.interface';
import { AspnetuserrolesViewUformComponent } from './../uform/aspnetuserroles-view-uform.component';
import { IaspnetuserrolesView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuserroles-view-udlg',
  templateUrl: './aspnetuserroles-view-udlg.component.html',
  styleUrls: ['./aspnetuserroles-view-udlg.component.css']
})
export class AspnetuserrolesViewUdlgComponent  {
    @ViewChild(AspnetuserrolesViewUformComponent) childForm: AspnetuserrolesViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserrolesViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserrolesViewUdlg ) { }
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

