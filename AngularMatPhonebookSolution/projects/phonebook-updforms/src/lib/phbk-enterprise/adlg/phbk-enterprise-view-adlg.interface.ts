
import { IPhbkEnterpriseView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkEnterpriseViewAdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkEnterpriseView | null;
        eformNewControlModel: IPhbkEnterpriseView | null;
}

