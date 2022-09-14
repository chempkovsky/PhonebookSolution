using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkEnterprise.UserControls {
    /// <summary>
    /// Interaction logic for PhbkEnterpriseViewSformUserControl.xaml
    /// </summary>
    public partial class PhbkEnterpriseViewSformUserControl: SformUserControlBase
    {
        public PhbkEnterpriseViewSformUserControl()
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

