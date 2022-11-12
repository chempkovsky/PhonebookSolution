
import { IPhbkEmployeeView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkEmployeeViewAdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkEmployeeView | null;
        eformNewControlModel: IPhbkEmployeeView | null;
}

