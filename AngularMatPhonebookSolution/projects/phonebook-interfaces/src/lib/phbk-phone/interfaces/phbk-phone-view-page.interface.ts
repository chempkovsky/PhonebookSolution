import { IPhbkPhoneView } from './phbk-phone-view.interface';

export interface IPhbkPhoneViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: IPhbkPhoneView[];
}


