using System.ComponentModel;
using Xamarin.Forms;

namespace CommonCustomControlLibrary.Helpers {
    public static class GridFlex
    {

        public static int LandscapeW = 768;
        public static int DesktopW = 992;

        public static readonly BindableProperty HorizontalFlexProperty =
             BindableProperty.CreateAttached(
                 "HorizontalFlex", typeof(  bool?  ), typeof(GridFlex),
                 null, propertyChanged: HorizontalFlexChanged);
        public static bool? GetHorizontalFlex(BindableObject obj)
        {
            
            return (bool?)obj.GetValue(HorizontalFlexProperty);
        }

        public static void SetHorizontalFlex(BindableObject obj, bool? value)
        {
            obj.SetValue(HorizontalFlexProperty, value);
        }
        public static void HorizontalFlexChanged(BindableObject obj, object oldValue, object newValue)
        {
            bool nv = false;
            if(newValue is bool)
            {
                nv = (bool)newValue; 
            }
            if(obj is Grid)
            {
                Grid grd = obj as Grid;
                if (nv)
                {
                    //grd.SizeChanged += OnSizeChangedEventHandler;

                    // we do not need "Weak Event pattern" since subscriber is a STATIC class with a STATIC handler
                    grd.PropertyChanged += PropertyChangedEventHandler;
                    UpdateGridSetting(grd);

                } else
                {
                    //grd.SizeChanged -= OnSizeChangedEventHandler;
                    grd.PropertyChanged -= PropertyChangedEventHandler;
                    UpdateGridSetting(grd); // do not comment this line!!!!
                }
            }
        }
        public static void UpdateGridSetting(Grid sender)
        {
            double ActualWidth = sender.Width;
            if (ActualWidth < 1) return;
/*            
            foreach (var c in sender.Children)
            {
                if (c is BindableObject)
                {
                    var d = c as BindableObject;
                    d.SetValue(Grid.RowProperty, 0);
                    d.SetValue(Grid.ColumnProperty, 0);
                    d.SetValue(Grid.ColumnSpanProperty, 1);
                }
            }
            sender.RowDefinitions.Clear();
            sender.ColumnDefinitions.Clear();
*/
            int count = 0;// sender.Children.Count;
            foreach(View ii in sender.Children)
            {
                if (ii.IsVisible) count++;
            }
            if (count < 1) count = 1;
            int colDefcount = count;
            int rowDefcount = 1;
            if(ActualWidth < LandscapeW)
            {
                colDefcount = 1;
                rowDefcount = count;
            }
            else if (ActualWidth < DesktopW) 
            {
                colDefcount = count >> 1;
                if (colDefcount << 1 < count) colDefcount++;
                rowDefcount = 2;
            }
            if (!((sender.RowDefinitions.Count != rowDefcount) || (sender.ColumnDefinitions.Count != colDefcount)))
            {
                return;
            }
            try {
                sender.BatchBegin();
                // sender.IsVisible = false;
                foreach (var c in sender.Children)
                {
                    if (c is BindableObject)
                    {
                        var d = c as BindableObject;
                        d.SetValue(Grid.RowProperty, 0);
                        d.SetValue(Grid.ColumnProperty, 0);
                        d.SetValue(Grid.ColumnSpanProperty, 1);
                    }
                }
                while (sender.RowDefinitions.Count > rowDefcount) 
                    sender.RowDefinitions.RemoveAt(sender.RowDefinitions.Count - 1);
                while (sender.ColumnDefinitions.Count > colDefcount) 
                    sender.ColumnDefinitions.RemoveAt(sender.ColumnDefinitions.Count - 1);

                //sender.RowDefinitions.Clear();
                //sender.ColumnDefinitions.Clear();
                //for (int i = 0; i < colDefcount; i++)
                for (int i = sender.ColumnDefinitions.Count; i < colDefcount; i++)
                    sender.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                //for (int i = 0; i < rowDefcount; i++)
                for (int i = sender.RowDefinitions.Count; i < rowDefcount; i++)
                    sender.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                int curCol = 0;
                int curRow = 0;
                int curId = 0;
                foreach (View c in sender.Children)
                {
                    if (!c.IsVisible) continue;
                    if (c is BindableObject)
                    {
                        var d = c as BindableObject;
                            d.SetValue(Grid.RowProperty, curRow);
                            d.SetValue(Grid.ColumnProperty, curCol);
                        curId++;
                        if (curId == count)
                        {
                            if ((colDefcount > 1) && (colDefcount < count))
                            {
                                if ((curCol == (colDefcount - 2)) && (curRow == rowDefcount - 1))
                                {
                                    d.SetValue(Grid.ColumnSpanProperty, 2);
                                }
                            }
                        }
                        curCol++;
                        if (curCol >= colDefcount)
                        {
                            curCol = 0;
                            curRow++;
                        }
                    }
                }
                // sender.IsVisible = true;
            }
            finally
            {
                sender.BatchCommit();
            }
        }
/*        
        public static void OnSizeChangedEventHandler(object sender, SizeChangedEventArgs e)
        {
            if(!e.WidthChanged) return;
            if ((e.PreviousSize.Width > 1) && (e.NewSize.Width > 1)) 
            {
                if ((e.PreviousSize.Width < LandscapeW) && (e.NewSize.Width < LandscapeW)) return;
                if ((e.PreviousSize.Width >= DesktopW) && (e.NewSize.Width >= DesktopW)) return;
                if ((e.PreviousSize.Width >= LandscapeW) && (e.PreviousSize.Width < DesktopW) && (e.NewSize.Width < DesktopW) && (e.NewSize.Width >= LandscapeW)) return;
            }
            if (sender != null)
            {
                if (sender is Grid)
                {
                        UpdateGridSetting(sender as Grid);
                }
            }
        }
*/
        public static void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Width")
            {
                if (sender != null)
                {
                    if (sender is Grid)
                    {
                        UpdateGridSetting(sender as Grid);
                    }
                }
            }
        }
    }
}

