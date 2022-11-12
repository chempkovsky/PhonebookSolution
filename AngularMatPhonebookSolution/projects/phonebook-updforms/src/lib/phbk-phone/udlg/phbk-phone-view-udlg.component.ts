
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkPhoneViewUdlg } from './phbk-phone-view-udlg.interface';
import { PhbkPhoneViewUformComponent } from './../uform/phbk-phone-view-uform.component';
import { IPhbkPhoneView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-view-udlg',
  templateUrl: './phbk-phone-view-udlg.component.html',
  styleUrls: ['./phbk-phone-view-udlg.component.css']
})
export class PhbkPhoneViewUdlgComponent  {
    @ViewChild(PhbkPhoneViewUformComponent) childForm: PhbkPhoneViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneViewUdlg ) { }
    onAfterSubmit(newVal: IPhbkPhoneView) {
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

