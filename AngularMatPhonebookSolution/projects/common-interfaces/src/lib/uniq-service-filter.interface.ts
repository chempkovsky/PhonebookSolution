import { FormControl } from '@angular/forms';

export interface IUniqServiceFilter {
    fltrDataType: string; 
    fltrValue: FormControl;
    fltrCaption: string; 
    fltrName: string; 
    fltrMaxLen: number|any;
    fltrMin: any;
    fltrMax: any;
    fltrFlx: number;
    fltrMd: number;
    fltrSm: number;
    fltrXs: number;
}

