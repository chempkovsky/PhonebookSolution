
import { IPhbkPhoneTypeView } from 'phonebook-interfaces';
import { IWebServiceFilterRslt } from 'common-interfaces';

export interface IPhbkPhoneTypeViewDlg {
        title : string | null; 
        showFilter: boolean;
        canAdd ? : boolean;
        canUpdate ? : boolean;
        canDelete ? : boolean;
        canView ? : boolean;
        hiddenFilter: Array<IWebServiceFilterRslt> | null;
        selectedItems: Array<IPhbkPhoneTypeView> | null;
        maxHeight: number | null;
        filterMaxHeight: number | null;
}

