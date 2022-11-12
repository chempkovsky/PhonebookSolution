
import { IPhbkPhoneView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkPhoneViewDlg {
        title : string | null; 
        showFilter: boolean;
        canAdd ? : boolean;
        canUpdate ? : boolean;
        canDelete ? : boolean;
        canView ? : boolean;
        hiddenFilter: Array<IWebServiceFilterRslt> | null;
        selectedItems: Array<IPhbkPhoneView> | null;
        maxHeight: number | null;
        filterMaxHeight: number | null;
}

