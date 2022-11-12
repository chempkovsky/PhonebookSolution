
import { IPhbkPhoneView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkPhoneViewVdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkPhoneView | null;
        eformNewControlModel: IPhbkPhoneView | null;
}

