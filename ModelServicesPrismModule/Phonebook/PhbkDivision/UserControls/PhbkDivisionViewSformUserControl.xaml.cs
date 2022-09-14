using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkDivision.UserControls {
    /// <summary>
    /// Interaction logic for PhbkDivisionViewSformUserControl.xaml
    /// </summary>
    public partial class PhbkDivisionViewSformUserControl: SformUserControlBase
    {
        public PhbkDivisionViewSformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }
        protected async void OnLoaded()
        {
            ISformViewModelInterface bcs = BindingContext as ISformViewModelInterface;
            if (bcs != null)
            {
                bcs.RowMenuItemsPropertyChanged(this, null, RowMenuItems);
                bcs.TableMenuItemsPropertyChanged(this, null, TableMenuItems);
                await bcs.HiddenFiltersPropertyChanged(this, null, HiddenFilters);
            }
            IBindingContextChanged bcl = this.BindingContext as IBindingContextChanged;
            if (bcl != null)
            {
                await bcl.OnLoaded(this, IsParentLoaded);
            }
        }
    }
}

