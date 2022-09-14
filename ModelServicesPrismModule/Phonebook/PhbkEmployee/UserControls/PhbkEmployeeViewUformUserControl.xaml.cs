using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.Phonebook.PhbkEmployee;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.Phonebook.PhbkEmployee.UserControls {
    /// <summary>
    /// Interaction logic for PhbkEmployeeViewUformUserControl.xaml
    /// </summary>
    public partial class PhbkEmployeeViewUformUserControl: EformUserControlBase
    {
        public PhbkEmployeeViewUformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }

        private void DDivisionNameTphdCntrlUpdMode_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxTextChanged(this, sender, "DDivisionName", (int)e.Reason, asbsender.Text);
        }
        private void DDivisionNameTphdCntrlUpdMode_QuerySubmitted(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxQuerySubmitted(this, sender, "DDivisionName", e.ChosenSuggestion, e.QueryText);
        }
        private void DEEntrprsNameTphdCntrlUpdMode_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxTextChanged(this, sender, "DEEntrprsName", (int)e.Reason, asbsender.Text);
        }
        private void DEEntrprsNameTphdCntrlUpdMode_QuerySubmitted(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxQuerySubmitted(this, sender, "DEEntrprsName", e.ChosenSuggestion, e.QueryText);
        }

    }
}

