
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkPhoneViewDdlg } from './phbk-phone-view-ddlg.interface';
import { PhbkPhoneViewDformComponent } from './../dform/phbk-phone-view-dform.component';
import { IPhbkPhoneView } from 'phonebook-interfaces';


@Component({
  selector: 'app-phbk-phone-view-ddlg',
  templateUrl: './phbk-phone-view-ddlg.component.html',
  styleUrls: ['./phbk-phone-view-ddlg.component.css']
})
export class PhbkPhoneViewDdlgComponent  {
    @ViewChild(PhbkPhoneViewDformComponent) childForm: PhbkPhoneViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneViewDdlg ) { }
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

