
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { IPhbkEnterpriseViewDdlg } from './phbk-enterprise-view-ddlg.interface';
import { PhbkEnterpriseViewDformComponent } from './../dform/phbk-enterprise-view-dform.component';
import { IPhbkEnterpriseView } from 'phonebook-interfaces';


@Component({
  selector: 'app-phbk-enterprise-view-ddlg',
  templateUrl: './phbk-enterprise-view-ddlg.component.html',
  styleUrls: ['./phbk-enterprise-view-ddlg.component.css']
})
export class PhbkEnterpriseViewDdlgComponent  {
    @ViewChild(PhbkEnterpriseViewDformComponent) childForm: PhbkEnterpriseViewDformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEnterpriseViewDdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEnterpriseViewDdlg ) { }
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

