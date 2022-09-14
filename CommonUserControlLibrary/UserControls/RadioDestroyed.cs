using Xamarin.Forms;

namespace CommonUserControlLibrary.UserControls {
    public class RadioDestroyed: RadioButton
    {
        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            RemoveBinding(GroupNameProperty);
            SetValue(GroupNameProperty, GroupNameProperty.DefaultValue); // this is  MessagingCenter.Unsubscribe<RadioButton, RadioButtonGroupSelectionChanged> and MessagingCenter.Unsubscribe<Layout<View>, RadioButtonGroupValueChanged>
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            RadioDestroyed inst = d as RadioDestroyed;
            if ((inst != null) && (newValue is bool))
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(RadioDestroyed),
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

