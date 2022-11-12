
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkPhoneTypeViewVdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkPhoneTypeView | null;
        eformNewControlModel: IPhbkPhoneTypeView | null;
}

