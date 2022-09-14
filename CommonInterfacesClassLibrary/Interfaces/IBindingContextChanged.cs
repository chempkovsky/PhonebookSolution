using System.Threading.Tasks;

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IBindingContextChanged
    {
        Task OnLoaded(object sender, object newValue);
        void OnDestroy();
    }
}

