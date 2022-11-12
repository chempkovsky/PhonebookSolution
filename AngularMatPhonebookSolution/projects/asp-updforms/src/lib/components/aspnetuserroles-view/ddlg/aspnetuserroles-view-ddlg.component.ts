
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetuserrolesViewDdlg } from './aspnetuserroles-view-ddlg.interface';
import { AspnetuserrolesViewDformComponent } from './../dform/aspnetuserroles-view-dform.component';
import { IaspnetuserrolesView } from 'asp-interfaces';


@Component({
  selector: 'app-aspnetuserroles-view-ddlg',
  templateUrl: './aspnetuserroles-view-ddlg.component.html',
  styleUrls: ['./aspnetuserroles-view-ddlg.component.css']
})
export class AspnetuserrolesViewDdlgComponent  {
    @ViewChild(AspnetuserrolesViewDformComponent) childForm: AspnetuserrolesViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserrolesViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserrolesViewDdlg ) { }
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

