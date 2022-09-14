using Prism.Regions;
using Prism.Regions.Adapters;
using Prism.Regions.Behaviors;


using CommonUserControlLibrary.UserControls;


/*
    In the App.xaml.cs the following lines of code must be inserted:

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        regionAdapterMappings.RegisterMapping<ProxyUserControl, ProxyUserControlRegionAdapter>();
    }
*/


namespace PrismPhonebook.Classes {


    public class ProxyUserControlRegionAdapter: RegionAdapterBase<ProxyUserControl>
    {
        public ProxyUserControlRegionAdapter(IRegionBehaviorFactory factory): base(factory)
        {
        }
        /*
        protected void SetBinding(BindableObject element, ProxyUserControl regionTarget, BindingMode mode, string propertyName, string sourcePropertyName) {
            var fieldInfo = element.GetType().GetField(propertyName + "Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if(fieldInfo!= null)
            {
                BindableProperty dp = fieldInfo.GetValue(null) as BindableProperty;
                if(dp != null)
                {
                    element.SetBinding(dp, new Binding(path: sourcePropertyName, mode: mode, source: regionTarget));
                }
            }
        }
        protected void ClearBinding(BindableObject element, ProxyUserControl regionTarget, string propertyName) {
            var fieldInfo = element.GetType().GetField(propertyName + "Property", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (fieldInfo != null)
            {
                BindableProperty dp = fieldInfo.GetValue(null) as BindableProperty;
                if (dp != null)
                {
                    if(element.IsSet(dp))
                    {
                        Binding bb = element.GetPropertyIfSet<Binding>(dp, null);
                        if (bb != null)
                        {
                            if (bb.Source == regionTarget)
                            {
                                element.RemoveBinding(dp);
                            }
                        }
                    }

                }
            }
        }
        */
        protected override void Adapt(IRegion region, ProxyUserControl regionTarget)
        {
            region.Views.CollectionChanged += regionTarget.OnViewsCollectionChanged;
            region.ActiveViews.CollectionChanged += regionTarget.OnActiveViewsCollectionChanged;
            regionTarget.ProxyRegion = region;
        /*
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (e.OldItems != null) {
                        foreach (View element in e.OldItems)
                        {
                            ClearBinding(element, regionTarget, "Caption");
                            ClearBinding(element, regionTarget, "FilterHeight");
                            ClearBinding(element, regionTarget, "ShowFilter");
                            ClearBinding(element, regionTarget, "ShowAddFilterBtn");
                            ClearBinding(element, regionTarget, "GridHeight");
                            ClearBinding(element, regionTarget, "ShowBackBtn");
                            ClearBinding(element, regionTarget, "NavigationBackCommand");
                            ClearBinding(element, regionTarget, "TableMenuItems");
                            ClearBinding(element, regionTarget, "TableMenuItemsCommand");
                            ClearBinding(element, regionTarget, "RowMenuItems");
                            ClearBinding(element, regionTarget, "RowMenuItemsCommand");
                            ClearBinding(element, regionTarget, "ContainerMenuItems");
                            ClearBinding(element, regionTarget, "ContainerMenuItemsCommand");
                            ClearBinding(element, regionTarget, "SelectedRowCommand");
                            ClearBinding(element, regionTarget, "HiddenFilters");
                            ClearBinding(element, regionTarget, "SformAfterAddItem");
                            ClearBinding(element, regionTarget, "SformAfterUpdItem");
                            ClearBinding(element, regionTarget, "SformAfterDelItem");
                            ClearBinding(element, regionTarget, "ShowSubmit");
                            ClearBinding(element, regionTarget, "FormControlModel");
                            ClearBinding(element, regionTarget, "EformMode");
                            ClearBinding(element, regionTarget, "SubmitCommand");
                            ClearBinding(element, regionTarget, "CancelCommand");
                            ClearBinding(element, regionTarget, "CanAdd");
                            ClearBinding(element, regionTarget, "CanUpdate");
                            ClearBinding(element, regionTarget, "CanDelete");
                            ClearBinding(element, regionTarget, "SformAfterAddItemCommand");
                            ClearBinding(element, regionTarget, "SformAfterUpdItemCommand");
                            ClearBinding(element, regionTarget, "SformAfterDelItemCommand");
                            ClearBinding(element, regionTarget, "IsParentLoaded");
                            



                            ClearBinding(element, regionTarget, "FilterHeightDetail");
                            ClearBinding(element, regionTarget, "ShowFilterDetail");
                            ClearBinding(element, regionTarget, "ShowAddFilterBtnDetail");
                            ClearBinding(element, regionTarget, "GridHeightDetail");
                            ClearBinding(element, regionTarget, "HiddenFiltersDetail");
                            ClearBinding(element, regionTarget, "TableMenuItemsDetail");
                            ClearBinding(element, regionTarget, "RowMenuItemsDetail");
                            ClearBinding(element, regionTarget, "CanAddDetail");
                            ClearBinding(element, regionTarget, "CanUpdateDetail");
                            ClearBinding(element, regionTarget, "CanDeleteDetail");

                            ClearBinding(element, regionTarget, "IsPermissionEditable");
                            ClearBinding(element, regionTarget, "PermissionVector");
                            ClearBinding(element, regionTarget, "PermissionChangedCommand");

                            if (regionTarget.Content == element) regionTarget.Content = null;
                        }
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    if(e.NewItems != null) {
                        foreach (View element in e.NewItems)
                        {
                            regionTarget.Content = element;
                            SetBinding(element, regionTarget, BindingMode.OneWay, "Caption",                     "Caption");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "FilterHeight",                "FilterHeight");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ShowFilter",                  "ShowFilter");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ShowAddFilterBtn",            "ShowAddFilterBtn");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "GridHeight",                  "GridHeight");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ShowBackBtn",                 "ShowBackBtn");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "NavigationBackCommand",       "OnNavigationBackCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "TableMenuItems",              "TableMenuItems");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "TableMenuItemsCommand",       "OnTableMenuItemsCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "RowMenuItems",                "RowMenuItems");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "RowMenuItemsCommand",         "OnRowMenuItemsCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ContainerMenuItems",          "ContainerMenuItems");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ContainerMenuItemsCommand",   "OnContainerMenuItemsCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SelectedRowCommand",          "OnSelectedRowCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "HiddenFilters",               "HiddenFilters");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SformAfterAddItem",           "SformAfterAddItem");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SformAfterUpdItem",           "SformAfterUpdItem");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SformAfterDelItem",           "SformAfterDelItem");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ShowSubmit",                  "ShowSubmit");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "FormControlModel",            "FormControlModel");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "EformMode",                   "EformMode");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SubmitCommand",               "OnSubmitCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CancelCommand",               "OnCancelCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CanAdd",                      "CanAdd");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CanUpdate",                      "CanUpdate");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CanDelete",                      "CanDelete");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SformAfterAddItemCommand",    "OnSformAfterAddItemCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SformAfterUpdItemCommand",    "OnSformAfterUpdItemCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "SformAfterDelItemCommand",    "OnSformAfterDelItemCommand");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "IsParentLoaded",              "IsParentLoaded");
                            



                            SetBinding(element, regionTarget, BindingMode.OneWay, "FilterHeightDetail"               , "FilterHeightDetail"    );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ShowFilterDetail"                 , "ShowFilterDetail"      );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "ShowAddFilterBtnDetail"           , "ShowAddFilterBtnDetail");
                            SetBinding(element, regionTarget, BindingMode.OneWay, "GridHeightDetail"                 , "GridHeightDetail"      );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "HiddenFiltersDetail"              , "HiddenFiltersDetail"   );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "TableMenuItemsDetail"             , "TableMenuItemsDetail"  );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "RowMenuItemsDetail"               , "RowMenuItemsDetail"    );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CanAddDetail"                     , "CanAddDetail"          );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CanUpdateDetail"                     , "CanUpdateDetail"          );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "CanDeleteDetail"                     , "CanDeleteDetail"          );


                            SetBinding(element, regionTarget, BindingMode.OneWay, "IsPermissionEditable"             , "IsPermissionEditable"   );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "PermissionVector"                 , "PermissionVector"       );
                            SetBinding(element, regionTarget, BindingMode.OneWay, "PermissionChangedCommand"         ,"OnPermissionChangedCommand");


                        }
                    }
                }
            };
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                var c = region.ActiveViews.FirstOrDefault();
                if (c != null) regionTarget.Content = c as View;
            };
            */
        }
        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }
    }
}

