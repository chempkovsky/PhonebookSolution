
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IaspnetuserViewVdlg } from './aspnetuser-view-vdlg.interface';
import { AspnetuserViewVformComponent } from './../vform/aspnetuser-view-vform.component';
import { IaspnetuserView } from 'asp-interfaces';

@Component({
  selector: 'app-aspnetuser-view-vdlg',
  templateUrl: './aspnetuser-view-vdlg.component.html',
  styleUrls: ['./aspnetuser-view-vdlg.component.css']
})
export class AspnetuserViewVdlgComponent  {
    @ViewChild(AspnetuserViewVformComponent) childForm: AspnetuserViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserViewVdlg ) { }
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

