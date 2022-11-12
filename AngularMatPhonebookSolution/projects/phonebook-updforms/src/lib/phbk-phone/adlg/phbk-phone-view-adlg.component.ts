
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkPhoneViewAdlg } from './phbk-phone-view-adlg.interface';
import { PhbkPhoneViewAformComponent } from './../aform/phbk-phone-view-aform.component';
import { IPhbkPhoneView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-view-adlg',
  templateUrl: './phbk-phone-view-adlg.component.html',
  styleUrls: ['./phbk-phone-view-adlg.component.css']
})
export class PhbkPhoneViewAdlgComponent  {
    @ViewChild(PhbkPhoneViewAformComponent) childForm: PhbkPhoneViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneViewAdlg ) { }
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

