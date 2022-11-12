import { ILprDivision01View } from './lpr-division01-view.interface';

export interface ILprDivision01ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprDivision01View[];
}


