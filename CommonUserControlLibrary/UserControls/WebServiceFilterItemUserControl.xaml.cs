using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CommonInterfacesClassLibrary.Interfaces;
using CommonCustomControlLibrary.Helpers;

namespace CommonUserControlLibrary.UserControls {
    /// <summary>
    /// Interaction logic for WebServiceFilterItemUserControl.xaml
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebServiceFilterItemUserControl: ContentView
    {
        public WebServiceFilterItemUserControl()
        {
            InitializeComponent();
        }


        #region SelectedFilterOperatorName
        public static readonly BindableProperty SelectedFilterOperatorNameProperty =
                BindableProperty.Create(
                "SelectedFilterOperatorName", typeof(string),
                typeof(WebServiceFilterItemUserControl),
                null);
        public string SelectedFilterOperatorName
        {
            get
            {
                return (string)GetValue(SelectedFilterOperatorNameProperty);
            }
            set
            {
                SetValue(SelectedFilterOperatorNameProperty, value);
            }
        }
        #endregion

        #region SelectedFilterOperator
        private static void SelectedFilterOperatorChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                IWebServiceFilterOperatorInterface newV = newValue as IWebServiceFilterOperatorInterface;
                if(newV == null)
                {
                    inst.SelectedFilterOperatorName = null;
                } else
                {
                    inst.SelectedFilterOperatorName = newV.oName;
                }
            }
        }
        public static readonly BindableProperty SelectedFilterOperatorProperty =
                BindableProperty.Create(
                "SelectedFilterOperator", typeof(IWebServiceFilterOperatorInterface),
                typeof(WebServiceFilterItemUserControl),
                null, propertyChanged: SelectedFilterOperatorChanged);
        public IWebServiceFilterOperatorInterface SelectedFilterOperator
        {
            get
            {
                return (IWebServiceFilterOperatorInterface)GetValue(SelectedFilterOperatorProperty);
            }
            set
            {
                SetValue(SelectedFilterOperatorProperty, value);
            }
        }
        #endregion

        #region FilterOperators
        private static void FilterOperatorsChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                if(inst.IsDestroyed) return;
                IEnumerable<IWebServiceFilterOperatorInterface> newVals = newValue as IEnumerable<IWebServiceFilterOperatorInterface>;
                if (newVals == null)
                {
                        inst.SelectedFilterOperatorName = null;
                        inst.SelectedFilterOperator = null;
                }
                else
                {
                    IWebServiceFilterOperatorInterface v = newVals.FirstOrDefault();
                    if (v == null)
                    {
                        inst.SelectedFilterOperatorName = null;
                        inst.SelectedFilterOperator = null;
                    }
                    else
                    {
                        inst.SelectedFilterOperatorName = v.oName;
                        inst.SelectedFilterOperator = v;
                    }
                }
            }
        }
        public static readonly BindableProperty FilterOperatorsProperty =
                BindableProperty.Create(
                "FilterOperators", typeof(IEnumerable<IWebServiceFilterOperatorInterface>),
                typeof(WebServiceFilterItemUserControl),
                null, propertyChanged: FilterOperatorsChanged);
        public IEnumerable<IWebServiceFilterOperatorInterface> FilterOperators
        {
            get
            {
                return (IEnumerable<IWebServiceFilterOperatorInterface>)GetValue(FilterOperatorsProperty);
            }
            set
            {
                SetValue(FilterOperatorsProperty, value);
            }
        }
        #endregion

        #region SelectedFilterDefinition
        private static void SelectedFilterDefinitionChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                if(inst.IsDestroyed) return;
                if (oldValue != null)
                {
                    inst.FilterValue = null;
                }
                inst.UpdateIsDateInput();
                inst.UpdateIsFilterValueReadOnly();
                inst.UpdateFilterError();
                inst.UpdateFilterValuePrompt();
                IWebServiceFilterDefInterface sfd = inst.SelectedFilterDefinition;
                if (sfd == null)
                {
                    inst.SelectedFilterDataType = null;
                    inst.SelectedFilterName = null;
                }
                else
                {
                    inst.SelectedFilterDataType = sfd.fltrDataType;
                    inst.SelectedFilterName = sfd.fltrName;
                }
            }
        }
        public static readonly BindableProperty SelectedFilterDefinitionProperty =
                BindableProperty.Create(
                "SelectedFilterDefinition", typeof(IWebServiceFilterDefInterface),
                typeof(WebServiceFilterItemUserControl),
                null, propertyChanged: SelectedFilterDefinitionChanged);
        public IWebServiceFilterDefInterface SelectedFilterDefinition
        {
            get
            {
                return (IWebServiceFilterDefInterface)GetValue(SelectedFilterDefinitionProperty);
            }
            set
            {
                SetValue(SelectedFilterDefinitionProperty, value);
            }
        }
        #endregion
        #region SelectedFilterDataType
        public static readonly BindableProperty SelectedFilterDataTypeProperty =
                BindableProperty.Create(
                "SelectedFilterDataType", typeof(string),
                typeof(WebServiceFilterItemUserControl),
                null);
        public string SelectedFilterDataType
        {
            get
            {
                return (string)GetValue(SelectedFilterDataTypeProperty);
            }
            set
            {
                SetValue(SelectedFilterDataTypeProperty, value);
            }
        }
        #endregion
        #region SelectedFilterName 
        public static readonly BindableProperty SelectedFilterNameProperty =
                BindableProperty.Create(
                "SelectedFilterName", typeof(string),
                typeof(WebServiceFilterItemUserControl),
                null);
        public string SelectedFilterName
        {
            get
            {
                return (string)GetValue(SelectedFilterNameProperty);
            }
            set
            {
                SetValue(SelectedFilterNameProperty, value);
            }
        }
        #endregion
        #region FilterDefinitions
        private static void FilterDefinitionsChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                if(inst.IsDestroyed) return;
                IEnumerable<IWebServiceFilterDefInterface> newVals = newValue as IEnumerable<IWebServiceFilterDefInterface>;
                if (newVals == null)
                {
                    inst.SelectedFilterDefinition = null;
                }
                else
                {
                    inst.SelectedFilterDefinition = newVals.Where(p => p.fltrName == null).FirstOrDefault();
                }
            }
        }
        public static readonly BindableProperty FilterDefinitionsProperty =
                BindableProperty.Create(
                "FilterDefinitions", typeof(IEnumerable<IWebServiceFilterDefInterface>),
                typeof(WebServiceFilterItemUserControl),
                null, propertyChanged: FilterDefinitionsChanged);
        public IEnumerable<IWebServiceFilterDefInterface> FilterDefinitions
        {
            get { 
                return (IEnumerable<IWebServiceFilterDefInterface>)GetValue(FilterDefinitionsProperty); 
            }
            set { 
                SetValue(FilterDefinitionsProperty, value); 
            }
        }
        #endregion
        #region FilterValue
        private static void FilterValueChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                inst.UpdateFilterError();
                inst.UpdateFilterValuePrompt();
            }
        }
        public static readonly BindableProperty FilterValueProperty =
                BindableProperty.Create(
                "FilterValue", typeof(object),
                typeof(WebServiceFilterItemUserControl),
                null, propertyChanged: FilterValueChanged);
        public object FilterValue
        {
            get
            {
                return (object)GetValue(FilterValueProperty);
            }
            set
            {
                SetValue(FilterValueProperty, value);
            }
        }
        #endregion
        #region IsDateInput
        protected void UpdateIsDateInput()
        {
            if(SelectedFilterDefinition == null)
            {
                IsDateInput = false;
            } else
            {
                IsDateInput = "datetime".Equals(SelectedFilterDefinition.fltrDataType, StringComparison.OrdinalIgnoreCase) || 
                              "date".Equals(SelectedFilterDefinition.fltrDataType, StringComparison.OrdinalIgnoreCase);
            }
        }
        private static void IsDateInputChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if ((inst != null) && (newValue is bool))
            {
                inst.IsDateInput = (bool)newValue;
            }
        }
        public static readonly BindableProperty IsDateInputProperty =
                BindableProperty.Create(
                "IsDateInput", typeof(bool),
                typeof(WebServiceFilterItemUserControl),
                false, propertyChanged: IsDateInputChanged);
        public bool IsDateInput
        {
            get
            {
                return (bool)GetValue(IsDateInputProperty);
            }
            set
            {
                SetValue(IsDateInputProperty, value);
            }
        }
        #endregion
        #region IsFilterValueReadOnly
        private void UpdateIsFilterValueReadOnly()
        {
            var x = SelectedFilterDefinition;
            if (x == null)
            {
                IsFilterValueReadOnly = true;
            } else
            {
                IsFilterValueReadOnly = string.IsNullOrEmpty(SelectedFilterDefinition.fltrDataType);
            }
        }
        private static void IsFilterValueReadOnlyChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if ((inst != null) && (newValue is bool))
            {
                inst.IsFilterValueReadOnly = (bool)newValue;
            }
        }
        public static readonly BindableProperty IsFilterValueReadOnlyProperty =
                BindableProperty.Create(
                "IsFilterValueReadOnly", typeof(bool),
                typeof(WebServiceFilterItemUserControl),
                true, propertyChanged: IsFilterValueReadOnlyChanged);
        public bool IsFilterValueReadOnly
        {
            get
            {
                return (bool)GetValue(IsFilterValueReadOnlyProperty);
            }
            set
            {
                SetValue(IsFilterValueReadOnlyProperty, value);
            }
        }
        #endregion
        #region FilterError
        protected void UpdateFilterError()
        {
            if (SelectedFilterDefinition == null)
            {
                FilterError = string.Empty;
            }
            else if (string.IsNullOrEmpty(SelectedFilterDefinition.fltrDataType))
            {
                FilterError = string.Empty;
            } else {
                if (FilterValue == null)
                {
                    FilterError = "Empty filter item will not be applied";
                }
                else if (IsDateInput) {
                    if(FilterValue is DateTime)
                    {
                        FilterError = string.Empty;
                    } else
                    {
                        DateTime i;
                        if (DateTime.TryParse(FilterValue?.ToString(), out i))
                        {
                            FilterError = string.Empty;
                        }
                        else
                        {
                            FilterError = "Filter item will not be applied: incorrect format";
                        }
                    }


                } else {
                    string tstvl = (FilterValue is string) ? FilterValue as string : FilterValue.ToString();
                    bool tstrslt = false;
                    bool maxLn = false;
                    object minVal = null;
                    object maxVal = null;
                    switch (SelectedFilterDefinition.fltrDataType)
                    {
                        case "int16":
                            {
                                Int16 i; tstrslt = Int16.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("int16", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((Int16)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("int16", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((Int16)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "int32":
                            {
                                Int32 i; tstrslt = Int32.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("int32", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((Int32)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("int32", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((Int32)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "int64":
                            {
                                Int64 i; tstrslt = Int64.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("int64", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((Int64)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("int64", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((Int64)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "uint16":
                            {
                                UInt16 i; tstrslt = UInt16.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("uint16", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((UInt16)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("uint16", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((UInt16)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "uint32":
                            {
                                UInt32 i; tstrslt = UInt32.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("uint32", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((UInt32)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("uint32", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((UInt32)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "uint64":
                            {
                                UInt64 i; tstrslt = UInt64.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("uint64", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((UInt64)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("uint64", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((UInt64)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "double":
                            {
                                double i; tstrslt = double.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("double", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((double)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("double", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((double)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "decimal":
                            {
                                decimal i; tstrslt = decimal.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("decimal", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((decimal)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("decimal", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((decimal)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "single":
                            {
                                Single i; tstrslt = Single.TryParse(tstvl, out i);
                                if (tstrslt)
                                {
                                    object k = ConvertHelper.TryToConvert("single", SelectedFilterDefinition.fltrMin);
                                    if (k != null) { if ((Single)k > i) minVal = k; }
                                    k = ConvertHelper.TryToConvert("single", SelectedFilterDefinition.fltrMax);
                                    if (k != null) { if ((Single)k < i) maxVal = k; }
                                }
                            }
                            break;
                        case "guid":
                            { Guid i; tstrslt = Guid.TryParse(tstvl, out i); }
                            break;
                        case "date":
                        case "datetime":
                            {
                                DateTime i; tstrslt = DateTime.TryParse(tstvl, out i);
                                //if (tstrslt)
                                //{
                                //    dynamic k = ConvertHelper.TryToConvert("datetime", SelectedFilterDefinition.fltrMin);
                                //    if (k != null) { if (k > i) minVal = k; }
                                //    k = ConvertHelper.TryToConvert("datetime", SelectedFilterDefinition.fltrMax);
                                //    if (k != null) { if (k < i) maxVal = k; }
                                //}
                            }
                            break;
                        default:
                            {
                                tstrslt = true;
                                if (SelectedFilterDefinition.fltrMaxLen.HasValue) maxLn = tstvl.Length > SelectedFilterDefinition.fltrMaxLen.Value;
                            }
                            break;
                    }
                    if (!tstrslt)
                    {
                        FilterError = "Filter item will not be applied: incorrect format";
                    }
                    else if (maxLn)
                    {
                        FilterError = "Filter item will not be applied: line length is greater than specified";
                    }
                    else
                    {
                        if (minVal != null)
                            FilterError = "Filter item will not be applied: the value must be greater than " + minVal;
                        else if (maxVal != null)
                            FilterError = "Filter item will not be applied: the value must be less than " + maxVal;
                        else FilterError = string.Empty;
                    }
                }
            }
        }
        private static void FilterErrorChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                inst.UpdateFilterValuePrompt();
            }
        }
        public static readonly BindableProperty FilterErrorProperty =
                BindableProperty.Create(
                "FilterError", typeof(string),
                typeof(WebServiceFilterItemUserControl),
                null, propertyChanged: FilterErrorChanged);


        public string FilterError
        {
            get
            {
                return (string)GetValue(FilterErrorProperty);
            }
            set
            {
                SetValue(FilterErrorProperty, value);
            }
        }
        #endregion
        #region FilterValuePrompt
        private void UpdateFilterValuePrompt()
        {
            string error = FilterError;
            if(string.IsNullOrEmpty(error)) {
                if (SelectedFilterDefinition != null)
                {
                    if ("string".Equals(SelectedFilterDefinition.fltrDataType, StringComparison.OrdinalIgnoreCase) && SelectedFilterDefinition.fltrMaxLen.HasValue)
                    {
                        string s = FilterValue as string;
                        if (s != null)
                        {
                            FilterValuePrompt = "(" + s.Length + " of " + SelectedFilterDefinition.fltrMaxLen.Value + ")";
                            return;
                        }
                    }
                }
                FilterValuePrompt = "Enter filter value";
            }
            else
            {
                FilterValuePrompt = error;
            }
        }
        public static readonly BindableProperty FilterValuePromptProperty =
                BindableProperty.Create(
                "FilterValuePrompt", typeof(string),
                typeof(WebServiceFilterItemUserControl),
                null);
        public string FilterValuePrompt
        {
            get
            {
                return (string)GetValue(FilterValuePromptProperty);
            }
            set
            {
                SetValue(FilterValuePromptProperty, value);
            }
        }
        #endregion
        #region SelectedModelRef
        public static readonly BindableProperty SelectedModelRefProperty =
                BindableProperty.Create(
                "SelectedModelRef", typeof(IWebServiceFilterRsltInterface),
                typeof(WebServiceFilterItemUserControl),
                null);
        public IWebServiceFilterRsltInterface SelectedModelRef
        {
            get
            {
                return (IWebServiceFilterRsltInterface)GetValue(SelectedModelRefProperty);
            }
            set
            {
                SetValue(SelectedModelRefProperty, value);
            }
        }
        #endregion
        #region RemoveWebServiceFilterItemCommandProperty
        public static readonly BindableProperty RemoveWebServiceFilterItemCommandProperty = 
            BindableProperty.Create(nameof(RemoveWebServiceFilterItemCommand), typeof(ICommand), typeof(WebServiceFilterItemUserControl), null);
        public ICommand RemoveWebServiceFilterItemCommand
        {
            get { return (ICommand)GetValue(RemoveWebServiceFilterItemCommandProperty); }
            set { SetValue(RemoveWebServiceFilterItemCommandProperty, value); }
        }
        protected ICommand _FilterItemCommand = null;
        public ICommand FilterItemCommand
        {
            get
            {
                return _FilterItemCommand ?? (_FilterItemCommand = new Command(() => FilterItemCommandExecute(), () => FilterItemCommandCanExecute()));
            }
        }
        protected void FilterItemCommandExecute()
        {
            if(!IsDestroyed)
                RemoveWebServiceFilterItemCommand?.Execute(SelectedModelRef);
        }
        protected bool FilterItemCommandCanExecute()
        {
            return !IsDestroyed;
        }
        #endregion

        #region IsGridFlexProperty
        public static readonly BindableProperty IsGridFlexProperty =
                BindableProperty.Create(
                "IsGridFlex", typeof(bool),
                typeof(WebServiceFilterItemUserControl),
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

        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            RemoveBinding(IsGridFlexProperty);
            RemoveBinding(SelectedFilterOperatorNameProperty);
            RemoveBinding(SelectedFilterOperatorProperty);
            RemoveBinding(FilterOperatorsProperty);
            RemoveBinding(SelectedFilterDefinitionProperty);
            RemoveBinding(SelectedFilterDataTypeProperty);
            RemoveBinding(SelectedFilterNameProperty);
            RemoveBinding(FilterDefinitionsProperty);
            RemoveBinding(FilterValueProperty);
            RemoveBinding(IsDateInputProperty);
            RemoveBinding(IsFilterValueReadOnlyProperty);
            RemoveBinding(FilterErrorProperty);
            RemoveBinding(FilterValuePromptProperty);
            RemoveBinding(SelectedModelRefProperty);
            RemoveBinding(RemoveWebServiceFilterItemCommandProperty);
            IsGridFlex = false;
            RemoveWebServiceFilterItemCommand = null;
            SelectedFilterDefinition = null;
            FilterOperators = null;
            FilterDefinitions = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            WebServiceFilterItemUserControl inst = d as WebServiceFilterItemUserControl;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(WebServiceFilterItemUserControl),
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

