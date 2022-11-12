
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkEmployeeViewDdlg } from './phbk-employee-view-ddlg.interface';
import { PhbkEmployeeViewDformComponent } from './../dform/phbk-employee-view-dform.component';
import { IPhbkEmployeeView } from 'phonebook-interfaces';


@Component({
  selector: 'app-phbk-employee-view-ddlg',
  templateUrl: './phbk-employee-view-ddlg.component.html',
  styleUrls: ['./phbk-employee-view-ddlg.component.css']
})
export class PhbkEmployeeViewDdlgComponent  {
    @ViewChild(PhbkEmployeeViewDformComponent) childForm: PhbkEmployeeViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEmployeeViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEmployeeViewDdlg ) { }
    onAfterSubmit(newVal: IPhbkEmployeeView) {
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

