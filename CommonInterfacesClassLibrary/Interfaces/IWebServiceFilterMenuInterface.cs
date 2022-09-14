using Xamarin.Forms;
using System.Windows.Input;

namespace CommonInterfacesClassLibrary.Interfaces {
    public interface IWebServiceFilterMenuInterface
    {
        string Id { get; set; }
        string Caption { get; set; }
        string IconName { get; set; }
        Color IconColor { get; set; }
        bool Enabled { get; set; }
        object Data { get; set; }
        object FeedbackData { get; set; }
        ICommand Command { get; set; }
        bool IsDestroyed { get; set; }
    }
}

