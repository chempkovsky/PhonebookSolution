
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IPhbkEmployeeViewVdlg } from './phbk-employee-view-vdlg.interface';
import { PhbkEmployeeViewVformComponent } from './../vform/phbk-employee-view-vform.component';
import { IPhbkEmployeeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-employee-view-vdlg',
  templateUrl: './phbk-employee-view-vdlg.component.html',
  styleUrls: ['./phbk-employee-view-vdlg.component.css']
})
export class PhbkEmployeeViewVdlgComponent  {
    @ViewChild(PhbkEmployeeViewVformComponent) childForm: PhbkEmployeeViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEmployeeViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEmployeeViewVdlg ) { }
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

