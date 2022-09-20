using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetusermaskView.UserControls.Lform {
    /// <summary>
    /// Interaction logic for AspnetusermaskViewLformUserControl.xaml
    /// </summary>
    public partial class AspnetusermaskViewLformUserControl: LformUserControlBase
    {
        public AspnetusermaskViewLformUserControl()
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

