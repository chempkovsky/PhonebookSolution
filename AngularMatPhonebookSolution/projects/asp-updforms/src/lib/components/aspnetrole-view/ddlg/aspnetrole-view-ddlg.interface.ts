
import { IaspnetroleView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetroleViewDdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IaspnetroleView | null;
        eformNewControlModel: IaspnetroleView | null;
}

