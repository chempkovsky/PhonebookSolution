using Xamarin.Forms;

namespace CommonUserControlLibrary.UserControls {
    public class ButtonDestroyed: Button
    {
        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            RemoveBinding(CommandProperty);
            RemoveBinding(CommandParameterProperty);
            Command = null;
            CommandParameter = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            ButtonDestroyed inst = d as ButtonDestroyed;
            if ((inst != null) && (newValue is bool))
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(ButtonDestroyed),
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

