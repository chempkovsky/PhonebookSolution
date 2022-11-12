
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkEmployeeViewAdlg } from './phbk-employee-view-adlg.interface';
import { PhbkEmployeeViewAformComponent } from './../aform/phbk-employee-view-aform.component';
import { IPhbkEmployeeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-employee-view-adlg',
  templateUrl: './phbk-employee-view-adlg.component.html',
  styleUrls: ['./phbk-employee-view-adlg.component.css']
})
export class PhbkEmployeeViewAdlgComponent  {
    @ViewChild(PhbkEmployeeViewAformComponent) childForm: PhbkEmployeeViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEmployeeViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEmployeeViewAdlg ) { }
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

