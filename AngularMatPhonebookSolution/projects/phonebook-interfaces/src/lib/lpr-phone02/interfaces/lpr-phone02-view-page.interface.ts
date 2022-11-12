import { ILprPhone02View } from './lpr-phone02-view.interface';

export interface ILprPhone02ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprPhone02View[];
}


