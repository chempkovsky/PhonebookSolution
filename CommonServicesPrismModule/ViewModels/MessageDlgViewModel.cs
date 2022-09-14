using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Services.Dialogs;
using CommonCustomControlLibrary.Fonts;

/*

    "MessageDlgViewModel"  is defined in the "CommonServicesPrismModule"-project.
    In the file of IModule-class of "CommonServicesPrismModule"-project the following line of code must be inserted:


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.RegisterDialog<MessageDlgUserControl, MessageDlgViewModel>("MessageDlg");
            ...
        }

*/

namespace CommonServicesPrismModule.ViewModels {
    public class MessageDlgViewModel: INotifyPropertyChanged, IDialogAware
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
        int DelayFromMilliseconds = 0;
        public void OnDialogOpened(IDialogParameters parameters)
        {
            if (parameters == null) return;
            if (parameters.ContainsKey("Title"))
            {
                Title = parameters.GetValue<string>("Title");
            }
            if (parameters.ContainsKey("Message"))
            {
                Message = parameters.GetValue<string>("Message");
            }
            if (parameters.ContainsKey("MessageIconName"))
            {
                MessageIconName = parameters.GetValue<string>("MessageIconName");
            }
            if (parameters.ContainsKey("MessageIconColor"))
            {
                MessageIconColor = parameters.GetValue<Color>("MessageIconColor");
            }
            if (parameters.ContainsKey("ShowCancelBtn"))
            {
                ShowCancelBtn = parameters.GetValue<bool>("ShowCancelBtn");
            }
            if (parameters.ContainsKey("ShowOkBtn"))
            {
                ShowOkBtn = parameters.GetValue<bool>("ShowOkBtn");
            }
            if (parameters.ContainsKey("DelayFromMilliseconds"))
            {
                DelayFromMilliseconds = parameters.GetValue<int>("DelayFromMilliseconds");
            }
            if(DelayFromMilliseconds > 0)
                Device.StartTimer(TimeSpan.FromMilliseconds(DelayFromMilliseconds) , () => { 
                    if (DelayFromMilliseconds > 0) {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            OkCommandAction();
                        });
                    }; 
                    return false; 
                });
            
        }
        #endregion
        #region Message
        string _Message = string.Empty;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                if (_Message != value)
                {
                    _Message = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region MessageIconName
        string _MessageIconName = IconFont.Info_outline;
        public string MessageIconName
        {
            get
            {
                return _MessageIconName;
            }
            set
            {
                if (_MessageIconName != value)
                {
                    _MessageIconName = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region MessageIconColor
        Color _MessageIconColor = Color.FromHex("#FFFFAB40");
        public Color MessageIconColor
        {
            get
            {
                return _MessageIconColor;
            }
            set
            {
                if (_MessageIconColor != value)
                {
                    _MessageIconColor = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region ShowOkBtn
        bool _ShowOkBtn = true;
        public bool ShowOkBtn
        {
            get
            {
                return _ShowOkBtn;
            }
            set
            {
                if (_ShowOkBtn != value)
                {
                    _ShowOkBtn = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
        #region ShowCancelBtn
        bool _ShowCancelBtn = false;
        public bool ShowCancelBtn
        {
            get
            {
                return _ShowCancelBtn;
            }
            set
            {
                if (_ShowCancelBtn != value)
                {
                    _ShowCancelBtn = value;
                    OnPropertyChanged();
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
                DelayFromMilliseconds = 0;
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Result", true);
                _RequestClose?.Invoke(parameters);
            }
        }
        protected bool OkCommandCheckOk()
        {
            return true;
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

