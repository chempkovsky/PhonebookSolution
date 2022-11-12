
import { Component, ViewChild, Inject  } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { IColumnSelectorItem } from 'common-interfaces';
import { ColumnSelectorComponent } from './../column-selector/column-selector.component';

@Component({
  selector: 'app-column-selector-dlg',
  templateUrl: './column-selector-dlg.component.html',
  styleUrls: ['./column-selector-dlg.component.css']
})

export class ColumnSelectorDlgComponent { 
    @ViewChild(ColumnSelectorComponent) childForm: ColumnSelectorComponent|any;
    constructor(public dialogRef: MatDialogRef<ColumnSelectorDlgComponent>, @Inject(MAT_DIALOG_DATA) public data: Array<IColumnSelectorItem>) { }
    onCancel() {
        this.dialogRef.close(null);
    }
    onOk() {
        if (typeof this.childForm === 'undefined') return;
        if (this.childForm === null) return;
        let ind = this.childForm.colums.findIndex((e: { checked: boolean; }) => { return e.checked === true; })
        if(ind < 0) {
            this.childForm.shwoError($localize`:No columns selected@@ColumnSelectorDlgComponent.No-columns-selected:No columns selected`);
            return;
        }
        this.dialogRef.close(this.childForm.colums);
    }
}


