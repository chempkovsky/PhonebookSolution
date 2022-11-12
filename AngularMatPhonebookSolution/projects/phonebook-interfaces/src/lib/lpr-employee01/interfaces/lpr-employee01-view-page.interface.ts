import { ILprEmployee01View } from './lpr-employee01-view.interface';

export interface ILprEmployee01ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprEmployee01View[];
}


