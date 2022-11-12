import { ILpdPhoneView } from './lpd-phone-view.interface';

export interface ILpdPhoneViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: ILpdPhoneView[];
}


