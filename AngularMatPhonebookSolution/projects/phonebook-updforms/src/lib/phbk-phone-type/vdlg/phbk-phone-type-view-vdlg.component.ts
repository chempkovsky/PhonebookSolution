
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IPhbkPhoneTypeViewVdlg } from './phbk-phone-type-view-vdlg.interface';
import { PhbkPhoneTypeViewVformComponent } from './../vform/phbk-phone-type-view-vform.component';
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-phone-type-view-vdlg',
  templateUrl: './phbk-phone-type-view-vdlg.component.html',
  styleUrls: ['./phbk-phone-type-view-vdlg.component.css']
})
export class PhbkPhoneTypeViewVdlgComponent  {
    @ViewChild(PhbkPhoneTypeViewVformComponent) childForm: PhbkPhoneTypeViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkPhoneTypeViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkPhoneTypeViewVdlg ) { }
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

