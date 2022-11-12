
import { IaspnetmodelView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetmodelViewDlg {
        title : string | null; 
        showFilter: boolean;
        canAdd ? : boolean;
        canUpdate ? : boolean;
        canDelete ? : boolean;
        canView ? : boolean;
        hiddenFilter: Array<IWebServiceFilterRslt> | null;
        selectedItems: Array<IaspnetmodelView> | null;
        maxHeight: number | null;
        filterMaxHeight: number | null;
}

