using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Services.Dialogs;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;

/*

    "ColumnSelectorDlgViewModel"  is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:
        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.RegisterDialog<ColumnSelectorDlgUserControl, ColumnSelectorDlgViewModel>("ColumnSelectorDlg");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class ColumnSelectorDlgViewModel: INotifyPropertyChanged, IDialogAware
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Title
        string _Title = string.Empty;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region IDialogAware
        event Action<IDialogParameters> _RequestClose;
        public event Action<IDialogParameters> RequestClose
        {
            add
            {
                _RequestClose += value;
            }
            remove
            {
                _RequestClose -= value;
            }
        }
        

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters == null) return;
            if (parameters.ContainsKey("Title"))
            {
                Title = parameters.GetValue<string>("Title");
            }
            if (parameters.ContainsKey("Columns"))  
            {
                IEnumerable<IColumnSelectorItemDefInterface> cols = parameters.GetValue<IEnumerable<IColumnSelectorItemDefInterface>>("Columns");
                if (cols != null)
                { 
                    ObservableCollection<ColumnSelectorItemDefViewModel> lColumns = null;
                    foreach (var col in cols)
                    {
                        if (col != null)
                        {
                            if (lColumns == null) lColumns = new ObservableCollection<ColumnSelectorItemDefViewModel>();
                            lColumns.Add(
                                new ColumnSelectorItemDefViewModel()
                                {
                                    Name = col.Name,
                                    Caption = col.Caption,
                                    IsChecked = col.IsChecked
                                });
                        }
                    }
                    Columns = lColumns;
                }
            }
        }
        #endregion
        #region Columns
        ObservableCollection<ColumnSelectorItemDefViewModel> _Columns = null;
        public ObservableCollection<ColumnSelectorItemDefViewModel> Columns
        {
            get
            {
                return _Columns;
            }
            set
            {
                if (_Columns != value)
                {
                    _Columns = value;
                    OnPropertyChanged();
                    (OkCommand as Command).ChangeCanExecute();
                }
            }
        }
        #endregion
        #region OkCommand
        private ICommand _OkCommand;
        public ICommand OkCommand
        {
            get
            {
                return _OkCommand ?? (_OkCommand = new Command(() => OkCommandAction(), () => OkCommandCanExecute()));
            }
        }
        protected void OkCommandAction()
        {
            if (OkCommandCheckOk())
            {
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Columns", Columns);
                parameters.Add("Result", true);
                _RequestClose?.Invoke(parameters);
            }
        }
        protected bool OkCommandCheckOk()
        {
           if (Columns != null)
            {
                return Columns.Any(c => c.IsChecked);
            }
            return false;
        }
        protected bool OkCommandCanExecute()
        {
            return true;
        }
        #endregion
        #region CancelCommand
        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _CancelCommand ?? (_CancelCommand = new Command(() => CancelCommandAction(), () => CancelCommandCanExecute()));
            }
        }
        protected void CancelCommandAction()
        {
            if (_RequestClose != null)
            {
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Result", false);
                _RequestClose?.Invoke(parameters);
            }
        }
        protected bool CancelCommandCanExecute()
        {
            return true;
        }
        #endregion
    }
}

