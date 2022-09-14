

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IValueChangedCmdParamInterface<T>
    {
        object Sender { get; set; }
        T OldVal { get; set; }
        T NewVal { get; set; }
    }
}

