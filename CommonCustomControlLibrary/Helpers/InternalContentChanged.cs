using Xamarin.Forms;

namespace CommonCustomControlLibrary.Helpers {
    public static class InternalContentChanged
    {
        public static readonly BindableProperty InternalContentProperty =
             BindableProperty.CreateAttached(
                 "InternalContent", typeof(object), typeof(InternalContentChanged),
                 null);
        public static object GetInternalContent(BindableObject obj)
        {
            
            return (object)obj.GetValue(InternalContentProperty);
        }
        public static void SetInternalContent(BindableObject obj, object value)
        {
            obj.SetValue(InternalContentProperty, value);
        }
    }
}

