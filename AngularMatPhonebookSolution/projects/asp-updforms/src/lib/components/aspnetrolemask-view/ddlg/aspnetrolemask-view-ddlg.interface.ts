
import { IaspnetrolemaskView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetrolemaskViewDdlg {
        title : string | null; 
        hiddenFilter: Array<IWebServiceFilterRslt>;
        eformControlModel: IaspnetrolemaskView | null;
        eformNewControlModel: IaspnetrolemaskView | null;
}

