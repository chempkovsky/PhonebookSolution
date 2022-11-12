
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IaspnetuserViewDdlg } from './aspnetuser-view-ddlg.interface';
import { AspnetuserViewDformComponent } from './../dform/aspnetuser-view-dform.component';
import { IaspnetuserView } from 'asp-interfaces';


@Component({
  selector: 'app-aspnetuser-view-ddlg',
  templateUrl: './aspnetuser-view-ddlg.component.html',
  styleUrls: ['./aspnetuser-view-ddlg.component.css']
})
export class AspnetuserViewDdlgComponent  {
    @ViewChild(AspnetuserViewDformComponent) childForm: AspnetuserViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<AspnetuserViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IaspnetuserViewDdlg ) { }
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

