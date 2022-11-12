
import { IaspnetuserView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetuserViewAdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IaspnetuserView | null;
        eformNewControlModel: IaspnetuserView | null;
}

