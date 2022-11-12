import { IaspnetuserpermsView } from './aspnetuserperms-view.interface';

export interface IaspnetuserpermsViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: IaspnetuserpermsView[];
}


