import { ILprEmployee02View } from './lpr-employee02-view.interface';

export interface ILprEmployee02ViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILprEmployee02View[];
}


