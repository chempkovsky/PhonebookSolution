
import { IPhbkDivisionView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkDivisionViewVdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IPhbkDivisionView | null;
        eformNewControlModel: IPhbkDivisionView | null;
}

