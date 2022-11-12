
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkPhoneTypeViewUdlg } from './phbk-phone-type-view-udlg.interface';
import { PhbkPhoneTypeViewUformComponent } from './../uform/phbk-phone-type-view-uform.component';
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-type-view-udlg',
  templateUrl: './phbk-phone-type-view-udlg.component.html',
  styleUrls: ['./phbk-phone-type-view-udlg.component.css']
})
export class PhbkPhoneTypeViewUdlgComponent  {
    @ViewChild(PhbkPhoneTypeViewUformComponent) childForm: PhbkPhoneTypeViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneTypeViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneTypeViewUdlg ) { }
    onAfterSubmit(newVal: IPhbkPhoneTypeView) {
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

