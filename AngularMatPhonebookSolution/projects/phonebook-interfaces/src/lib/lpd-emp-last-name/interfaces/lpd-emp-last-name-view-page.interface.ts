import { ILpdEmpLastNameView } from './lpd-emp-last-name-view.interface';

export interface ILpdEmpLastNameViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILpdEmpLastNameView[];
}


