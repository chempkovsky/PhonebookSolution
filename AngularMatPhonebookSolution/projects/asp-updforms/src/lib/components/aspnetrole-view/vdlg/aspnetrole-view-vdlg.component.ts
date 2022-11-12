
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IaspnetroleViewVdlg } from './aspnetrole-view-vdlg.interface';
import { AspnetroleViewVformComponent } from './../vform/aspnetrole-view-vform.component';
import { IaspnetroleView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetrole-view-vdlg',
  templateUrl: './aspnetrole-view-vdlg.component.html',
  styleUrls: ['./aspnetrole-view-vdlg.component.css']
})
export class AspnetroleViewVdlgComponent  {
    @ViewChild(AspnetroleViewVformComponent) childForm: AspnetroleViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetroleViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetroleViewVdlg ) { }
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

