using Xamarin.Forms;
using System.ComponentModel;

namespace CommonCustomControlLibrary.Helpers {
    public static class MaxScrollViewHeight
    {
        public static readonly BindableProperty MaxHeightProperty =
             BindableProperty.CreateAttached(
                 "MaxHeight", typeof(double), typeof(MaxScrollViewHeight),
                 -1d, propertyChanged: MaxHeightChanged);
        public static double GetMaxHeight(BindableObject obj)
        {
            
            return (double)obj.GetValue(MaxHeightProperty);
        }

        public static void SetMaxHeight(BindableObject obj, object value)
        {
            obj.SetValue(MaxHeightProperty, value);
        }
        public static void MaxHeightChanged(BindableObject obj, object oldValue, object newValue) {
            double nv = -1;
            if (newValue is double)
            {
                nv = (double)newValue;
            }
            if (obj is ScrollView)
            {
                ScrollView sw = obj as ScrollView;
                if(nv != -1) {
                    sw.PropertyChanged -= PropertyChangedEventHandler; // this is correct
                    sw.PropertyChanged += PropertyChangedEventHandler;
                    UpdateScrollViewSetting(sw);
                }
                else
                {
                    sw.PropertyChanged -= PropertyChangedEventHandler;
                    sw.HeightRequest = -1;
                    UpdateScrollViewSetting(sw);
                }
            }
        }
        public static void UpdateScrollViewSetting(ScrollView sw)
        {
            double maxHeight = GetMaxHeight(sw);
            if (maxHeight <= 0)
            {
                if (sw.HeightRequest >= 0) sw.HeightRequest = -1;
                return;
            }
            if (sw.Content == null)
            {
                if (sw.HeightRequest >= 0) sw.HeightRequest = -1;
                return;
            }
            double contentHeight = sw.Content.Height;
            if (contentHeight > maxHeight) {
                if(sw.HeightRequest != maxHeight) { sw.HeightRequest = maxHeight; }
                return;
            }
            if (sw.Height == maxHeight) return;
            if(sw.Height > maxHeight) { sw.HeightRequest = maxHeight; return; }
            sw.HeightRequest = -1;
        }
        public static void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == "InternalContent") || (e.PropertyName == "Height") || (e.PropertyName == "Width")) 
            {
                if (sender != null)
                {
                    if (sender is ScrollView)
                    {
                        UpdateScrollViewSetting(sender as ScrollView);
                    }
                }
            }
        }
    }
}

