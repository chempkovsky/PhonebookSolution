using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkDivision.UserControls {
    /// <summary>
    /// Interaction logic for PhbkDivisionViewLformUserControl.xaml
    /// </summary>
    public partial class PhbkDivisionViewLformUserControl: LformUserControlBase
    {
        public PhbkDivisionViewLformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }

        protected async void OnLoaded()
        {
            ILformViewModelInterface bcs = BindingContext as ILformViewModelInterface;
            if (bcs != null)
            {
                bcs.RowMenuItemsPropertyChanged(this, null, RowMenuItems);
                bcs.TableMenuItemsPropertyChanged(this, null, TableMenuItems);
                bcs.HiddenFiltersPropertyChanged(this, null, HiddenFilters);
                bcs.CanAddPropertyChanged(this, null, CanAdd);
                bcs.CanUpdatePropertyChanged(this, null, CanUpdate);
                bcs.CanDeletePropertyChanged(this, null, CanDelete);
            }
            IBindingContextChanged bcl = this.BindingContext as IBindingContextChanged;
            if (bcl != null)
            {
                await bcl.OnLoaded(this, IsParentLoaded);
            }
        }

    }
}

