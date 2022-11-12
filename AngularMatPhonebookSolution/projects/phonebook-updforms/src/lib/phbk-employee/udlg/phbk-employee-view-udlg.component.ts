
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkEmployeeViewUdlg } from './phbk-employee-view-udlg.interface';
import { PhbkEmployeeViewUformComponent } from './../uform/phbk-employee-view-uform.component';
import { IPhbkEmployeeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-employee-view-udlg',
  templateUrl: './phbk-employee-view-udlg.component.html',
  styleUrls: ['./phbk-employee-view-udlg.component.css']
})
export class PhbkEmployeeViewUdlgComponent  {
    @ViewChild(PhbkEmployeeViewUformComponent) childForm: PhbkEmployeeViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEmployeeViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEmployeeViewUdlg ) { }
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

