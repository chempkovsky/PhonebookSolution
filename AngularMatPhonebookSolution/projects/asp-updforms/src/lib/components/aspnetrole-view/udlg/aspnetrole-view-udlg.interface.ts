
import { IaspnetroleView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetroleViewUdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IaspnetroleView | null;
        eformNewControlModel: IaspnetroleView | null;
}

