import { ILpdEmpFirstNameView } from './lpd-emp-first-name-view.interface';

export interface ILpdEmpFirstNameViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILpdEmpFirstNameView[];
}


