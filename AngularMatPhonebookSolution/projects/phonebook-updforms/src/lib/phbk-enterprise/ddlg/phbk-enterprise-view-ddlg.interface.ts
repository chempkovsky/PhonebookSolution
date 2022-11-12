
import { IPhbkEnterpriseView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkEnterpriseViewDdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkEnterpriseView | null;
        eformNewControlModel: IPhbkEnterpriseView | null;
}

