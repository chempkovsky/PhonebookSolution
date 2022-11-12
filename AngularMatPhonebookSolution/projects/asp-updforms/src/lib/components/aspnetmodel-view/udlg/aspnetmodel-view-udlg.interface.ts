
import { IaspnetmodelView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetmodelViewUdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IaspnetmodelView | null;
        eformNewControlModel: IaspnetmodelView | null;
}

