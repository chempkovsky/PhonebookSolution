import { ILpdDivisionView } from './lpd-division-view.interface';

export interface ILpdDivisionViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILpdDivisionView[];
}


