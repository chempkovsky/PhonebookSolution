using Xamarin.Forms;
using System.Threading.Tasks;

namespace CommonCustomControlLibrary.Controls {
    public class  ContentViewWithBCFeedback: ContentView
    {
        #region BindingContextFeedbackRef
        protected virtual void OnBindingContextFeedbackRef(object v)
        {
            
        }
        private static void BindingContextFeedbackRefChanged(BindableObject bindable, object oldValue, object newValue)
        {
            try {
                ContentViewWithBCFeedback sender = bindable as ContentViewWithBCFeedback;
                if(sender != null)
                {
                    if(sender.IsDestroyed) return;
                    sender.OnBindingContextFeedbackRef(newValue);
                }
            } catch {}
        }
        public static readonly BindableProperty BindingContextFeedbackRefProperty =
                BindableProperty.Create(
                "BindingContextFeedbackRef", typeof(object),
                typeof(ContentViewWithBCFeedback),
                null, propertyChanged: BindingContextFeedbackRefChanged);
        public object BindingContextFeedbackRef
        {
            get
            {
                return (object)GetValue(BindingContextFeedbackRefProperty);
            }
            set
            {
                SetValue(BindingContextFeedbackRefProperty, value);
            }
        }
        #endregion

        public virtual void OnDestroyed()
        {
            RemoveBinding(IsDestroyedProperty);
            IsDestroyed = true;
            RemoveBinding(BindingContextFeedbackRefProperty);
            BindingContextFeedbackRef = null;
        }
        private static void IsDestroyedChanged(BindableObject d, object oldValue, object newValue)
        {
            ContentViewWithBCFeedback inst = d as ContentViewWithBCFeedback;
            if (inst != null)
            {
                inst.OnDestroyed();
            }
        }
        public static readonly BindableProperty IsDestroyedProperty =
                BindableProperty.Create(
                "IsDestroyed", typeof(bool),
                typeof(ContentViewWithBCFeedback),
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

