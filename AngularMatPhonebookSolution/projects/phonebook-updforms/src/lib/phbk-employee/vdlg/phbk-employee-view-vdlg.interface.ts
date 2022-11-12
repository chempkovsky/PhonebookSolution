
import { IPhbkEmployeeView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkEmployeeViewVdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkEmployeeView | null;
        eformNewControlModel: IPhbkEmployeeView | null;
}

