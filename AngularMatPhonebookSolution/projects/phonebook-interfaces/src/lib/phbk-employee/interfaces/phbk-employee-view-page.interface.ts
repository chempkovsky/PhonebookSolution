import { IPhbkEmployeeView } from './phbk-employee-view.interface';

export interface IPhbkEmployeeViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: IPhbkEmployeeView[];
}


