
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkPhoneTypeViewDdlg } from './phbk-phone-type-view-ddlg.interface';
import { PhbkPhoneTypeViewDformComponent } from './../dform/phbk-phone-type-view-dform.component';
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';


@Component({
  selector: 'app-phbk-phone-type-view-ddlg',
  templateUrl: './phbk-phone-type-view-ddlg.component.html',
  styleUrls: ['./phbk-phone-type-view-ddlg.component.css']
})
export class PhbkPhoneTypeViewDdlgComponent  {
    @ViewChild(PhbkPhoneTypeViewDformComponent) childForm: PhbkPhoneTypeViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneTypeViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneTypeViewDdlg ) { }
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

