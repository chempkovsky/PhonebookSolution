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
    /// Interaction logic for PhbkEmployeeViewAformUserControl.xaml
    /// </summary>
    public partial class PhbkEmployeeViewAformUserControl: EformUserControlBase
    {
        public PhbkEmployeeViewAformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }

        private void DDivisionNameTphdCntrlAddMode_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxTextChanged(this, sender, "DDivisionName", (int)e.Reason, asbsender.Text);
        }
        private void DDivisionNameTphdCntrlAddMode_QuerySubmitted(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxQuerySubmitted(this, sender, "DDivisionName", e.ChosenSuggestion, e.QueryText);
        }
        private void DEEntrprsNameTphdCntrlAddMode_TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e)
        {
            if(e == null) return;
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface ;
            if(bcs == null) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            bcs.OnAutoSuggestBoxTextChanged(this, sender, "DEEntrprsName", (int)e.Reason, asbsender.Text);
        }
        private void DEEntrprsNameTphdCntrlAddMode_QuerySubmitted(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e)
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

