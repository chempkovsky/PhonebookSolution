using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;
using CommonUserControlLibrary.Classes;
using CommonCustomControlLibrary.Fonts;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for TablePaginationUserControl.xaml
    /// </summary>
    public partial class TablePaginationUserControl : ContentView
    {
        public TablePaginationUserControl()
        {
            InitializeComponent();
        }
        protected void ResetToAndFrom()
        {
            if(  TotalCount.HasValue)
            {
                int w = CurrentPage * RowsPerPage + 1;
                if(w > TotalCount.Value) w = TotalCount.Value;
                CountFrom = w;
                int v = CurrentPage * RowsPerPage + RowsPerPage;
                if (v > TotalCount.Value) v = TotalCount.Value;
                CountTo = v;
            } else
            {
                CountFrom = null;
                CountTo = null;
            }
        }

        #region Title
        public static readonly BindableProperty TitleProperty =
                BindableProperty.Create(
                "Title", typeof(string),
                typeof(TablePaginationUserControl),
                "Page size");
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
        #region RowsPerPageOptions
        private static void RowsPerPageOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            TablePaginationUserControl inst = bindable as TablePaginationUserControl;
            if (inst != null)
            {
                inst.OnPropertyChanged("RowsPerPage");
            }
        }
        public static readonly BindableProperty RowsPerPageOptionsProperty =
                BindableProperty.Create(
                "RowsPerPageOptions", typeof(IEnumerable<int>),
                typeof(TablePaginationUserControl),
                null, propertyChanged: RowsPerPageOptionsChanged);
        public IEnumerable<int> RowsPerPageOptions
        {
            get
            {
                return (IEnumerable<int>)GetValue(RowsPerPageOptionsProperty);
            }
            set
            {
                SetValue(RowsPerPageOptionsProperty, value);
            }
        }
        #endregion
        #region RowsPerPageChangedCommand
        public static readonly BindableProperty RowsPerPageChangedCommandProperty =
            BindableProperty.Create(nameof(RowsPerPageChangedCommand), typeof(ICommand), typeof(TablePaginationUserControl), null);
        public ICommand RowsPerPageChangedCommand
        {
            get { return (ICommand)GetValue(RowsPerPageChangedCommandProperty); }
            set { SetValue(RowsPerPageChangedCommandProperty, value); }
        }
        #endregion
        #region RowsPerPage
        private static void RowsPerPageChanged(BindableObject  d, object oldValue, object newValue)
        {
            TablePaginationUserControl inst = d as TablePaginationUserControl;
            if (inst != null)
            {
                inst.ResetToAndFrom();
                if(inst.RowsPerPageChangedCommand != null) {
                    ValueChangedCmdParam<int> prm = new ValueChangedCmdParam<int>() {
                        Sender= inst,
                        OldVal= (int)oldValue,
                        NewVal= (int)newValue,
                    };
                    if(inst.RowsPerPageChangedCommand.CanExecute(prm)) {
                        inst.RowsPerPageChangedCommand.Execute(prm);
                    }
                }
                (inst.OnNextPageCommand as Command).ChangeCanExecute();
                (inst.OnPreviousPageCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty RowsPerPageProperty =
                BindableProperty.Create(
                "RowsPerPage", typeof(int),
                typeof(TablePaginationUserControl),
                0, propertyChanged: RowsPerPageChanged);
        public int RowsPerPage
        {
            get
            {
                return (int)GetValue(RowsPerPageProperty);
            }
            set
            {
                SetValue(RowsPerPageProperty, value);
            }
        }
        #endregion
        #region CountFrom
        public static readonly BindableProperty CountFromProperty =
                BindableProperty.Create(
                "CountFrom", typeof(Nullable<int>),
                typeof(TablePaginationUserControl),
                null);
        public Nullable<int> CountFrom
        {
            get
            {
                return (Nullable<int>)GetValue(CountFromProperty);
            }
            set
            {
                SetValue(CountFromProperty, value);
            }
        }
        #endregion
        #region CountTo
        public static readonly BindableProperty CountToProperty =
                BindableProperty.Create(
                "CountTo", typeof(Nullable<int>),
                typeof(TablePaginationUserControl),
                null);
        public Nullable<int> CountTo
        {
            get
            {
                return (Nullable<int>)GetValue(CountToProperty);
            }
            set
            {
                SetValue(CountToProperty, value);
            }
        }
        #endregion
        #region TotalCount
        private static void TotalCountChanged(BindableObject d, object oldValue, object newValue)
        {

            TablePaginationUserControl inst = d as TablePaginationUserControl;
            if (inst != null)
            {
                inst.ResetToAndFrom();
                if(inst.TotalCountChangedCommand != null) {
                    ValueChangedCmdParam<Nullable<int>> prm = new ValueChangedCmdParam<Nullable<int>>() {
                        Sender= inst,
                        OldVal= oldValue as Nullable<int>,
                        NewVal= newValue as Nullable<int>,
                    };
                    if(inst.TotalCountChangedCommand.CanExecute(prm)) {
                        inst.TotalCountChangedCommand.Execute(prm);
                    }
                }
                (inst.OnNextPageCommand as Command).ChangeCanExecute();
                (inst.OnPreviousPageCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty TotalCountProperty =
                BindableProperty.Create(
                "TotalCount", typeof(Nullable<int>),
                typeof(TablePaginationUserControl),
                0, propertyChanged: TotalCountChanged);
        public Nullable<int> TotalCount
        {
            get
            {
                return (Nullable<int>)GetValue(TotalCountProperty);
            }
            set
            {
                SetValue(TotalCountProperty, value);
            }
        }
        #endregion
        #region CurrentPage
        private static void CurrentPageChanged(BindableObject d, object oldValue, object newValue)
        {
            TablePaginationUserControl inst = d as TablePaginationUserControl;
            if (inst != null)
            {
                inst.ResetToAndFrom();
                if(inst.CurrentPageChangedCommand != null) {
                    ValueChangedCmdParam<int> prm = new ValueChangedCmdParam<int>() {
                        Sender= inst,
                        OldVal= (int)oldValue,
                        NewVal= (int)newValue,
                    };
                    if(inst.CurrentPageChangedCommand.CanExecute(prm)) {
                        inst.CurrentPageChangedCommand.Execute(prm);
                    }
                }
                (inst.OnNextPageCommand as Command).ChangeCanExecute();
                (inst.OnPreviousPageCommand as Command).ChangeCanExecute();
            }
        }
        public static readonly BindableProperty CurrentPageProperty =
                BindableProperty.Create(
                "CurrentPage", typeof(int),
                typeof(TablePaginationUserControl),
                0, propertyChanged: CurrentPageChanged);
        public int CurrentPage
        {
            get
            {
                return (int)GetValue(CurrentPageProperty);
            }
            set
            {
                SetValue(CurrentPageProperty, value);
            }
        }
        #endregion
        #region PreviousButtonIconName
        public static readonly BindableProperty PreviousButtonIconNameProperty =
                BindableProperty.Create(
                "PreviousButtonIconName", typeof(string),
                typeof(TablePaginationUserControl),
                IconFont.Chevron_left);
        public string PreviousButtonIconName
        {
            get
            {
                return (string)GetValue(PreviousButtonIconNameProperty);
            }
            set
            {
                SetValue(PreviousButtonIconNameProperty, value);
            }
        }
        #endregion
        #region NextButtonIconName
        public static readonly BindableProperty NextButtonIconNameProperty =
                BindableProperty.Create(
                "NextButtonIconName", typeof(string),
                typeof(TablePaginationUserControl),
                IconFont.Chevron_right);
        public string NextButtonIconName
        {
            get
            {
                return (string)GetValue(NextButtonIconNameProperty);
            }
            set
            {
                SetValue(NextButtonIconNameProperty, value);
            }
        }
        #endregion
        #region ButtonIconColor
        public static readonly BindableProperty ButtonIconColorProperty =
                BindableProperty.Create(
                "ButtonIconColor", typeof(Color),
                typeof(TablePaginationUserControl),
                Color.FromHex("#FFFFFF"));
        public Color ButtonIconColor
        {
            get
            {
                return (Color)GetValue(ButtonIconColorProperty);
            }
            set
            {
                SetValue(ButtonIconColorProperty, value);
            }
        }
        #endregion
        #region ButtonBackgroundColor
        public static readonly BindableProperty ButtonBackgroundColorProperty =
                BindableProperty.Create(
                "ButtonBackgroundColor", typeof(Color),
                typeof(TablePaginationUserControl),
                Color.FromHex("#FF0086AF"));
        public Color ButtonBackgroundColor
        {
            get
            {
                return (Color)GetValue(ButtonBackgroundColorProperty);
            }
            set
            {
                SetValue(ButtonBackgroundColorProperty, value);
            }
        }
        #endregion

        #region CurrentPageChangedCommand
        public static readonly BindableProperty CurrentPageChangedCommandProperty =
            BindableProperty.Create(nameof(CurrentPageChangedCommand), typeof(ICommand), typeof(TablePaginationUserControl), null);
        public ICommand CurrentPageChangedCommand
        {
            get { return (ICommand)GetValue(CurrentPageChangedCommandProperty); }
            set { SetValue(CurrentPageChangedCommandProperty, value); }
        }
        #endregion
        #region TotalCountChangedCommand
        public static readonly BindableProperty TotalCountChangedCommandProperty =
            BindableProperty.Create(nameof(TotalCountChangedCommand), typeof(ICommand), typeof(TablePaginationUserControl), null);
        public ICommand TotalCountChangedCommand
        {
            get { return (ICommand)GetValue(TotalCountChangedCommandProperty); }
            set { SetValue(TotalCountChangedCommandProperty, value); }
        }
        #endregion

        #region OnNextPageCommand
        protected ICommand _OnNextPageCommand = null;
        public ICommand OnNextPageCommand
        {
            get
            {
                return _OnNextPageCommand ?? (_OnNextPageCommand = new Command(() => OnNextPageCommandExecute(), () => OnNextPageCommandCanExecute()));
            }
        }
        protected void OnNextPageCommandExecute()
        {
            if (CountTo.HasValue && TotalCount.HasValue ? CountTo.Value < TotalCount.Value : false)
            {
                CurrentPage = CurrentPage + 1;
            }
        }
        protected bool OnNextPageCommandCanExecute()
        {
            return (CountTo.HasValue && TotalCount.HasValue ? CountTo.Value < TotalCount.Value : false);
        }
        #endregion
        #region OnPreviousPageCommand
        protected ICommand _OnPreviousPageCommand = null;
        public ICommand OnPreviousPageCommand
        {
            get
            {
                return _OnPreviousPageCommand ?? (_OnPreviousPageCommand = new Command(() => OnPreviousPageCommandExecute(), () => OnPreviousPageCommandCanExecute()));
            }
        }
        private void OnPreviousPageCommandExecute()
        {
            if (CurrentPage > 0 )
            {
                CurrentPage = CurrentPage - 1;
            }
        }
        private bool OnPreviousPageCommandCanExecute()
        {
            return (CurrentPage > 0);
        }
        #endregion

        public virtual void OnDestroyed()
        {
                RemoveBinding(IsDestroyedProperty);
                IsDestroyed = true;
                RemoveBinding(TitleProperty);
                RemoveBinding(RowsPerPageOptionsProperty);
                RemoveBinding(RowsPerPageChangedCommandProperty);
                RemoveBinding(RowsPerPageProperty);
                RemoveBinding(CountFromProperty);
                RemoveBinding(CountToProperty);
                RemoveBinding(TotalCountProperty);
                RemoveBinding(CurrentPageProperty);
                RemoveBinding(PreviousButtonIconNameProperty);
                RemoveBinding(NextButtonIconNameProperty);
                RemoveBinding(ButtonIconColorProperty);
                RemoveBinding(ButtonBackgroundColorProperty);
                RemoveBinding(CurrentPageChangedCommandProperty);
                RemoveBinding(TotalCountChangedCommandProperty);
                RowsPerPageChangedCommand = null;
                CurrentPageChangedCommand = null;
                TotalCountChangedCommand = null;
                RowsPerPageOptions = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            TablePaginationUserControl inst = d as TablePaginationUserControl;
            if (inst != null) 
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(TablePaginationUserControl),
                false, propertyChanged: IsDestroyedChanged);
        public bool IsDestroyed
        {
            get
            {
                return (bool)GetValue(IsDestroyedProperty);
            }
            set
            {
                SetValue(IsDestroyedProperty, value);
            }
        }

   }
}

