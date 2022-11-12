import { ILprPhone01View } from './lpr-phone01-view.interface';

export interface ILprPhone01ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprPhone01View[];
}


