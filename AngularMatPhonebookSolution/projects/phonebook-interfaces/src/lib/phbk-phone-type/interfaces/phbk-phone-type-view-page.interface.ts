import { IPhbkPhoneTypeView } from './phbk-phone-type-view.interface';

export interface IPhbkPhoneTypeViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: IPhbkPhoneTypeView[];
}


