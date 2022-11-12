
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetroleViewDdlg } from './aspnetrole-view-ddlg.interface';
import { AspnetroleViewDformComponent } from './../dform/aspnetrole-view-dform.component';
import { IaspnetroleView } from 'asp-interfaces';


@Component({
  selector: 'app-aspnetrole-view-ddlg',
  templateUrl: './aspnetrole-view-ddlg.component.html',
  styleUrls: ['./aspnetrole-view-ddlg.component.css']
})
export class AspnetroleViewDdlgComponent  {
    @ViewChild(AspnetroleViewDformComponent) childForm: AspnetroleViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetroleViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetroleViewDdlg ) { }
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

