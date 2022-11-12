import { IPhbkEnterpriseView } from './phbk-enterprise-view.interface';

export interface IPhbkEnterpriseViewPage {
        page : number; // int
        pagesize : number; // int
        pagecount : number; // int
        total : number; // int
        items ?: IPhbkEnterpriseView[];
}


