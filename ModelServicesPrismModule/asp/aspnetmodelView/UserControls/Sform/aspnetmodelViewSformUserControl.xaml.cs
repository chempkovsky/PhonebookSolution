using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetmodelView.UserControls.Sform {
    /// <summary>
    /// Interaction logic for AspnetmodelViewSformUserControl.xaml
    /// </summary>
    public partial class AspnetmodelViewSformUserControl: SformUserControlBase
    {
        public AspnetmodelViewSformUserControl()
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

