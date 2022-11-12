
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IaspnetuserrolesViewVdlg } from './aspnetuserroles-view-vdlg.interface';
import { AspnetuserrolesViewVformComponent } from './../vform/aspnetuserroles-view-vform.component';
import { IaspnetuserrolesView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuserroles-view-vdlg',
  templateUrl: './aspnetuserroles-view-vdlg.component.html',
  styleUrls: ['./aspnetuserroles-view-vdlg.component.css']
})
export class AspnetuserrolesViewVdlgComponent  {
    @ViewChild(AspnetuserrolesViewVformComponent) childForm: AspnetuserrolesViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserrolesViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserrolesViewVdlg ) { }
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

