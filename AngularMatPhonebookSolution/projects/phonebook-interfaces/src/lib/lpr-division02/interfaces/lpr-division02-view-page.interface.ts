import { ILprDivision02View } from './lpr-division02-view.interface';

export interface ILprDivision02ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprDivision02View[];
}


