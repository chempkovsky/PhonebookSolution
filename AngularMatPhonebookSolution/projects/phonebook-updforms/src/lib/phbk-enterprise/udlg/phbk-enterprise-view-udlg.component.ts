
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkEnterpriseViewUdlg } from './phbk-enterprise-view-udlg.interface';
import { PhbkEnterpriseViewUformComponent } from './../uform/phbk-enterprise-view-uform.component';
import { IPhbkEnterpriseView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-enterprise-view-udlg',
  templateUrl: './phbk-enterprise-view-udlg.component.html',
  styleUrls: ['./phbk-enterprise-view-udlg.component.css']
})
export class PhbkEnterpriseViewUdlgComponent  {
    @ViewChild(PhbkEnterpriseViewUformComponent) childForm: PhbkEnterpriseViewUformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEnterpriseViewUdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEnterpriseViewUdlg ) { }
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

