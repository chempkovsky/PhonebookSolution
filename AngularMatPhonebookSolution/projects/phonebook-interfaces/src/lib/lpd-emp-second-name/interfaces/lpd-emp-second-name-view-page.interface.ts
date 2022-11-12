import { ILpdEmpSecondNameView } from './lpd-emp-second-name-view.interface';

export interface ILpdEmpSecondNameViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILpdEmpSecondNameView[];
}


