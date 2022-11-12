
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkDivisionViewDdlg } from './phbk-division-view-ddlg.interface';
import { PhbkDivisionViewDformComponent } from './../dform/phbk-division-view-dform.component';
import { IPhbkDivisionView } from 'phonebook-interfaces';


@Component({
  selector: 'app-phbk-division-view-ddlg',
  templateUrl: './phbk-division-view-ddlg.component.html',
  styleUrls: ['./phbk-division-view-ddlg.component.css']
})
export class PhbkDivisionViewDdlgComponent  {
    @ViewChild(PhbkDivisionViewDformComponent) childForm: PhbkDivisionViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkDivisionViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkDivisionViewDdlg ) { }
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

