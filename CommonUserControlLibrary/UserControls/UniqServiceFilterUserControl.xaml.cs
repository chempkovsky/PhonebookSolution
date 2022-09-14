using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.ViewModels;
using CommonCustomControlLibrary.Helpers;
using CommonUserControlLibrary.Classes;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for UniqServiceFilterUserControl.xaml
    /// </summary>
    public partial class UniqServiceFilterUserControl: ContentView
    {

        public UniqServiceFilterUserControl()
        {
            InitializeComponent();
        }
        #region Caption
        public static readonly BindableProperty CaptionProperty =
                BindableProperty.Create(
                "Caption", typeof(string),
                typeof(UniqServiceFilterUserControl),
                null);
        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }
        #endregion
        #region ShowBackBtn
        public static readonly BindableProperty ShowBackBtnProperty =
                BindableProperty.Create(
                "ShowBackBtn", typeof(bool),
                typeof(UniqServiceFilterUserControl),
                false);
        public bool ShowBackBtn
        {
            get
            {
                return (bool)GetValue(ShowBackBtnProperty);
            }
            set
            {
                SetValue(ShowBackBtnProperty, value);
            }
        }
        #endregion
        #region OnNavigationBackCommand
        public static readonly BindableProperty NavigationBackCommandProperty =
            BindableProperty.Create(nameof(NavigationBackCommand), typeof(ICommand), typeof(UniqServiceFilterUserControl), null);
        public ICommand NavigationBackCommand
        {
            get { return (ICommand)GetValue(NavigationBackCommandProperty); }
            set { SetValue(NavigationBackCommandProperty, value); }
        }

        protected ICommand _OnNavigationBackCommand = null;
        public ICommand OnNavigationBackCommand
        {
            get
            {
                return _OnNavigationBackCommand ?? (_OnNavigationBackCommand = new Command(() => OnNavigationBackCommandExecute(), () => OnNavigationBackCommandCanExecute()));
            }
        }
        protected void OnNavigationBackCommandExecute()
        {
            if(IsDestroyed) return;
            ICommand cmd = NavigationBackCommand;
            if(cmd != null) {
                if(cmd.CanExecute(this)) cmd.Execute(this);
            }
        }
        protected bool OnNavigationBackCommandCanExecute()
        {
            return true;
        }
        #endregion
        
        #region InternalContent
        int _InternalContent = 0;
        protected void InternalContentChanged()
        {
            if (_InternalContent < 10) _InternalContent++; else _InternalContent = 0;
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Task.Delay(1);
                this.OnPropertyChanged("InternalContent");
            });
        }
        public int InternalContent
        {
            get { return _InternalContent; }
        }
        #endregion

        #region FilterDefinitions
        private static void FilterDefinitionsChanged(BindableObject d, object oldValue, object newValue)
        {
            UniqServiceFilterUserControl inst = d as UniqServiceFilterUserControl;
            if (inst != null)
            {
                if(inst.IsDestroyed) return;
                bool gf = inst.IsGridFlex;
                if(gf) inst.IsGridFlex = false;
                inst.OnPropertyChanged("IsVisible1");
                inst.OnPropertyChanged("DisplayMemberPath1");
                inst.OnPropertyChanged("TextMemberPath1");
                inst.OnPropertyChanged("Caption1");
                inst.OnPropertyChanged("IsVisible2");
                inst.OnPropertyChanged("DisplayMemberPath2");
                inst.OnPropertyChanged("TextMemberPath2");
                inst.OnPropertyChanged("Caption2");
                inst.OnPropertyChanged("IsVisible3");
                inst.OnPropertyChanged("DisplayMemberPath3");
                inst.OnPropertyChanged("TextMemberPath3");
                inst.OnPropertyChanged("Caption3");
                inst.OnPropertyChanged("IsVisible4");
                inst.OnPropertyChanged("DisplayMemberPath4");
                inst.OnPropertyChanged("TextMemberPath4");
                inst.OnPropertyChanged("Caption4");
                inst.OnPropertyChanged("IsVisible5");
                inst.OnPropertyChanged("DisplayMemberPath5");
                inst.OnPropertyChanged("TextMemberPath5");
                inst.OnPropertyChanged("Caption5");
                inst.OnPropertyChanged("IsVisible6");
                inst.OnPropertyChanged("DisplayMemberPath6");
                inst.OnPropertyChanged("TextMemberPath6");
                inst.OnPropertyChanged("Caption6");
                inst.OnPropertyChanged("IsVisible7");
                inst.OnPropertyChanged("DisplayMemberPath7");
                inst.OnPropertyChanged("TextMemberPath7");
                inst.OnPropertyChanged("Caption7");
                inst.OnPropertyChanged("IsVisible8");
                inst.OnPropertyChanged("DisplayMemberPath8");
                inst.OnPropertyChanged("TextMemberPath8");
                inst.OnPropertyChanged("Caption8");
                if(gf) inst.IsGridFlex = true;
                inst.InternalContentChanged();
            }
        }
        public static readonly BindableProperty FilterDefinitionsProperty =
                BindableProperty.Create(
                "FilterDefinitions", typeof(IList<IUniqServiceFilterDefInterface>),
                typeof(UniqServiceFilterUserControl),
                null, propertyChanged: FilterDefinitionsChanged);
        public IList<IUniqServiceFilterDefInterface> FilterDefinitions
        {
            get
            {
                return (IList<IUniqServiceFilterDefInterface>)GetValue(FilterDefinitionsProperty);
            }
            set
            {
                SetValue(FilterDefinitionsProperty, value);
            }
        }
        #endregion

        #region CurrentContainerMenuItems
        protected ObservableCollection<IWebServiceFilterMenuInterface> _CurrentContainerMenuItems = new ObservableCollection<IWebServiceFilterMenuInterface>();
        public ObservableCollection<IWebServiceFilterMenuInterface> CurrentContainerMenuItems { get {return _CurrentContainerMenuItems; } }
        public void CurrentContainerMenuItemsClear() {
            if(_CurrentContainerMenuItems != null) {
                foreach(IWebServiceFilterMenuInterface itm in _CurrentContainerMenuItems) {
                    itm.IsDestroyed = true;
                }
                _CurrentContainerMenuItems.Clear();
            }
        }
        #endregion

        #region ContainerMenuItems
        private static void ContainerMenuItemsChanged(BindableObject d, object oldValue, object newValue)
        {
            UniqServiceFilterUserControl inst = d as UniqServiceFilterUserControl;
            if (inst != null)
            {
                inst.CurrentContainerMenuItemsClear();
                if(inst.IsDestroyed) return;
                IEnumerable<IWebServiceFilterMenuInterface> cmitms =  newValue as IEnumerable<IWebServiceFilterMenuInterface>;
                if(cmitms != null) {
                    foreach(IWebServiceFilterMenuInterface itm in cmitms) {
                        inst.CurrentContainerMenuItems.Add(
                            new WebServiceFilterMenuViewModel() {
                                Id = itm.Id,
                                Caption = itm.Caption,
                                IconName = itm.IconName,
                                IconColor = itm.IconColor,
                                Enabled = itm.Enabled,
                                Data = itm.Data,
                                FeedbackData = itm.FeedbackData,
                                Command = itm.Command,
                                IsDestroyed = itm.IsDestroyed
                            }
                        );
                    }
                }
            }
        }
        public static readonly BindableProperty ContainerMenuItemsProperty =
                BindableProperty.Create(
                "ContainerMenuItems", typeof(IEnumerable<IWebServiceFilterMenuInterface>),
                typeof(UniqServiceFilterUserControl),
                propertyChanged: ContainerMenuItemsChanged);
        public IEnumerable<IWebServiceFilterMenuInterface> ContainerMenuItems
        {
            get
            {
                return (IEnumerable<IWebServiceFilterMenuInterface>)GetValue(ContainerMenuItemsProperty);
            }
            set
            {
                SetValue(ContainerMenuItemsProperty, value);
            }
        }
        #endregion

        #region FilterCommand
        public static readonly BindableProperty FilterCommandProperty =
            BindableProperty.Create(nameof(FilterCommand), typeof(ICommand), typeof(UniqServiceFilterUserControl), 
            null); 
        public ICommand FilterCommand
        {
            get { return (ICommand)GetValue(FilterCommandProperty); }
            set { SetValue(FilterCommandProperty, value); }
        }
        #endregion

        #region HiddenFilters
        public static readonly BindableProperty HiddenFiltersProperty =
                BindableProperty.Create(
                "HiddenFilters", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(UniqServiceFilterUserControl),
                null);
        public IEnumerable<IWebServiceFilterRsltInterface> HiddenFilters
        {
            get
            {
                return (IEnumerable<IWebServiceFilterRsltInterface>)GetValue(HiddenFiltersProperty);
            }
            set
            {
                SetValue(HiddenFiltersProperty, value);
            }
        }
        #endregion

        #region OnFilterCommand
        protected IList<IWebServiceFilterRsltInterface> InternalDefineFilter()
        {
            IList<IWebServiceFilterRsltInterface> rslt = new List<IWebServiceFilterRsltInterface>();
            if(FilterDefinitions != null) {
                int k = 1;
                foreach (var flt in FilterDefinitions)
                {
                    if(k > 8) break;
                    object v = null;
                    switch (k)
                    {
                        case 1:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text1);
                            break;
                        case 2:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text2);
                            break;
                        case 3:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text3);
                            break;
                        case 4:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text4);
                            break;
                        case 5:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text5);
                            break;
                        case 6:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text6);
                            break;
                        case 7:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text7);
                            break;
                        case 8:
                            v = ConvertHelper.TryToConvert(flt.fltrDataType, Text8);
                            break;

                        default:
                            break;
                    }
                    if (v is null) break;
                    rslt.Add(new WebServiceFilterRslt() { fltrName = flt.fltrName, fltrDataType = flt.fltrDataType, fltrOperator = "eq", fltrValue = v });
                    k++;
                }
            }
            if (HiddenFilters != null)
            {
                foreach (IWebServiceFilterRsltInterface flt in HiddenFilters)
                {
                    if (string.IsNullOrEmpty(flt.fltrError))
                    {
                        if ((flt.fltrValue != null) && (!string.IsNullOrEmpty(flt.fltrDataType)) && (!string.IsNullOrEmpty(flt.fltrOperator)))
                        {
                            object v = ConvertHelper.TryToConvert(flt.fltrDataType, flt.fltrValue);
                            if (v != null)
                            {
                                rslt.Add(new WebServiceFilterRslt() { fltrName = flt.fltrName, fltrDataType = flt.fltrDataType, fltrOperator = flt.fltrOperator, fltrValue = v });
                            }
                        }
                    }
                }
            }
            return rslt;
        }
        protected ICommand _OnFilterCommand = null;
        public ICommand OnFilterCommand
        {
            get
            {
                return _OnFilterCommand ?? (_OnFilterCommand = new Command(() => OnFilterCommandExecute(), () => OnFilterCommandCanExecute()));
            }
        }
        protected void OnFilterCommandExecute()
        {
            if(IsDestroyed) return;
            ICommand cmd = FilterCommand;
            if (cmd != null)
            {
                IList<IWebServiceFilterRsltInterface> flt = InternalDefineFilter();
                if(cmd.CanExecute(flt)) { 
                    cmd.Execute(flt);
                }
            }
        }
        protected bool OnFilterCommandCanExecute()
        {
            return true;
        }
        #endregion

        #region OnContainerMenuItemsCommand
        public static readonly BindableProperty ContainerMenuItemsCommandProperty =
            BindableProperty.Create(nameof(ContainerMenuItemsCommand), typeof(ICommand), typeof(UniqServiceFilterUserControl), 
            null); 
        public ICommand ContainerMenuItemsCommand
        {
            get { return (ICommand)GetValue(ContainerMenuItemsCommandProperty); }
            set { SetValue(ContainerMenuItemsCommandProperty, value); }
        }

        protected ICommand _OnContainerMenuItemsCommand = null;
        public ICommand OnContainerMenuItemsCommand
        {
            get
            {
                return _OnContainerMenuItemsCommand ?? (_OnContainerMenuItemsCommand = new Command((p) => OnContainerMenuItemsCommandExecute(p), (p) => OnContainerMenuItemsCommandCanExecute(p)));
            }
        }
        protected void OnContainerMenuItemsCommandExecute(object p)
        {
            if(IsDestroyed) return;
            ICommand cmd = ContainerMenuItemsCommand;
            if(cmd != null) {
                if(cmd.CanExecute(p)) cmd.Execute(p);
            }
        }
        protected bool OnContainerMenuItemsCommandCanExecute(object p)
        {
            return true;
        }
        #endregion

        #region FilterHeight
        public static readonly BindableProperty FilterHeightProperty =
                BindableProperty.Create(
                "FilterHeight", typeof(double),
                typeof(UniqServiceFilterUserControl),
                -1d);
        public double FilterHeight
        {
            get
            {
                return (double)GetValue(FilterHeightProperty);
            }
            set
            {
                SetValue(FilterHeightProperty, value);
            }
        }
        #endregion

        #region IsGridFlexProperty
        public static readonly BindableProperty IsGridFlexProperty =
                BindableProperty.Create(
                "IsGridFlex", typeof(bool),
                typeof(UniqServiceFilterUserControl),
                true);
        public bool IsGridFlex
        {
            get
            {
                return (bool)GetValue(IsGridFlexProperty);
            }
            set
            {
                SetValue(IsGridFlexProperty, value);
            }
        }
        #endregion

        #region IsDestroyed
        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            RemoveBinding(IsGridFlexProperty);
            RemoveBinding(CaptionProperty);
            RemoveBinding(ShowBackBtnProperty);
            RemoveBinding(NavigationBackCommandProperty);
            RemoveBinding(FilterDefinitionsProperty);
            RemoveBinding(ContainerMenuItemsProperty);
            RemoveBinding(FilterCommandProperty);
            RemoveBinding(ContainerMenuItemsCommandProperty);
            RemoveBinding(FilterHeightProperty);
            RemoveBinding(TextChangedCommandProperty);
            RemoveBinding(QuerySubmittedProperty);
            RemoveBinding(HiddenFiltersProperty);
            RemoveBinding(TextChangedCommandProperty);
            RemoveBinding(UnfocusedCommandProperty);
            RemoveBinding(ItemsSource1Property);
            RemoveBinding(Text1Property);
            RemoveBinding(ItemsSource2Property);
            RemoveBinding(Text2Property);
            RemoveBinding(ItemsSource3Property);
            RemoveBinding(Text3Property);
            RemoveBinding(ItemsSource4Property);
            RemoveBinding(Text4Property);
            RemoveBinding(ItemsSource5Property);
            RemoveBinding(Text5Property);
            RemoveBinding(ItemsSource6Property);
            RemoveBinding(Text6Property);
            RemoveBinding(ItemsSource7Property);
            RemoveBinding(Text7Property);
            RemoveBinding(ItemsSource8Property);
            RemoveBinding(Text8Property);
            IsGridFlex = false;
            FilterHeight = -1d; // unsubscribe from event
            NavigationBackCommand = null;
            ContainerMenuItems = null;
            FilterCommand = null;
            TextChangedCommand = null;
            QuerySubmitted = null;
            ContainerMenuItemsCommand = null;
            FilterDefinitions = null;
            HiddenFilters = null;
            TextChangedCommand = null;
            UnfocusedCommand = null;
            CurrentContainerMenuItemsClear();
            ItemsSource1 = null;
            // Text1 = null;
            ItemsSource2 = null;
            // Text2 = null;
            ItemsSource3 = null;
            // Text3 = null;
            ItemsSource4 = null;
            // Text4 = null;
            ItemsSource5 = null;
            // Text5 = null;
            ItemsSource6 = null;
            // Text6 = null;
            ItemsSource7 = null;
            // Text7 = null;
            ItemsSource8 = null;
            // Text8 = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            UniqServiceFilterUserControl inst = d as UniqServiceFilterUserControl;
            if (inst != null) 
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(UniqServiceFilterUserControl),
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
        #endregion

        #region AutoSuggestBox
        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(ICommand), typeof(UniqServiceFilterUserControl), 
            null); 
        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }
        
        public static readonly BindableProperty QuerySubmittedProperty =
            BindableProperty.Create(nameof(QuerySubmitted), typeof(ICommand), typeof(UniqServiceFilterUserControl), 
            null); 
        public ICommand QuerySubmitted
        {
            get { return (ICommand)GetValue(QuerySubmittedProperty); }
            set { SetValue(QuerySubmittedProperty, value); }
        }

        public static readonly BindableProperty UnfocusedCommandProperty =
            BindableProperty.Create(nameof(UnfocusedCommand), typeof(ICommand), typeof(UniqServiceFilterUserControl), 
            null); 
        public ICommand UnfocusedCommand
        {
            get { return (ICommand)GetValue(UnfocusedCommandProperty); }
            set { SetValue(UnfocusedCommandProperty, value); }
        }
        
        protected void TextChanged(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e, int k) {
            if((IsDestroyed) || (FilterDefinitions == null)) return;
            if ((e == null) || (FilterDefinitions.Count() < k ))  return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            ICommand cmd = TextChangedCommand;
            if (cmd != null)
            {
                (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, int Reason, string QueryText) prm = 
                    (this, sender, FilterDefinitions[k-1], (int)e.Reason, asbsender.Text);
                if(cmd.CanExecute(prm)) cmd.Execute(prm);
            }
        }
        protected void QuerySubmittedEx(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e, int k) {
            if ((IsDestroyed) || (FilterDefinitions == null)) return;
            if ((e == null) || (FilterDefinitions.Count() < k ))  return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            ICommand cmd = QuerySubmitted;
            if (cmd != null)
            {
                (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef, object ChosenSuggestion, string QueryText) prm = 
                    (this, sender, FilterDefinitions[k-1], e.ChosenSuggestion, e.QueryText);
                if(cmd.CanExecute(prm)) cmd.Execute(prm);
            }
        }
        protected void RunUnfocused(object sender, int k) {
            if ((IsDestroyed) || (FilterDefinitions == null)) return;
            if (FilterDefinitions.Count() < k) return;
            dotMorten.Xamarin.Forms.AutoSuggestBox asbsender = sender as dotMorten.Xamarin.Forms.AutoSuggestBox;
            if(asbsender == null) return;
            ICommand cmd = UnfocusedCommand;
            if (cmd != null)
            {
                (object Cmpnt, object Sender, IUniqServiceFilterDefInterface FltDef) prm = 
                    (this, sender, FilterDefinitions[k-1]);
                if(cmd.CanExecute(prm)) cmd.Execute(prm);
            }
        }
        public string Caption1 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 1)
                        return FilterDefinitions[0].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible1 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 1;
                }
                return false;
            }
        }
        public string DisplayMemberPath1 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 1)
                        return FilterDefinitions[0].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath1 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 1)
                        return FilterDefinitions[0].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource1Property =
                BindableProperty.Create(
                "ItemsSource1", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource1 {
            get {
                return (IList)GetValue(ItemsSource1Property);
            }
            set {
                SetValue(ItemsSource1Property, value);
            }
        }
        public static readonly BindableProperty Text1Property =
                BindableProperty.Create(
                "Text1", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text1 {
            get {
                return (string)GetValue(Text1Property);
            }
            set {
                SetValue(Text1Property, value);
            }
        }
        public void TextChanged1(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 1);
        }
        public void QuerySubmitted1(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 1);
        }
        public void Unfocused1(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 1);
        }
        public string Caption2 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 2)
                        return FilterDefinitions[1].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible2 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 2;
                }
                return false;
            }
        }
        public string DisplayMemberPath2 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 2)
                        return FilterDefinitions[1].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath2 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 2)
                        return FilterDefinitions[1].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource2Property =
                BindableProperty.Create(
                "ItemsSource2", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource2 {
            get {
                return (IList)GetValue(ItemsSource2Property);
            }
            set {
                SetValue(ItemsSource2Property, value);
            }
        }
        public static readonly BindableProperty Text2Property =
                BindableProperty.Create(
                "Text2", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text2 {
            get {
                return (string)GetValue(Text2Property);
            }
            set {
                SetValue(Text2Property, value);
            }
        }
        public void TextChanged2(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 2);
        }
        public void QuerySubmitted2(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 2);
        }
        public void Unfocused2(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 2);
        }
        public string Caption3 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 3)
                        return FilterDefinitions[2].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible3 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 3;
                }
                return false;
            }
        }
        public string DisplayMemberPath3 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 3)
                        return FilterDefinitions[2].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath3 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 3)
                        return FilterDefinitions[2].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource3Property =
                BindableProperty.Create(
                "ItemsSource3", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource3 {
            get {
                return (IList)GetValue(ItemsSource3Property);
            }
            set {
                SetValue(ItemsSource3Property, value);
            }
        }
        public static readonly BindableProperty Text3Property =
                BindableProperty.Create(
                "Text3", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text3 {
            get {
                return (string)GetValue(Text3Property);
            }
            set {
                SetValue(Text3Property, value);
            }
        }
        public void TextChanged3(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 3);
        }
        public void QuerySubmitted3(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 3);
        }
        public void Unfocused3(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 3);
        }
        public string Caption4 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 4)
                        return FilterDefinitions[3].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible4 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 4;
                }
                return false;
            }
        }
        public string DisplayMemberPath4 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 4)
                        return FilterDefinitions[3].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath4 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 4)
                        return FilterDefinitions[3].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource4Property =
                BindableProperty.Create(
                "ItemsSource4", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource4 {
            get {
                return (IList)GetValue(ItemsSource4Property);
            }
            set {
                SetValue(ItemsSource4Property, value);
            }
        }
        public static readonly BindableProperty Text4Property =
                BindableProperty.Create(
                "Text4", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text4 {
            get {
                return (string)GetValue(Text4Property);
            }
            set {
                SetValue(Text4Property, value);
            }
        }
        public void TextChanged4(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 4);
        }
        public void QuerySubmitted4(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 4);
        }
        public void Unfocused4(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 4);
        }
        public string Caption5 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 5)
                        return FilterDefinitions[4].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible5 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 5;
                }
                return false;
            }
        }
        public string DisplayMemberPath5 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 5)
                        return FilterDefinitions[4].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath5 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 5)
                        return FilterDefinitions[4].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource5Property =
                BindableProperty.Create(
                "ItemsSource5", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource5 {
            get {
                return (IList)GetValue(ItemsSource5Property);
            }
            set {
                SetValue(ItemsSource5Property, value);
            }
        }
        public static readonly BindableProperty Text5Property =
                BindableProperty.Create(
                "Text5", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text5 {
            get {
                return (string)GetValue(Text5Property);
            }
            set {
                SetValue(Text5Property, value);
            }
        }
        public void TextChanged5(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 5);
        }
        public void QuerySubmitted5(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 5);
        }
        public void Unfocused5(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 5);
        }
        public string Caption6 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 6)
                        return FilterDefinitions[5].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible6 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 6;
                }
                return false;
            }
        }
        public string DisplayMemberPath6 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 6)
                        return FilterDefinitions[5].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath6 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 6)
                        return FilterDefinitions[5].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource6Property =
                BindableProperty.Create(
                "ItemsSource6", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource6 {
            get {
                return (IList)GetValue(ItemsSource6Property);
            }
            set {
                SetValue(ItemsSource6Property, value);
            }
        }
        public static readonly BindableProperty Text6Property =
                BindableProperty.Create(
                "Text6", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text6 {
            get {
                return (string)GetValue(Text6Property);
            }
            set {
                SetValue(Text6Property, value);
            }
        }
        public void TextChanged6(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 6);
        }
        public void QuerySubmitted6(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 6);
        }
        public void Unfocused6(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 6);
        }
        public string Caption7 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 7)
                        return FilterDefinitions[6].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible7 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 7;
                }
                return false;
            }
        }
        public string DisplayMemberPath7 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 7)
                        return FilterDefinitions[6].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath7 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 7)
                        return FilterDefinitions[6].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource7Property =
                BindableProperty.Create(
                "ItemsSource7", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource7 {
            get {
                return (IList)GetValue(ItemsSource7Property);
            }
            set {
                SetValue(ItemsSource7Property, value);
            }
        }
        public static readonly BindableProperty Text7Property =
                BindableProperty.Create(
                "Text7", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text7 {
            get {
                return (string)GetValue(Text7Property);
            }
            set {
                SetValue(Text7Property, value);
            }
        }
        public void TextChanged7(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 7);
        }
        public void QuerySubmitted7(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 7);
        }
        public void Unfocused7(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 7);
        }
        public string Caption8 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 8)
                        return FilterDefinitions[7].fltrCaption;
                }
                return "";
            }
        }
        public bool IsVisible8 {
            get {
                if(FilterDefinitions != null) {
                    return FilterDefinitions.Count() >= 8;
                }
                return false;
            }
        }
        public string DisplayMemberPath8 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 8)
                        return FilterDefinitions[7].fltrDispMemb;
                }
                return "";
            }
        }
        public string TextMemberPath8 {
            get {
                if(FilterDefinitions != null) {
                    if(FilterDefinitions.Count() >= 8)
                        return FilterDefinitions[7].fltrTextMemb;
                }
                return "";
            }
        }
        public static readonly BindableProperty ItemsSource8Property =
                BindableProperty.Create(
                "ItemsSource8", typeof(IList),
                typeof(UniqServiceFilterUserControl),
                null);
        public IList ItemsSource8 {
            get {
                return (IList)GetValue(ItemsSource8Property);
            }
            set {
                SetValue(ItemsSource8Property, value);
            }
        }
        public static readonly BindableProperty Text8Property =
                BindableProperty.Create(
                "Text8", typeof(string),
                typeof(UniqServiceFilterUserControl),
                "");
        public string Text8 {
            get {
                return (string)GetValue(Text8Property);
            }
            set {
                SetValue(Text8Property, value);
            }
        }
        public void TextChanged8(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxTextChangedEventArgs e) {
            TextChanged(sender, e, 8);
        }
        public void QuerySubmitted8(object sender, dotMorten.Xamarin.Forms.AutoSuggestBoxQuerySubmittedEventArgs e) {
            QuerySubmittedEx(sender, e, 8);
        }
        public void Unfocused8(object sender, FocusEventArgs e) {
            RunUnfocused(sender, 8);
        }
        #endregion
    }
}

