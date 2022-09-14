using System;
using Xamarin.Forms;
using System.Windows.Input;

using CommonCustomControlLibrary.Fonts;

namespace CommonServicesPrismModule.UserControls {
    /// <summary>
    /// Interaction logic for MessageUserControl.xaml
    /// </summary>
    public partial class MessageUserControl: ContentView
    {
        public MessageUserControl()
        {
            InitializeComponent();
        }
        #region Title
        public static readonly BindableProperty TitleProperty =
                BindableProperty.Create(
                "Title", typeof(string),
                typeof(MessageUserControl),
                null);
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        #endregion
        #region Message
        public static readonly BindableProperty MessageProperty =
                BindableProperty.Create(
                "Message", typeof(string),
                typeof(MessageUserControl),
                null);
        public string Message
        {
            get
            {
                return (string)GetValue(MessageProperty);
            }
            set
            {
                SetValue(MessageProperty, value);
            }
        }
        #endregion
        #region MessageIconName
        public static readonly BindableProperty MessageIconNameProperty =
                BindableProperty.Create(
                "MessageIconName", typeof(string),
                typeof(MessageUserControl),
                IconFont.Info_outline);
        public string MessageIconName
        {
            get
            {
                return (string)GetValue(MessageIconNameProperty);
            }
            set
            {
                SetValue(MessageIconNameProperty, value);
            }
        }
        #endregion
        #region MessageIconColor
        public static readonly BindableProperty MessageIconColorProperty =
                BindableProperty.Create(
                "MessageIconColor", typeof(Color),
                typeof(MessageUserControl),
                Color.FromHex("#FFFFAB40"));
        public Color MessageIconColor
        {
            get
            {
                return (Color)GetValue(MessageIconColorProperty);
            }
            set
            {
                SetValue(MessageIconColorProperty, value);
            }
        }
        #endregion
        #region ShowOkBtn
        public static readonly BindableProperty ShowOkBtnProperty =
                BindableProperty.Create(
                "ShowOkBtn", typeof(bool),
                typeof(MessageUserControl),
                false);
        public bool ShowOkBtn
        {
            get
            {
                return (bool)GetValue(ShowOkBtnProperty);
            }
            set
            {
                SetValue(ShowOkBtnProperty, value);
            }
        }
        #endregion
        #region ShowCancelBtn
        public static readonly BindableProperty ShowCancelBtnProperty =
                BindableProperty.Create(
                "ShowCancelBtn", typeof(bool),
                typeof(MessageUserControl),
                false);
        public bool ShowCancelBtn
        {
            get
            {
                return (bool)GetValue(ShowCancelBtnProperty);
            }
            set
            {
                SetValue(ShowCancelBtnProperty, value);
            }
        }
        #endregion

        #region OkCommand
        public static readonly BindableProperty OkCommandProperty =
            BindableProperty.Create(nameof(OkCommand), typeof(ICommand), typeof(MessageUserControl), null);
        public ICommand OkCommand
        {
            get { return (ICommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }
        #endregion
        #region OnOkCommand
        protected ICommand _OnOkCommand = null;
        public ICommand OnOkCommand
        {
            get
            {
                return _OnOkCommand ?? (_OnOkCommand = new Command(() => OnOkCommandExecute(), () => OnOkCommandCanExecute()));
            }
        }
        private void OnOkCommandExecute()
        {
            if(OkCommand != null) {
                if(OkCommand.CanExecute(this)) {
                    OkCommand.Execute(this);
                }
            }
        }
        private bool OnOkCommandCanExecute()
        {
            return true;
        }
        #endregion
        #region CancelCommand
        public static readonly BindableProperty CancelCommandProperty =
            BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), typeof(MessageUserControl), null);
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        #endregion
        #region OnCancelCommand
        protected ICommand _OnCancelCommand = null;
        public ICommand OnCancelCommand
        {
            get
            {
                return _OnCancelCommand ?? (_OnCancelCommand = new Command(() => OnCancelCommandExecute(), () => OnCancelCommandCanExecute()));
            }
        }
        private void OnCancelCommandExecute()
        {
            if(CancelCommand != null) {
                if(CancelCommand.CanExecute(this)) {
                    CancelCommand.Execute(this);
                }
            }
        }
        private bool OnCancelCommandCanExecute()
        {
            return true;
        }
        #endregion
    }
}

