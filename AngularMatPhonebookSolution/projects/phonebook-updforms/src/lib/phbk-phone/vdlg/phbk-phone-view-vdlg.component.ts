
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IPhbkPhoneViewVdlg } from './phbk-phone-view-vdlg.interface';
import { PhbkPhoneViewVformComponent } from './../vform/phbk-phone-view-vform.component';
import { IPhbkPhoneView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-view-vdlg',
  templateUrl: './phbk-phone-view-vdlg.component.html',
  styleUrls: ['./phbk-phone-view-vdlg.component.css']
})
export class PhbkPhoneViewVdlgComponent  {
    @ViewChild(PhbkPhoneViewVformComponent) childForm: PhbkPhoneViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneViewVdlg ) { }
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

