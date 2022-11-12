
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IPhbkDivisionViewVdlg } from './phbk-division-view-vdlg.interface';
import { PhbkDivisionViewVformComponent } from './../vform/phbk-division-view-vform.component';
import { IPhbkDivisionView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-division-view-vdlg',
  templateUrl: './phbk-division-view-vdlg.component.html',
  styleUrls: ['./phbk-division-view-vdlg.component.css']
})
export class PhbkDivisionViewVdlgComponent  {
    @ViewChild(PhbkDivisionViewVformComponent) childForm: PhbkDivisionViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkDivisionViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkDivisionViewVdlg ) { }
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

