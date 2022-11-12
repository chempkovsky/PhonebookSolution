
import { IaspnetroleView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetroleViewDlg {
        title : string | null; 
        showFilter: boolean;
        canAdd ? : boolean;
        canUpdate ? : boolean;
        canDelete ? : boolean;
        canView ? : boolean;
        hiddenFilter: Array<IWebServiceFilterRslt> | null;
        selectedItems: Array<IaspnetroleView> | null;
        maxHeight: number | null;
        filterMaxHeight: number | null;
}

