
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkDivisionViewUdlg } from './phbk-division-view-udlg.interface';
import { PhbkDivisionViewUformComponent } from './../uform/phbk-division-view-uform.component';
import { IPhbkDivisionView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-division-view-udlg',
  templateUrl: './phbk-division-view-udlg.component.html',
  styleUrls: ['./phbk-division-view-udlg.component.css']
})
export class PhbkDivisionViewUdlgComponent  {
    @ViewChild(PhbkDivisionViewUformComponent) childForm: PhbkDivisionViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkDivisionViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkDivisionViewUdlg ) { }
    onAfterSubmit(newVal: IPhbkDivisionView) {
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

