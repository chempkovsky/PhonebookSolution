
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkDivisionViewAdlg } from './phbk-division-view-adlg.interface';
import { PhbkDivisionViewAformComponent } from './../aform/phbk-division-view-aform.component';
import { IPhbkDivisionView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-division-view-adlg',
  templateUrl: './phbk-division-view-adlg.component.html',
  styleUrls: ['./phbk-division-view-adlg.component.css']
})
export class PhbkDivisionViewAdlgComponent  {
    @ViewChild(PhbkDivisionViewAformComponent) childForm: PhbkDivisionViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkDivisionViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkDivisionViewAdlg ) { }
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

