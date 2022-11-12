
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetroleViewUdlg } from './aspnetrole-view-udlg.interface';
import { AspnetroleViewUformComponent } from './../uform/aspnetrole-view-uform.component';
import { IaspnetroleView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrole-view-udlg',
  templateUrl: './aspnetrole-view-udlg.component.html',
  styleUrls: ['./aspnetrole-view-udlg.component.css']
})
export class AspnetroleViewUdlgComponent  {
    @ViewChild(AspnetroleViewUformComponent) childForm: AspnetroleViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetroleViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetroleViewUdlg ) { }
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

