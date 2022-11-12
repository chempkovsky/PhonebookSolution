
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetroleViewAdlg } from './aspnetrole-view-adlg.interface';
import { AspnetroleViewAformComponent } from './../aform/aspnetrole-view-aform.component';
import { IaspnetroleView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrole-view-adlg',
  templateUrl: './aspnetrole-view-adlg.component.html',
  styleUrls: ['./aspnetrole-view-adlg.component.css']
})
export class AspnetroleViewAdlgComponent  {
    @ViewChild(AspnetroleViewAformComponent) childForm: AspnetroleViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetroleViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetroleViewAdlg ) { }
    onAfterSubmit(newVal: IaspnetroleView) {
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

