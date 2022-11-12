
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IaspnetmodelViewVdlg } from './aspnetmodel-view-vdlg.interface';
import { AspnetmodelViewVformComponent } from './../vform/aspnetmodel-view-vform.component';
import { IaspnetmodelView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetmodel-view-vdlg',
  templateUrl: './aspnetmodel-view-vdlg.component.html',
  styleUrls: ['./aspnetmodel-view-vdlg.component.css']
})
export class AspnetmodelViewVdlgComponent  {
    @ViewChild(AspnetmodelViewVformComponent) childForm: AspnetmodelViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetmodelViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetmodelViewVdlg ) { }
    onAfterSubmit(newVal: IaspnetmodelView) {
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

