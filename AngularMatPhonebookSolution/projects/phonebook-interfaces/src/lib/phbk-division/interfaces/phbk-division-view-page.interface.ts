import { IPhbkDivisionView } from './phbk-division-view.interface';

export interface IPhbkDivisionViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: IPhbkDivisionView[];
}


