
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkEnterpriseViewAdlg } from './phbk-enterprise-view-adlg.interface';
import { PhbkEnterpriseViewAformComponent } from './../aform/phbk-enterprise-view-aform.component';
import { IPhbkEnterpriseView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-enterprise-view-adlg',
  templateUrl: './phbk-enterprise-view-adlg.component.html',
  styleUrls: ['./phbk-enterprise-view-adlg.component.css']
})
export class PhbkEnterpriseViewAdlgComponent  {
    @ViewChild(PhbkEnterpriseViewAformComponent) childForm: PhbkEnterpriseViewAformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEnterpriseViewAdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEnterpriseViewAdlg ) { }
    onAfterSubmit(newVal: IPhbkEnterpriseView) {
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

