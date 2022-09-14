using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Navigation;
using CommonInterfacesClassLibrary.Interfaces;
using CommonInterfacesClassLibrary.Enums;
using CommonCustomControlLibrary.Classes;


namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for EformUserControlBase.xaml
    /// </summary>
    public class EformUserControlBase: UserControlWithContainerMenu, INotifiedByParentInterface, IDestructible
    {
       // public EformUserControlBase()
       // {
       //     InitializeComponent();
       //     OnLoaded();
       // }

        #region OnBindingContextFeedbackRef
        protected override void OnBindingContextFeedbackRef(object v)
        {
            BindingContextFeedback bcf = v as BindingContextFeedback;
            if(bcf == null) return;
            if(string.IsNullOrEmpty(bcf.BcfName)) return;
		    if(bcf.BcfName == "SubmitCommand") {
                ICommand cmd = SubmitCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            } else if(bcf.BcfName == "CancelCommand") {
                ICommand cmd = CancelCommand; 
                if(cmd != null) {
                    if(cmd.CanExecute(bcf.BcfData))
                        cmd.Execute(bcf.BcfData);
                }
            }
        }
        #endregion

        #region OnLoaded
        // "async void" is correct for this method
        protected virtual async void OnLoaded()
        {
            IEformViewModelInterface bcs = BindingContext as IEformViewModelInterface;
            if (bcs != null)
            {
                await bcs.HiddenFiltersPropertyChanged(this, null, HiddenFilters);
                await bcs.FormControlModelChanged(this, null, FormControlModel);
                await bcs.EformModeChanged(this, null, EformMode);
            }
            IBindingContextChanged bcl = this.BindingContext as IBindingContextChanged;
            if (bcl != null)
            {
                await bcl.OnLoaded(this, IsParentLoaded);
            }
        }
        #endregion

        #region Caption
        public static readonly BindableProperty CaptionProperty =
                BindableProperty.Create(
                "Caption", typeof(string),
                typeof(EformUserControlBase),
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

        #region ShowSubmit
        public static readonly BindableProperty ShowSubmitProperty =
                BindableProperty.Create(
                "ShowSubmit", typeof(bool),
                typeof(EformUserControlBase),
                true);
        public bool ShowSubmit
        {
            get
            {
                return (bool)GetValue(ShowSubmitProperty);
            }
            set
            {
                SetValue(ShowSubmitProperty, value);
            }
        }
        #endregion

        #region HiddenFilters
        private static async void HiddenFiltersChanged(BindableObject d, object oldValue, object newValue)
        {
            EformUserControlBase inst = d as EformUserControlBase;
            if (inst != null)
            {
                IEformViewModelInterface bc = inst.BindingContext as IEformViewModelInterface;
                if(bc != null)
                    await bc.HiddenFiltersPropertyChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty HiddenFiltersProperty =
                BindableProperty.Create(
                "HiddenFilters", typeof(IEnumerable<IWebServiceFilterRsltInterface>),
                typeof(EformUserControlBase),
                null, propertyChanged: HiddenFiltersChanged);
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

        #region FormControlModel
        private static async void FormControlModelChanged(BindableObject d, object oldValue, object newValue)
        {
            EformUserControlBase inst = d as EformUserControlBase;
            if (inst != null)
            {
                IEformViewModelInterface bc = inst.BindingContext as IEformViewModelInterface;
                if(bc != null)
                    await bc.FormControlModelChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty FormControlModelProperty =
                BindableProperty.Create(
                "FormControlModel", typeof(object), // this is correct
                typeof(EformUserControlBase),
                null, propertyChanged: FormControlModelChanged);
        public object FormControlModel // this is correct
        {
            get
            {
                return (object)GetValue(FormControlModelProperty);
            }
            set
            {
                SetValue(FormControlModelProperty, value);
            }
        }
        #endregion

        #region EformMode
        private static async void EformModeChanged(BindableObject d, object oldValue, object newValue)
        {
            EformUserControlBase inst = d as EformUserControlBase;
            if (inst != null)
            {
                IEformViewModelInterface bc = inst.BindingContext as IEformViewModelInterface;
                if(bc != null)
                    await bc.EformModeChanged(inst, oldValue, newValue);
            }
        }
        public static readonly BindableProperty EformModeProperty =
                BindableProperty.Create(
                "EformMode", typeof(EformModeEnum),
                typeof(EformUserControlBase),
                EformModeEnum.DeleteMode, propertyChanged: EformModeChanged);
        public EformModeEnum EformMode
        {
            get
            {
                return (EformModeEnum)GetValue(EformModeProperty);
            }
            set
            {
                SetValue(EformModeProperty, value);
            }
        }
        #endregion

        #region SubmitCommand
        public static readonly BindableProperty SubmitCommandProperty =
            BindableProperty.Create(nameof(SubmitCommand), typeof(ICommand), 
            typeof(EformUserControlBase), 
            null);
        public ICommand SubmitCommand
        {
            get { return (ICommand)GetValue(SubmitCommandProperty); }
            set { SetValue(SubmitCommandProperty, value); }
        }
        #endregion

        #region CancelCommand
        public static readonly BindableProperty CancelCommandProperty =
            BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), 
            typeof(EformUserControlBase), 
            null);
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        #endregion
        #region IsParentLoaded
        private static async void IsParentLoadedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EformUserControlBase d = bindable as EformUserControlBase;
            if (d != null)
            {
               IBindingContextChanged bcl = d.BindingContext as IBindingContextChanged;
                if (bcl != null)
                {
                    await bcl.OnLoaded(bindable, newValue);
                }
            }
        }
        public static readonly BindableProperty IsParentLoadedProperty =
                BindableProperty.Create(
                "IsParentLoaded", typeof(bool),
                typeof(EformUserControlBase),
                false, propertyChanged: IsParentLoadedChanged);
        public bool IsParentLoaded
        {
            get
            {
                return (bool)GetValue(IsParentLoadedProperty);
            }
            set
            {
                SetValue(IsParentLoadedProperty, value);
            }
        }
        #endregion

        #region IsGridFlexProperty
        public static readonly BindableProperty IsGridFlexProperty =
                BindableProperty.Create(
                "IsGridFlex", typeof(bool),
                typeof(EformUserControlBase),
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

        #region OnDestroyed
        public override void OnDestroyed()
        {
            base.OnDestroyed();
            IBindingContextChanged bc = BindingContext as IBindingContextChanged;
            if(bc != null) bc.OnDestroy();
            RemoveBinding(IsGridFlexProperty);
            RemoveBinding(CaptionProperty);
            RemoveBinding(ShowSubmitProperty);
            RemoveBinding(HiddenFiltersProperty);
            RemoveBinding(FormControlModelProperty);
            RemoveBinding(EformModeProperty);
            RemoveBinding(SubmitCommandProperty);
            RemoveBinding(CancelCommandProperty);
            RemoveBinding(IsParentLoadedProperty);
            IsGridFlex = false;
            IsParentLoaded = false;
            SubmitCommand = null;
            CancelCommand = null;
            HiddenFilters = null;
            FormControlModel = null;
        }
        #endregion

        #region IDestructible
        public void Destroy()
        {
            if(IsDestroyed) return;
            OnDestroyed();
        }
        #endregion

    }
}

