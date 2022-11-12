
import { Component,  Input, Output, EventEmitter, ViewChild, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

import { IPhbkEnterpriseViewVdlg } from './phbk-enterprise-view-vdlg.interface';
import { PhbkEnterpriseViewVformComponent } from './../vform/phbk-enterprise-view-vform.component';
import { IPhbkEnterpriseView } from 'phonebook-interfaces';

@Component({
  selector: 'app-phbk-enterprise-view-vdlg',
  templateUrl: './phbk-enterprise-view-vdlg.component.html',
  styleUrls: ['./phbk-enterprise-view-vdlg.component.css']
})
export class PhbkEnterpriseViewVdlgComponent  {
    @ViewChild(PhbkEnterpriseViewVformComponent) childForm: PhbkEnterpriseViewVformComponent|any;
    constructor(public dialogRef: MatDialogRef<PhbkEnterpriseViewVdlgComponent>, @Inject(MAT_DIALOG_DATA) public data: IPhbkEnterpriseViewVdlg ) { }
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

