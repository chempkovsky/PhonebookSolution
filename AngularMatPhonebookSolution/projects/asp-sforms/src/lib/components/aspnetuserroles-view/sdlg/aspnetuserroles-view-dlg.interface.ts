
import { IaspnetuserrolesView } from 'asp-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IaspnetuserrolesViewDlg {
        title : string | null; 
        showFilter: boolean;
        canAdd ? : boolean;
        canUpdate ? : boolean;
        canDelete ? : boolean;
        canView ? : boolean;
        hiddenFilter: Array<IWebServiceFilterRslt> | null;
        selectedItems: Array<IaspnetuserrolesView> | null;
        maxHeight: number | null;
        filterMaxHeight: number | null;
}

