
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetuserViewUdlg } from './aspnetuser-view-udlg.interface';
import { AspnetuserViewUformComponent } from './../uform/aspnetuser-view-uform.component';
import { IaspnetuserView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuser-view-udlg',
  templateUrl: './aspnetuser-view-udlg.component.html',
  styleUrls: ['./aspnetuser-view-udlg.component.css']
})
export class AspnetuserViewUdlgComponent  {
    @ViewChild(AspnetuserViewUformComponent) childForm: AspnetuserViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserViewUdlg ) { }
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

