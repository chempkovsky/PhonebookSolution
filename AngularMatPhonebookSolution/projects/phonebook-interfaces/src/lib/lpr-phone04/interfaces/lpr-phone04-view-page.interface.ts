import { ILprPhone04View } from './lpr-phone04-view.interface';

export interface ILprPhone04ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprPhone04View[];
}


