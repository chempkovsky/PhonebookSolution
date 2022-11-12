
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkPhoneTypeViewAdlg } from './phbk-phone-type-view-adlg.interface';
import { PhbkPhoneTypeViewAformComponent } from './../aform/phbk-phone-type-view-aform.component';
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-type-view-adlg',
  templateUrl: './phbk-phone-type-view-adlg.component.html',
  styleUrls: ['./phbk-phone-type-view-adlg.component.css']
})
export class PhbkPhoneTypeViewAdlgComponent  {
    @ViewChild(PhbkPhoneTypeViewAformComponent) childForm: PhbkPhoneTypeViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneTypeViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneTypeViewAdlg ) { }
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

