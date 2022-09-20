using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using CommonInterfacesClassLibrary.Interfaces;
using ModelInterfacesClassLibrary.interfaces.asp.aspnetmodelView;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Controls;
using CommonUserControlLibrary.UserControls;


namespace ModelServicesPrismModule.asp.aspnetmodelView.UserControls {
    /// <summary>
    /// Interaction logic for AspnetmodelViewAformUserControl.xaml
    /// </summary>
    public partial class AspnetmodelViewAformUserControl: EformUserControlBase
    {
        public AspnetmodelViewAformUserControl()
        {
            InitializeComponent();
            OnLoaded();
        }


    }
}

