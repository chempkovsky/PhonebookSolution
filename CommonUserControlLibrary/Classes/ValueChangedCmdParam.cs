using Xamarin.Forms;
using CommonInterfacesClassLibrary.Interfaces;

namespace CommonUserControlLibrary.Classes {
    public class ValueChangedCmdParam<T>: IValueChangedCmdParamInterface<T>
    {
        public object Sender { get; set; }
        public T OldVal { get; set; }
        public T NewVal { get; set; }
    }
}

