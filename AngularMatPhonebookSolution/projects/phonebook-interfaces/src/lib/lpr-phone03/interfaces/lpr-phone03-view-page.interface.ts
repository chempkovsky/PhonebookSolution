import { ILprPhone03View } from './lpr-phone03-view.interface';

export interface ILprPhone03ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprPhone03View[];
}


