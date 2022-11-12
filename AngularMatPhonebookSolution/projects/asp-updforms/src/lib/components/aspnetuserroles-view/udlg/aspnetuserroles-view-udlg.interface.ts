
import { IaspnetuserrolesView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetuserrolesViewUdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IaspnetuserrolesView | null;
        eformNewControlModel: IaspnetuserrolesView | null;
}

